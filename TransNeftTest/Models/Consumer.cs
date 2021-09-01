using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    public class Consumer : Organization
    {
        public List<MeasuringPoint> MeasurePoints { get; set; }
    }
}
