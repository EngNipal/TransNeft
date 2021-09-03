using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary>
    /// Счётчик электроэнергии.
    /// </summary>
    public class ElicticityMeter : Device
    {
        /// <summary> Тип счётчика </summary>
        public string Type { get; set; }
    }
}