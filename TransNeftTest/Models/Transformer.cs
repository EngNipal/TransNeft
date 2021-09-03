using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary>
    /// Трансформатор.
    /// </summary>
    public class Transformer
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime CheckDate { get; set; }

        public int? MeterPointId {  get; set; }
        public MeterPoint MeterPoint {  get; set; }
    }
}