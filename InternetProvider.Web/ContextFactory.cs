using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using InternetProvider.Data;

namespace InternetProvider.Web
{
    public class ContextFactory:IDbContextFactory<InetContext>
    {
        public InetContext Create()
        {
            ConnectionStringSettings mySetting = ConfigurationManager.ConnectionStrings["InternetProviderDb"];
            if (mySetting == null || string.IsNullOrEmpty(mySetting.ConnectionString))
                throw new Exception("Fatal error: missing connecting string in web.config file");
            return new InetContext(mySetting.ConnectionString);
        }
    }
}