using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    public class OrganizationDto : IdentifiedObjectDto
    {
        /// <summary> Id организации-владельца </summary>
        public int? ParentOrganizationId { get; set; }

        public OrganizationDto() { }
        public OrganizationDto(Organization entity) : base(entity)
        {
            ParentOrganizationId = entity.ParentOrganizationId;
        }
    }
}