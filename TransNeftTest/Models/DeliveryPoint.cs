using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary> Точка поставки электроэнергии. </summary>
    public class DeliveryPoint
    {
        public int Id { get; set; }
        /// <summary> Наименование точки поставки </summary>
        public string Name { get; set; }
        /// <summary> Максимальная мощность, кВт </summary>
        public int MaxPower { get; set; }
        /// <summary> Id расчётного прибора учёта </summary>
        public int CalcMeterId { get; set; }
        /// <summary> Расчётный прибор учёта </summary>
        public CalcMeter CalcMeter { get; set; }
        /// <summary> Id потребителя </summary>
        public int EObjectId { get; set; }
        /// <summary> Потребитель </summary>
        public EObject EObject { get; set; }
    }
}