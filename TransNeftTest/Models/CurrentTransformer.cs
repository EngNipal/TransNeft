namespace TransNeftTest.Models
{
    /// <summary> Трансформатор тока. </summary>
    public class CurrentTransformer : Device
    {
        /// <summary> Id точки измерения электроэнергии </summary>
        public int? MeterPointId { get; set; }
        /// <summary> Точка измерения электроэнергии </summary>
        public MeterPoint MeterPoint { get; set; }
        /// <summary> Коэффициент трансформации тока </summary>
        public double KTT { get; set; }
    }
}
