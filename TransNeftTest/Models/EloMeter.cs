using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    public class EloMeter
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public EloMeterType Type { get; set; }
        public DateTime CheckDate { get; set; }
    }
}
