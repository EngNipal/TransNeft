using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.DTOModels
{
    public class VoltageTransformerDTO : DeviceDTO
    {
        /// <summary> Коэффициент трансформации напряжения. </summary>
        public double KTH { get; set; }
    }
}
