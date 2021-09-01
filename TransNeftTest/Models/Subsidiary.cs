using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    public class Subsidiary : Organization
    {
        public List<EloMeter> EloMeters { get; set; }
        public List<DeliveryPoint> DeliveryPoints { get; set; }
    }
}
