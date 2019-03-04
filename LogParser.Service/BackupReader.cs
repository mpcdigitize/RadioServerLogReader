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

        public IEnumerable<IpDetail> ParseFile(string filePath)
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
    }
}
