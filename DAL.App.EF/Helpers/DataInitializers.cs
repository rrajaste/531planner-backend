using System;
using System.Collections.Generic;
using System.IO;
using Contracts.DAL.Base;
using ee.itcollege.raraja.Contracts.Domain;
using DAL.Base;
using Domain;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DAL.App.EF.Helpers
{
    public static class DataInitializers
    {
        public static void MigrateDatabase(AppDbContext context)
        {
            context.Database.Migrate();
        }

        public static void DeleteDatabase(AppDbContext context)
        {
            context.Database.EnsureDeleted();
        }

        public static void SeedIdentity(UserManager<AppUser> userManager, RoleManager<AppUserRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedData(AppDbContext context)
        {
            var path = SeedDataFilePaths.BasePath;
            SeedDomainEntity(context.RoutineTypes, path + SeedDataFilePaths.RoutineTypes);
            SeedDomainEntity(context.UnitTypes, path + SeedDataFilePaths.UnitTypes);
            SeedDomainEntity(context.Exercises, path + SeedDataFilePaths.Exercises);
            SeedDomainEntity(context.ExerciseTypes, path + SeedDataFilePaths.ExerciseTypes);
            SeedDomainEntity(context.MuscleGroups, path + SeedDataFilePaths.MuscleGroups);
            SeedDomainEntity(context.TrainingDaysTypes, path + SeedDataFilePaths.TrainingDayTypes);
            SeedDomainEntity(context.SetTypes, path + SeedDataFilePaths.SetTypes);
            context.SaveChanges();
        }

        private static void SeedUsers(UserManager<AppUser> userManager)
        {
            var filePath = SeedDataFilePaths.BasePath + SeedDataFilePaths.AppUsers;
            var usersToSeed = GetSeedObjectsList<User>(filePath);
            foreach (var userToSeed in usersToSeed)
            {
                var userInUserManager = userManager.FindByNameAsync(userToSeed.Name).Result;
                if (userInUserManager == null)
                {
                    userInUserManager = new AppUser()
                    {
                        UserName = userToSeed.Name,
                        Email = userToSeed.Email,
                        EmailConfirmed = userToSeed.IsEmailConfirmed
                    };
                    var result = userManager.CreateAsync(userInUserManager, userToSeed.Password).Result;
                    if (!result.Succeeded)
                    {
                        throw new ApplicationException("Failed to create seeded user");
                    }
                }
                var roleAddResult = userManager.AddToRoleAsync(userInUserManager, userToSeed.AppRole).Result;
            }
        }

        private static void SeedRoles(RoleManager<AppUserRole> roleManager)
        {
            var filePath = SeedDataFilePaths.BasePath + SeedDataFilePaths.AppRoles;
            var rolesToSeed = GetSeedObjectsList<Role>(filePath);
            foreach (var roleToSeed in rolesToSeed)
            {
                var role = roleManager.FindByNameAsync(roleToSeed.Name).Result;
                if (role == null)
                {
                    role = new AppUserRole {Name = roleToSeed.Name, DisplayName = roleToSeed.DisplayName};
                    var result = roleManager.CreateAsync(role).Result;
                    if (!result.Succeeded)
                    {
                        throw new ApplicationException("Role creation failed!");
                    }
                }
            }
        }

        private static void SeedDomainEntity<TEntity>(DbSet<TEntity> dbSet, string filePath)
            where TEntity : class, IDomainEntityIdMetadata
        {
            dbSet.AddRange(GetSeedObjectsList<TEntity>(filePath));
        }

        private static List<TObject> GetSeedObjectsList<TObject>(string filePath)
        {
            using var reader = new StreamReader(filePath);
            var json = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<TObject>>(json);
        }
        
        private struct User
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string AppRole { get; set; }
            public bool IsEmailConfirmed { get; set; }
        }
        
        private struct Role
        {
            public string Name { get; set; }
            public string DisplayName { get; set; }
        }
    }
}