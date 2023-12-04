using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StatusOfHealthService : IStatusOfHealthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StatusOfHealthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddStatusOfHealth(StatusOfHealthDTO statusOfHealthDTO)
        {
            StatusOfHealth statusOfHealth = mapper.Map<StatusOfHealthDTO, StatusOfHealth>(statusOfHealthDTO);
            await unitOfWork.StatusOfHealth.CreateAsync(statusOfHealth);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<IEnumerable<StatusOfHealthDTO>> GetAllStatusOfHealths()
        {
            IEnumerable<StatusOfHealth> statusOfHealths = await unitOfWork.StatusOfHealth.GetAllAsync();
            return mapper.Map<IEnumerable<StatusOfHealth>, IEnumerable<StatusOfHealthDTO>>(statusOfHealths);
        }

        public async Task<StatusOfHealthDTO> GetStatusOfHealthId(int statusOfHealthId)
        {
            StatusOfHealth statusOfHealth = await unitOfWork.StatusOfHealth.GetAsync(statusOfHealthId);
            return mapper.Map<StatusOfHealth, StatusOfHealthDTO>(statusOfHealth);
        }

        public async Task RemoveStatusOfHealth(int statusOfHealthId)
        {
            await unitOfWork.StatusOfHealth.DeleteAsync(statusOfHealthId);
            unitOfWork.Save();
        }

        public async Task UpdateStatusOfHealth(StatusOfHealthDTO statusOfHealthDTO)
        {
            StatusOfHealth statusOfHealth = mapper.Map<StatusOfHealthDTO, StatusOfHealth>(statusOfHealthDTO);
            await unitOfWork.StatusOfHealth.UpdateAsync(statusOfHealth);
            unitOfWork.Save();
        }
    }
}
