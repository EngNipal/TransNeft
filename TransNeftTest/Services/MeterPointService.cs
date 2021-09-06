using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;
using TransNeftTest.Repositories;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public class MeterPointService : IMeterPointService
    {
        private IRepository<MeterPoint> _meterPointRepo;
        private IMapper _mapper;
        private const string _messageMeterPointWrongId = "Получен несуществующий Id точки измерения.";

        public MeterPointService(IRepository<MeterPoint> meterPointRepo, IMapper mapper)
        {
            _meterPointRepo = meterPointRepo;
            _mapper = mapper;
        }

        

        public async Task<MeterPointViewModel> GetAsync(int meterPointId)
{
            MeterPoint meterPointDb = await _meterPointRepo.GetAsync(meterPointId);
            if (meterPointDb == null)
            {
                throw new Exception(_messageMeterPointWrongId);
            }

            return _mapper.Map<MeterPoint, MeterPointViewModel>(meterPointDb);
        }

        public async Task<IList<MeterPointViewModel>> GetListAsync()
        {
            IList<MeterPoint> meterPointList = await _meterPointRepo.GetListAsync();

            return _mapper.Map<IList<MeterPoint>, IList<MeterPointViewModel>>(meterPointList);
        }

        public async Task SaveAsync() => await _meterPointRepo.SaveAsync();

        public async Task UpdateAsync(MeterPointDTO meterPointDTO)
        {
            try
            {
                await _meterPointRepo.UpdateAsync(_mapper.Map<MeterPointDTO, MeterPoint>(meterPointDTO));
            }
            catch
            {
                throw;
            }
        }
    }
}
