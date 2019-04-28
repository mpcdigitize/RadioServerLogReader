using LogParser.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Domain.LogParser
{
    public class Parser
    {

        List<string> lines = new List<string>();
       


        private void ReadLogLine(string filePath)
        {
       
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                lines.Add(line);

            }

            file.Close();

        }



        public IEnumerable<LogLine> ParseLog(string filePath)
        {
            IEnumerable<string> selected = new List<string>();
            List<LogLine> media = new List<LogLine>();

            var logLine = new LogLine();
            this.ReadLogLine(filePath);

            selected = lines.Where(l => l.Contains("GET"))
                            .Where(l => l.Contains("+("))
                            .Where(l => l.Contains(")"))
                            .Where(l => l.Contains(".xml"));

            foreach (var l in selected)
            {
                 
               logLine = l.GetLogLine();

               media.Add(logLine);

            }


            return media;
        }

  
    }
}
