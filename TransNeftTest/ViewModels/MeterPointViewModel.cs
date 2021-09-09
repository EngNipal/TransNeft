using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.ViewModels
{
    public class MeterPointViewModel
    {
        public int Id { get; set; }
        /// <summary> Наименование </summary>
        public string Name { get; set; }
        /// <summary> Id счётчика электроэнергии. </summary>
        public int ElictricityMeterId { get; set; }
        /// <summary> Номер счётчика электроэнергии. </summary>
        public string ElicticityMeterNumber { get; set; }
        /// <summary> Id трансформатора тока. </summary>
        public int CurrentTransformerId { get; set; }
        /// <summary> Номер трансформатора тока. </summary>
        public string CurrentTransformerNumber { get; set; }
        /// <summary> Id трансформатора напряжения </summary>
        public int VoltageTransformerId { get; set; }
        /// <summary> Номер трансформатора напряжения </summary>
        public string VoltageTransformerNumber { get; set; }
        /// <summary> Id объекта потребления. </summary>
        public int EObjectId { get; set; }
        /// <summary> Название объекта потребления. </summary>
        public string EObjectName { get; set; }
        /// <summary> Id расчётного прибора учёта. </summary>
        public int CalcMeterId { get; set; }
        /// <summary> Номер расчётного прибор учёта. </summary>
        public string CalcMeterNumber { get; set; }
    }
}
