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
        AdoptionApplicationRepository AdoptionApplication { get; }
        AdoptionStatusRepository AdoptionStatus { get; }
        AnimalRepository Animal { get; }
        AnimalStatusRepository AnimalStatus { get; }
        AppointmentRepository Appointment { get; }
        ClinicRepository Clinic { get; }
        DonationRepository Donation { get; }
        EventScheduleRepository EventSchedule{ get; }
        GenderRepository Gender { get; }
        PositionRepository Position { get; }
        ReviewRepository Review { get; }
        ShelterInformationRepository ShelterInformation { get; }
        SpeciallizationRepository Speciallization { get; }
        SpeciesRepository Species { get; }
        StaffRepository Staff { get; }
        StaffRoleRepository StaffRole { get; }
        StatusOfHealthRepository StatusOfHealth { get; }
        UserRepository User { get; }
        UserRoleRepository UserRole { get; }
        UsersGenderRepository UsersGender { get; }
        VeterinarianRepository Veterinarian { get; }
        void Save();
    }
}
