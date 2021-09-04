using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.DTOModels
{
    public class SubsidiaryDTO : OrganizationDTO
    {
        /// <summary> Id головной организации </summary>
        public int HoldingId { get; set; }
    }
}
