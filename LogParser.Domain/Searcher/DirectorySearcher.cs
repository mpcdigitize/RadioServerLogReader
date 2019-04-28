using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Domain.Searcher
{
    public class DirectorySearcher
    {

        //private const string searchPattern = "*.log";
        private IEnumerable<String> _files;



        public DirectorySearcher()
        {
            _files = new List<String>();

        }


        public IEnumerable<String> ScanFolder(string folderPath,string searchPattern)
        {

            Console.WriteLine(folderPath);

            _files = folderPath.GetAllFiles(searchPattern);
                    

            return _files;


        }

       


    }

}

