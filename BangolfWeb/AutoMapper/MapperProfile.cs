using AutoMapper;
using BangolfModels;
using BangolfWeb.Models;

namespace BangolfWeb.AutoMapper
{
    public class MapperProfile : Profile
    {
public MapperProfile() 
        {
            CreateMap<Player, PlayerIndexViewModel>();
            CreateMap<Player, PlayerCreateViewModel>().ReverseMap();
            CreateMap<Player, PlayerEditViewModel>().ReverseMap();
            CreateMap<Player, PlayerDetailsViewModel>()
                .ForMember(
                dest => dest.NrOfCompetitions,
                    from => from.MapFrom(s => s.Competitions.Count));
        }
       
    }

}
