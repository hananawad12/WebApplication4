using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
	public class MakeupArtist:Client
	{

        public virtual ICollection<Package> Packages { get; set; }
		public virtual ICollection<Post> Posts { get; set; }

		public virtual ICollection<Busy> Busies { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

        public MakeupArtist()
        {
            Packages=new HashSet<Package>();
            Posts=new HashSet<Post>();
            Busies = new HashSet<Busy> ();
            Offers= new HashSet<Offer> ();
        }



    }
}
