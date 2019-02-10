



using LogParser.Domain;
using LogParser.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LogParser.Domain.Model;

namespace LogParser
{
    class Program
    {
        static void Main(string[] args)
        {

            var svc = new AppService();

            string ip = "100.2.132.189";

            var result = svc.GetIpHistoryByIpNumber(ip);

            foreach (var item in result)
            {
                Console.WriteLine(item.IpClient + " == " + item.MediaItem + " == " + item.Country);
            }
            


            Console.WriteLine("done");





            Console.ReadLine();
        }
    }
}
