/*	Jitbit's simple SAML 2.0 component for ASP.NET
	https://github.com/jitbit/AspNetSaml/
	(c) Jitbit LP, 2016
	Use this freely under the MIT license (see http://choosealicense.com/licenses/mit/)
	version 1.2
*/

using System;
using System.Xml;
using System.Security.Cryptography.Xml;
using System.Collections.Generic;

namespace SECSSO.ADFS
{
	public class Response
	{
		private XmlDocument _xmlDoc;
		private Certificate _certificate;
		private XmlNamespaceManager _xmlNameSpaceManager; //we need this one to run our XPath queries on the SAML XML

		public string Xml { get { return _xmlDoc.OuterXml; } }

		public Response(byte[] certificateBytes)
		{
			RSAPKCS1SHA256SignatureDescription.Init(); //init the SHA256 crypto provider (for needed for .NET 4.0 and lower)

			_certificate = new Certificate();
			_certificate.LoadCertificate(certificateBytes);
		}

		public Response(string certificateStr)
		{
			RSAPKCS1SHA256SignatureDescription.Init(); //init the SHA256 crypto provider (for needed for .NET 4.0 and lower)

			_certificate = new Certificate();
			_certificate.LoadCertificate(certificateStr);
		}

		public void LoadXml(string xml)
		{
			_xmlDoc = new XmlDocument();
			_xmlDoc.PreserveWhitespace = true;
			_xmlDoc.XmlResolver = null;
			_xmlDoc.LoadXml(xml);

			_xmlNameSpaceManager = GetNamespaceManager(); //lets construct a "manager" for XPath queries
		}

		public void LoadXmlFromBase64(string response)
		{
			System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
			LoadXml(enc.GetString(Convert.FromBase64String(response)));
		}

		public bool IsValid()
		{
			XmlNodeList nodeList = _xmlDoc.SelectNodes("//ds:Signature", _xmlNameSpaceManager);

			SignedXml signedXml = new SignedXml(_xmlDoc);

			if (nodeList.Count == 0) return false;

			signedXml.LoadXml((XmlElement)nodeList[0]);
			var v1 = ValidateSignatureReference(signedXml);
			var v2 = signedXml.CheckSignature(_certificate.cert, true);
			var v3 = !IsExpired();
			return v1 && v2 && v3;
		}

		//an XML signature can "cover" not the whole document, but only a part of it
		//.NET's built in "CheckSignature" does not cover this case, it will validate to true.
		//We should check the signature reference, so it "references" the id of the root document element! If not - it's a hack
		private bool ValidateSignatureReference(SignedXml signedXml)
		{
			if (signedXml.SignedInfo.References.Count != 1) //no ref at all
				return false;

			var reference = (Reference)signedXml.SignedInfo.References[0];
			var id = reference.Uri.Substring(1);

			var idElement = signedXml.GetIdElement(_xmlDoc, id);

			if (idElement == _xmlDoc.DocumentElement)
				return true;
			else //sometimes its not the "root" doc-element that is being signed, but the "assertion" element
			{
				var assertionNode = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion", _xmlNameSpaceManager) as XmlElement;
				if (assertionNode != idElement)
					return false;
			}

			return true;
		}

		private bool IsExpired()
		{
			DateTime expirationDate = DateTime.MaxValue;
			XmlNode node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:Subject/saml:SubjectConfirmation/saml:SubjectConfirmationData", _xmlNameSpaceManager);
			if (node != null && node.Attributes["NotOnOrAfter"] != null)
			{
				DateTime.TryParse(node.Attributes["NotOnOrAfter"].Value, out expirationDate);
			}
			return DateTime.UtcNow > expirationDate.ToUniversalTime();
		}

		public string GetNameID()
		{
			XmlNode node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:Subject/saml:NameID", _xmlNameSpaceManager);
			return node.InnerText;
		}

		public string GetEmail()
		{
			XmlNode node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='User.email']/saml:AttributeValue", _xmlNameSpaceManager);

			//some providers (for example Azure AD) put email into an attribute named "http://schemas.sec.com/identity/claims/emailaddress"
			if (node == null)
				node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='http://schemas.sec.com/identity/claims/emailaddress']/saml:AttributeValue", _xmlNameSpaceManager);

