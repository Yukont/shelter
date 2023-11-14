using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using shelter;

namespace DAL.EF;

public partial class ShelterContext : DbContext
{
    public ShelterContext()
    {
    }

    public ShelterContext(DbContextOptions<ShelterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdoptionApplication> AdoptionApplications { get; set; }

    public virtual DbSet<AdoptionStatus> AdoptionStatuses { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AnimalStatus> AnimalStatuses { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<EventSchedule> EventSchedules { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ShelterInformation> ShelterInformations { get; set; }

    public virtual DbSet<Speciallization> Speciallizations { get; set; }

    public virtual DbSet<Species> Species { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffRole> StaffRoles { get; set; }

    public virtual DbSet<StatusOfHealth> StatusOfHealths { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UsersGender> UsersGenders { get; set; }

    public virtual DbSet<Veterinarian> Veterinarians { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=shelter;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdoptionApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__adoption__3214EC070B3C7C38");

            entity.ToTable("adoptionApplications");

            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdAnimalNavigation).WithMany(p => p.AdoptionApplications)
                .HasForeignKey(d => d.IdAnimal)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__adoptionA__IdAni__01142BA1");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.AdoptionApplications)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__adoptionA__IdSta__02084FDA");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.AdoptionApplications)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__adoptionA__idUse__00200768");
        });

        modelBuilder.Entity<AdoptionStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__adoption__3214EC0716BA3FD8");

            entity.ToTable("adoptionStatus");

            entity.HasIndex(e => e.Name, "UQ__adoption__737584F61DBC631C").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__animal__3214EC07D2C54815");

            entity.ToTable("animal", tb => tb.HasTrigger("CheckShelterCapacity"));

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.DateOf)
                .HasMaxLength(50)
                .HasColumnName("dateOf");
            entity.Property(e => e.DescriptionOfAnimal)
                .HasMaxLength(50)
                .HasColumnName("descriptionOfAnimal");
            entity.Property(e => e.IdAnimalStatus).HasColumnName("idAnimalStatus");
            entity.Property(e => e.IdGender).HasColumnName("idGender");
            entity.Property(e => e.IdSpecies).HasColumnName("idSpecies");
            entity.Property(e => e.IdStatusOfHealth).HasColumnName("idStatusOfHealth");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Photo)
                .HasMaxLength(50)
                .HasColumnName("photo");

            entity.HasOne(d => d.IdAnimalStatusNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => d.IdAnimalStatus)
                .HasConstraintName("FK__animal__idAnimal__571DF1D5");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("FK__animal__idGender__5629CD9C");

            entity.HasOne(d => d.IdSpeciesNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => d.IdSpecies)
                .HasConstraintName("FK__animal__idSpecie__5535A963");

