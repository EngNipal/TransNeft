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

        public int ElictricityMeterId { get; set; }
        /// <summary> Счётчик электроэнергии. </summary>
        public ElicticityMeter ElicticityMeter { get; set; }

        public int CurrentTransformerId { get; set; }
        /// <summary>Трансформатор тока. </summary>
        public CurrentTransformer CurrentTransformer { get; set; }

        public int VoltageTransformerId { get; set; }
        /// <summary> Трансформатор напряжения </summary>
        public VoltageTransformer VoltageTransformer { get; set; }

        public int ConsumerId { get; set; }
        /// <summary> Объект потребления. </summary>
        public Consumer Consumer { get; set; }

        public int CalcMeterId { get; set; }
        /// <summary> Расчётный прибор учёта. </summary>
        public CalcMeter CalcMeter { get; set; }
    }
}