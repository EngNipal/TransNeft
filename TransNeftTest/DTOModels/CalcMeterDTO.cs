using System;

namespace TransNeftTest.DTOModels
{
    public class CalcMeterDto
    {
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

        public CalcMeterDto(int id, string number)
        {
            Id = id;
            Number = number;
        }

        // TODO: Возможно добавить конструктор проецирующий entity в Dto
    }
}
