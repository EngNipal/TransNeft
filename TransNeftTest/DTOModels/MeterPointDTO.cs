namespace TransNeftTest.DTOModels
{
    public class MeterPointDTO
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }
        /// <summary> Наименование </summary>
        public string Name { get; set; }
        /// <summary> Id счётчика электроэнергии. </summary>
        public int ElictricityMeterId { get; set; }
        /// <summary> Id трансформатора тока. </summary>
        public int CurrentTransformerId { get; set; }
        /// <summary> Id трансформатора напряжения </summary>
        public int VoltageTransformerId { get; set; }
        /// <summary> Id объекта потребления. </summary>
        public int EObjectId { get; set; }
        /// <summary> Id расчётного прибора учёта. </summary>
        public int CalcMeterId { get; set; }
    }
}
