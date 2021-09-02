using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary>
    /// Дочерняя организация
    /// </summary>
    public class Subsidiary : Organization
    {
        public List<Consumer> Consumers { get; set; } = new List<Consumer>();

        public int? HoldingId {  get; set; }
        public Holding Holding { get; set; }
    }
}