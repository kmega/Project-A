using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateRanges;

namespace ProjectTests
{
    [TestClass]
    public class AddMethodTests
    {
        [TestMethod]
        public void ShouldAddWhenEndIsOutside()
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
        public void ShouldAddWhenStartIsOutside()
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
        public void ShouldAddWhenStartAndEndAreInside()
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
        public void ShouldSubtractWhenEndIsOutside()
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
        public void ShouldSubtractWhenStartIsOutside()
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

    [TestClass]
    public class MergeMethodTests
    {
        [TestMethod]
        public void ShouldMergeWhenEndIsOutside()
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

            newRange.Merge(range);

            // Assert
            Assert.AreEqual(newRange.Start, currentRange.Start);
            Assert.AreEqual(newRange.End, range.End);
        }

        [TestMethod]
        public void ShouldMergeWhenStartIsOutside()
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

            newRange.Merge(range);

            // Assert
            Assert.AreEqual(newRange.Start, range.Start);
            Assert.AreEqual(newRange.End, currentRange.End);
        }

        [TestMethod]
        public void ShouldMergeWhenStartAndEndAreInside()
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

            newRange.Merge(range);

            // Assert
            Assert.AreEqual(newRange.Start, range.Start);
            Assert.AreEqual(newRange.End, range.End);
        }

        [TestMethod]
        public void ShouldMergeWhenRangesDoNotOverlap()
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
                Start = new DateTime(2020, 6, 01),
                End = new DateTime(2020, 6, 30)
            };

            newRange.Merge(range);

            // Assert
            Assert.AreEqual(newRange.Start, currentRange.Start);
            Assert.AreEqual(newRange.End, range.End);
        }
    }

    [TestClass]
    public class ExpandToMethodTests
    {
        [TestMethod]
        public void ShouldNotExpandWhenDateIsPartOfRange()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 01),
                End = new DateTime(2020, 4, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given

            newRange.ExpandTo(new DateTime(2020, 4, 15));

            // Assert
            Assert.AreEqual(newRange.Start, currentRange.Start);
            Assert.AreEqual(newRange.End, currentRange.End);
        }

        [TestMethod]
        public void ShouldExpandWhenDateIsNewerThanRange()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 01),
                End = new DateTime(2020, 4, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given

            DateTime date = new DateTime(2020, 6, 30);
            newRange.ExpandTo(date);

            // Assert
            Assert.AreEqual(newRange.Start, currentRange.Start);
            Assert.AreEqual(newRange.End, date);
        }
    }
}