﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary>
    /// Дочерняя организация
    /// </summary>
    public class Holding : Organization
    {
        public List<Subsidiary> Subsidiaries { get; set; } = new List<Subsidiary>();
    }
}