			return node.InnerText;
		}

		public string GetFirstName()
		{
			XmlNode node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='first_name']/saml:AttributeValue", _xmlNameSpaceManager);

			//some providers (for example Azure AD) put email into an attribute named "http://schemas.sec.com/identity/claims/givenname"
			if (node == null)
				node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='http://schemas.sec.com/identity/claims/givenname']/saml:AttributeValue", _xmlNameSpaceManager);

			return node.InnerText;
		}

		public string GetLastName()
		{
			XmlNode node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='last_name']/saml:AttributeValue", _xmlNameSpaceManager);

			//some providers (for example Azure AD) put email into an attribute named "http://schemas.sec.com/identity/claims/surname"
			if (node == null)
				node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='http://schemas.sec.com/identity/claims/surname']/saml:AttributeValue", _xmlNameSpaceManager);
			return node.InnerText;
		}

		public string GetDepartment()
		{
			XmlNode node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='http://schemas.sec.com/identity/claims/department']/saml:AttributeValue", _xmlNameSpaceManager);
			return node.InnerText;
		}

		public string GetPhone()
		{
			XmlNode node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='http://schemas.sec.com/identity/claims/homephone']/saml:AttributeValue", _xmlNameSpaceManager);
			if (node == null)
				node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='http://schemas.sec.com/identity/claims/telephonenumber']/saml:AttributeValue", _xmlNameSpaceManager);
			return node.InnerText;
		}

		public string GetCompany()
		{
			XmlNode node = _xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='http://schemas.sec.com/identity/claims/companyname']/saml:AttributeValue", _xmlNameSpaceManager);
			return node.InnerText;
		}

		public string GetValue(string claimType)
		{
			string stReturn = string.Empty;
			XmlNode node = _xmlDoc.SelectSingleNode(string.Format("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute[@Name='{0}']/saml:AttributeValue", claimType), _xmlNameSpaceManager);
			if (node != null) stReturn = node.InnerText;
			return stReturn;
		}

		/// <summary>
		/// Get AD FS Auth Claim List
		/// </summary>
		/// <returns></returns>
		public List<KeyValuePair<string, string>> GetClaims()
		{
			List<KeyValuePair<string, string>> sList = null;

			try
			{
				XmlNodeList xList = _xmlDoc.SelectNodes("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute", _xmlNameSpaceManager);

				if (xList != null && xList.Count > 0)
				{
					sList = new List<KeyValuePair<string, string>>();

					foreach (XmlNode node in xList)
					{
						sList.Add(new KeyValuePair<string, string>(node.Attributes[0].Value, node.InnerText));
					}
				}
			}
			catch (Exception ex) { }

			return sList;
		}

		/// <summary>
		/// Get AD FS Auth Claim List
		/// </summary>
		/// <returns></returns>
		public List<ADFSClaimModel> GetClaimsList()
		{
			List<ADFSClaimModel> sList = null;

			try
			{
				XmlNodeList xList = _xmlDoc.SelectNodes("/samlp:Response/saml:Assertion/saml:AttributeStatement/saml:Attribute", _xmlNameSpaceManager);

				if (xList != null && xList.Count > 0)
				{
					sList = new List<ADFSClaimModel>();

					foreach (XmlNode node in xList)
					{
						ADFSClaimModel model = new ADFSClaimModel();
						model.ClaimKey = node.Attributes[0].Value;
						model.ClaimValue = node.InnerText;
						sList.Add(model);
					}
				}
			}
			catch (Exception ex) { }

			return sList;
		}

		//returns namespace manager, we need one b/c MS says so... Otherwise XPath doesnt work in an XML doc with namespaces
		//see https://stackoverflow.com/questions/7178111/why-is-xmlnamespacemanager-necessary
		private XmlNamespaceManager GetNamespaceManager()
		{
			XmlNamespaceManager manager = new XmlNamespaceManager(_xmlDoc.NameTable);
			manager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
			manager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
			manager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");

			return manager;
		}
	}
}
