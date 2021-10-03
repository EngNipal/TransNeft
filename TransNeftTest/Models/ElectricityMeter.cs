namespace TransNeftTest.Models
{
    /// <summary> Счётчик электроэнергии. </summary>
    public class ElectricityMeter : Device
    {
        /// <summary> Id точки измерения электроэнергии </summary>
        public int? MeterPointId { get; set; }
        /// <summary> Точка измерения электроэнергии </summary>
        public MeterPoint MeterPoint { get; set; }
        /// <summary> Тип счётчика </summary>
        public string Type { get; set; }
    }
}