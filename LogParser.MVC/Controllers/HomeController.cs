using LogParser.Domain;
using LogParser.Domain.Model;
using LogParser.Service;
using LogParserMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogParserMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           // var repo = new Repository();
           // IEnumerable<LogLine> logs;
            //IEnumerable<LogLine> selected;


           // repo.ScanFolder(@"C:\LogFiles\one");
           // logs = repo.GetLogs();

           


            return View();
        }

        public ActionResult Logs()
        {
            var svc = new AppService();
            var lines = svc.GetLogLines();



            var result = lines.Select(p => new LogLineModel
            {
                Date = p.Date,
                Time = p.Time,
                IpClient = p.IpClient,
                MediaItem = p.MediaItem,
                IspProvider = p.IspProvider,
                Country = p.Country,
                State = p.State,
                Location = p.Location,
                IpDetailId = p.IpDetailId,
                Client = p.Client,
                ClientVersion = p.ClientVersion,
                Platform = p.Platform

            });


            return View(result);
        }

        public ActionResult IpHistory(string ipNumber)
        {
            var svc = new AppService();
            //string ip = "100.2.132.189";
            var lines = svc.GetIpHistoryByIpNumber(ipNumber);

            ViewBag.LinesCount = lines.Count();

            TempData["msg"] = "<script>alert(" + lines.Count() + ");</script>";

            var result = lines.Select(p => new LogLineModel
            {
                Date = p.Date,
                Time = p.Time,
                IpClient = p.IpClient,
                MediaItem = p.MediaItem,
                IspProvider = p.IspProvider,
                Country = p.Country,
                State = p.State,
                Location = p.Location,
                IpDetailId = p.IpDetailId,
                Client = p.Client,
                ClientVersion = p.ClientVersion,
                Platform = p.Platform


            });


            return View(result);
        }


        public ActionResult SelectedByDate(string date)
        {
            var svc = new AppService();
            //string ip = "100.2.132.189";
            var lines = svc.GetIpHistoryByDate(date);

            ViewBag.LinesCount = lines.Count();

            //TempData["msg"] = "<script>alert(" + lines.Count() + ");</script>";

            var result = lines.Select(p => new LogLineModel
            {
                Date = p.Date,
                Time = p.Time,
                IpClient = p.IpClient,
                MediaItem = p.MediaItem,
                IspProvider = p.IspProvider,
                Country = p.Country,
                State = p.State,
                Location = p.Location,
                IpDetailId = p.IpDetailId,
                Client = p.Client,
                ClientVersion = p.ClientVersion,
                Platform = p.Platform


            });


            return View(result);
        }


        public ActionResult SelectedByTime(string time)
        {
            var svc = new AppService();
            //string ip = "100.2.132.189";
            var lines = svc.GetIpHistoryByTime(time);

            ViewBag.LinesCount = lines.Count();

            //TempData["msg"] = "<script>alert(" + lines.Count() + ");</script>";

            var result = lines.Select(p => new LogLineModel
            {
                Date = p.Date,
                Time = p.Time,
                IpClient = p.IpClient,
                MediaItem = p.MediaItem,
                IspProvider = p.IspProvider,
                Country = p.Country,
                State = p.State,
                Location = p.Location,
                IpDetailId = p.IpDetailId,
                Client = p.Client,
                ClientVersion = p.ClientVersion,
                Platform = p.Platform


            });


            return View(result);
        }


        public ActionResult SelectedByMedia(string media)
        {
            var svc = new AppService();
            //string ip = "100.2.132.189";
            var lines = svc.GetIpHistoryByMedia(media);

            ViewBag.LinesCount = lines.Count();

            //TempData["msg"] = "<script>alert(" + lines.Count() + ");</script>";

            var result = lines.Select(p => new LogLineModel
            {
                Date = p.Date,
                Time = p.Time,
                IpClient = p.IpClient,
                MediaItem = p.MediaItem,
                IspProvider = p.IspProvider,
                Country = p.Country,
                State = p.State,
                Location = p.Location,
                IpDetailId = p.IpDetailId,
                Client = p.Client,
                ClientVersion = p.ClientVersion,
                Platform = p.Platform


            });


            return View(result);
        }


        public ActionResult SelectedByClient(string client)
        {
            var svc = new AppService();
            //string ip = "100.2.132.189";
            var lines = svc.GetIpHistoryByClient(client);

            ViewBag.LinesCount = lines.Count();

            //TempData["msg"] = "<script>alert(" + lines.Count() + ");</script>";

            var result = lines.Select(p => new LogLineModel
            {
                Date = p.Date,
                Time = p.Time,
                IpClient = p.IpClient,
                MediaItem = p.MediaItem,
                IspProvider = p.IspProvider,
                Country = p.Country,
                State = p.State,
                Location = p.Location,
                IpDetailId = p.IpDetailId,
                Client = p.Client,
                ClientVersion = p.ClientVersion,
                Platform = p.Platform


            });


            return View(result);
        }



        public ActionResult EditIpDetail(string id)
        {
            var svc = new AppService();
            var detail = svc.GetIpDetailById(id);
            var modelId = id;

            IpDetailModel detailView = new IpDetailModel
            {
                IpNumber = detail.IpNumber,
                IspProvider = detail.IspProvider,
                Location = detail.Location,
                State = detail.State,
                Country = detail.Country,
                IpDetailId = modelId,
                IsHidden = detail.IsHidden,
                Alias = detail.Alias

            };



            return View(detailView);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditIpDetail(IpDetailModel model)
        {

            //var model = new IpDetailModel();

            if (ModelState.IsValid)
            {
                var svc = new AppService();
                svc.EditIpDetail(
                    model.IpDetailId,
                    model.IpNumber,
                    model.IspProvider,
                    model.Country,
                    model.Location,
                    model.State,
                    model.IsHidden,
                    model.Alias
                    );

                return RedirectToAction("Index");

            }


            return View();

        }


        public ActionResult IpDetails()
        {
            var svc = new AppService();
            var details = svc.GetIpDetails();

            var result = details.Select(p => new IpDetailModel
            {
                IpNumber = p.IpNumber,
                IspProvider = p.IspProvider,
                Country = p.Country,
                Location = p.Location,
                State = p.State
            });

            return View(result);





        }


        public ActionResult CreateProvider()
        {
            ViewBag.Message = "Create provider";

            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProvider(IpDetailModel model)
        {

            //var model = new IpDetailModel();

            if (ModelState.IsValid)
            {
                var svc = new AppService();
                svc.CreateIpDetail(
                    model.IpNumber,
                    model.IspProvider,
                    model.Country,
                    model.Location,
                    model.State
                    );

                return RedirectToAction("Index");

            }


            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Scan()
        {
            var svc = new AppService();
            string path;

            path = @"C:\LogFiles\one";

            svc.ScanFolder(path);


            return RedirectToAction("Index");
        }



        public ActionResult CreateText()
        {
            string path = @"C:\temp\MyTest.txt";
            if (!System.IO.File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }


            return RedirectToAction("Index");
        }


        public ActionResult Settings()
        {
            var svc = new AppService();
            var setting = svc.GetSettings();

            if (setting != null)
            {

                var settingModel = new LocalSettingModel
                {

                    SettingId = setting.SettingId,
                    FolderPath = setting.FolderPath,
                    FileExtension = setting.FileExtension
                };

                return View(settingModel);
            }
            else
            {
                var settingModel = new LocalSettingModel
                {

                    SettingId = Guid.NewGuid()
                    
                };

                return View(settingModel);
            }
           

            //return View();
            


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Settings(LocalSettingModel model)
        {

            if (ModelState.IsValid)
            {
                var svc = new AppService();
                var setting = new LocalSetting
                {

                    SettingId = model.SettingId,
                    FolderPath = model.FolderPath,
                    FileExtension = model.FileExtension
                };


                svc.SaveSetting(setting);

                return RedirectToAction("Index");

            }

            return View();


        }


    }
}