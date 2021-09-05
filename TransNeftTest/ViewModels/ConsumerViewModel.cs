using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.ViewModels
{
    public class ConsumerViewModel : OrganizationViewModel
    {
        /// <summary> Id организации-владельца </summary>
        public int SubsidiaryId { get; set; }
        /// <summary> Название организации-владельца </summary>
        public string SubsidiaryName { get; set; }
    }
}