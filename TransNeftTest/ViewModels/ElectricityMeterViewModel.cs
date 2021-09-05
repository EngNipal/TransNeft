using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.ViewModels
{
    public class ElectricityMeterViewModel : DeviceViewModel
    {
        /// <summary> Тип счётчика </summary>
        public string Type { get; set; }
    }
}
