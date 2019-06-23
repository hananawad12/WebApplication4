using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
    public class Reservation
    {
        public int Id { get; set; }
       
        public DateTime Date { get; set; }

        //public virtual ICollection<User> Users { get; set; }

        //public virtual ICollection<Offer> Offers { get; set; }

        //public virtual ICollection<Package> Packages { get; set; }


        public virtual User Users { get; set; }

        public virtual Offer Offers { get; set; }

        public virtual Package Packages { get; set; }


        //public Reservation()
        //{

        //    Users = new HashSet<User>();
        //    Offers = new HashSet<Offer>();
        //    Packages = new HashSet<Package>();
        //}


    }
}
