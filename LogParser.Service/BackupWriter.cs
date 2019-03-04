using LogParser.Domain.Model;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Service
{
    public class BackupWriter
    {
        IEnumerable<IpDetail> _details;
        IEnumerable<LogLine> _lines;
        IEnumerable<LogFile> _files;
        XElement data;
        List<XElement> detailElements = new List<XElement>();
        List<XElement> fileElements = new List<XElement>();
        List<XElement> lineElements = new List<XElement>();

        public BackupWriter(IEnumerable<IpDetail> details, IEnumerable<LogLine> lines, IEnumerable<LogFile> files)
        {

            this._details = details;
            this._lines = lines;
            this._files = files;


        }

        

        public void CreateBackup(string filePath)
        {

            foreach (var item in _lines)
            {
                data = new XElement("LogLines",
                        new XElement("LogLineId", item.LogLineId),
                        new XElement("Date", item.Date),
                        new XElement("Time", item.Time),
                        new XElement("IpNumber", item.IpNumber),
                        new XElement("MediaItem", item.MediaItem),
                        new XElement("Port", item.Port),
                        new XElement("IpClient", item.IpClient),
                        new XElement("Client", item.Client),
                        new XElement("ClientVersion", item.ClientVersion),
                        new XElement("Platform", item.Platform),
                        new XElement("LogFileId", item.LogFileId));

                lineElements.Add(data);
            }


            foreach (var item in _files)
            {
                data = new XElement("Files",
                        new XElement("LogFileId",item.LogFileId),
                        new XElement("FilePath", item.FilePath),
                        new XElement("FileName", item.FileName),
                        new XElement("FileSize", item.FileSize));

                fileElements.Add(data);
            }


            foreach (var item in this._details)
            {
                data = new XElement("IpDetail",
                    new XElement("IpDetailId", item.IpDetailId),
                    new XElement("IpNumber", item.IpNumber),
                    new XElement("IspProvider", item.IspProvider),
                    new XElement("Country", item.Country),
                    new XElement("Location", item.Location),
                    new XElement("State", item.State),
                    new XElement("Alias", item.Alias),
                    new XElement("IsHidden", item.IsHidden));

                detailElements.Add(data);
            } 



            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("backup",
                    new XElement("IpDetails",
                        detailElements),
                    new XElement("Files",
                        fileElements),
                    new XElement("LogLines",
                        lineElements)));




            xmlDocument.Save(filePath);


        }



    }
}
