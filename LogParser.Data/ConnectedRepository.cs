
using LogParser.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Data
{
    public class ConnectedRepository
    {
        private AppContext _context;

        public ConnectedRepository()
        {

            _context = new AppContext();

        }


        public void CreateNewIsp(IpDetail isp)
        {
            _context.IpDetails.Add(isp);

        }

        public void SaveChanges()
        {

            _context.SaveChanges();
        }


        public IEnumerable<IpDetail> GetIpDetail()
        {
            var list = _context.IpDetails.ToList();

            return list;
        }




    }
}