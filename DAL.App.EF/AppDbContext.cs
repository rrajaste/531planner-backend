﻿using System;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppUserRole, Guid>
    {
        public DbSet<BodyMeasurement> BodyMeasurements { get; set; } = default!;
        public DbSet<DailyNutritionIntake> DailyNutritionIntakes { get; set; } = default!;
        public DbSet<Exercise> Exercises { get; set; } = default!;
        public DbSet<ExerciseInTrainingDay> ExercisesInTrainingDays { get; set; } = default!;
        public DbSet<ExerciseType> ExerciseTypes { get; set; } = default!;
        public DbSet<Muscle> Muscles { get; set; } = default!;
        public DbSet<MuscleGroup> MuscleGroups { get; set; } = default!;
        public DbSet<ExerciseSet> ExerciseSets { get; set; } = default!;
        public DbSet<PersonalRecord> PersonalRecords { get; set; } = default!;
        public DbSet<RoutineType> RoutineTypes { get; set; } = default!;
        public DbSet<TargetMuscleGroup> TargetMuscleGroups { get; set; } = default!;
        public DbSet<TrainingCycle> TrainingCycles { get; set; } = default!;
        public DbSet<TrainingDay> TrainingDays { get; set; } = default!;
        public DbSet<TrainingDayType> TrainingDaysTypes { get; set; } = default!;
        public DbSet<TrainingWeek> TrainingWeeks { get; set; } = default!;
        public DbSet<UnitType> UnitsTypes { get; set; } = default!;
        public DbSet<AppUser> AppUsers { get; set; } = default!;
        public DbSet<WorkoutRoutine> WorkoutRoutines { get; set; } = default!;
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

    }
}