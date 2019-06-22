using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
	public class Package
	{
		public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public decimal Price { get; set; }
        


        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }





        public Package()
        {
            Clients = new HashSet<Client>();
            Photos = new HashSet<Photo>();

        }

    }
}
