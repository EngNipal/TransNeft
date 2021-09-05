using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.ViewModels
{
    public class CurrentTransformerViewModel : DeviceViewModel
    {
        /// <summary> Коэффициент трансформации тока </summary>
        public double KTT { get; set; }
    }
}