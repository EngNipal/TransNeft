namespace TransNeftTest.DTOModels
{
    public class ElectricityMeterDto : DeviceDto
    {
        /// <summary> Тип счётчика </summary>
        public string Type { get; set; }

        // TODO: Возможно добавить конструктор проецирующий entity в Dto
    }
}
