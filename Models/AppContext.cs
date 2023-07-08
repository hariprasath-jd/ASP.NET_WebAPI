using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI_Main.Models
{
    public class AppContext : DbContext
    {
        public AppContext():base("name = db") {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppContext>());
        }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<LoginData> LoginDatas { get; set; }
    }
    
}