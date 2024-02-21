/*	Jitbit's simple SAML 2.0 component for ASP.NET
	https://github.com/jitbit/AspNetSaml/
	(c) Jitbit LP, 2016
	Use this freely under the MIT license (see http://choosealicense.com/licenses/mit/)
	version 1.2
*/

using System.Security.Cryptography.X509Certificates;

namespace SECSSO.ADFS
{
	public class Certificate
	{
		public X509Certificate2 cert;

		public void LoadCertificate(string certificate)
		{
			LoadCertificate(StringToByteArray(certificate));
		}

		public void LoadCertificate(byte[] certificate)
		{
			cert = new X509Certificate2();
			cert.Import(certificate);
		}

		private byte[] StringToByteArray(string st)
		{
			byte[] bytes = new byte[st.Length];
			for (int i = 0; i < st.Length; i++)
			{
				bytes[i] = (byte)st[i];
			}
			return bytes;
		}
	}
}
