using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary>
    /// Объект потребления.
    /// </summary>
    public class Consumer : Organization 
    {
        public List<MeterPoint> MeasurePoints { get; set; } = new List<MeterPoint>();
        public List<DeliveryPoint> DeliveryPoints { get; set; } = new List<DeliveryPoint>();

        public int? SubsidiaryId { get; set; }
        public Subsidiary Subsidiary { get; set; }
    }
}