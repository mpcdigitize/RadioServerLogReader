using LogParser.Data;
using LogParser.Domain;
using LogParser.Domain.Model;
using LogParser.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Service
{
    public class AppService
    {

        public void ScanFolder()
        {
            string searchPattern = SearchPattern.Log;
            var repo = new DisconnectedRepository();
            var fileProcessor = new FileProcessor();

            LocalSetting setting = repo.GetLocalSettings();
            string folderPath = @"" + setting.FolderPath;
            var filesToProcess = fileProcessor.FindNewFiles(folderPath,searchPattern);
            
            var ipDetails = repo.GetIpDetails();

            List<string> ipNumbers = ipDetails.Select(p => p.IpNumber).ToList();
            List<string> scannedIpNumbers = new List<string>();


            Guid id = new Guid();
          
            var logProcessor = new LogProcessor();

            foreach (var logFile in filesToProcess)
            {
                var linesToProcess = logProcessor.FindNewlogLines(logFile);
                var fileInDatabase = repo.GetLogFileByFileName(logFile.FileName);

                if (fileInDatabase != null)
                {
                    id = fileInDatabase.LogFileId;

                }
                else
                {
                    id = logFile.LogFileId;
                    repo.AddNewLogFile(logFile);
                }


                foreach (var logLine in linesToProcess)
                {


                    scannedIpNumbers.Add(logLine.IpClient);

                    logLine.LogFileId = id;

                    repo.AddNewLogLine(logLine);

                }

            }

            var newIpNumbers = scannedIpNumbers.Except(ipNumbers);

            foreach (var item in newIpNumbers)
            {
                var ipDetail = new IpDetail();
                ipDetail.IpNumber = item;
                repo.AddNewIpDetail(ipDetail);
                Console.WriteLine(item);
            }



        }


        public IEnumerable<LogLineView> GetLogLines()
        {
            var repo = new DisconnectedRepository();
            var ipDetails = repo.GetIpDetails();
            var lines = repo.GetLogLines();
            var providers = new Providers(ipDetails);



            var result = lines.Select(p => new LogLineView
            {
                Date = p.Date,
                Time = p.Time,
                IpClient = p.IpClient,
                MediaItem = p.MediaItem,
                IspProvider = providers.GetValue(p.IpClient).IspProvider,
                Country = providers.GetValue(p.IpClient).Country,
                State = providers.GetValue(p.IpClient).State,
                Location = providers.GetValue(p.IpClient).Location,
                IpDetailId = providers.GetValue(p.IpClient).IpDetailId,
                Client = p.Client,
                ClientVersion = p.ClientVersion,
                Platform = p.Platform,
                IsHidden = providers.GetValue(p.IpClient).IsHidden


            });

            

            return result;


        }


        public IEnumerable<IpDetail> GetIpDetails()
        {
            var repo = new DisconnectedRepository();
            var ipDetails = repo.GetIpDetails()
                            .OrderBy(p => p.IpNumber).ToList();

            return ipDetails;


        }


        public void EditIpDetail(string id, string ipNumber, string ispProvider, string country, string location, string state, bool IsHidden, string alias)
        {
            var repo = new DisconnectedRepository();
            IpDetail detail = new IpDetail
            {
                IpNumber = ipNumber,
                IspProvider = ispProvider,
                Country = country,
                Location = location,
                State = state,
                IpDetailId = new Guid(id),
                IsHidden = IsHidden,
                Alias = alias
            };

            repo.EditIpDetail(detail);


        }


        public void CreateIpDetail(string ipNumber, string ispProvider,string country,string location,string state)
        {

            var repo = new DisconnectedRepository();

            repo.AddNewIpDetail(new IpDetail {
                    IpNumber = ipNumber,
                    IspProvider = ispProvider,
                    Country = country,
                    Location = location,
                    State = state

            });

        }


        public IpDetail GetIpDetailById(string id)
        {
            var repo = new DisconnectedRepository();
            var detail = repo.GetIpDetailById(new Guid(id));

            return detail;


        }

        public IEnumerable<LogLineView> GetIpHistoryByIpNumber(string ipNumber)
        {
            var repo = new DisconnectedRepository();
            var ipDetails = repo.GetIpDetails();
            var lines = repo.GetLogsByIpNumber(ipNumber);
            var providers = new Providers(ipDetails);



            var result = lines.Select(p => new LogLineView
            {
                Date = p.Date,
                Time = p.Time,
                IpClient = p.IpClient,
                MediaItem = p.MediaItem,
                IspProvider = providers.GetValue(p.IpClient).IspProvider,
                Country = providers.GetValue(p.IpClient).Country,
                State = providers.GetValue(p.IpClient).State,
                Location = providers.GetValue(p.IpClient).Location,
                IpDetailId = providers.GetValue(p.IpClient).IpDetailId,
                Client = p.Client,
                ClientVersion = p.ClientVersion,
                Platform = p.Platform,
                IsHidden = providers.GetValue(p.IpClient).IsHidden


            });

            return result;
        }

        public IEnumerable<LogLineView> GetIpHistoryByDate(string date)
        {
            var repo = new DisconnectedRepository();
            var ipDetails = repo.GetIpDetails();
            var lines = repo.GetLogsByDate(date);
            var providers = new Providers(ipDetails);



            var result = lines.Select(p => new LogLineView
            {
                Date = p.Date,
                Time = p.Time,
                IpClient = p.IpClient,
                MediaItem = p.MediaItem,
                IspProvider = providers.GetValue(p.IpClient).IspProvider,
                Country = providers.GetValue(p.IpClient).Country,
                State = providers.GetValue(p.IpClient).State,
                Location = providers.GetValue(p.IpClient).Location,
                IpDetailId = providers.GetValue(p.IpClient).IpDetailId,
                Client = p.Client,
                ClientVersion = p.ClientVersion,
                Platform = p.Platform,
                IsHidden = providers.GetValue(p.IpClient).IsHidden


            });

            return result;
        }


        public IEnumerable<LogLineView> GetIpHistoryByTime(string time)
        {
            var repo = new DisconnectedRepository();
            var ipDetails = repo.GetIpDetails();
            var lines = repo.GetLogsByTime(time);
            var providers = new Providers(ipDetails);



            var result = lines.Select(p => new LogLineView
            {
                Date = p.Date,
                Time = p.Time,
                IpClient = p.IpClient,
                MediaItem = p.MediaItem,
                IspProvider = providers.GetValue(p.IpClient).IspProvider,
                Country = providers.GetValue(p.IpClient).Country,
                State = providers.GetValue(p.IpClient).State,
                Location = providers.GetValue(p.IpClient).Location,
                IpDetailId = providers.GetValue(p.IpClient).IpDetailId,
                Client = p.Client,
                ClientVersion = p.ClientVersion,
                Platform = p.Platform,
                IsHidden = providers.GetValue(p.IpClient).IsHidden


            });

            return result;
        }


        public IEnumerable<LogLineView> GetIpHistoryByMedia(string media)
        {
            var repo = new DisconnectedRepository();
            var ipDetails = repo.GetIpDetails();
            var lines = repo.GetLogsByMedia(media);
            var providers = new Providers(ipDetails);



            var result = lines.Select(p => new LogLineView
            {
                Date = p.Date,
                Time = p.Time,
                IpClient = p.IpClient,
                MediaItem = p.MediaItem,
                IspProvider = providers.GetValue(p.IpClient).IspProvider,
                Country = providers.GetValue(p.IpClient).Country,
                State = providers.GetValue(p.IpClient).State,
                Location = providers.GetValue(p.IpClient).Location,
                IpDetailId = providers.GetValue(p.IpClient).IpDetailId,
                Client = p.Client,
                ClientVersion = p.ClientVersion,
                Platform = p.Platform,
                IsHidden = providers.GetValue(p.IpClient).IsHidden


            });

            return result;
        }


        public IEnumerable<LogLineView> GetIpHistoryByClient(string client)
        {
            var repo = new DisconnectedRepository();
            var ipDetails = repo.GetIpDetails();
            var lines = repo.GetLogsByClient(client);
            var providers = new Providers(ipDetails);



            var result = lines.Select(p => new LogLineView
            {
                Date = p.Date,
                Time = p.Time,
                IpClient = p.IpClient,
                MediaItem = p.MediaItem,
                IspProvider = providers.GetValue(p.IpClient).IspProvider,
                Country = providers.GetValue(p.IpClient).Country,
                State = providers.GetValue(p.IpClient).State,
                Location = providers.GetValue(p.IpClient).Location,
                IpDetailId = providers.GetValue(p.IpClient).IpDetailId,
                Client = p.Client,
                ClientVersion = p.ClientVersion,
                Platform = p.Platform,
                IsHidden = providers.GetValue(p.IpClient).IsHidden


            });

            return result;
        }


        public void CreateLocalSetting(LocalSetting localSetting)
        {

            var repo = new DisconnectedRepository();
            repo.AddNewLocalSetting(localSetting);


            
        }

        public void UpdateLocalSetting(LocalSetting localSetting)
        {

            var repo = new DisconnectedRepository();
            repo.EditLocalSetting(localSetting);



        }

        public void SaveSetting(LocalSetting localSetting)
        {

            var repo = new DisconnectedRepository();

            var setting = repo.GetLocalSettings();

            if (setting != null)
            {
                repo.EditLocalSetting(localSetting);
            }
            else
            {
                repo.AddNewLocalSetting(localSetting);
            }

        }



        public LocalSetting GetSettings()
        {

            var repo = new DisconnectedRepository();

            return repo.GetLocalSettings();


        }


        public void Backup()
        {
            var repo = new DisconnectedRepository();
            var ipDetails = repo.GetIpDetails();
            var files = repo.GetLogFiles();
            var lines = repo.GetLogLines();
            var setting = repo.GetLocalSettings();
            var backupWriter = new BackupWriter(ipDetails,lines,files,setting);


            var time = DateTime.Now.ToString("yyyy.dd.mm.HH.mm");

            var path = setting.BackupFolder;
            var fileName =path + setting.BackupName + time + BackupFormat.Xml;

            backupWriter.CreateBackup(fileName);




        }

        public IEnumerable<string> GetBackups()
        {

            var repo = new DisconnectedRepository();
            IEnumerable<string> result = new  List<string>();
            var directorySearcher = new DirectorySearcher();
            var setting = repo.GetLocalSettings();


            if (setting != null)
            {

                result = directorySearcher.ScanFolder(setting.BackupFolder, SearchPattern.Xml);
            }

 

            


            return result;

        }



        public void Restore(string filePath)
        {
            var repo = new DisconnectedRepository();
            var reader = new BackupReader();

            var ipDetails = reader.ParseIpDetails(filePath);
            var files = reader.ParseLogFiles(filePath);
            var lines = reader.ParseLogLines(filePath);



            repo.ClearTables();

            foreach (var detail in ipDetails)
            {
                repo.AddNewIpDetail(detail);
            }

   
            foreach (var file in files)
            {
                repo.AddNewLogFile(file);
            }
            

            foreach (var line in lines)
            {
                repo.AddNewLogLine(line);
            }

           


        }


        public void ClearTables()
        {
            var repo = new DisconnectedRepository();
            repo.ClearTables();

        }

      

    }
}
