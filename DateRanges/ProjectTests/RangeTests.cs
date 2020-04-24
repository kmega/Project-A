using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateRanges;

namespace ProjectTests
{
    [TestClass]
    public class RangeTests
    {
        [TestMethod]
        public void ShouldAddRange01()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 01),
                End = new DateTime(2020, 4, 30)
            };

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 15),
                End = new DateTime(2020, 5, 15)
            };

            // Assert

            currentRange.Add(range);

            Assert.AreEqual(currentRange.End, range.End);
        }

        [TestMethod]
        public void ShouldAddRange02()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 01),
                End = new DateTime(2020, 4, 30)
            };

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 3, 15),
                End = new DateTime(2020, 4, 15)
            };

            // Assert
            Assert.AreNotEqual(currentRange.Start, range.Start);

            currentRange.Add(range);

            Assert.AreEqual(currentRange.Start, range.Start);
        }

        [TestMethod]
        public void ShouldAddRange03()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 15),
                End = new DateTime(2020, 4, 16)
            };

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 01),
                End = new DateTime(2020, 4, 30)
            };

            // Assert
            Assert.AreNotEqual(currentRange.Start, range.Start);
            Assert.AreNotEqual(currentRange.End, range.End);

            currentRange.Add(range);

            Assert.AreEqual(currentRange.Start, new DateTime(2020, 4, 01));
            Assert.AreEqual(currentRange.End, new DateTime(2020, 4, 30));
        }
    }
}