            entity.HasOne(d => d.IdStatusOfHealthNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => d.IdStatusOfHealth)
                .HasConstraintName("FK__animal__idStatus__5812160E");
        });

        modelBuilder.Entity<AnimalStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__animalSt__3214EC07783F7317");

            entity.ToTable("animalStatus");

            entity.HasIndex(e => e.Name, "UQ__animalSt__737584F60F0695F3").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__appointm__3214EC07F65BDD06");

            entity.ToTable("appointment", tb => tb.HasTrigger("UpdateHealthStatus"));

            entity.Property(e => e.DateOf)
                .HasColumnType("date")
                .HasColumnName("dateOf");
            entity.Property(e => e.Descriptions).HasMaxLength(50);
            entity.Property(e => e.Illnesses).HasMaxLength(50);
            entity.Property(e => e.Prescriptions).HasMaxLength(50);

            entity.HasOne(d => d.IdAnimalNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.IdAnimal)
                .HasConstraintName("FK__appointme__IdAni__47A6A41B");

            entity.HasOne(d => d.IdVeterinarianNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.IdVeterinarian)
                .HasConstraintName("FK__appointme__IdVet__46B27FE2");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clinic__3214EC07DF105D32");

            entity.ToTable("clinic");

            entity.HasIndex(e => e.Name, "UQ__clinic__737584F6E6FC3D2A").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__donation__3214EC079464F1B6");

            entity.ToTable("donations");

            entity.Property(e => e.DateOf)
                .HasColumnType("date")
                .HasColumnName("dateOf");
            entity.Property(e => e.Donation1).HasColumnName("donation");
            entity.Property(e => e.IdUser).HasColumnName("idUser");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Donations)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__donations__idUse__778AC167");
        });

        modelBuilder.Entity<EventSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__eventSch__3214EC075FEF8F5F");

            entity.ToTable("eventSchedule");

            entity.Property(e => e.DateOf)
                .HasColumnType("date")
                .HasColumnName("dateOf");
            entity.Property(e => e.Descriptions)
                .HasMaxLength(50)
                .HasColumnName("descriptions");
            entity.Property(e => e.LocationOfEvent)
                .HasMaxLength(50)
                .HasColumnName("locationOfEvent");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.TimeOf).HasColumnName("timeOf");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__gender__3214EC07B51BCDC4");

            entity.ToTable("gender");

            entity.HasIndex(e => e.Name, "UQ__gender__737584F6000B79F8").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__position__3214EC079FF49CF0");

            entity.ToTable("position");

            entity.HasIndex(e => e.Name, "UQ__position__737584F6AE4C37F4").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__review__3214EC07C352584F");

            entity.ToTable("review");

            entity.Property(e => e.DateOf)
                .HasColumnType("date")
                .HasColumnName("dateOf");
            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Review1).HasColumnName("review");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__review__idUser__7A672E12");
        });

        modelBuilder.Entity<ShelterInformation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__shelterI__3214EC0783888DB3");

            entity.ToTable("shelterInformation");

            entity.HasIndex(e => e.Name, "UQ__shelterI__737584F6961A72F4").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Descriptions).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Speciallization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__speciall__3214EC070CAA8B8C");

            entity.ToTable("speciallization");

            entity.HasIndex(e => e.Name, "UQ__speciall__737584F68E906696").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Species>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__species__3214EC077961A027");

            entity.ToTable("species");

            entity.HasIndex(e => e.Name, "UQ__species__737584F6F5AD83DD").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__staff__3214EC074A5ADB81");

            entity.ToTable("staff");

            entity.Property(e => e.Contacts).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.WorkSchedule).HasMaxLength(50);

            entity.HasOne(d => d.IdStaffRoleNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.IdStaffRole)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__staff__IdStaffRo__3E1D39E1");
        });

        modelBuilder.Entity<StaffRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__staffRol__3214EC07F0C754C9");

            entity.ToTable("staffRole");

            entity.HasIndex(e => e.Name, "UQ__staffRol__737584F664A4EBE3").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<StatusOfHealth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__statusOf__3214EC07386E0DC0");

            entity.ToTable("statusOfHealth");

            entity.HasIndex(e => e.Name, "UQ__statusOf__737584F64C75AFBD").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3214EC07F69EC944");

            entity.ToTable("users");

            entity.HasIndex(e => e.Name, "UQ__users__737584F669B11E6D").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IdUserGender).HasColumnName("idUserGender");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.IdUserGenderNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdUserGender)
                .HasConstraintName("FK__users__idUserGen__74AE54BC");

            entity.HasOne(d => d.IdUserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdUserRole)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__users__IdUserRol__73BA3083");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__userRole__3214EC074C9C20E9");

            entity.ToTable("userRole");

            entity.HasIndex(e => e.Name, "UQ__userRole__737584F6E40846DA").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<UsersGender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usersGen__3214EC07340DE63D");

            entity.ToTable("usersGender");

            entity.HasIndex(e => e.Name, "UQ__usersGen__737584F6A750B7B8").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Veterinarian>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__veterina__3214EC0794102527");

            entity.ToTable("veterinarian");

            entity.HasOne(d => d.IdClinicNavigation).WithMany(p => p.Veterinarians)
                .HasForeignKey(d => d.IdClinic)
                .HasConstraintName("FK__veterinar__IdCli__42E1EEFE");

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Veterinarians)
                .HasForeignKey(d => d.IdPosition)
                .HasConstraintName("FK__veterinar__IdPos__41EDCAC5");

            entity.HasOne(d => d.IdSpeciallizationNavigation).WithMany(p => p.Veterinarians)
                .HasForeignKey(d => d.IdSpeciallization)
                .HasConstraintName("FK__veterinar__IdSpe__43D61337");

            entity.HasOne(d => d.IdStaffNavigation).WithMany(p => p.Veterinarians)
                .HasForeignKey(d => d.IdStaff)
                .HasConstraintName("FK__veterinar__IdSta__40F9A68C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
