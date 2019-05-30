using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
	public class WeddingHall
	{
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public int Phone { get; set; }
        public int Rating { get; set; }
        public string Image { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Description { get; set; }


        public virtual ICollection<Package> Packages { get; set; }

    }
}
