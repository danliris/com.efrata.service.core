using Com.Efrata.Service.Core.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Com.Moonlay.Models;
using Com.Efrata.Service.Core.Lib.Models;
using System.Linq.Expressions;

namespace Com.Efrata.Service.Core.Lib.Services.BankCashReceiptType
{
    public interface IBankCashReceiptTypeService : IBaseService<BankCashReceiptTypeModel>
    {
        bool CheckExisting(Expression<Func<BankCashReceiptTypeModel, bool>> filter);
    }

}
