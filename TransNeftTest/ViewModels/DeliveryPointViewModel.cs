namespace TransNeftTest.ViewModels
{
    public class DeliveryPointViewModel
    {
        public int Id { get; set; }
        /// <summary> Наименование точки поставки </summary>
        public string Name { get; set; }
        /// <summary> Максимальная мощность, кВт </summary>
        public int MaxPower { get; set; }
        /// <summary> Id расчётного прибора учёта </summary>
        public int CalcMeterId { get; set; }
        /// <summary> Номер расчётного прибора учёта </summary>
        public string CalcMeterNumber { get; set; }
        /// <summary> Id организации-владельца </summary>
        public int ConsumerId { get; set; }
        /// <summary> Название организации-владельца </summary>
        public string ConsumerName { get; set; }
    }
}
