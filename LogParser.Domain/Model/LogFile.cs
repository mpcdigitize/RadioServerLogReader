using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LogParser.Domain.Model
{
    public class LogFile
    {

        public LogFile()
        {

            LogFileId = Guid.NewGuid();

        }

        [Key]
        public Guid LogFileId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }



    }
}
