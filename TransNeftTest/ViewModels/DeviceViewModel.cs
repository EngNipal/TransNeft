using System;

namespace TransNeftTest.ViewModels
{
    public class DeviceViewModel
    {
        public int Id { get; set; }
        /// <summary> Номер. </summary>
        public string Number { get; set; }
        /// <summary> Дата поверки </summary>
        public DateTime CheckDate { get; set; }
        /// <summary> Id точки измерения электроэнергии </summary>
        public int MeterPointId { get; set; }
        /// <summary> Точка измерения электроэнергии </summary>
        public string MeterPointName { get; set; }
    }
}
