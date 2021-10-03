namespace TransNeftTest.DTOModels
{
    public class VoltageTransformerDto : DeviceDto
    {
        /// <summary> Коэффициент трансформации напряжения. </summary>
        public double KTH { get; set; }

        // TODO: Возможно добавить конструктор проецирующий entity в Dto
    }
}
