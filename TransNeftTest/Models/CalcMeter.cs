using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary>
    /// Расчётный прибор учёта.
    /// </summary>
    public class CalcMeter
    {
        public int Id { get; set; }

        public int? DeliveryPointId {  get; set; }
        public DeliveryPoint DeliveryPoint { get; set; }
    }
}