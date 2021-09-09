using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary> Конкретизированный объект </summary>
    public class IdentifiedObject
    {
        public int Id { get; set; }
        /// <summary> Название </summary>
        public string Name { get; set; }
        /// <summary> Адрес </summary>
        public string Address { get; set; }
    }
}