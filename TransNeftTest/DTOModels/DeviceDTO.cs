using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.DTOModels
{
    public class DeviceDTO
    {
        public int Id { get; set; }
        /// <summary> Номер. </summary>
        public string Number { get; set; }
        /// <summary> Дата поверки </summary>
        public DateTime CheckDate { get; set; }
        /// <summary> Id точки измерения электроэнергии </summary>
        public int MeterPointId { get; set; }
    }
}