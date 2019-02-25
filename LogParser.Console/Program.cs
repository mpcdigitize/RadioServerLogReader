



using LogParser.Domain;
using LogParser.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LogParser.Domain.Model;
using LogParser.Data;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {


            var repo = new DisconnectedRepository();
            var details = repo.GetIpDetails();
            var backup = new BackupWriter(details);


            backup.CreateBackup();

            // var seed = new DataSeed();

            // var details = seed.SeedIpDetail();
            ////var svc = new AppService();

            //var repo = new DisconnectedRepository();
            ////svc.ScanFolder(@"C:\LogFiles\one");

            //foreach (var item in details)
            //{
            //    Console.WriteLine(item.IpNumber);
            //    repo.AddNewIpDetail(item);
            //}


            Console.WriteLine("done");





            Console.ReadLine();
        }
    }
}
