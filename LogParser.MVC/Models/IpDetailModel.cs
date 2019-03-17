using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogParserMVC.Models
{
    public class IpDetailModel
    {
        [Display(Name = "IP Number")]
        [Required(ErrorMessage ="You neeed to give us Ip Number")]
        public string IpNumber { get; set; }


        public string IpDetailId { get; set; }

        [Display(Name = "ISP Provider")]
        public string IspProvider { get; set; }

        public string Country { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string Alias { get; set; }

        [Display(Name = "Hide")]
        public bool IsHidden { get; set; }


    }
}