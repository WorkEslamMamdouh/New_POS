using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using System.Web.Http.Dependencies;
using Inv.DAL.Repository;
using Inv.BLL.Services.GUSERS;
using Inv.BLL.Services.CompStatus;
using Inv.BLL.Services.IControl;
 
using Inv.BLL.Services.IGCodes; 
using Inv.BLL.Services.GCostCenter;
using Inv.BLL.Services.GRole;
using Inv.BLL.Services.GRoleUsers;
using Inv.BLL.Services.G_Control;
using Inv.BLL.Services.GBRANCH;
using Inv.BLL.Services.G_SUB_SYSTEM;
using Inv.BLL.Services.USER_BRANCH;
using Inv.BLL.Services.GCompany;
using Inv.BLL.Services.GAlertControl;

namespace Inv.API.Infrastructure
{
    public static class IocConfigurator
    {

        public static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<IG_USERSService, G_USERSService>();
            container.RegisterType<II_VW_GetCompStatusService, I_VW_GetCompStatusService>();
            container.RegisterType<II_ControlService, I_ControlService>();

            
            container.RegisterType<IIGCodesService, IGCodesService>();

            container.RegisterType<IGCostCenterService, GCostCenterService>();
   
            container.RegisterType<IG_ControlService, G_ControlService>();
            container.RegisterType<IGRoleUsersService, GRoleUsersService>();
            container.RegisterType<IGRoleService, GRoleService>();
            container.RegisterType<IGBRANCHService, GBRANCHService>();
   
            container.RegisterType<IG_SUB_SYSTEMSService, G_SUB_SYSTEMSService>();
   
            container.RegisterType<IG_USER_BRANCHService, G_USER_BRANCHService>();
        

          
            container.RegisterType<IGCompanyService, GCompanyService>();
            container.RegisterType<IG_AlertControlService, G_AlertControlService>();
           
        }
    }
}