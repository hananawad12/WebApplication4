using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
	public class Package
	{
		public int Id { get; set; }
		public string  Name { get; set; }
		public string Details { get; set; }
		public decimal Price { get; set; }

		public virtual MakeupArtist MakeupArtist { get; set; }
        public virtual Photographer Photographer { get; set; }
        public virtual WeddingHall WeddingHall { get; set; }
        public virtual Atelier Atelier { get; set; }


    }
}
