using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    /// <summary> Dto-объект точки поставки электроэнергии. </summary>
    public class DeliveryPointDto
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }
        /// <summary> Наименование точки поставки </summary>
        public string Name { get; set; }
        /// <summary> Максимальная мощность, кВт </summary>
        public int MaxPower { get; set; }
        /// <summary> Id организации-владельца </summary>
        public int EObjectId { get; set; }

        public DeliveryPointDto() { }

        public DeliveryPointDto(DeliveryPoint entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            MaxPower = entity.MaxPower;
            EObjectId = entity.EObjectId;
        }
    }
}