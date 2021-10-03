namespace TransNeftTest.DTOModels
{
    public class EObjectDto : IdentifiedObjectDto
    {
        /// <summary> Id организации-владельца </summary>
        public int ParentOrganizationId { get; set; }

        // TODO: Возможно добавить конструктор проецирующий entity в Dto
    }
}
