using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    /// <summary> Dto-объект точки измерения электроэнергии. </summary>
    public class MeterPointDto
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }
        /// <summary> Наименование </summary>
        public string Name { get; set; }
        /// <summary> Id счётчика электроэнергии. </summary>
        public int ElectricityMeterId { get; set; }
        /// <summary> Id трансформатора тока. </summary>
        public int CurrentTransformerId { get; set; }
        /// <summary> Id трансформатора напряжения </summary>
        public int VoltageTransformerId { get; set; }
        /// <summary> Id объекта потребления. </summary>
        public int EObjectId { get; set; }
        /// <summary> Id расчётного прибора учёта. </summary>
        public int CalcMeterId { get; set; }

        public MeterPointDto() { }

        public MeterPointDto(MeterPoint entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            ElectricityMeterId = entity.ElectricityMeterId;
            CurrentTransformerId = entity.CurrentTransformerId;
            VoltageTransformerId = entity.VoltageTransformerId;
            EObjectId = entity.EObjectId;
            CalcMeterId = entity.CalcMeterId;
        }
    }
}
