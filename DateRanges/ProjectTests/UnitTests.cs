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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 15),
                End = new DateTime(2020, 05, 15)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 03, 15),
                End = new DateTime(2020, 04, 15)
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
                Start = new DateTime(2020, 04, 15),
                End = new DateTime(2020, 04, 16)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 15),
                End = new DateTime(2020, 04, 16)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 06, 01),
                End = new DateTime(2020, 06, 30)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 15),
                End = new DateTime(2020, 05, 15)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 03, 15),
                End = new DateTime(2020, 04, 15)
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
                Start = new DateTime(2020, 04, 15),
                End = new DateTime(2020, 04, 16)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 15),
                End = new DateTime(2020, 04, 30)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 15),
                End = new DateTime(2020, 04, 16)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 06, 01),
                End = new DateTime(2020, 06, 30)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 15),
                End = new DateTime(2020, 05, 15)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 03, 15),
                End = new DateTime(2020, 04, 15)
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
                Start = new DateTime(2020, 04, 15),
                End = new DateTime(2020, 04, 16)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 15),
                End = new DateTime(2020, 04, 16)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 06, 01),
                End = new DateTime(2020, 06, 30)
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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given

            newRange.ExpandTo(new DateTime(2020, 03, 15));

            // Assert
        }

        [TestMethod]
        public void ShouldNotExpandWhenDateIsPartOfCurrentRange()
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given

            newRange.ExpandTo(new DateTime(2020, 04, 15));

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
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given

            DateTime date = new DateTime(2020, 06, 30);
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
        [DataRow(03, 04)]
        [DataRow(04, 05)]
        [DataRow(04, 04)]
        [DataRow(03, 05)]
        public void ShouldReturnTrueWhenRangesAreOverlapping(int firstMonth, int secondMonth)
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
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

        [TestMethod]
        [DataRow(01)]
        [DataRow(06)]
        public void ShouldReturnFalseWhenRangesAreOverNotlapping(int month)
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
                Start = new DateTime(2020, month, 01),
                End = new DateTime(2020, month, 30)
            };

            bool value = newRange.IntersectsWith(range);

            // Assert
            Assert.IsFalse(value);
        }
    }

    [TestClass]
    public class ContainsMethodTests
    {
        [TestMethod]
        [DataRow(01, 10)]
        [DataRow(10, 20)]
        [DataRow(20, 30)]
        public void ShouldReturnTrueWhenCurrentRangeContainsRange(int firstDay, int secondDay)
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, firstDay),
                End = new DateTime(2020, 04, secondDay)
            };

            bool value = newRange.Contains(range);

            // Assert
            Assert.IsTrue(value);
        }

        [TestMethod]
        [DataRow(01)]
        [DataRow(06)]
        public void ShouldReturnFalseWhenCurrentRangeDoNotContainsRange(int month)
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, month, 01),
                End = new DateTime(2020, month, 30)
            };

            bool value = newRange.Contains(range);

            // Assert
            Assert.IsFalse(value);
        }
    }

    [TestClass]
    public class StartsWithMethodTests
    {
        [TestMethod]
        [DataRow(01)]
        [DataRow(15)]
        public void ShouldReturnTrueWhenCurrentRangeStartsWithRange(int day)
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, day)
            };

            bool value = newRange.StartsWith(range);

            // Assert
            Assert.IsTrue(value);
        }

        [TestMethod]
        [DataRow(15)]
        [DataRow(30)]
        public void ShouldReturnFalseWhenCurrentRangeDoNotStartsWithRange(int day)
        {
            // For
            DateTimeRange currentRange = new DateTimeRange
            {
                Start = new DateTime(2020, 04, 01),
                End = new DateTime(2020, 04, 30)
            };

            DateTimeRange newRange = currentRange;

            // Given
            DateTimeRange range = new DateTimeRange
            {
                Start = new DateTime(2020, 04, day),
                End = new DateTime(2020, 04, 30)
            };

            bool value = newRange.StartsWith(range);

            // Assert
            Assert.IsFalse(value);
        }
    }
}