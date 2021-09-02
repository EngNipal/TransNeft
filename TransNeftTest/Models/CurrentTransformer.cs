using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary>
    /// Трансформатор тока.
    /// </summary>
    public class CurrentTransformer : Transformer
    {
        public double KTT { get; set; }
    }
}
