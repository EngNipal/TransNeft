using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary>
    /// Точка поставки электроэнергии.
    /// </summary>
    public class DeliveryPoint
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxPower { get; set; }
        public CalcMeter CalcMeter { get; set; }

        public int? ConsumerId { get; set; }
        public Consumer Consumer { get; set; }
    }
}
