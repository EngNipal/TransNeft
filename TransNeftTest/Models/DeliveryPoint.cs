using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary> Точка поставки электроэнергии. </summary>
    public class DeliveryPoint
    {
        public int ID { get; set; }
        /// <summary> Наименование точки поставки </summary>
        public string Name { get; set; }
        /// <summary> Максимальная мощность, кВт </summary>
        public int MaxPower { get; set; }

        public int CalcMeterId { get; set; }
        /// <summary> Расчётный прибор учёта </summary>
        public CalcMeter CalcMeter { get; set; }

        public int ConsumerId { get; set; }
        /// <summary> Организация-владелец </summary>
        public Consumer Consumer { get; set; }
    }
}
