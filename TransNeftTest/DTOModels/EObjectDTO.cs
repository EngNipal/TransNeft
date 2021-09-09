using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.DTOModels
{
    public class EObjectDTO : IdentifiedObjectDTO
    {
        /// <summary> Id организации-владельца </summary>
        public int ParentOrganizationId { get; set; }
    }
}
