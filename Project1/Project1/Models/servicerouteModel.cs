using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models
{
    class servicerouteModel
    {
        public int service_route_id { get; set; }
        public string service_route_name { get; set; }

        public int station_id { get; set; }
        public string station_name { get; set; }

        public int station_id2 { get; set; }
        public string station_name2 { get; set; }

        public int line_id { get; set; }
        public string line_name { get; set; }
    }
}
