using System.Collections.Generic;

namespace TransNeftTest.Models
{
    /// <summary> Точка поставки электроэнергии. </summary>
    public class DeliveryPoint
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }
        /// <summary> Наименование точки поставки </summary>
        public string Name { get; set; }
        /// <summary> Максимальная мощность, кВт </summary>
        public int MaxPower { get; set; }
        /// <summary> Расчётные приборы учёта </summary>
        public List<CalcMeter> CalcMeters { get; set; }
        /// <summary> Id потребителя </summary>
        public int EObjectId { get; set; }
        /// <summary> Потребитель </summary>
        public EObject EObject { get; set; }

        public DeliveryPoint() { }
    }
}