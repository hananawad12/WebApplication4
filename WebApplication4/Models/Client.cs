using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
	public abstract class Client
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "this filed is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "this filed is required")]
		public string Location { get; set; }

		[Required(ErrorMessage = "this filed is required")]
		public int Phone { get; set; }
		public string Email { get; set; }
		[Required(ErrorMessage = "this filed is required")]
		public int Rating { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
		public string Description { get; set; }
		[DataType(DataType.Upload)]
		public string Image { get; set; }

		public virtual ICollection<Message> Messages { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<Like> Likes { get; set; }
	}

}
