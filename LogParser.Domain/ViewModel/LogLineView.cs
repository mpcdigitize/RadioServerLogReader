using LogParser.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogParser.Domain.ViewModel
{
    public class LogLineView
    {
        public Guid LogLineId { get; set; }
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
        public Guid IpDetailId { get; set;}
        public bool IsHidden { get; set; }
        public string Alias { get; set; }


    }
}
