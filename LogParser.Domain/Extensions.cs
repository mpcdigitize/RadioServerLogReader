using LogParser.Domain.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Domain
{
    public static class Extensions
    {


        public static IEnumerable<string> GetAllFiles(this string path, string searchPattern)
        {

            var files = new List<string>();


            try
            {
                files = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories).ToList();


            }

            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e.Message);
            }

            return files;


        }


        public static LogLine GetLogLine(this string path)
        {

            var logLine = new LogLine();
            List<string> words = new List<string>();

          

            try
            {
                int lenPath = path.Length;

                int firstPartSplit = path.IndexOf("GET");
                string firstPart = path.Substring(0, firstPartSplit);
                int lenFirstPart = firstPart.Length;
               
                string secondPart = path.Substring(lenFirstPart, lenPath - lenFirstPart-1);
                int lenSecondPart = secondPart.Length;
                int secondSplit = secondPart.IndexOf(" - ");
     

                string thirdPart = secondPart.Substring(secondSplit+2, lenSecondPart - secondSplit-2).Trim();
                int secondHyphen = thirdPart.IndexOf(" - ");
                int lenThirdPart = thirdPart.Length;

                string fourthPart = thirdPart.Substring(secondHyphen+2, lenThirdPart - secondHyphen-2).Trim();
                int secondSpace = fourthPart.IndexOf(" ");
                int lenFourthPart = fourthPart.Length;

                string fifthPart = fourthPart.Substring(secondSpace, lenFourthPart - secondSpace).Trim();
                int firstForwardSlash = fifthPart.IndexOf("/");
                int firstForwardPlusSign = fifthPart.IndexOf("+");
                int lenFifthPart = fifthPart.Length;
                int openingParenthesis = fifthPart.IndexOf("(");
                int closingParenthesis = fifthPart.IndexOf(")");


                logLine.Date = DateTime.Parse(firstPart.Substring(0, 10).Trim());
                logLine.Time = firstPart.Substring(11, 9).Trim();
                logLine.IpNumber = firstPart.Substring(20, lenFirstPart-20).Trim();
                logLine.MediaItem = secondPart.Substring(4, secondSplit - 4).Trim();
                logLine.Port = thirdPart.Substring(0, secondHyphen).Trim();
                logLine.IpClient = fourthPart.Substring(0, secondSpace).Trim();

                if (firstForwardSlash > 0)
                {

                    logLine.Client = fifthPart.Substring(0, firstForwardSlash).Trim();
                }
                else if (firstForwardPlusSign > 0)
                {
                    logLine.Client = fifthPart.Substring(0, firstForwardPlusSign).Trim();
                }

                //Console.WriteLine(logLine.Client);
                logLine.ClientVersion = fifthPart.Substring(firstForwardSlash+1, openingParenthesis - firstForwardSlash-2).Trim();
               // Console.WriteLine(fifthPart);
                //Console.WriteLine("Op: " + openingParenthesis + "Cl: " + closingParenthesis);
                logLine.Platform = fifthPart.Substring(openingParenthesis+1, closingParenthesis - openingParenthesis-1).Trim();

            
                return logLine;

            }

            catch (Exception e)
            {

                Console.WriteLine("An error occurred: '{0}'", e);
               
            }

            return logLine;


        }
    }
}
