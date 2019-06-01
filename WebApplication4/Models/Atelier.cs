using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
	public class Atelier
	{
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Upload)]
        public string Image { get; set; }

        public virtual ICollection<Package> Packages { get; set; }
        public virtual ICollection<Busy> Busy { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }





    }
}
