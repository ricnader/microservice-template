using AutoMapper;
using Application.DTOs.Distribuitor;
using Domain.Entities;

namespace Application.Map
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<DistribuitorDTO, Distribuitor>();
            CreateMap<Distribuitor, DistribuitorDTO>();

            //Custom DTOs
            CreateMap<DistribuitorCreateDTO, Distribuitor>();
            CreateMap<DistribuitorUpdateDTO, Distribuitor>();
        }

    }
}



