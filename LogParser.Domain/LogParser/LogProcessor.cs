using LogParser.Domain.LogParser;
using LogParser.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogParser.Service
{
    public class LogProcessor
    {

        public IEnumerable<LogLine> FindNewlogLines(LogFile logFile)
        {
            var linesInParsedFile = this.ParseLogFile(logFile);


            var linesInDatabase = this.GetLogLines();
            var newLines = linesInParsedFile.Where(p => !linesInDatabase.Any(p2 => p2.Date == p.Date & 
                                                                                p2.Time == p.Time &
                                                                                p2.IpClient == p.IpClient));

            return newLines;


        }


        private IEnumerable<LogLine> ParseLogFile(LogFile logFile)
        {
            var parser = new Parser();
            var lines = parser.ParseLog(logFile.FilePath);

            return lines;

        }

        private IEnumerable<LogLine> GetLogLines()
        {
            var repo = new DisconnectedRepository();
            var files = repo.GetLogLines();
            

            return files;

        }

        private IEnumerable<LogLine> GetLogLinesByFileId(Guid id)
        {
            var repo = new DisconnectedRepository();
            var files = repo.GetLogLinesByFileId(id);


            return files;

        }



        private void AddLogLine(LogLine logLine)
        {

            var repo = new DisconnectedRepository();
            var files = repo.GetLogLines();


        }


    }
}
