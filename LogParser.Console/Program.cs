﻿



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

            //Console.WriteLine(FileType.Log + " <> " + FileType.Txt + " <> " + FileType.Xml); 





            /*
            var reader = new BackupReader();

            var details = reader.ParseFile();

            foreach (var item in details)
            {
                Console.WriteLine(item.IpNumber + " - " + item.Location + " - " + item.IspProvider + " - " + item.IsHidden);
            }
            */


            /*
            var repo = new DisconnectedRepository();
            var details = repo.GetIpDetails();
            var backup = new BackupWriter(details);



            backup.CreateBackup();
            */






            // var seed = new DataSeed();

            // var details = seed.SeedIpDetail();
            var svc = new AppService();

            //var repo = new DisconnectedRepository();

           // string pattern = SearchPattern.Log;
           // string path = @"C:\LogFiles\one";

            svc.ScanFolder();

            var result = svc.GetLogLines();


            foreach (var item in result)
            {
                Console.WriteLine(item.IpClient + " - " + item.IspProvider);
            }

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
