using System;
using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    /// <summary> Dto-объект трансформатора напряжения </summary>
    public class VoltageTransformerDto : DeviceDto
    {
        /// <summary> Коэффициент трансформации напряжения. </summary>
        public double KTH { get; set; }


        public VoltageTransformerDto() { }
        public VoltageTransformerDto(int id, string number, DateTime checkDate) : base(id, number, checkDate) { }

        public VoltageTransformerDto(VoltageTransformer entity) : base(entity)
        {
            MeterPointId = entity.MeterPointId;
            KTH = entity.KTH;
        }
    }
}
