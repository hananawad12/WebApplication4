using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Upload)]
        public string Image { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }



        public Post()
        {
            Comments= new HashSet<Comment>();
            Likes = new HashSet<Like>();
            Photos = new HashSet<Photo>();


        }




    }
}
