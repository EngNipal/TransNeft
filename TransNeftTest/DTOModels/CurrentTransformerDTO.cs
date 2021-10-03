using System;
using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    /// <summary> Dto-объект трансформатора тока. </summary>
    public class CurrentTransformerDto : DeviceDto
    {
        /// <summary> Коэффициент трансформации тока </summary>
        public double KTT { get; set; }

        public CurrentTransformerDto() { }
        public CurrentTransformerDto(int id, string number, DateTime checkDate) : base(id, number, checkDate) { }

        public CurrentTransformerDto(CurrentTransformer entity) : base(entity)
        {
            MeterPointId = entity.MeterPointId;
            KTT = entity.KTT;
        }
    }
}