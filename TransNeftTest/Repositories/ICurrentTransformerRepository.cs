using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public interface ICurrentTransformerRepository : IRepository<CurrentTransformer>
    {
        /// <summary> Метод получения свободных трансформаторов тока. </summary>
        /// <returns> Dto-cписок свободных трансформаторов тока. </returns>
        public Task<IEnumerable<CurrentTransformerDto>> GetFreeAsync();

        /// <summary> Метод получения трансформаторов тока с истекшей датой поверки. </summary>
        /// <param name="eObjectId"> Id потребителя. </param>
        /// <returns> Dto-cписок просроченных трансформаторов тока у указанного потребителя. </returns>
        public Task<IEnumerable<CurrentTransformerDto>> GetExpiredByEObjectIdAsync(int eObjectId);
    }
}