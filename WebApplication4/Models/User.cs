using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
    public class User:Client
    {

        public virtual ICollection<Reservation> Reservations { get; set; }

        public User()
        {
            Reservations = new HashSet<Reservation>();
        }


    }
}
