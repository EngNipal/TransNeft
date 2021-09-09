namespace TransNeftTest.DTOModels
{
    public class EObjectDTO : IdentifiedObjectDTO
    {
        /// <summary> Id организации-владельца </summary>
        public int ParentOrganizationId { get; set; }
    }
}
