using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public interface IVoltageTransformerRepository : IRepository<VoltageTransformer>
    {
        /// <summary> Метод получения свободных трансформаторов напряжения. </summary>
        /// <returns> Dto-cписок свободных трансформаторов напряжения. </returns>
        public Task<IEnumerable<VoltageTransformerDto>> GetFreeAsync();

        /// <summary> Метод получения трансформаторов напряжения с истекшей датой поверки. </summary>
        /// <param name="eObjectId"> Id потребителя. </param>
        /// <returns> Dto-cписок просроченных трансформаторов напряжения у указанного потребителя. </returns>
        public Task<IEnumerable<VoltageTransformerDto>> GetExpiredByEObjectIdAsync(int eObjectId);
    }
}