﻿using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.Configuration;

namespace DAL.EFUnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
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
        private AuthRepository authRepository;
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

        public AdoptionApplicationRepository AdoptionApplication => adoptionApplicationRepository ??= new AdoptionApplicationRepository(db);

        public AdoptionStatusRepository AdoptionStatus => adoptionStatusRepository ??= new AdoptionStatusRepository(db);

        public AnimalRepository Animal => animalRepository ??= new AnimalRepository(db);

        public AnimalStatusRepository AnimalStatus => animalStatusRepository ??= new AnimalStatusRepository(db);

        public AppointmentRepository Appointment => appointmentRepository ??= new AppointmentRepository(db);

        public ClinicRepository Clinic => clinicRepository ??= new ClinicRepository(db);

        public DonationRepository Donation => donationRepository ??= new DonationRepository(db);

        public EventScheduleRepository EventSchedule => eventScheduleRepository ??= new EventScheduleRepository(db);

        public GenderRepository Gender => genderRepository ??= new GenderRepository(db);

        public PositionRepository Position => positionRepository ??= new PositionRepository(db);

        public ReviewRepository Review => reviewRepository ??= new ReviewRepository(db);

        public ShelterInformationRepository ShelterInformation => shelterInformationRepository ??= new ShelterInformationRepository(db);

        public SpeciallizationRepository Speciallization => speciallizationRepository ??= new SpeciallizationRepository(db);

        public SpeciesRepository Species => speciesRepository ??= new SpeciesRepository(db);

        public StaffRepository Staff => staffRepository ??= new StaffRepository(db);

        public AuthRepository Auth => authRepository ??= new AuthRepository(db);

        public StatusOfHealthRepository StatusOfHealth => statusOfHealthRepository ??= new StatusOfHealthRepository(db);

        public UserRepository User => userRepository ??= new UserRepository(db);

        public UserRoleRepository UserRole => userRoleRepository ??= new UserRoleRepository(db);

        public UsersGenderRepository UsersGender => usersGenderRepository ??= new UsersGenderRepository(db);

        public VeterinarianRepository Veterinarian => veterinarianRepository ??= new VeterinarianRepository(db);

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
