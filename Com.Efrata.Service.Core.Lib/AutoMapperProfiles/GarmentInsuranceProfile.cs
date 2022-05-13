using AutoMapper;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.ViewModels;

namespace Com.Efrata.Service.Core.Lib.AutoMapperProfiles
{
    public class GarmentInsuranceProfile : Profile
    {
        public GarmentInsuranceProfile()
        {
            CreateMap<GarmentInsuranceModel, GarmentInsuranceViewModel>()
                .ReverseMap();
        }
    }
}
