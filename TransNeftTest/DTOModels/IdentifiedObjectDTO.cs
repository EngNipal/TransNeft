using TransNeftTest.Models;

namespace TransNeftTest.DTOModels
{
    /// <summary> Dto-объект конкретизированного объекта.</summary>
    public class IdentifiedObjectDto
    {
        /// <summary> Идентификатор </summary>
        public int Id { get; set; }
        /// <summary> Название </summary>
        public string Name { get; set; }
        /// <summary> Адрес </summary>
        public string Address { get; set; }

        public IdentifiedObjectDto() { }

        public IdentifiedObjectDto(IdentifiedObject entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Address = entity.Address;
        }
    }
}
