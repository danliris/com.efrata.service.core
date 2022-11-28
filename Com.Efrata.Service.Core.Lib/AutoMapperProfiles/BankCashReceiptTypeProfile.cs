using AutoMapper;
using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Efrata.Service.Core.Lib.AutoMapperProfiles
{
    public class BankCashReceiptTypeProfile : Profile
    {
        public BankCashReceiptTypeProfile()
        {
            CreateMap<BankCashReceiptTypeModel, BankCashReceiptTypeViewModel>()
                .ReverseMap();
        }
    }
}
