using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogParserMVC.Models
{
    public class LocalSettingModel
    {

        public Guid SettingId { get; set; }
        public string FolderPath { get; set; }
        public string BackupFolder { get; set; }
        public string BackupName { get; set; }
    }
}