namespace TransNeftTest.Models
{
    /// <summary> Трансформатор напряжения </summary>
    public class VoltageTransformer : Device
    {
        /// <summary> Id точки измерения электроэнергии </summary>
        public int? MeterPointId { get; set; }
        /// <summary> Точка измерения электроэнергии </summary>
        public MeterPoint MeterPoint { get; set; }
        /// <summary> Коэффициент трансформации напряжения. </summary>
        public double KTH { get; set; }
    }
}
