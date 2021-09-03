using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary> Трансформатор напряжения </summary>
    public class VoltageTransformer : Device
    {
        /// <summary> Коэффициент трансформации напряжения. </summary>
        public double KTH { get; set; }
    }
}
