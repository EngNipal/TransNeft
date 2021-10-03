using System;
using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    /// <summary> Dto-объект прибора. </summary>
    public class DeviceDto
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }
        /// <summary> Номер. </summary>
        public string Number { get; set; }
        /// <summary> Дата поверки </summary>
        public DateTime CheckDate { get; set; }
        /// <summary> Id точки измерения электроэнергии </summary>
        public int? MeterPointId { get; set; }

        public DeviceDto() { }
        public DeviceDto(int id, string number, DateTime checkDate)
        {
            Id = id;
            Number = number;
            CheckDate = checkDate;
        }

        public DeviceDto(Device entity)
        {
            Id = entity.Id;
            Number = entity.Number;
            CheckDate = entity.CheckDate;
        }
    }
}