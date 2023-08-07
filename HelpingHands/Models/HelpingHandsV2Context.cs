using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HelpingHands.Models;

public partial class HelpingHandsV2Context : DbContext
{
    public HelpingHandsV2Context()
    {
    }

    public HelpingHandsV2Context(DbContextOptions<HelpingHandsV2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Condition> Conditions { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Nurse> Nurses { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientCondition> PatientConditions { get; set; }

    public virtual DbSet<PrefferedSuburb> PrefferedSuburbs { get; set; }

    public virtual DbSet<Suburb> Suburbs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    public virtual DbSet<Wound> Wounds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Lithi_Mgwebi\\SQLEXPRESS;Initial Catalog=HelpingHandsV2;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.Abbreviation).HasMaxLength(5);
            entity.Property(e => e.CityName).HasMaxLength(20);
        });

        modelBuilder.Entity<Condition>(entity =>
        {
            entity.ToTable("Condition");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.ToTable("Contract");

            entity.Property(e => e.AddressLineOne).HasMaxLength(50);
            entity.Property(e => e.AddressLineTwo).HasMaxLength(50);
            entity.Property(e => e.Comment).HasMaxLength(100);
            entity.Property(e => e.ContractDate).HasColumnType("date");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.Status).HasMaxLength(5);

            entity.HasOne(d => d.Nurse).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.NurseId)
                .HasConstraintName("FK_Contract_Nurse");

            entity.HasOne(d => d.Patient).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Patient");

            entity.HasOne(d => d.Suburb).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.SuburbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Suburb");

            entity.HasOne(d => d.Wound).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.WoundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Wound");
        });

        modelBuilder.Entity<Nurse>(entity =>
        {
            entity.ToTable("Nurse");

            entity.Property(e => e.NurseId).ValueGeneratedNever();
            entity.Property(e => e.Grade).HasMaxLength(5);

            entity.HasOne(d => d.NurseNavigation).WithOne(p => p.Nurse)
                .HasForeignKey<Nurse>(d => d.NurseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nurse_User");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.PatientId).ValueGeneratedNever();
            entity.Property(e => e.AdditionalInfo).HasMaxLength(100);
            entity.Property(e => e.AddressLineOne).HasMaxLength(50);
            entity.Property(e => e.AddressLineTwo).HasMaxLength(50);
            entity.Property(e => e.Icename)
                .HasMaxLength(15)
                .HasColumnName("ICEName");
            entity.Property(e => e.Icenumber)
                .HasMaxLength(20)
                .HasColumnName("ICENumber");

            entity.HasOne(d => d.PatientNavigation).WithOne(p => p.Patient)
                .HasForeignKey<Patient>(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_User");

            entity.HasOne(d => d.Suburb).WithMany(p => p.Patients)
                .HasForeignKey(d => d.SuburbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_Suburb");
        });

        modelBuilder.Entity<PatientCondition>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.ConditionId });

            entity.ToTable("PatientCondition");

            entity.HasOne(d => d.Condition).WithMany(p => p.PatientConditions)
                .HasForeignKey(d => d.ConditionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientCondition_Condition");

            entity.HasOne(d => d.Patient).WithMany(p => p.PatientConditions)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PatientCondition_Patient");
        });

        modelBuilder.Entity<PrefferedSuburb>(entity =>
        {
            entity.HasKey(e => new { e.NurseId, e.SuburbId });

            entity.ToTable("PrefferedSuburb");

            entity.HasOne(d => d.Nurse).WithMany(p => p.PrefferedSuburbs)
                .HasForeignKey(d => d.NurseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrefferedSuburb_Nurse");

            entity.HasOne(d => d.Suburb).WithMany(p => p.PrefferedSuburbs)
                .HasForeignKey(d => d.SuburbId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrefferedSuburb_Suburb");
        });

        modelBuilder.Entity<Suburb>(entity =>
        {
            entity.ToTable("Suburb");

            entity.Property(e => e.SuburbName).HasMaxLength(20);

            entity.HasOne(d => d.City).WithMany(p => p.Suburbs)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Suburb_City");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.ApplicationType).HasMaxLength(5);
            entity.Property(e => e.ContactNumber).HasMaxLength(20);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.EmailAddress).HasMaxLength(30);
            entity.Property(e => e.Firstname).HasMaxLength(15);
            entity.Property(e => e.Gender).HasMaxLength(15);
            entity.Property(e => e.Idnumber).HasColumnName("IDNumber");
            entity.Property(e => e.Lastname).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(20);
            entity.Property(e => e.ProfilePictureName).HasMaxLength(50);
            entity.Property(e => e.UserType).HasMaxLength(5);
            entity.Property(e => e.Username).HasMaxLength(20);
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.ToTable("Visit");

            entity.Property(e => e.Note).HasMaxLength(100);
            entity.Property(e => e.VisitDate).HasColumnType("date");
            entity.Property(e => e.WoundCondition).HasMaxLength(50);

            entity.HasOne(d => d.Contract).WithMany(p => p.Visits)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Visit_Contract");
        });

        modelBuilder.Entity<Wound>(entity =>
        {
            entity.ToTable("Wound");

            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Grade).HasMaxLength(5);
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
