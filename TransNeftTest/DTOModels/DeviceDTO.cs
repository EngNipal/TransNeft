using System;

namespace TransNeftTest.DTOModels
{
    public class DeviceDto
    {
        public int Id { get; set; }
        /// <summary> Номер. </summary>
        public string Number { get; set; }
        /// <summary> Дата поверки </summary>
        public DateTime CheckDate { get; set; }
        /// <summary> Id точки измерения электроэнергии </summary>
        public int? MeterPointId { get; set; }

        // TODO: Возможно добавить конструктор проецирующий entity в Dto
    }
}