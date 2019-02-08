
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogParser.Domain.Model;

namespace LogParser.Data
{
    public class DisconnectedRepository
    {


        public IEnumerable<IpDetail> GetIpDetails()
        {

            using (var context = new AppContext())
            {
                var result = context.IpDetails.ToList();
                return result;

               
            }

        }


        public IpDetail GetIpDetailById(Guid id)
        {

            using (var context = new AppContext())
            {
                var result = context.IpDetails.Where(p => p.IpDetailId == id).FirstOrDefault();
                return result;


            }

        }


        public LocalSetting GetLocalSettings()
        {
            using (var context = new AppContext())
            {
                var result = context.LocalSettings.FirstOrDefault();

                return result;


            }


        }


        public LocalSetting GetLocalSettingByid(Guid id)
        {

            using (var context = new AppContext())
            {
                var result = context.LocalSettings.Where(p => p.SettingId == id).FirstOrDefault();
                return result;


            }

        }




        public void AddNewLocalSetting(LocalSetting localSetting)
        {
            using (var context = new AppContext())
            {
                context.Entry(localSetting).State = EntityState.Added;
                context.SaveChanges();

            }


        }

        public void EditLocalSetting(LocalSetting localSetting)
        {
            using (var context = new AppContext())
            {

                context.Entry(localSetting).State = EntityState.Modified;
                context.SaveChanges();

            }


        }



        public void AddNewIpDetail(IpDetail ipDetail)
        {
            using (var context = new AppContext())
            {
                context.Entry(ipDetail).State = EntityState.Added;
                context.SaveChanges();

            }


        }

        public void EditIpDetail(IpDetail ipDetail)
        {
            using (var context = new AppContext())
            {

                context.Entry(ipDetail).State = EntityState.Modified;
                context.SaveChanges();

            }


        }


        public void AddNewLogLine(LogLine logLine)
        {

            using (var context = new AppContext())
            {
                context.Entry(logLine).State = EntityState.Added;
                context.SaveChanges();

            }

        }


        public void AddNewLogFile(LogFile logFile)
        {

            using (var context = new AppContext())
            {
                context.Entry(logFile).State = EntityState.Added;
                context.SaveChanges();

            }

        }


        public IEnumerable<LogFile> GetLogFiles()
        {

            using (var context = new AppContext())
            {
                var result = context.LogFiles.ToList();
                return result;


            }


        }


        public IEnumerable<LogLine> GetLogLines()
        {

            using (var context = new AppContext())
            {
                var result = context.LogLines.Take(10);
                return result.ToList();


            }


        }

        public IEnumerable<LogLine> GetLogLinesByFileId(Guid id)
        {

            using (var context = new AppContext())
            {
                var result = context.LogLines.Where(p => p.LogFileId == id);
                return result;


            }


        }


        public LogFile GetLogFileByFileName(string name)
        {

            using (var context = new AppContext())
            {
                LogFile result = context.LogFiles.Where(p => p.FileName == name).FirstOrDefault();
                return result;


            }
        }

        /*
        public IEnumerable<LogLine> GetGraphLogLines()
        {

            using (var context = new AppContext())
            {
                var result = context.LogLines.Include(p => p.IpDetail).ToList();
                return result;


            }
   

        }

        */

        public void AddGraph(LogFile logFile, LogLine logLine)
        {
            using (var context = new AppContext())
            {

                context.Entry(logFile).State = EntityState.Added;
                context.Entry(logLine).State = EntityState.Added;
                context.SaveChanges();

            }

        }





    }
}
