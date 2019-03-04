using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LogParser.Domain.Model
{
    public class LocalSetting
    {
        [Key]
        public Guid SettingId { get; set; } = Guid.NewGuid();
        public string FolderPath { get; set; }
        public string BackupFolder { get; set; }

    }
}
