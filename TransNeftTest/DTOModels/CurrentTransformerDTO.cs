namespace TransNeftTest.DTOModels
{
    public class CurrentTransformerDto : DeviceDto
    {
        /// <summary> Коэффициент трансформации тока </summary>
        public double KTT { get; set; }

        // TODO: Возможно добавить конструктор проецирующий entity в Dto
    }
}
