﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string ReceiverId { get; set; }

        [Range(0, 1)]
        public int Read { get; set; }

        public virtual MakeupArtist MakeupArtist { get; set; }
        public virtual Photographer Photographer { get; set; }
        public virtual WeddingHall WeddingHall { get; set; }
        public virtual Atelier Atelier { get; set; }
        public virtual User User { get; set; }


    }
}
