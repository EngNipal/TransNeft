using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Models;
using TransNeftTest.ViewModels;

namespace TransNeftTest.Services
{
    public interface IEObjectService : IService<EObjectViewModel>
    {
        public Task UpdateAsync(EObjectDTO eObjectDTO);
    }
}