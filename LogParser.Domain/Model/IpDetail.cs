using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Domain.Model
{
    public class IpDetail
    {

        public IpDetail()
        {
            IpDetailId = Guid.NewGuid();
        }

        [Key]
        public Guid IpDetailId { get; set; }
        public string IpNumber { get; set; }
        public string IspProvider { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string State { get; set; }
        public string Alias { get; set; }
        public bool IsHidden { get; set; } = false;





    }
}
