﻿// <auto-generated />
using System;
using DAL.App.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.App.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200224182929_InitialDbCreation")]
    partial class InitialDbCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.AppUserRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Domain.BodyMeasurements", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int?>("Arm")
                        .HasColumnType("int");

                    b.Property<int?>("BodyFatPercentage")
                        .HasColumnType("int");

                    b.Property<int?>("Chest")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int?>("Hip")
                        .HasColumnType("int");

                    b.Property<int>("UnitsTypeId")
                        .HasColumnType("int");

                    b.Property<string>("UnitsTypeId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int?>("Waist")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitsTypeId1");

                    b.HasIndex("UserId");

                    b.ToTable("BodyMeasurements");
                });

            modelBuilder.Entity("Domain.DailyNutritionIntake", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int?>("Carbohydrates")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Fats")
                        .HasColumnType("int");

                    b.Property<int?>("Protein")
                        .HasColumnType("int");

                    b.Property<int>("UnitsTypeId")
                        .HasColumnType("int");

                    b.Property<string>("UnitsTypeId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UnitsTypeId1");

                    b.HasIndex("UserId");

                    b.ToTable("DailyNutritionIntakes");
                });

            modelBuilder.Entity("Domain.Exercise", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseTypeId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTypeId1");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Domain.ExerciseInTrainingDay", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("TrainingDayId")
                        .HasColumnType("int");

                    b.Property<string>("TrainingDayId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId1");

                    b.HasIndex("TrainingDayId1");

                    b.ToTable("ExercisesInTrainingDays");
                });

            modelBuilder.Entity("Domain.ExerciseType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ExerciseTypes");
                });

            modelBuilder.Entity("Domain.Muscle", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("MuscleGroupId")
                        .HasColumnType("int");

                    b.Property<string>("MuscleGroupId1")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("MuscleGroupId1");

                    b.ToTable("Muscles");
                });

            modelBuilder.Entity("Domain.MuscleGroup", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("MuscleGroups");
                });

            modelBuilder.Entity("Domain.PerformedExercise", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("NrOfReps")
                        .HasColumnType("int");

                    b.Property<int>("NrOfSets")
                        .HasColumnType("int");

                    b.Property<int>("TrainingDayId")
                        .HasColumnType("int");

                    b.Property<string>("TrainingDayId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("UnitsTypeId")
                        .HasColumnType("int");

                    b.Property<string>("UnitsTypeId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("WorkoutRoutineId")
                        .HasColumnType("int");

                    b.Property<string>("WorkoutRoutineId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId1");

                    b.HasIndex("TrainingDayId1");

                    b.HasIndex("UnitsTypeId1");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutRoutineId1");

                    b.ToTable("PerformedExercises");
                });

            modelBuilder.Entity("Domain.RoutineType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("ClosedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("RoutineTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RoutineTypes");
                });

            modelBuilder.Entity("Domain.TargetMuscleGroup", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("ExerciseId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("MuscleGroupId")
                        .HasColumnType("int");

                    b.Property<string>("MuscleGroupId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId1");

                    b.HasIndex("MuscleGroupId1");

                    b.ToTable("TargetMuscleGroups");
                });

            modelBuilder.Entity("Domain.TrainingCycle", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CycleNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("EndingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("WorkoutRoutineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TrainingCycles");
                });

            modelBuilder.Entity("Domain.TrainingDay", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TrainingDayTypeId")
                        .HasColumnType("int");

                    b.Property<string>("TrainingDayTypeId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("TrainingWeekId")
                        .HasColumnType("int");

                    b.Property<string>("TrainingWeekId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("TrainingDayTypeId1");

                    b.HasIndex("TrainingWeekId1");

                    b.ToTable("TrainingDays");
                });

            modelBuilder.Entity("Domain.TrainingDayType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("TrainingDayTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TrainingDaysTypes");
                });

            modelBuilder.Entity("Domain.TrainingWeek", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("EndingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeload")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TrainingCycleId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("TrainingWeekId")
                        .HasColumnType("int");

                    b.Property<int>("WeekNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainingCycleId");

                    b.ToTable("TrainingWeeks");
                });

            modelBuilder.Entity("Domain.UnitsType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("UnitsTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UnitsTypes");
                });

            modelBuilder.Entity("Domain.WorkoutRoutine", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<int>("RoutineTypeId")
                        .HasColumnType("int");

                    b.Property<string>("RoutineTypeId1")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("WorkoutRoutineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoutineTypeId1");

                    b.HasIndex("UserId");

                    b.ToTable("WorkoutRoutines");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.BodyMeasurements", b =>
                {
                    b.HasOne("Domain.UnitsType", "UnitsType")
                        .WithMany()
                        .HasForeignKey("UnitsTypeId1");

                    b.HasOne("Domain.AppUser", "User")
                        .WithMany("BodyMeasurements")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Domain.DailyNutritionIntake", b =>
                {
                    b.HasOne("Domain.UnitsType", "UnitsType")
                        .WithMany()
                        .HasForeignKey("UnitsTypeId1");

                    b.HasOne("Domain.AppUser", "User")
                        .WithMany("DailyNutritionIntakes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Domain.Exercise", b =>
                {
                    b.HasOne("Domain.ExerciseType", "ExerciseType")
                        .WithMany("Exercises")
                        .HasForeignKey("ExerciseTypeId1");
                });

            modelBuilder.Entity("Domain.ExerciseInTrainingDay", b =>
                {
                    b.HasOne("Domain.Exercise", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId1");

                    b.HasOne("Domain.TrainingDay", "TrainingDay")
                        .WithMany()
                        .HasForeignKey("TrainingDayId1");
                });

            modelBuilder.Entity("Domain.Muscle", b =>
                {
                    b.HasOne("Domain.MuscleGroup", "MuscleGroup")
                        .WithMany("Muscles")
                        .HasForeignKey("MuscleGroupId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.PerformedExercise", b =>
                {
                    b.HasOne("Domain.Exercise", "Exercise")
                        .WithMany("PerformedExercises")
                        .HasForeignKey("ExerciseId1");

                    b.HasOne("Domain.TrainingDay", "TrainingDay")
                        .WithMany()
                        .HasForeignKey("TrainingDayId1");

                    b.HasOne("Domain.UnitsType", "UnitsType")
                        .WithMany()
                        .HasForeignKey("UnitsTypeId1");

                    b.HasOne("Domain.AppUser", "User")
                        .WithMany("PerformedExercises")
                        .HasForeignKey("UserId");

                    b.HasOne("Domain.WorkoutRoutine", "WorkoutRoutine")
                        .WithMany()
                        .HasForeignKey("WorkoutRoutineId1");
                });

            modelBuilder.Entity("Domain.TargetMuscleGroup", b =>
                {
                    b.HasOne("Domain.Exercise", "Exercise")
                        .WithMany("TargetMuscleGroups")
                        .HasForeignKey("ExerciseId1");

                    b.HasOne("Domain.MuscleGroup", "MuscleGroup")
                        .WithMany("TargetMuscleGroups")
                        .HasForeignKey("MuscleGroupId1");
                });

            modelBuilder.Entity("Domain.TrainingDay", b =>
                {
                    b.HasOne("Domain.TrainingDayType", "TrainingDayType")
                        .WithMany("TrainingDays")
                        .HasForeignKey("TrainingDayTypeId1");

                    b.HasOne("Domain.TrainingWeek", "TrainingWeek")
                        .WithMany()
                        .HasForeignKey("TrainingWeekId1");
                });

            modelBuilder.Entity("Domain.TrainingWeek", b =>
                {
                    b.HasOne("Domain.TrainingCycle", "TrainingCycle")
                        .WithMany()
                        .HasForeignKey("TrainingCycleId");
                });

            modelBuilder.Entity("Domain.WorkoutRoutine", b =>
                {
                    b.HasOne("Domain.RoutineType", "RoutineType")
                        .WithMany()
                        .HasForeignKey("RoutineTypeId1");

                    b.HasOne("Domain.AppUser", "User")
                        .WithMany("WorkoutRoutines")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Domain.AppUserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Domain.AppUserRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
