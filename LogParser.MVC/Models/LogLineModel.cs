using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogParserMVC.Models
{
    public class LogLineModel
    {

        public string Date { get; set; }
        public string Time { get; set; }

        [Display(Name = "Media")]
        public string MediaItem { get; set; }

        [Display(Name = "IP Number")]
        public string IpClient { get; set; }
        public string Client { get; set; }

        [Display(Name = "Version")]
        public string ClientVersion { get; set; }
        public string Platform { get; set; }

        [Display(Name = "Provider")]
        public string IspProvider { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public Guid IpDetailId { get; set; }
    }
}