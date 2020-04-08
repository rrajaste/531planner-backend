using System;
using Extensions;
using NUnit.Framework;

namespace TestProject1
{
    public class StartingFromGetDatesWithSameDayOfWeekTests
    {
        [Test]
        public void Should_return_correct_new_dates_starting_from_sunday()
        {
            var startingDate = new DateTime(2020, 3, 29);
            var firstDay = new DateTime(2020, 2, 24);
            var secondDay = new DateTime(2020, 2, 26);
            var thirdDay = new DateTime(2020, 2, 28);
            var dates = new DateTime[] {firstDay, secondDay, thirdDay};
            var newFirstDay = new DateTime(2020, 3, 30);
            var newSecondDay = new DateTime(2020, 4, 1);
            var newThirdDay = new DateTime(2020, 4, 3);
            var expectedResult = new DateTime[]{newFirstDay, newSecondDay, newThirdDay};

            var returnedResult = startingDate.StartingFromGetDatesWithSameDayOfWeek(dates);
            
            CollectionAssert.AreEqual(expectedResult, returnedResult);
        }
        
        [Test]
        public void Should_return_correct_new_dates_starting_from_monday()
        {
            var startingDate = new DateTime(2020, 3, 30);
            var firstDay = new DateTime(2020, 2, 25);
            var secondDay = new DateTime(2020, 2, 27);
            var thirdDay = new DateTime(2020, 2, 29);
            var dates = new DateTime[] {firstDay, secondDay, thirdDay};
            var newFirstDay = new DateTime(2020, 3, 31);
            var newSecondDay = new DateTime(2020, 4, 2);
            var newThirdDay = new DateTime(2020, 4, 4);
            var expectedResult = new DateTime[]{newFirstDay, newSecondDay, newThirdDay};

            var returnedResult = startingDate.StartingFromGetDatesWithSameDayOfWeek(dates);
            
            CollectionAssert.AreEqual(expectedResult, returnedResult);
        }
    }
}