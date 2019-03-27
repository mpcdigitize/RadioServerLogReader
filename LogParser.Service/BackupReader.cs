using LogParser.Domain.Model;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Service
{
    public class BackupReader
    {

       


        public IEnumerable<IpDetail> ParseIpDetails(string filePath)
        {
            List<IpDetail> details = new List<IpDetail>();


            XDocument.Load(filePath).Descendants("IpDetail").ToList().ForEach(
                XElement => details.Add(new IpDetail {
                                            IpDetailId = Guid.Parse(XElement.Element("IpDetailId").Value.ToString()),
                                            IpNumber = XElement.Element("IpNumber").Value.ToString(),
                                            IspProvider = XElement.Element("IspProvider").Value.ToString(),
                                            Country = XElement.Element("Country").Value.ToString(),
                                            Location = XElement.Element("Location").Value.ToString(),
                                            State = XElement.Element("State").Value.ToString(),
                                            Alias = XElement.Element("Alias").Value.ToString(),
                                            IsHidden = bool.Parse(XElement.Element("IsHidden").Value.ToString())


                }));


            return details;
        }


        public IEnumerable<LogLine> ParseLogLines(string filePath)
        {

            List<LogLine> lines = new List<LogLine>();



        XDocument.Load(filePath).Descendants("LogLine").ToList().ForEach(
                XElement => lines.Add(new LogLine
                {
                    LogLineId = Guid.Parse(XElement.Element("LogLineId").Value.ToString()),
                    Date  = DateTime.Parse(XElement.Element("Date").Value.ToString()),
                    Time = XElement.Element("Time").Value.ToString(),
                    IpNumber = XElement.Element("IpNumber").Value.ToString(),
                    MediaItem = XElement.Element("MediaItem").Value.ToString(),
                    Port = XElement.Element("Port").Value.ToString(),
                    IpClient = XElement.Element("IpClient").Value.ToString(),
                    Client = XElement.Element("Client").Value.ToString(),
                    ClientVersion = XElement.Element("ClientVersion").Value.ToString(),
                    Platform = XElement.Element("Platform").Value.ToString(),
                    LogFileId = Guid.Parse(XElement.Element("LogFileId").Value.ToString()),



                }));


            return lines;
        }


        public IEnumerable<LogFile> ParseLogFiles(string filePath)
        {

            List<LogFile> files = new List<LogFile>();


            XDocument.Load(filePath).Descendants("File").ToList().ForEach(
                XElement => files.Add(new LogFile
                {
                    LogFileId = Guid.Parse(XElement.Element("LogFileId").Value.ToString()),
                    FilePath = XElement.Element("FilePath").Value.ToString(),
                    FileName = XElement.Element("FileName").Value.ToString(),
                    FileSize = long.Parse(XElement.Element("FileSize").Value.ToString())
                   


                }));


            return files;
        }
    }
}
