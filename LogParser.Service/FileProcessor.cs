using LogParser.Domain;
using LogParser.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LogParser.Data;

namespace LogParser.Service
{
    public class FileProcessor
    {

    
        private DirectorySearcher _searcher;



        public FileProcessor()
        {
            _searcher = new DirectorySearcher();

        }


        public IEnumerable<LogFile> FindNewFiles(string folderPath)
        {
            var filesInFolder = this.GetFilesInFolder(folderPath);
            var filesInDatabase = this.GetLogFiles();
            var newFiles = filesInFolder.Where(p => !filesInDatabase.Any(p2 => p2.FilePath == p.FilePath & p2.FileSize == p.FileSize));


            return newFiles;           

        }


        private IEnumerable<LogFile> GetFilesInFolder(string folderPath)
        {

            var files = this._searcher.ScanFolder(folderPath);
            var output = new List<LogFile>();

            foreach (var f in files)
            {
                long length = new FileInfo(f).Length;

                var logFile = new LogFile
                {
                    LogFileId = Guid.NewGuid(),
                    FilePath = f,
                    FileName = Path.GetFileName(f),
                    FileSize = length
                };

                output.Add(logFile);
            }
            return output;


        }


        private IEnumerable<LogFile> GetLogFiles()
        {
            var repo = new DisconnectedRepository();
            var files = repo.GetLogFiles();

            return files;

        }

        /*
        private void ParseLogs()
        {
            foreach (var item in this._files)
            {

                //this._media = this._parser.ParseLog(item);

            }

        }

        public IEnumerable<LogLine> GetLogs()
        {

            return this._media;
        }
        */


    }




}

