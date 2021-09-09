namespace TransNeftTest.ViewModels
{
    public class EObjectViewModel : IdentifiedObjectViewModel
    {
        /// <summary> Id организации-владельца </summary>
        public int ParentOrganizationId { get; set; }
        /// <summary> Название организации-владельца </summary>
        public string ParentOrganizationName { get; set; }
    }
}
