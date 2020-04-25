﻿using System;
using System.Data.Entity;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
        public Microsoft.EntityFrameworkCore.DbSet<BodyMeasurement> BodyMeasurements { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<DailyNutritionIntake> DailyNutritionIntakes { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<Exercise> Exercises { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<ExerciseType> ExerciseTypes { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<Muscle> Muscles { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<MuscleGroup> MuscleGroups { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<ExerciseSet> ExerciseSets { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<PersonalRecord> PersonalRecords { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<RoutineType> RoutineTypes { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<TargetMuscleGroup> TargetMuscleGroups { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<TrainingCycle> TrainingCycles { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<TrainingDay> TrainingDays { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<TrainingDayType> TrainingDaysTypes { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<TrainingWeek> TrainingWeeks { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<UnitType> UnitTypes { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<AppUser> AppUsers { get; set; } = default!;
        public Microsoft.EntityFrameworkCore.DbSet<WorkoutRoutine> WorkoutRoutines { get; set; } = default!;
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkoutRoutine>()
                .HasMany(w => w.ExerciseSets)
                .WithOne(nameof(ExerciseSet.WorkoutRoutine))
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}