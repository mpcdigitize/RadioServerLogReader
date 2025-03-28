﻿using LogParser.Domain;
using LogParser.Domain.Model;
using LogParser.Service;
using LogParserMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


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

        public ActionResult Logs(int? page)
        {
            var svc = new AppService();
            var lines = svc.GetLogLines().Where(p => p.IsHidden == false);

            int pageSize = 20;
            int pageNumber = (page ?? 1);


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


            return View(result.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Backups()
        {
            var svc = new AppService();
            var backups = svc.GetBackups();

            var result = backups.Select(p => new BackupModel
            {
                FilePath = p
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


        public ActionResult SelectedByDate(string date,int? page)
        {
            var svc = new AppService();
            //string ip = "100.2.132.189";
            var lines = svc.GetIpHistoryByDate(date);

            ViewBag.LinesCount = lines.Count();

            int pageSize = 20;
            int pageNumber = (page ?? 1);

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


            return View(result.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult SelectedByIpNumber(string ipNumber,int? page)
        {
            var svc = new AppService();
            //string ip = "100.2.132.189";
            var lines = svc.GetIpHistoryByIpNumber(ipNumber);

            int pageSize = 20;
            int pageNumber = (page ?? 1);

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


            return View(result.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult SelectedByTime(string time,int? page)
        {
            var svc = new AppService();
            var lines = svc.GetIpHistoryByTime(time);



            int pageSize = 20;
            int pageNumber = (page ?? 1);

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


            return View(result.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult SelectedByMedia(string media,int? page)
        {
            var svc = new AppService();
            //string ip = "100.2.132.189";
            var lines = svc.GetIpHistoryByMedia(media);

            ViewBag.LinesCount = lines.Count();

            int pageSize = 20;
            int pageNumber = (page ?? 1);


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


            return View(result.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult SelectedByClient(string client, int? page)
        {
            var svc = new AppService();
            //string ip = "100.2.132.189";
            var lines = svc.GetIpHistoryByClient(client);


            int pageSize = 20;
            int pageNumber = (page ?? 1);


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


            return View(result.ToPagedList(pageNumber, pageSize));
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

                return RedirectToAction("IpDetails");

            }


            return View();

        }


        public ActionResult IpDetails(int? page)
        {
            var svc = new AppService();
            var details = svc.GetIpDetails();

   
            int pageSize = 20;
            int pageNumber = (page ?? 1);


            var result = details.Select(p => new IpDetailModel
            {
                IpNumber = p.IpNumber,
                IspProvider = p.IspProvider,
                Country = p.Country,
                Location = p.Location,
                State = p.State,
                IpDetailId = p.IpDetailId.ToString(),
                Alias = p.Alias,
                IsHidden = p.IsHidden
            });

            return View(result.ToPagedList(pageNumber,pageSize));





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
            

            svc.ScanFolder();


            return RedirectToAction("Index");
        }


        public ActionResult RestoreDetails(string path)
        {
            var svc = new AppService();

            svc.RestoreDetails(path);


            return RedirectToAction("Index");
        }


        public ActionResult Restore(string path)
        {
            var svc = new AppService();

            svc.Restore(path);


            return RedirectToAction("Index");
        }

        public ActionResult CreateBackupDetail()
        {
            var svc = new AppService();

            svc.BackupDetails();


            return RedirectToAction("Index");
        }


        public ActionResult CreateBackup()
        {
            var svc = new AppService();

            svc.Backup();


            return RedirectToAction("Index");
        }

        public ActionResult ClearTables()
        {
            var svc = new AppService();

            svc.ClearTables();


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
                    BackupFolder = setting.BackupFolder,
                    BackupName = setting.BackupName
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
                    BackupFolder = model.BackupFolder,
                    BackupName = model.BackupName
                };


                svc.SaveSetting(setting);

                return RedirectToAction("Index");

            }

            return View();


        }


    }
}