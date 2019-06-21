using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace WeddingGo.Models
{
    public class Message //:IIdentity
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

        public virtual Client Client { get; set; }

		//public string AuthenticationType()
		//{
		//	throw new NotImplementedException();
		//}

		//public bool IsAuthenticated()
		//{
		//	throw new NotImplementedException();
		//}

		//public string Name()
		//{
		//	throw new NotImplementedException();
		//}
	}
}
