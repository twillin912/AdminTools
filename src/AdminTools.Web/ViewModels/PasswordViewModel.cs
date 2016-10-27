using System.ComponentModel.DataAnnotations;

namespace AdminTools.Web.ViewModels
{
	public class PasswordViewModel
	{
        [Range(minimum: 6, maximum: 48)]
		[Display(Name = "Password Length")]
		public int Length { get; set; }

        [Range(1,20)]
		[Display(Name ="Password Count")]
		public int Count { get; set; }

		[Display(Name ="Allow Symbols")]
		public bool Symbols { get; set; }

		[Display(Name ="Generated Password")]
		public string Password { get; set; }
		public string Phonetic { get; set; }

	}
}
