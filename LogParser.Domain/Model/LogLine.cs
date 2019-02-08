using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Domain.Model
{
    public class LogLine
    {

        public LogLine()
        {

            LogLineId = Guid.NewGuid();

        }


        [Key]
        public Guid LogLineId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string IpNumber { get; set; }
        public string MediaItem { get; set; }
        public string Port { get; set; }
        public string IpClient { get; set;}
        public string Client { get; set; }
        public string ClientVersion { get; set; }
        public string Platform { get; set; }

        //[Required]
        public Guid LogFileId { get; set;}




        



    }
}
