using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repositories.GeneratedModels;

public partial class MyDBContext : DbContext
{
    public MyDBContext()
    {
    }

    public MyDBContext(DbContextOptions<MyDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alarm> Alarms { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Travel> Travels { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Volunteer> Volunteers { get; set; }

    //    When re-running the Scaffold command to update the changes in the DB,
    //    The OnConfiguring function should be put in a comment
    //    because it interferes with the connection to the DB when the project is running.

    //    The Scaffold command is:

    //    Scaffold-DbContext Name = "MyDBConnectionString" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir GeneratedModels -Force -Context MyDBContext

    //    It must be run in the console of the Repositories project

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseNpgsql("Name=MyDBConnectionString");

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    if (!optionsBuilder.IsConfigured)
    //    {
    //        optionsBuilder.UseNpgsql("MyDBConnectionString");
    //    }
    //}


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("MyDBConnectionString");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alarm>(entity =>
        {
            entity.HasKey(e => e.Codealarm).HasName("alarms_pkey");

            entity.ToTable("alarms");

            entity.Property(e => e.Codealarm)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(10L, 10L, null, null, null, null)
                .HasColumnName("codealarm");
            entity.Property(e => e.Maxhour).HasColumnName("maxhour");
            entity.Property(e => e.Minhour).HasColumnName("minhour");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Alarms)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("userid");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Codecar).HasName("cars_pkey");

            entity.ToTable("cars");

            entity.Property(e => e.Codecar)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(770L, 10L, null, null, null, null)
                .HasColumnName("codecar");
            entity.Property(e => e.Ambulance).HasColumnName("ambulance");
            entity.Property(e => e.Babychair).HasColumnName("babychair");
            entity.Property(e => e.Elevator).HasColumnName("elevator");
            entity.Property(e => e.Motorcycle).HasColumnName("motorcycle");
            entity.Property(e => e.Numofsits).HasColumnName("numofsits");
            entity.Property(e => e.Privatecar).HasColumnName("privatecar");
            entity.Property(e => e.Stretcher).HasColumnName("stretcher");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Cars)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("userid");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Codecity).HasName("cities_pkey");

            entity.ToTable("cities");

            entity.Property(e => e.Codecity)
                .UseIdentityAlwaysColumn()
                .HasColumnName("codecity");
            entity.Property(e => e.Cityname)
                .HasMaxLength(50)
                .HasColumnName("cityname");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Cities)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("userid");
        });

        modelBuilder.Entity<Travel>(entity =>
        {
            entity.HasKey(e => e.TravelId).HasName("travels_pkey");

            entity.ToTable("travels");

            entity.Property(e => e.TravelId)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, null, 100L, null, null, null);
            entity.Property(e => e.Ambulance).HasDefaultValueSql("false");
            entity.Property(e => e.BabyChair).HasDefaultValueSql("false");
            entity.Property(e => e.Car).HasDefaultValueSql("false");
            entity.Property(e => e.Dest).HasColumnType("character varying");
            entity.Property(e => e.Elevator).HasDefaultValueSql("false");
            entity.Property(e => e.Motorcycle).HasDefaultValueSql("false");
            entity.Property(e => e.Places).HasDefaultValueSql("0");
            entity.Property(e => e.Time).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.User).WithMany(p => p.Travels)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("userId");

            entity.HasOne(d => d.Volunteer).WithMany(p => p.Travels)
                .HasForeignKey(d => d.VolunteerId)
                .HasConstraintName("volunteerId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("code");

            entity.ToTable("users");

            entity.Property(e => e.Code)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(100L, 5L, null, null, null, null)
                .HasColumnName("  code");
            entity.Property(e => e.Activestatus).HasColumnName("activestatus");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(100)
                .HasColumnName("fullname");
            entity.Property(e => e.Housenumber).HasColumnName("housenumber");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .HasColumnName("phone");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .HasColumnName("street");
            entity.Property(e => e.Usertype).HasColumnName("usertype");
        });

        modelBuilder.Entity<Volunteer>(entity =>
        {
            entity.HasKey(e => e.Voluntercode).HasName("volunteers_pkey");

            entity.ToTable("volunteers");

            entity.Property(e => e.Voluntercode)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(100L, 5L, null, null, null, null)
                .HasColumnName("voluntercode");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.Usercode).HasColumnName("usercode");

            entity.HasOne(d => d.UsercodeNavigation).WithMany(p => p.Volunteers)
                .HasForeignKey(d => d.Usercode)
                .HasConstraintName("codeuser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
