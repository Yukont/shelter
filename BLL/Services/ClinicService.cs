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
    public class ClinicService : IClinicService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ClinicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddClinic(ClinicDTO clinicDTO)
        {
            Clinic clinic = mapper.Map<ClinicDTO, Clinic>(clinicDTO);
            await unitOfWork.Clinic.CreateAsync(clinic);
            unitOfWork.Save();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public async Task<IEnumerable<ClinicDTO>> GetAllClinics()
        {
            IEnumerable<Clinic> clinics = await unitOfWork.Clinic.GetAllAsync();
            return mapper.Map<IEnumerable<Clinic>, IEnumerable<ClinicDTO>>(clinics);
        }

        public async Task<ClinicDTO> GetClinicId(int clinicId)
        {
            Clinic clinic = await unitOfWork.Clinic.GetAsync(clinicId);
            return mapper.Map<Clinic, ClinicDTO>(clinic);
        }

        public async Task RemoveClinic(int clinicId)
        {
            await unitOfWork.Clinic.DeleteAsync(clinicId);
            unitOfWork.Save();
        }

        public async Task UpdateClinic(ClinicDTO clinicDTO)
        {
            Clinic clinic = mapper.Map<ClinicDTO, Clinic>(clinicDTO);
            await unitOfWork.Clinic.UpdateAsync(clinic);
            unitOfWork.Save();
        }
    }
}
