using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    public class DeliveryPoint
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public CalcMeter CalcMeter { get; set; }
    }
}
