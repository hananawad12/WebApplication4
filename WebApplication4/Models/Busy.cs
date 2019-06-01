using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
    public class Busy
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }

        public virtual MakeupArtist MakeupArtist { get; set; }
        public virtual Photographer Photographer { get; set; }
        public virtual WeddingHall WeddingHall { get; set; }
        public virtual Atelier Atelier { get; set; }
    }
}
