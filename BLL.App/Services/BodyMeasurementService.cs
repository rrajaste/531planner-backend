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

namespace BLL.Services
{
    public class BodyMeasurementService :
        BaseEntityService<IBodyMeasurementRepository, IAppUnitOfWork, BodyMeasurement,
            App.DTO.BodyMeasurement, IBLLMapper<BodyMeasurement, App.DTO.BodyMeasurement>>, IBodyMeasurementService
    {
        public BodyMeasurementService(IAppUnitOfWork unitOfWork,
            IBLLMapper<BodyMeasurement, App.DTO.BodyMeasurement> mapper)
            : base(unitOfWork, mapper, unitOfWork.BodyMeasurements)
        {
        }

        public async Task<IEnumerable<App.DTO.BodyMeasurement>> AllWithAppUserIdAsync(Guid id)
        {
            return (
                await UnitOfWork.BodyMeasurements.AllWithAppUserIdAsync(id)
            ).Select(Mapper.MapDALToBLL);
        }

        public async Task<App.DTO.BodyMeasurement> FindWithAppUserIdAsync(Guid id, Guid appUserId)
        {
            return Mapper.MapDALToBLL(
                await UnitOfWork.BodyMeasurements.FindWithAppUserIdAsync(id, appUserId));
        }

        public async Task<App.DTO.BodyMeasurement> FirstForUserWithIdAsync(Guid userId)
        {
            return Mapper.MapDALToBLL(await ServiceRepository.FirstForUserWithIdAsync(userId));
        }

        public async Task<App.DTO.BodyMeasurement> LatestForUserWithIdAsync(Guid userId)
        {
            return Mapper.MapDALToBLL(await ServiceRepository.LatestForUserWithIdAsync(userId));
        }

        public async Task<BodyMeasurementStatistics> GetUserStatisticsAsync(Guid userId)
        {
            var measurements = await ServiceRepository.AllWithAppUserIdAsync(userId);
            var sortedMeasurements = measurements
                .OrderBy(measurement => measurement.LoggedAt).ToList();
            var currentMeasurement = sortedMeasurements.Last();
            var firstMeasurement = sortedMeasurements.First();
            var statistics = new BodyMeasurementStatistics
            {
                CurrentBMI = CalculateBMI(currentMeasurement),
                BMIChange = CalculateBMIChange(firstMeasurement, currentMeasurement),
                BodyFatPercentageChange = CalculateBodyFatPercentageChange(firstMeasurement, currentMeasurement),
                CurrentBodyFatPercentage = currentMeasurement.BodyFatPercentage,
                FirstLogAt = firstMeasurement.LoggedAt,
                WeightChange = CalculateWeightChange(firstMeasurement, currentMeasurement),
                CurrentWeight = currentMeasurement.Weight
            };
            return statistics;
        }

        private static float CalculateBMI(BodyMeasurement currentMeasurement)
        {
            return currentMeasurement.Weight / (currentMeasurement.Height / 100 * (currentMeasurement.Height / 100));
        }

        private static float CalculateBMIChange(BodyMeasurement startingMeasurement,
            BodyMeasurement currentMeasurement)
        {
            var startingBmi = CalculateBMI(startingMeasurement);
            var currentBmi = CalculateBMI(currentMeasurement);
            return currentBmi - startingBmi;
        }

        private static float CalculateWeightChange(BodyMeasurement startingMeasurement,
            BodyMeasurement currentMeasurement)
        {
            var startingWeight = startingMeasurement.Weight;
            var currentWeight = currentMeasurement.Weight;
            return currentWeight - startingWeight;
        }

        private static float CalculateBodyFatPercentageChange(BodyMeasurement startingMeasurement,
            BodyMeasurement currentMeasurement)
        {
            var startingBodyFatPercentage = startingMeasurement.BodyFatPercentage;
            var currentBodyFatPercentage = currentMeasurement.BodyFatPercentage;
            return currentBodyFatPercentage - startingBodyFatPercentage;
        }
    }
}