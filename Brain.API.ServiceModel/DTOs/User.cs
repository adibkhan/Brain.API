using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brain.API.ServiceModel.DTOs
{
    public class User
    {
        public string Name { get; set; }

        public string Uid { get; set; }

        public string Gid { get; set; }

        public string Comment { get; set; }

        public string Home { get; set; }
    }
}
