using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateRanges;

namespace ProjectTests
{
    [TestClass]
    public class AddMethodTests
    {
        [TestMethod]
        public void ShouldAddWhenOnlyStartIsOutsideGivenRange()
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
        public void ShouldAddWhenOnlyEndIsOutsideGivenRange()
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
        public void ShouldAddWhenStartAndEndAreInsideGivenRange()
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
        public void ShouldNotAddWhenStartAndEndAreOutsideGivenRange()
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

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldNotAddWhenRangesAreNotOverlapping()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 15),
                End = new DateTime(2020, 4, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 5, 15),
                End = new DateTime(2020, 5, 30)
            };

            newRange.Add(range);

            // Assert
        }
    }

    [TestClass]
    public class SubtractMethodTests
    {
        [TestMethod]
        public void ShouldSubtractWhenOnlyEndIsOutsideGivenRange()
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
        public void ShouldSubtractWhenOnlyStartIsOutsideGivenRange()
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

        [TestMethod]
        public void ShouldAssignLowestPossibleValueWhenStartAndEndAreInsideGivenRange()
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

            newRange.Subtract(range);

            // Assert
            Assert.AreEqual(newRange.Start, DateTime.MinValue);
            Assert.AreEqual(newRange.End, DateTime.MinValue);
        }

        [TestMethod]
        public void ShouldSubtractWhenSplitWillNotHappen()
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
                End = new DateTime(2020, 4, 30)
            };

            newRange.Subtract(range);

            // Assert
            Assert.AreEqual(newRange.Start, currentRange.Start);
            Assert.AreEqual(newRange.End, range.Start);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldNotSubtractWhenSplitWillHappen()
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

            newRange.Subtract(range);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ShouldNotSubtractWhenRangesAreNotOverlapping()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 15),
                End = new DateTime(2020, 4, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 5, 15),
                End = new DateTime(2020, 5, 30)
            };

            newRange.Subtract(range);

            // Assert
        }
    }

    [TestClass]
    public class MergeMethodTests
    {
        [TestMethod]
        public void ShouldMergeWhenOnlyStartIsOutsideGivenRange()
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
        public void ShouldMergeWhenOnlyEndIsOutsideGivenRange()
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
        public void ShouldMergeWhenStartAndEndAreInsideGivenRange()
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
        public void ShouldNotMergeWhenStartAndEndAreOutsideGivenRange()
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

            newRange.Merge(range);

            // Assert
            Assert.AreEqual(newRange.Start, currentRange.Start);
            Assert.AreEqual(newRange.End, currentRange.End);
        }

        [TestMethod]
        public void ShouldMergeWhenRangesAreNotOverlapping()
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
        [ExpectedException(typeof(Exception))]
        public void ShouldNotExpandWhenDateIsEarlierThanStartingDate()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 4, 01),
                End = new DateTime(2020, 4, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given

            newRange.ExpandTo(new DateTime(2020, 3, 15));

            // Assert
        }

        [TestMethod]
        public void ShouldNotExpandWhenDateIsPartOfCurrentRange()
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
        public void ShouldExpandWhenDateIsOlderThanCurrentRange()
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

    [TestClass]
    public class IntersectsWithMethodTests
    {
        [TestMethod]
        [DataRow(3, 4)]
        [DataRow(4, 5)]
        [DataRow(4, 4)]
        [DataRow(3, 5)]
        public void ShouldIntersectsWithWhenRangesAreOverlapping(int firstMonth, int secondMonth)
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
                Start = new DateTime(2020, firstMonth, 15),
                End = new DateTime(2020, secondMonth, 15)
            };

            bool value = newRange.IntersectsWith(range);

            // Assert
            Assert.IsTrue(value);
        }
    }
}