using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogParserMVC.Models
{
    public class LocalSettingModel
    {

        public Guid SettingId { get; set; }

        [Display(Name = "Source Path")]
        public string FolderPath { get; set; }

        [Display(Name = "Backup Path")]
        public string BackupFolder { get; set; }

        [Display(Name = "Backup Name")]
        public string BackupName { get; set; }
    }
}