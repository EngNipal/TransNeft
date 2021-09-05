using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.ViewModels
{
    public class CalcMeterViewModel
    {
        public int Id { get; set; }
        /// <summary> Номер </summary>
        public string Number { get; set; }
        /// <summary> Дата начала работы. </summary>
        public DateTime StartDate { get; set; }
        /// <summary> Дата окончания работы. </summary>
        public DateTime EndDate { get; set; }
        /// <summary> Id точки поставки электроэнергии. </summary>
        public int DeliveryPointId { get; set; }
        /// <summary> Название точки поставки электроэнергии. </summary>
        public string DeliveryPointName { get; set; }
        /// <summary> Id точки измерения электроэнергии. </summary>
        public int MeterPointId { get; set; }
        /// <summary> Название точки измерения электроэнергии. </summary>
        public string MeterPointName { get; set;}
    }
}
