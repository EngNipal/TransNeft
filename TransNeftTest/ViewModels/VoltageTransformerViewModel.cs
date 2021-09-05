using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.ViewModels
{
    public class VoltageTransformerViewModel : DeviceViewModel
    {
        /// <summary> Коэффициент трансформации напряжения. </summary>
        public double KTH { get; set; }
    }
}
