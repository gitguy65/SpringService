using AutoMapper;
using SpringService.Api.Model.Dto;
using SpringService.Api.Models;

namespace SpringService.Api.Util
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<History, HistoryDto>();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<Booking, BookingDto>();
        }
    }
}

