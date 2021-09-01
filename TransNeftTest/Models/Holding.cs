using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    public class Holding : Organization
    {
        public List<Subsidiary> Subsidiaries { get; set; }
    }
}
