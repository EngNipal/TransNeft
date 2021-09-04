﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    public class DeliveryPointDTO
    {
        public int Id { get; set; }
        /// <summary> Наименование точки поставки </summary>
        public string Name { get; set; }
        /// <summary> Максимальная мощность, кВт </summary>
        public int MaxPower { get; set; }
        /// <summary> Id расчётного прибора учёта </summary>
        public int CalcMeterId { get; set; }
        /// <summary> Id организации-владельца </summary>
        public int ConsumerId { get; set; }
    }
}