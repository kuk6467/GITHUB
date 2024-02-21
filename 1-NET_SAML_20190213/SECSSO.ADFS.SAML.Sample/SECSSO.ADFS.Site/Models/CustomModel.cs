using System.ComponentModel.DataAnnotations;

namespace SECSSO.ADFS.Site.Models
{
	public class LoginUserModel
	{
		[Required(ErrorMessage = "ID를 입력해 주십시오.")]
		public string Id { get; set; }
		[Required(ErrorMessage = "암호를 입력해 주십시오.")]
		public string UserPassword { get; set; }
	}
}