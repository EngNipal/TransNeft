namespace TransNeftTest.Models
{
    /// <summary> Трансформатор тока. </summary>
    public class CurrentTransformer : Device
    {
        /// <summary> Коэффициент трансформации тока </summary>
        public double KTT { get; set; }
    }
}
