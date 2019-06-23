using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
	public class Offer
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
		[DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
		[Display(Name= "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "End Date")]
		public DateTime EndDate { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public virtual ICollection< Client> Clients { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }


        public Offer()
        {
            
            Clients = new HashSet<Client>();
            Photos = new HashSet<Photo>();
            Reservations = new HashSet<Reservation>();


        }


    }
}
