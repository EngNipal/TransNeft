namespace TransNeftTest.DTOModels
{
    public class OrganizationDTO : IdentifiedObjectDTO
    {
        /// <summary> Id организации-владельца </summary>
        public int? ParentOrganizationID { get; set; }
    }
}