



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



            //var setting = new LocalSetting();
            var setting = svc.GetSettings();


            Console.WriteLine("Val: " + setting.SettingId + " == " + setting.FolderPath + " == " + setting.FileExtension);

            setting.FileExtension = @"ZIP";
            setting.FolderPath = @"AAAAAAAAA";

            svc.SaveSetting(setting);

            var setting1 = svc.GetSettings();


            Console.WriteLine("Val: " + setting1.SettingId + " == " + setting1.FolderPath + " == " + setting1.FileExtension);




            Console.WriteLine("done");





            Console.ReadLine();
        }
    }
}
