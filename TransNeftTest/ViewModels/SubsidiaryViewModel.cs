using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.ViewModels
{
    public class SubsidiaryViewModel : OrganizationViewModel
    {
        /// <summary> Id головной организации </summary>
        public int HoldingId { get; set; }
        /// <summary> Головная организация </summary>
        public string HoldingName { get; set; }
    }
}