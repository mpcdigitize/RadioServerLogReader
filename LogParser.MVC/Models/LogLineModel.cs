using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogParserMVC.Models
{
    public class LogLineModel
    {

        public string Date { get; set; }
        public string Time { get; set; }
        public string MediaItem { get; set; }
        public string IpClient { get; set; }
        public string Client { get; set; }
        public string ClientVersion { get; set; }
        public string Platform { get; set; }
        public string IspProvider { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public Guid IpDetailId { get; set; }
    }
}