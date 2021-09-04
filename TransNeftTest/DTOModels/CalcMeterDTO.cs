using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    public class CalcMeterDTO
    {
        public int Id { get; set; }
        /// <summary> Дата начала работы. </summary>
        public DateTime StartDate { get; set; }
        /// <summary> Дата окончания работы. </summary>
        public DateTime EndDate { get; set; }
        /// <summary> Id точки поставки электроэнергии. </summary>
        public int DeliveryPointId { get; set; }
        /// <summary> Id точки измерения электроэнергии. </summary>
        public int MeterPointId { get; set; }
    }
}
