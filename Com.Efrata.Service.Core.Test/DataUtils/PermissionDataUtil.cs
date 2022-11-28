//using Com.Efrata.Service.Core.Lib;
//using Com.Efrata.Service.Core.Lib.Models.Account_and_Roles;
//using Com.Efrata.Service.Core.Lib.Services.Account_and_Roles;
//using Com.Efrata.Service.Core.Lib.ViewModels.Account_and_Roles;
//using Com.Efrata.Service.Core.Test.Helpers;
//using Com.Efrata.Service.Core.Test.Interface;
//using System.Threading.Tasks;

//namespace Com.Efrata.Service.Core.Test.DataUtils
//{
//    public class PermissionDataUtil : BasicDataUtil<CoreDbContext, PermissionService, Permission>, IEmptyData<PermissionViewModel>
//    {
//        public PermissionDataUtil(CoreDbContext dbContext, PermissionService service) : base(dbContext, service)
//        {
//        }

//        public PermissionViewModel GetEmptyData()
//        {
//            return new PermissionViewModel();
//        }

//        public override Permission GetNewData()
//        {
//            return new Permission{
                
//            };
//        }

//        public override async Task<Permission> GetTestDataAsync()
//        {
//            var model = GetNewData();
//            await Service.CreateModel(model);
//            return model;
//        }
//    }
//}
