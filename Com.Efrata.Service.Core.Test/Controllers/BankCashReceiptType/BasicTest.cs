using Com.Efrata.Service.Core.Lib.Models;
using Com.Efrata.Service.Core.Lib.Services.BankCashReceiptType;
using Com.Efrata.Service.Core.Lib.ViewModels;
using Com.Efrata.Service.Core.Test.Utils;
using Com.Efrata.Service.Core.WebApi.Controllers.v1.BasicControllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Efrata.Service.Core.Test.Controllers.BankCashReceiptType
{
    public class BasicTest : BaseControllerTest<BankCashReceiptTypeController, BankCashReceiptTypeModel, BankCashReceiptTypeViewModel, IBankCashReceiptTypeService>
    {
        public BasicTest()
        {
        }
    }
}
