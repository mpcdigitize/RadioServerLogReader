using LogParser.Domain.Model;
using System.Collections.Generic;



namespace LogParser.Domain
{
    public class Providers
    {
        private Dictionary<string, IpDetail> _providers;



        public Providers(IEnumerable<IpDetail> providers)   
        {
          

            this._providers = new Dictionary<string, IpDetail>();

            foreach (var p in providers)
            {
                this._providers.Add(p.IpNumber, p);
            }

        

        }


        public IpDetail GetValue(string key)
        {
            var IpDetail = new IpDetail();

            if (!this._providers.TryGetValue(key, out IpDetail))
            {

                var isp = new IpDetail();

                isp.IpNumber = string.Empty;
                isp.Country = string.Empty;
                isp.IspProvider = string.Empty;
                isp.Location = string.Empty;
                isp.State = string.Empty;
                IpDetail = isp;

            }

            return IpDetail;

        }

        public IEnumerable<IpDetail> SeedProviders()
        {

            List<IpDetail> providers = new List<IpDetail>{

            new IpDetail() { IpNumber = "100.2.132.189", IspProvider = "FIOS", Country = "USA", Location = "Jamaica", State = "NY" },
            new IpDetail() { IpNumber = "172.58.227.169", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.224.174", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "213.137.16.2", IspProvider = "Manx Telecom", Country = "Isle of Man", Location = "Douglas" },
            new IpDetail() { IpNumber = "174.4.1.227", IspProvider = "Shaw Communications", Country = "Canada", Location = "Kamloops", State = "British Columbia" },

            new IpDetail() { IpNumber = "73.36.198.224", IspProvider = "Comcast", Country = "USA", Location = "Plainfield", State = "NJ" },
            new IpDetail() { IpNumber = "172.56.34.153", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "68.147.100.43", IspProvider = "Shaw Communications", Country = "Canada", Location = "Calgary", State = "Alberta" },
            new IpDetail() { IpNumber = "93.158.161.72", IspProvider = "Yandex", Country = "Russia", Location = "", State = "" },
            new IpDetail() { IpNumber = "197.237.112.240", IspProvider = "Wananchi", Country = "Kenya", Location = "", State = "" },

            new IpDetail() { IpNumber = "174.231.151.209", IspProvider = "Celico", Country = "USA", Location = "Louisville", State = "KY" },
            new IpDetail() { IpNumber = "50.69.20.11", IspProvider = "Shaw Communications", Country = "Canada", Location = "Kamloops", State = "British Columbia" },
            new IpDetail() { IpNumber = "158.69.116.72", IspProvider = "OVH", Country = "Canada", Location = "Montreal", State = "Quebec" },
            new IpDetail() { IpNumber = "142.162.19.197", IspProvider = "Bell Canada", Country = "Canada", Location = "Oromocto", State = "New Brunswick" },
            new IpDetail() { IpNumber = "99.26.245.236", IspProvider = "AT&T", Country = "USA", Location = "Duncan", State = "SC" },

            new IpDetail() { IpNumber = "77.173.78.74", IspProvider = "KPN", Country = "Netherlands", Location = "Waddinxveen", State = "South Holland" },
            new IpDetail() { IpNumber = "74.221.181.166", IspProvider = "EPB", Country = "USA", Location = "Hixson", State = "TN" },
            new IpDetail() { IpNumber = "104.193.62.85", IspProvider = "Start Communication", Country = "Canada", Location = "Woodstock", State = "Ontario" },
            new IpDetail() { IpNumber = "135.23.137.101", IspProvider = "tekSavvy", Country = "Canada", Location = "Toronto", State = "Ontario" },
            new IpDetail() { IpNumber = "172.58.227.12", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },

            new IpDetail() { IpNumber = "88.80.191.109", IspProvider = "Linode", Country = "UK", Location = "London", State = "England" },
            new IpDetail() { IpNumber = "172.58.227.5", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.225.103", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "139.162.225.200", IspProvider = "Linode", Country = "UK", Location = "London", State = "England" },
            new IpDetail() { IpNumber = "142.177.245.203", IspProvider = "Bell Canada", Country = "Canada", Location = "Dartmouth", State = "Nova Scotia" },

            new IpDetail() { IpNumber = "172.56.34.80", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "83.82.69.201", IspProvider = "Vodafone", Country = "Netherlands", Location = "Prinsenbeek", State = "North Brabant " },
            new IpDetail() { IpNumber = "77.247.85.71", IspProvider = "SysEleven", Country = "Germany", Location = "", State = "" },
            new IpDetail() { IpNumber = "104.237.136.161", IspProvider = "Linode", Country = "USA", Location = "Dallas", State = "TX" },
            new IpDetail() { IpNumber = "72.204.0.49", IspProvider = "Cox Communication", Country = "USA", Location = "Fayetteville", State = "AR" },

            new IpDetail() { IpNumber = "172.58.225.217", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "139.162.233.184", IspProvider = "Linode", Country = "UK", Location = "London", State = "England" },
            new IpDetail() { IpNumber = "104.237.137.166", IspProvider = "Linode", Country = "USA", Location = "Dallas", State = "TX" },
            new IpDetail() { IpNumber = "67.226.224.58", IspProvider = "DMTS", Country = "Canada", Location = "Dryden", State = "Ontario" },
            new IpDetail() { IpNumber = "172.58.227.96", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },

            new IpDetail() { IpNumber = "174.231.170.155", IspProvider = "Celico", Country = "USA", Location = "Louisville", State = "KY" },
            new IpDetail() { IpNumber = "172.56.34.142", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.225.56", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "183.179.127.151", IspProvider = "HK Broadband", Country = "Hong Kong", Location = "Hong Kong", State = "" },
            new IpDetail() { IpNumber = "172.56.35.30", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },

            new IpDetail() { IpNumber = "208.54.37.176", IspProvider = "T Mobile", Country = "USA", Location = "Brooklyn", State = "NY" },
            new IpDetail() { IpNumber = "172.56.34.107", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "209.8.144.216", IspProvider = "PCCW Global", Country = "USA", Location = "", State = "" },
            new IpDetail() { IpNumber = "160.162.120.30", IspProvider = "Itissalat", Country = "Marocco", Location = "Kenitra", State = "Kenitra" },
            new IpDetail() { IpNumber = "71.112.158.81", IspProvider = "MCI", Country = "USA", Location = "Pittsburgh", State = "PI" },

            new IpDetail() { IpNumber = "172.58.225.112", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "208.54.37.222", IspProvider = "T Mobile", Country = "USA", Location = "Brooklyn", State = "NY" },
            new IpDetail() { IpNumber = "172.58.225.21", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.56.35.56", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.56.28.139", IspProvider = "T Mobile", Country = "USA", Location = "Philadelphia", State = "PA" },

            new IpDetail() { IpNumber = "172.58.227.75", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.227.36", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.224.23", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.56.34.31", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.224.35", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },

            new IpDetail() { IpNumber = "172.56.35.187", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "174.231.172.57", IspProvider = "Celico", Country = "USA", Location = "Louisville", State = "KY" },
            new IpDetail() { IpNumber = "172.58.224.193", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.56.34.108", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "174.231.157.99", IspProvider = "Celico", Country = "USA", Location = "Prospect", State = "KY" },

            new IpDetail() { IpNumber = "172.58.224.108", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.233.98", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.232.149", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.233.43", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "208.54.37.189", IspProvider = "T Mobile", Country = "USA", Location = "Brooklyn", State = "NY" },

            new IpDetail() { IpNumber = "172.58.230.238", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.56.35.102", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.56.35.37", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.56.34.255", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.230.142", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },

            new IpDetail() { IpNumber = "208.54.37.151", IspProvider = "T Mobile", Country = "USA", Location = "Brooklyn", State = "NY" },
            new IpDetail() { IpNumber = "105.139.123.103", IspProvider = "Itissalat", Country = "Marocco", Location = "Casablanca", State = "Casablanca" },
            new IpDetail() { IpNumber = "70.50.214.138", IspProvider = "Bell Canada", Country = "Canada", Location = "Kanata", State = "Ontario" },
            new IpDetail() { IpNumber = "216.71.204.31", IspProvider = "Novus", Country = "Canada", Location = "Vancouver", State = "British Columbia" },
            new IpDetail() { IpNumber = "210.128.16.89", IspProvider = "Internet Initiative", Country = "Japan", Location = "Suita", State = "Osaka" },

            new IpDetail() { IpNumber = "172.56.34.50", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "208.54.37.239", IspProvider = "T Mobile", Country = "USA", Location = "Brooklyn", State = "NY" },
            new IpDetail() { IpNumber = "172.58.225.153", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.56.34.114", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.56.35.185", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },

            new IpDetail() { IpNumber = "172.56.35.227", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.230.146", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.225.9", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.56.29.98", IspProvider = "T Mobile", Country = "USA", Location = "Philadelphia", State = "PA" },
            new IpDetail() { IpNumber = "172.58.227.14", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.56.35.110", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" },
            new IpDetail() { IpNumber = "172.58.224.95", IspProvider = "T Mobile", Country = "USA", Location = "Bronx", State = "NY" }
            };


            return providers;

        }

      






    }
}
