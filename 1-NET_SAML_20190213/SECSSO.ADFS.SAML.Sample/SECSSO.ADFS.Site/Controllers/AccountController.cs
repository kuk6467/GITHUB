using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Security;
using SECSSO.ADFS.Site.Models;

namespace SECSSO.ADFS.Site.Controllers
{
    public class AccountController : Controller
    {
		#region Login/Logout

		/// <summary>
		/// Login Page
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Login Process
		/// </summary>
		/// <param name="userModel"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Login(LoginUserModel userModel)
		{
			if (ModelState.IsValid)
			{
				bool isAuthentication = false;

				try
				{
					// 1. System user authentication logic 
					isAuthentication = true;

					if (isAuthentication)
					{
						// 2. User information inquiry (session processing data)
						// 3. System Session generation
						HttpContext.Session["LoginID"] = userModel.Id;
						HttpContext.Session["UserName"] = "Hong gil-dong";

						// 3. Move to Portal when authentication is successful
						return RedirectToAction("Index", "Home");
					}

					return View();
				}
				catch (Exception ex)
				{
					return View();
				}
			}
			else
			{
				return View();
			}
		}
		
		/// <summary>
		/// Logout Process
		/// </summary>
		/// <returns></returns>
		public ActionResult Logout()
		{
			// 1. System session initialization
			Session.Abandon();
			Session.Clear();

			// 2. Go to login page
			return RedirectToAction("Index", "Account");
		}

		#endregion

		#region ADFS Login Method

		/// <summary>
		/// AD FS Login
		/// </summary>
		/// <returns></returns>
		public ActionResult ADFSLogin()
		{
			// Create AD FS Auth Request
			var request = new AuthRequest(SPEntityID, SPAssertionConsumerService);
			string url = request.GetRedirectUrl(IdpEntityID);
			return this.Redirect(url);
		}

		/// <summary>
		/// ADFS Auth Callback
		/// </summary>
		/// <returns></returns>
		public ActionResult SamlConsume()
		{
			Response samlResponse = new Response(CertFile);
			var samlResponsePostData = Request.Form["SAMLResponse"];
			List<ADFSClaimModel> lModel = null;

			if (!string.IsNullOrEmpty(samlResponsePostData))
			{
				samlResponse.LoadXmlFromBase64(samlResponsePostData);

				if (samlResponse.IsValid())
				{
					string loginID, name;

					try
					{
						// 1. Get Claim Value
						loginID = samlResponse.GetValue(ClaimTypes.LoginID);
						name = samlResponse.GetValue(ClaimTypes.UserName);

						// 2. System Session generation
						HttpContext.Session["LoginID"] = loginID;
						HttpContext.Session["UserName"] = name;
					}
					catch (Exception ex)
					{
						return null;
					}

					// 3. Claim list inquiry. Go to the main page.
					// TempData temporarily used to temporarily display Claim information
					// (Used for testing purposes and added Claim information to Session when applying code)
					lModel = samlResponse.GetClaimsList();
					TempData["ClaimModel"] = lModel;
					return RedirectToAction("Index", "Home");
				}
			}

			return View();
		}

		/// <summary>
		/// AD FS Logout
		/// </summary>
		/// <returns></returns>
		public ActionResult ADFSLogout()
		{
			// 1. System session initialization
			Session.Abandon();
			Session.Clear();

			// 2. Integrated authentication Access to logout URL when logging out
			return new RedirectResult(IdpSignoutURL);
		}

		#endregion

		#region property

		/// <summary>
		/// SP Entity ID
		/// https://localhost:44364
		/// </summary>
		private string SPEntityID
		{
			get
			{
				return ConfigurationManager.AppSettings["sp.EntityID"];
			}
		}

		/// <summary>
		/// AD FS Callback URL
		/// https://localhost:44364/Home/SamlConsume
		/// </summary>
		private string SPAssertionConsumerService
		{
			get
			{
				return ConfigurationManager.AppSettings["sp.AssertionConsumerService"];
			}
		}

		/// <summary>
		/// AD FS Auth URL
		/// </summary>
		private string IdpEntityID
		{
			get
			{
				return ConfigurationManager.AppSettings["idp.EntityID"];
			}
		}

		/// <summary>
		/// AD FS Signout URL
		/// </summary>
		private string IdpSignoutURL
		{
			get
			{
				return ConfigurationManager.AppSettings["idp.SignoutUrl"];
			}
		}

		/// <summary>
		/// Certification File content to byte array
		/// </summary>
		private byte[] CertFile
		{
			get
			{
				string stCertFileName = ConfigurationManager.AppSettings["certFileName"];
				var certPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, stCertFileName);
				var samlCertificateBytes = System.IO.File.ReadAllBytes(certPath);
				byte[] arrCert = null;

				if (!string.IsNullOrEmpty(certPath) && System.IO.File.Exists(certPath))
				{
					arrCert = System.IO.File.ReadAllBytes(certPath);
				}

				return arrCert;
			}
		}

		#endregion
	}
}