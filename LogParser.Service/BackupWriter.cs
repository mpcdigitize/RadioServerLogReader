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
        XElement data;
        List<XElement> elements = new List<XElement>(); 

        public BackupWriter(IEnumerable<IpDetail> details)
        {

            this._details = details;


        }


        public void CreateBackup()
        {


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

                elements.Add(data);
            } 



            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("IpDetails Backup"),
                new XElement("IpDetails",
                        elements));




            xmlDocument.Save(@"C:\backup\test_backup.xml");


        }



    }
}
