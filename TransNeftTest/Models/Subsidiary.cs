using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary> Дочерняя организация </summary>
    public class Subsidiary : Organization
    {
        /// <summary> Список потребителей </summary>
        public List<Consumer> Consumers { get; set; } = new List<Consumer>();
        /// <summary> Id головной организации </summary>
        public int HoldingId { get; set; }
        /// <summary> Головная организация </summary>
        public Holding Holding { get; set; }
    }
}