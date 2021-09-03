using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary>
    /// Счётчик электроэнергии.
    /// </summary>
    public class ElicticityMeter
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public EloMeterType Type { get; set; }
        public DateTime CheckDate { get; set; }

        public int? MeasurePointId { get; set; }
        public MeterPoint MeasurePoint { get; set; }
    }
}