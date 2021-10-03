using System.Threading.Tasks;

namespace TransNeftTest.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary> Метод добавления сущности. </summary>
        /// <param name="entity"> Объект сущности. </param>
        Task AddAsync(T entity);

        /// <summary> Метод проверки наличия сущности по Id. </summary>
        /// <param name="id"> Id сущности. </param>
        /// /// <returns><see langword = "true"/> - если сущность найдена.
        /// <see langword = "false"/> - если сущность не найдена. </returns>
        Task<bool> Exist(int id);

        /// <summary> Метод получения сущности по Id. </summary>
        /// <param name="id"> Id сущности. </param>
        /// <returns> Объект сущности. </returns>
        Task<T> GetAsync(int id);
    }
}