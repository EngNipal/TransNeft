using System;
using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    /// <summary> Dto-объект счётчика электроэнергии. </summary>
    public class ElectricityMeterDto : DeviceDto
    {
        /// <summary> Тип счётчика </summary>
        public string Type { get; set; }

        public ElectricityMeterDto() { }
        public ElectricityMeterDto(int id, string number, DateTime checkDate) : base(id, number, checkDate) { }

        public ElectricityMeterDto(ElectricityMeter entity) : base(entity)
        {
            MeterPointId = entity.MeterPointId;
            Type = entity.Type;
        }
    }
}