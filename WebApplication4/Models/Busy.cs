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

        public virtual ICollection<Client> Clients { get; set; }


        public Busy()
        {
            Clients = new HashSet<Client>();
        }

	}
}
