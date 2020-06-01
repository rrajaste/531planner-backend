using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.App.DTO;
using BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using BodyMeasurement = DAL.App.DTO.BodyMeasurement;
using DailyNutritionIntake = DAL.App.DTO.DailyNutritionIntake;

namespace BLL.Services
{
    public class DailyNutritionIntakeService :
        BaseEntityService<IDailyNutritionIntakeRepository, IAppUnitOfWork, DailyNutritionIntake,
            App.DTO.DailyNutritionIntake, IBLLMapper<DailyNutritionIntake, App.DTO.DailyNutritionIntake>>,
        IDailyNutritionIntakeService
    {
        public DailyNutritionIntakeService(IAppUnitOfWork unitOfWork,
            IBLLMapper<DailyNutritionIntake, App.DTO.DailyNutritionIntake> mapper)
            : base(unitOfWork, mapper, unitOfWork.DailyNutritionIntakes)
        {
        }

        public async Task<IEnumerable<App.DTO.DailyNutritionIntake>> AllWithAppUserIdAsync(Guid id)
        {
            return (
                await UnitOfWork.DailyNutritionIntakes.AllWithAppUserIdAsync(id)
            ).Select(Mapper.MapDALToBLL);
        }

        public async Task<App.DTO.DailyNutritionIntake> FindWithAppUserIdAsync(Guid id, Guid appUserId)
        {
            return Mapper.MapDALToBLL(
                await UnitOfWork.DailyNutritionIntakes.FindWithAppUserIdAsync(id, appUserId));
        }

        public async Task<NutritionStatistics> GetNutritionStatisticsAsync(Guid userId,
            List<App.DTO.DailyNutritionIntake> userMeasurements)
        {
            var lastBodyMeasurement = await UnitOfWork.BodyMeasurements.LatestForUserWithIdAsync(userId);
            var lastNutrition = userMeasurements[^1];
            var tdee = calculateTDEE(lastBodyMeasurement);
            var averageCalories = userMeasurements.Average(
                measurement => measurement.Calories);
            var averageCaloriesTdeeDelta = averageCalories - tdee;
            var averageProtein = userMeasurements.Average(
                measurement => measurement.Protein);
            var predictedProteinNeed = CalculatePredictedProteinNeed(lastBodyMeasurement);
            var predictedWeightChange = CalculatePredictedWeightChange(userMeasurements, tdee);
            var firstLogAt = userMeasurements
                .OrderBy(measurement => measurement.LoggedAt)
                .FirstOrDefault()
                .LoggedAt;

            var statistics = new NutritionStatistics
            {
                FirstLogAt = firstLogAt,
                TDEE = tdee,
                AverageCaloriesTdeeDelta = averageCaloriesTdeeDelta,
                AverageCalories = averageCalories,
                AverageProtein = averageProtein,
                PredictedProteinNeed = predictedProteinNeed,
                PredictedWeightChange = predictedWeightChange
            };
            return statistics;
        }

        private static float CalculatePredictedWeightChange(List<App.DTO.DailyNutritionIntake> userMeasurements,
            float tdee)
        {
            var totalCaloriesConsumed = userMeasurements.Sum(
                measurement => measurement.Calories);
            var totalCaloriesNeeded = tdee * userMeasurements.Count;
            var caloriesDelta = totalCaloriesConsumed - totalCaloriesNeeded;
            const int caloriesPerKgOfBodyWeight = 7700;
            return caloriesDelta / caloriesPerKgOfBodyWeight;
        }

        private static float CalculatePredictedProteinNeed(BodyMeasurement lastBodyMeasurement)
        {
            return (float) (lastBodyMeasurement.Weight * 1.75);
        }

        private static float calculateTDEE(BodyMeasurement userMeasurement)
        {
            var leanMass = userMeasurement.Weight * (1 - userMeasurement.BodyFatPercentage / 100);
            var baseTDEE = 370 + 21.6 * leanMass;
            const int additionalEnergyCost = 500;
            return (float) (baseTDEE + additionalEnergyCost);
        }
    }
}