namespace TransNeftTest.DTOModels
{
    public class OrganizationDto : IdentifiedObjectDto
    {
        /// <summary> Id организации-владельца </summary>
        public int? ParentOrganizationID { get; set; }

        // TODO: Возможно добавить конструктор проецирующий entity в Dto
    }
}