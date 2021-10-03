using System;

namespace TransNeftTest.Models
{
    /// <summary> Прибор. </summary>
    public class Device
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }
        /// <summary> Номер. </summary>
        public string Number { get; set; }
        /// <summary> Дата поверки </summary>
        public DateTime CheckDate { get; set; }
    }
}