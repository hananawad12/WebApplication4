using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Dtos
{
	public class UserForDetailed
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }

		public int Phone { get; set; }
		public string Email { get; set; }
		public int? Rating { get; set; }
		
		public string Description { get; set; }
		public string Type { get; set; }

	}
}
