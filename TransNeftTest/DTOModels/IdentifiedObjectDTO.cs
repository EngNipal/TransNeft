namespace TransNeftTest.DTOModels
{
    public class IdentifiedObjectDto
    {
        public int Id { get; set; }
        /// <summary> Название </summary>
        public string Name { get; set; }
        /// <summary> Адрес </summary>
        public string Address { get; set; }

        // TODO: Возможно добавить конструктор проецирующий entity в Dto
    }
}
