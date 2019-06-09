using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "you must specify password between 4 and 8 characters")]
        public string Password { get; set; }

		public string Description { get; set; }

		public string Email { get; set; }

		[Required(ErrorMessage ="this filed is required")]
		public string Location { get; set; }

		[Required(ErrorMessage = "this filed is required")]
		public int Phone { get; set; }

		//[Required(ErrorMessage = "this filed is required")]
		public int Rating { get; set; }



	}
}
