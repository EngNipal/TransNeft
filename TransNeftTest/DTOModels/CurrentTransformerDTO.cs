using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.DTOModels
{
    public class CurrentTransformerDTO : DeviceDTO
    {
        /// <summary> Коэффициент трансформации тока </summary>
        public double KTT { get; set; }
    }
}
