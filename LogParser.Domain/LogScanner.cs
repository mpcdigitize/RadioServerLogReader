using LogParser.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Domain
{
    public class LogScanner
    {

        private DirectorySearcher _searcher;
        private Parser _parser;
        private IEnumerable<string> _files;
        private IEnumerable<LogLine> _media;


        public LogScanner()
        {
            this._searcher = new DirectorySearcher();
            this._parser = new Parser();
            

        }


        public void ScanFolder(string folderPath,string searchPattern)
        {
            this._files = new List<string>();
            this._files = this._searcher.ScanFolder(folderPath,searchPattern);
            this.ParseLogs();

        }

        private void ParseLogs()
        {
            foreach (var item in this._files)
            {

                this._media = this._parser.ParseLog(item);

            }

        }

        public IEnumerable<LogLine> GetLogs()
        {

            return this._media;
        }







    }
}
