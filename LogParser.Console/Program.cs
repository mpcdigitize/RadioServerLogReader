



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

            var seed = new DataSeed();

            var details = seed.SeedIpDetail();

            var repo = new DisconnectedRepository();


            foreach (var item in details)
            {
                item.IsHidden = false;

                repo.AddNewIpDetail(item);
            }

            Console.WriteLine("done");





            Console.ReadLine();
        }
    }
}
