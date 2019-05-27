using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
	public class Package
	{
		public int Id { get; set; }
		public string  Nmae { get; set; }
		public string Details { get; set; }
		public decimal Price { get; set; }

		//public virtual int MakeupArtistId  { get; set; }
		public virtual Client Client { get; set; }

	}
}
