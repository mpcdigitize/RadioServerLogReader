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

        public void ScanFolder(string folderPath)
        {
            var fileProcessor = new FileProcessor();
            var filesToProcess = fileProcessor.FindNewFiles(folderPath);
            var repo = new DisconnectedRepository();
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
                    logLine.LogFileId = id;
                    repo.AddNewLogLine(logLine);

                }

            }
            




        }


        public IEnumerable<LogLineView> GetLogLines()
        {
            var repo = new DisconnectedRepository();
            var ipDetails = repo.GetIpDetails();
            var lines = repo.GetLogLines();
            var providers = new Providers(ipDetails);



            var result = lines.Select(p => new LogLineView {
                        Date = p.Date,
                        Time = p.Time,
                        IpClient = p.IpClient,
                        MediaItem = p.MediaItem,
                        IspProvider = providers.GetValue(p.IpClient).IspProvider,
                        Country = providers.GetValue(p.IpClient).Country,
                        State = providers.GetValue(p.IpClient).State,
                        Location = providers.GetValue(p.IpClient).Location,
                        IpDetailId = providers.GetValue(p.IpClient).IpDetailId

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
                IpDetailId = providers.GetValue(p.IpClient).IpDetailId

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

    }
}
