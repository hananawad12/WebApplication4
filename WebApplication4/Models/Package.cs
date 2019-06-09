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
        [DataType(DataType.Upload)]
        public string Image { get; set; }


        //public virtual ICollection<Client> Clients { get; set; }

        public virtual Client Client{ get; set; }
       


    }
}
