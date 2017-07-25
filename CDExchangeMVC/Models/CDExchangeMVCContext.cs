using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CDExchangeMVC.Models
{
    public class CDExchangeMVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CDExchangeMVCContext() : base("name=CDExchangeMVCContext")
        {
        }

        public System.Data.Entity.DbSet<CDExchangeMVC.Models.CD> CDs { get; set; }

        public System.Data.Entity.DbSet<CDExchangeMVC.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<CDExchangeMVC.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<CDExchangeMVC.Models.Checkout> Checkouts { get; set; }
    }
}
