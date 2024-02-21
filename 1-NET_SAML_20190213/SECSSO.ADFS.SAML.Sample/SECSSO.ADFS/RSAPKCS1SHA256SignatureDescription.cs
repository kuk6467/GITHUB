/*	Jitbit's simple SAML 2.0 component for ASP.NET
	https://github.com/jitbit/AspNetSaml/
	(c) Jitbit LP, 2016
	Use this freely under the MIT license (see http://choosealicense.com/licenses/mit/)
	version 1.2
*/

using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace SECSSO.ADFS
{
	/// <summary>
	/// this class adds support of SHA256 signing to .NET 4.0 and earlier
	/// (you can use it in .NET 4.5 too, if you don't want a "System.Deployment" dependency)
	/// </summary>
	public sealed class RSAPKCS1SHA256SignatureDescription : SignatureDescription
	{
		public RSAPKCS1SHA256SignatureDescription()
		{
			KeyAlgorithm = typeof(RSACryptoServiceProvider).FullName;
			DigestAlgorithm = typeof(SHA256Managed).FullName;   // Note - SHA256CryptoServiceProvider is not registered with CryptoConfig
			FormatterAlgorithm = typeof(RSAPKCS1SignatureFormatter).FullName;
			DeformatterAlgorithm = typeof(RSAPKCS1SignatureDeformatter).FullName;
		}

		public override AsymmetricSignatureDeformatter CreateDeformatter(AsymmetricAlgorithm key)
		{
			if (key == null)
				throw new ArgumentNullException("key");

			RSAPKCS1SignatureDeformatter deformatter = new RSAPKCS1SignatureDeformatter(key);
			deformatter.SetHashAlgorithm("SHA256");
			return deformatter;
		}

		public override AsymmetricSignatureFormatter CreateFormatter(AsymmetricAlgorithm key)
		{
			if (key == null)
				throw new ArgumentNullException("key");

			RSAPKCS1SignatureFormatter formatter = new RSAPKCS1SignatureFormatter(key);
			formatter.SetHashAlgorithm("SHA256");
			return formatter;
		}

		private static bool _initialized = false;
		public static void Init()
		{
			if (!_initialized)
				CryptoConfig.AddAlgorithm(typeof(RSAPKCS1SHA256SignatureDescription), "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");
			_initialized = true;
		}
	}
}
