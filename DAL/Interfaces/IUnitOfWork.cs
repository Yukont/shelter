using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    internal interface IUnitOfWork : IDisposable
    {
        IRepository<AdoptionApplicationRepository> AdoptionApplication { get; }
        IRepository<AdoptionStatusRepository> AdoptionStatus { get; }
        IRepository<AnimalRepository> Animal { get; }
        IRepository<AnimalStatusRepository> AnimalStatus { get; }
        IRepository<AppointmentRepository> Appointment { get; }
        IRepository<ClinicRepository> Clinic { get; }
        IRepository<DonationRepository> Donation { get; }
        IRepository<EventScheduleRepository> EventSchedule{ get; }
        IRepository<GenderRepository> Gender { get; }
        IRepository<PositionRepository> Position { get; }
        IRepository<ReviewRepository> Review { get; }
        IRepository<ShelterInformationRepository> ShelterInformation { get; }
        IRepository<SpeciallizationRepository> Speciallization { get; }
        IRepository<SpeciesRepository> Species { get; }
        IRepository<StaffRepository> Staff { get; }
        IRepository<StaffRoleRepository> StaffRole { get; }
        IRepository<StatusOfHealthRepository> StatusOfHealth { get; }
        IRepository<UserRepository> User { get; }
        IRepository<UserRoleRepository> UserRole { get; }
        IRepository<UsersGenderRepository> UsersGender { get; }
        IRepository<VeterinarianRepository> Veterinarian { get; }
        void Save();
    }
}
