using System;
using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    /// <summary> Dto-объект расчётного прибора учёта.</summary>
    public class CalcMeterDto
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }
        /// <summary> Номер. </summary>
        public string Number { get; set; }
        /// <summary> Дата начала работы. </summary>
        public DateTime StartDate { get; set; }
        /// <summary> Дата окончания работы. </summary>
        public DateTime EndDate { get; set; }
        /// <summary> Id точки поставки электроэнергии. </summary>
        public int DeliveryPointId { get; set; }
        /// <summary> Id точки измерения электроэнергии. </summary>
        public int MeterPointId { get; set; }

        public CalcMeterDto() { }

        public CalcMeterDto(int id, string number, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Number = number;
            StartDate = startDate;
            EndDate = endDate;
        }

        public CalcMeterDto(CalcMeter entity)
        {
            Id = entity.Id;
            Number = entity.Number;
            StartDate = entity.StartDate;
            EndDate = entity.EndDate;
            DeliveryPointId = entity.DeliveryPointId;
            MeterPointId = entity.MeterPointId;
        }
    }
}
