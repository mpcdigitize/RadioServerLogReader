using System;
using System.Collections.Generic;
using System.Text;

namespace LogParser.Domain.Searcher
{
    public static class SearchPattern
    {
        public static String Log { get { return "*.log"; } }
        public static String Txt { get { return "*.txt"; } }
        public static String Xml { get { return "*.xml"; } }


    }
}
