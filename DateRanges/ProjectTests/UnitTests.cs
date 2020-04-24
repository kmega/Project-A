using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateRanges;

namespace ProjectTests
{
    [TestClass]
    public class AddMethodTests
    {
        [TestMethod]
        public void ShouldAddWhenEndIsNotPartOfRange()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 01),
                End = new DateTime(2020, 4, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 15),
                End = new DateTime(2020, 5, 15)
            };

            newRange.Add(range);

            // Assert
            Assert.AreEqual(newRange.Start, currentRange.Start);
            Assert.AreEqual(newRange.End, range.End);
        }

        [TestMethod]
        public void ShouldAddWhenStartIsNotPartOfRange()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 01),
                End = new DateTime(2020, 4, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 3, 15),
                End = new DateTime(2020, 4, 15)
            };

            newRange.Add(range);

            // Assert
            Assert.AreEqual(newRange.Start, range.Start);
            Assert.AreEqual(newRange.End, currentRange.End);
        }

        [TestMethod]
        public void ShouldAddWhenCurrentRangeIsPartOfRange()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 15),
                End = new DateTime(2020, 4, 16)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 01),
                End = new DateTime(2020, 4, 30)
            };

            newRange.Add(range);

            // Assert
            Assert.AreEqual(newRange.Start, range.Start);
            Assert.AreEqual(newRange.End, range.End);
        }
    }

    [TestClass]
    public class SubtractMethodTests
    {
        [TestMethod]
        public void ShouldSubtractWhenEndIsNotPartOfRange()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 01),
                End = new DateTime(2020, 4, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 15),
                End = new DateTime(2020, 5, 15)
            };

            newRange.Subtract(range);

            // Assert
            Assert.AreEqual(newRange.Start, currentRange.Start);
            Assert.AreEqual(newRange.End, range.Start);
        }

        [TestMethod]
        public void ShouldSubtractWhenStartIsNotPartOfRange()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 01),
                End = new DateTime(2020, 4, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 3, 15),
                End = new DateTime(2020, 4, 15)
            };

            newRange.Subtract(range);

            // Assert
            Assert.AreEqual(newRange.Start, range.End);
            Assert.AreEqual(newRange.End, currentRange.End);
        }
    }
}