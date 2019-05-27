using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
	public class Photographer
	{
		public int Id { get; set; }
		[ForeignKey("Client")]
		public int PhotographerId { get; set; }
		public virtual Client Client { get; set; }

	}
}
