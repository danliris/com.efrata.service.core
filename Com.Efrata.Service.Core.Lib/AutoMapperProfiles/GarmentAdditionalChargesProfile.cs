using AutoMapper;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.ViewModels;

namespace Com.Efrata.Service.Core.Lib.AutoMapperProfiles
{
    public class GarmentAdditionalChargesProfile : Profile
    {
        public GarmentAdditionalChargesProfile()
        {
            CreateMap<GarmentAdditionalChargesModel, GarmentAdditionalChargesViewModel>()
                .ReverseMap();
        }
    }
}
