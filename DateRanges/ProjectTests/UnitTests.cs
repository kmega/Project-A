using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateRanges;

namespace ProjectTests
{
    [TestClass]
    public class AddMethodTests
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
        public void ShouldAddRange02()
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
        public void ShouldAddRange03()
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
        [TestMethod]
        public void ShouldAddRange04()
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
                End = new DateTime(2020, 4, 16)
            };

            newRange.Add(range);

            // Assert
            Assert.AreEqual(newRange.Start, currentRange.Start);
            Assert.AreEqual(newRange.End, currentRange.End);
        }
    }

    [TestClass]
    public class holder
    {
        [TestMethod]
        public void holder01()
        {
            Assert.Fail();
        }
    }
}
