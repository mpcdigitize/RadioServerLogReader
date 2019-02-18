



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

            // var seed = new DataSeed();

            // var details = seed.SeedIpDetail();
            var svc = new AppService();

            // var repo = new DisconnectedRepository();
            var result = svc.GetLogLines();

            foreach (var item in result)
            {
                //item.IsHidden = false;

                Console.WriteLine(item.IpClient + " == " + item.IsHidden);
            }

            Console.WriteLine("done");





            Console.ReadLine();
        }
    }
}
