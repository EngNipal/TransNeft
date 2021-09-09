using System.Collections.Generic;

namespace TransNeftTest.Models
{
    /// <summary> Организация </summary>
    public class Organization : IdentifiedObject
    {
        /// <summary> Дочерние организации </summary>
        public List<Organization> ChildrenOrganizations {  get; set; }
        /// <summary> Потребители </summary>
        public List<EObject> EObjects {  get; set; }
        /// <summary> Id организации-владельца </summary>
        public int? ParentOrganizationId { get; set; }
        /// <summary> Организация-владелец </summary>
        public Organization ParentOrganization { get; set; }
    }
}