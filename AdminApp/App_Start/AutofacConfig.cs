using Admin.App.BusinessLayer.Services;
using Admin.App.Common.Interface;
using Admin.App.DataAccessLayer.Interface;
using Admin.App.DataAccessLayer.Provider;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminApp.App_Start
{
    public class AutofacConfig:Module
    {
        private string connStr;
        public AutofacConfig(string connString)
        {
            this.connStr = connString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //Register All service with the Interface
            builder.RegisterType<RoleService>().As<IRole>();
            builder.RegisterType<RoleProvider>().As<IRoleProvider>();
            builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>();
            builder.RegisterType<UserAuthenticationService>().As<IUserAuthentication>();
            builder.RegisterType<UserAuthenticationProvider>().As<IUserAuthentication>();
            builder.RegisterType<CompanyService>().As<ICompanyDetails>();
            builder.RegisterType<UserDetailsService>().As<IUserDetails>();
            builder.RegisterType<CommonService>().As<ICommon>();
            base.Load(builder);
        }
    }
}