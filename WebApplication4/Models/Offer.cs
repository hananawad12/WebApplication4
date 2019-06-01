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
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [DataType(DataType.Upload)]
        public string Image { get; set; }

        public virtual MakeupArtist MakeupArtist { get; set; }
        public virtual Photographer Photographer { get; set; }
        public virtual WeddingHall WeddingHall { get; set; }
        public virtual Atelier Atelier { get; set; }

    }
}
