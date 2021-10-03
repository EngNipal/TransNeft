namespace TransNeftTest.DTOModels
{
    public class DeliveryPointDto
    {
        public int Id { get; set; }
        /// <summary> Наименование точки поставки </summary>
        public string Name { get; set; }
        /// <summary> Максимальная мощность, кВт </summary>
        public int MaxPower { get; set; }
        /// <summary> Id расчётного прибора учёта </summary>
        public int CalcMeterId { get; set; }
        /// <summary> Id организации-владельца </summary>
        public int EObjectId { get; set; }

        // TODO: Возможно добавить конструктор проецирующий entity в Dto
    }
}