using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public interface IElectricityMeterRepository : IRepository<ElectricityMeter>
    {
        /// <summary> Метод получения свободных счётчиков электроэнергии. </summary>
        /// <returns> Dto-cписок свободных счётчиков электроэнергии. </returns>
        Task<IEnumerable<ElectricityMeterDto>> GetFreeAsync();

        /// <summary> Метод получения счётчиков электроэнергии с истекшей датой поверки. </summary>
        /// <param name="eObjectId"> Id потребителя. </param>
        /// <returns> Dto-cписок просроченных счётчиков электроэнергии у указанного потребителя. </returns>
        Task<IEnumerable<ElectricityMeterDto>> GetExpiredByEObjectIdAsync(int eObjectId);
    }
}