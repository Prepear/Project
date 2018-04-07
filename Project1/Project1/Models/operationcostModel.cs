using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models
{
  public  class operationcostModel
    {
        public int operation_cost_id { get; set; }
        public int train_set_model_id { get; set; }
        public string train_set_model_name { get; set; }

        public int station_id { get; set; }
        public string station_name { get; set; }

        public int station_id2 { get; set; }
        public string station_name2 { get; set; }
    }
}
