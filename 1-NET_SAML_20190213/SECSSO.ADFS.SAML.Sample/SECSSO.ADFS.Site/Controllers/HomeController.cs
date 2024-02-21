using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SECSSO.ADFS.Site.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
		/// Site Portal
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
        public ActionResult Index()
        {
			if (this.HttpContext.Session["UserName"] != null)
			{
				ViewBag.LoginUserName = this.HttpContext.Session["UserName"];
			}

			// TempData temporarily used to temporarily display Claim information
			// (Used for testing purposes and added Claim information to Session when applying code)
			List<ADFSClaimModel> lModel = null;

			if (TempData["ClaimModel"] != null)
			{
				lModel = TempData["ClaimModel"] as List<ADFSClaimModel>;
			}

			return View(lModel);
        }
	}
}