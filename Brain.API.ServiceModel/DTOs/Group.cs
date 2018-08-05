using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brain.API.ServiceModel.DTOs
{
    public class Group
    {
        public string Name { get; set; }
        public string Gid { get; set; }
        public List<string> Members { get; set; }
    }
}
