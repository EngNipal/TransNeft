using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    public class CalcMeter
    {
        public int ID { get; set; }
        public List<EloMeter> EloMeters { get; set; }
    }
}
