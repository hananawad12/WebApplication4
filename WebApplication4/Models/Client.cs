using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
	public class Client
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public string Location{ get; set; }
		public int Phone { get; set; }
		public int Rating { get; set; }
		public string Image { get; set; }
		public int Password { get; set; }
		public string Description { get; set; }


		public virtual ICollection<Package> Packages { get; set; }
		//derived classes
		public virtual MakeupArtist MakeupArtist { get; set; }
		public virtual WeddingHall WeddingHall { get; set; }
		public virtual Photographer Photographer { get; set; }
		public virtual Atelier Atelier { get; set; }




	}
}
