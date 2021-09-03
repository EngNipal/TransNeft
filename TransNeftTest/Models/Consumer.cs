using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary> Объект потребления. </summary>
    public class Consumer : Organization 
    {
        /// <summary> Список точек измерения </summary>
        public List<MeterPoint> MeterPoints { get; set; } = new List<MeterPoint>();
        /// <summary> Список точек доставки </summary>
        public List<DeliveryPoint> DeliveryPoints { get; set; } = new List<DeliveryPoint>();

        public int SubsidiaryId { get; set; }
        /// <summary> Организация-владелец </summary>
        public Subsidiary Subsidiary { get; set; }
    }
}