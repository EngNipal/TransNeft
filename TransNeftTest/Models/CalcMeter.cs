using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary> Расчётный прибор учёта. </summary>
    public class CalcMeter
    {
        public int Id { get; set; }
        /// <summary> Номер </summary>
        public string Number {  get; set; }
        /// <summary> Дата начала работы. </summary>
        public DateTime StartDate { get; set; }
        /// <summary> Дата окончания работы. </summary>
        public DateTime EndDate { get; set; }
        /// <summary> Id точки поставки электроэнергии. </summary>
        public int DeliveryPointId {  get; set; }
        /// <summary> Точка поставки электроэнергии. </summary>
        public DeliveryPoint DeliveryPoint { get; set; }
        /// <summary> Id точки измерения электроэнергии. </summary>
        public int MeterPointId { get; set; }
        /// <summary> Точка измерения электроэнергии. </summary>
        public MeterPoint MeterPoint { get; set; }
    }
}