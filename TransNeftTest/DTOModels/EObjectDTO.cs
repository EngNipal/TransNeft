using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    /// <summary> Dto-объект потребителя.</summary>
    public class EObjectDto : IdentifiedObjectDto
    {
        /// <summary> Id организации-владельца </summary>
        public int ParentOrganizationId { get; set; }

        public EObjectDto() : base() { }
        public EObjectDto(EObject entity) : base(entity)
        {
            ParentOrganizationId = entity.ParentOrganizationId;
        }
    }
}
