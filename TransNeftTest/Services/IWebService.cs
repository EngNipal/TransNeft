using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;

namespace TransNeftTest.Services
{
    public interface IWebService
    {
        /// <summary> Метод получения свободных счётчиков электроэнергии. </summary>
        /// <returns> Dto-cписок свободных счётчиков электроэнергии. </returns>
        public Task<IEnumerable<ElectricityMeterDto>> GetFreeElectricityMeters();

        /// <summary> Метод получения свободных трансформаторов тока. </summary>
        /// <returns> Dto-cписок свободных трансформаторов тока. </returns>
        public Task<IEnumerable<CurrentTransformerDto>> GetFreeCurrentTransformers();

        /// <summary> Метод получения свободных трансформаторов напряжения. </summary>
        /// <returns> Dto-cписок свободных трансформаторов напряжения. </returns>
        public Task<IEnumerable<VoltageTransformerDto>> GetFreeVoltageTransformers();

        /// <summary> Создание новой точки измерения. </summary>
        /// <param name="meterPointDto"> Dto-объект точки измерения. </param>
        public Task CreateMeterPoint(MeterPointDto meterPointDto);

        /// <summary> Метод получения расчётных приборов учёта по году. </summary>
        /// <param name="year"> Год. </param>
        /// <returns> Dto-список расчётных приборов учёта. </returns>
        public Task<IEnumerable<CalcMeterDto>> GetCalcMetersByYear(int year);

        /// <summary> Метод проверки существования потребителя. </summary>
        /// <param name="eObjectId"> Id потребителя. </param>
        /// <returns><see langword = "true"/> - если потребитель найден
        /// <see langword = "false"/> - если потребитель не найден </returns>
        public Task<bool> EObjectExists(int eObjectId);

        /// <summary> Метод получения счётчиков электроэнергии с истекшей датой поверки. </summary>
        /// <param name="eObjectId"> Id потребителя. </param>
        /// <returns> Список просроченных счётчиков электроэнергии у указанного потребителя. </returns>
        public Task<IEnumerable<ElectricityMeterDto>> GetElectricityMeterExpiredByEObject(int eObjectId);

        /// <summary> Метод получения трансформаторов тока с истекшей датой поверки. </summary>
        /// <param name="eObjectId"> Id потребителя. </param>
        /// <returns> Список просроченных трансформаторов тока у указанного потребителя. </returns>
        public Task<IEnumerable<CurrentTransformerDto>> GetCurrentTransformerExpiredByEObject(int eObjectId);

        /// <summary> Метод получения трансформаторов напряжения с истекшей датой поверки. </summary>
        /// <param name="eObjectId"> Id потребителя. </param>
        /// <returns> Список просроченных трансформаторов напряжения у указанного потребителя. </returns>
        public Task<IEnumerable<VoltageTransformerDto>> GetVoltageTransformerExpiredByEObject(int eObjectId);
    }
}