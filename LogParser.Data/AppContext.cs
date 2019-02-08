


using LogParser.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogParser.Data
{
    public class AppContext : DbContext
    {


        public AppContext() : base("name=ForTestingOnly")
        {

            //string path = @"C:\github\LogParserMVC\LogParserMVC.Data\App_Data\";
            //AppDomain.CurrentDomain.SetData("DataDirectory", path);


            //set up connection string with DataDirectory
            /*
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relative = @"..\..\App_Data\";
            string absolute = Path.GetFullPath(Path.Combine(baseDirectory, relative));
            AppDomain.CurrentDomain.SetData("DataDirectory", absolute);
            */

            /*
                 Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext,
                 LogParserMVC.Data.Migrations.Configuration>("AttachToMdfStoredInAppFolder"));
             */
        }

        public DbSet<LogFile> LogFiles { get; set; }
        public DbSet<IpDetail> IpDetails { get; set; }
        public DbSet<LogLine> LogLines { get; set; }
        public DbSet<LocalSetting> LocalSettings { get; set; }

    }
}
