using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary>
    /// Точка измерения электроэнергии.
    /// </summary>
    public class MeterPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int? ElictricityMeterId { get; set; }
        public ElicticityMeter ElicticityMeter { get; set; }
        //public int? CurrentTransformerId { get; set; }
        public CurrentTransformer CurrentTransformer { get; set; }
        //public int? VoltageTransformerId { get; set; }
        public VoltageTransformer VoltageTransformer { get; set; }

        public int? ConsumerId { get; set; }
        public Consumer Consumer { get; set; }
    }
}