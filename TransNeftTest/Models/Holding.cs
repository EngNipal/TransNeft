using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary> Головная организация </summary>
    public class Holding : Organization
    {
        /// <summary> Список дочерних организаций </summary>
        public List<Subsidiary> Subsidiaries { get; set; } = new List<Subsidiary>();
    }
}
