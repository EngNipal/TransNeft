using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    public class MeasuringPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EloMeter EloMeter { get; set; }
        public Transformer CurrentTransformer { get; set; }
        public Transformer VoltageTransformer { get; set; }
    }
}
