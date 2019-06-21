using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingGo.Dtos;
using WeddingGo.Models;

namespace WeddingGo.Helpers
{
	public class AutoMapperProfiles:Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<MakeupArtist, UserForListDto>()
				.ForMember(dest => dest.PhotoUrl, opt =>
				{
					opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
				});
				
			CreateMap<MakeupArtist, UserForDetailed>()
				.ForMember(dest => dest.PhotoUrl, opt =>
				{
					opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
				});

			CreateMap<Photo, PhotosForDetailedDto>();
		}		
	}
}
