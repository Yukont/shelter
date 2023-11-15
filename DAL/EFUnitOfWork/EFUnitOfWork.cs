using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;
using shelter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFUnitOfWork
{
    internal class EFUnitOfWork : IUnitOfWork
    {
        private ShelterContext db;
        private AdoptionApplicationRepository adoptionApplicationRepository;
        private AdoptionStatusRepository adoptionStatusRepository;
        private AnimalRepository animalRepository;
        private AnimalStatusRepository animalStatusRepository;
        private AppointmentRepository appointmentRepository;
        private ClinicRepository clinicRepository;
        private DonationRepository donationRepository;
        private EventScheduleRepository eventScheduleRepository;
        private GenderRepository genderRepository;
        private PositionRepository positionRepository;
        private ReviewRepository reviewRepository;
        private ShelterInformationRepository shelterInformationRepository;
        private SpeciallizationRepository speciallizationRepository;
        private SpeciesRepository speciesRepository;
        private StaffRepository staffRepository;
        private StaffRoleRepository staffRoleRepository;
        private StatusOfHealthRepository statusOfHealthRepository;
        private UserRepository userRepository;
        private UserRoleRepository userRoleRepository;
        private UsersGenderRepository usersGenderRepository;
        private VeterinarianRepository veterinarianRepository;

        public EFUnitOfWork(IConfiguration configuration) 
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            db = new ShelterContext(connectionString);
        }

        public IRepository<AdoptionApplicationRepository> AdoptionApplication => throw new NotImplementedException();

        public IRepository<AdoptionStatusRepository> AdoptionStatus => throw new NotImplementedException();

        public IRepository<Animal> Animals
        {
            get
            {
                if (animalRepository == null)
                    animalRepository = new AnimalRepository(db);
                return animalRepository;
            }
        }
        public IRepository<AnimalRepository> Animal => AnimalRepository ??= new AnimalRepository(db);

        public IRepository<AnimalStatusRepository> AnimalStatus => throw new NotImplementedException();

        public IRepository<AppointmentRepository> Appointment => throw new NotImplementedException();

        public IRepository<ClinicRepository> Clinic => throw new NotImplementedException();

        public IRepository<DonationRepository> Donation => throw new NotImplementedException();

        public IRepository<EventScheduleRepository> EventSchedule => throw new NotImplementedException();

        public IRepository<GenderRepository> Gender => throw new NotImplementedException();

        public IRepository<PositionRepository> Position => throw new NotImplementedException();

        public IRepository<ReviewRepository> Review => throw new NotImplementedException();

        public IRepository<ShelterInformationRepository> ShelterInformation => throw new NotImplementedException();

        public IRepository<SpeciallizationRepository> Speciallization => throw new NotImplementedException();

        public IRepository<SpeciesRepository> Species => throw new NotImplementedException();

        public IRepository<StaffRepository> Staff => throw new NotImplementedException();

        public IRepository<StaffRoleRepository> StaffRole => throw new NotImplementedException();

        public IRepository<StatusOfHealthRepository> StatusOfHealth => throw new NotImplementedException();

        public IRepository<UserRepository> User => throw new NotImplementedException();

        public IRepository<UserRoleRepository> UserRole => throw new NotImplementedException();

        public IRepository<UsersGenderRepository> UsersGender => throw new NotImplementedException();

        public IRepository<VeterinarianRepository> Veterinarian => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
