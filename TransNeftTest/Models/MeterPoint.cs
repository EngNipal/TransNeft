using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary> Точка измерения электроэнергии. </summary>
    public class MeterPoint
    {
        public int Id { get; set; }
        /// <summary> Наименование </summary>
        public string Name { get; set; }
        /// <summary> Id счётчика электроэнергии. </summary>
        public int ElectricityMeterId { get; set; }
        /// <summary> Счётчик электроэнергии. </summary>
        public ElectricityMeter ElectricityMeter { get; set; }
        /// <summary> Id трансформатора тока. </summary>
        public int CurrentTransformerId { get; set; }
        /// <summary>Трансформатор тока. </summary>
        public CurrentTransformer CurrentTransformer { get; set; }
        /// <summary> Id трансформатора напряжения </summary>
        public int VoltageTransformerId { get; set; }
        /// <summary> Трансформатор напряжения </summary>
        public VoltageTransformer VoltageTransformer { get; set; }
        /// <summary> Id объекта потребления. </summary>
        public int ConsumerId { get; set; }
        /// <summary> Объект потребления. </summary>
        public Consumer Consumer { get; set; }
        /// <summary> Id расчётного прибора учёта. </summary>
        public int CalcMeterId { get; set; }
        /// <summary> Расчётный прибор учёта. </summary>
        public CalcMeter CalcMeter { get; set; }
    }
}