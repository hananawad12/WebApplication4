using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGo.Models.Repositery
{
	public interface IClientRepositery
	{
		List<MakeupArtist> getAll();

		MakeupArtist getById(int id);

	}
}
