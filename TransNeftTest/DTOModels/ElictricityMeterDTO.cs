using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.DTOModels
{
    public class ElictricityMeterDTO : DeviceDTO
    {
        /// <summary> Тип счётчика </summary>
        public string Type { get; set; }
    }
}
