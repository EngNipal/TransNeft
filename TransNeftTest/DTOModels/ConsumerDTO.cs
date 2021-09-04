using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    public class ConsumerDTO : OrganizationDTO
    {
        /// <summary> Id Организации-владельца </summary>
        public int SubsidiaryId { get; set; }
    }
}