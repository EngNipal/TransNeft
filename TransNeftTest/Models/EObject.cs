using System.Collections.Generic;

namespace TransNeftTest.Models
{
    /// <summary> Потребитель </summary>
    public class EObject : IdentifiedObject
    {
        /// <summary> Список точек измерения </summary>
        public List<MeterPoint> MeterPoints { get; set; } = new List<MeterPoint>();
        /// <summary> Список точек доставки </summary>
        public List<DeliveryPoint> DeliveryPoints { get; set; } = new List<DeliveryPoint>();
        /// <summary> Id организации-владельца </summary>
        public int ParentOrganizationId { get; set; }
        /// <summary> Организация-владелец </summary>
        public Organization ParentOrganization { get; set; }
    }
}