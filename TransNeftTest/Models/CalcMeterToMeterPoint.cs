using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransNeftTest.Models
{
    /// <summary>
    /// Класс, связывающий 
    /// </summary>
    public class CalcMeterToMeterPoint
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? CalcMeterId { get; set; }
        [ForeignKey("CalcMeterId")]
        public CalcMeter CalcMeter {  get; set; }
        
        public int? MeterPointId { get; set; }
        [ForeignKey("MeterPointId")]
        public MeterPoint MeterPoint { get; set; }
        
    }
}