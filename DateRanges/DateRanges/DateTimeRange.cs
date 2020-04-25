using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateRanges
{
    /// <summary>
    /// Represents one continuos DateTime range
    /// </summary>
    public class DateTimeRange
    {
        /// <summary>
        /// Range start
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// Range end
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Adds given range to current range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public DateTimeRange[] Add(DateTimeRange range)
        {
            switch (CheckRange(range))
            {
                case 0:
                    Start = range.Start;
                    break;
                case 1:
                    End = range.End;
                    break;
                case 2:
                    Start = range.Start;
                    End = range.End;
                    break;
                case 3:
                    // Changes nothing.
                    break;
                case 4:
                    throw new Exception("You can't add ranges that don't overlap. Use 'Merge' method to create longest period possible.");
                default:
                    throw new Exception("Unexpected error occured.");
            }

            return null;
        }

        /// <summary>
        /// Subtracts given range from current range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public DateTimeRange[] Subtract(DateTimeRange range)
        {
            switch (CheckRange(range))
            {
                case 0:
                    Start = range.End;
                    break;
                case 1:
                    End = range.Start;
                    break;
                case 2:
                    // This would subtract everything so I'm assigning lowest value possible.
                    Start = DateTime.MinValue;
                    End = DateTime.MinValue;
                    break;
                case 3:
                    // Checks if subtraction won't split current range into two separate ranges.
                    if (range.Start == Start)
                    {
                        Start = range.End;
                        break;
                    }
                    else if (range.End == End)
                    {
                        End = range.Start;
                        break;
                    }
                    else
                    {
                        throw new Exception("This subtraction would create two different ranges as a result.");
                    }
                case 4:
                    throw new Exception("You can't subtract ranges that don't overlap.");
                default:
                    throw new Exception("Unexpected error occured.");
            }

            return null;
        }

        /// <summary>
        /// Merges current range with given range
        /// If ranges doesn't intersect, they are merged as longest period possible to create
        /// </summary>
        /// <param name="dateRange"></param>
        public DateTimeRange Merge(DateTimeRange dateRange)
        {
            switch (CheckRange(dateRange))
            {
                case 0:
                    Start = dateRange.Start;
                    break;
                case 1:
                    End = dateRange.End;
                    break;
                case 2:
                    Start = dateRange.Start;
                    End = dateRange.End;
                    break;
                case 3:
                    // Changes nothing.
                    break;
                case 4:
                    // Checks which date is the oldest and the newest and then assignes them.
                    Start = Start < dateRange.Start ? Start : dateRange.Start;
                    End = End > dateRange.End ? End : dateRange.End;
                    break;
                default:
                    throw new Exception("Unexpected error occured.");
            }

            return null;
        }

        /// <summary>
        /// Expands current range to given date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTimeRange ExpandTo(DateTime date)
        {
            // Checks if date is not earlier than starting date.
            if (date < Start)
            {
                throw new Exception("You can't expand to date that is before starting date.");
            }
            else if (date >= Start && date <= End)
            {
                // Changes nothing.
            }
            else
            {
                End = date;
            }

            return null;
        }

        /// <summary>
        /// Return value indicating if current range intersects with given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean IntersectsWith(DateTimeRange range)
        {
            switch (CheckRange(range))
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return true;
                case 4:
                    return false;
                default:
                    throw new Exception("Unexpected error occured.");
            }
        }


        /// <summary>
        /// Return value indicating if current range contains whole given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean Contains(DateTimeRange range)
        {
            switch (CheckRange(range))
            {
                case 0:
                case 1:
                case 2:
                case 4:
                    return false;
                case 3:
                    return true;
                default:
                    throw new Exception("Unexpected error occured.");
            }
        }

        /// <summary>
        /// Returns value indicating if current range starts with given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean StartsWith(DateTimeRange range)
        {
            if (CheckDate(Start, range.Start) && range.End > Start && range.End < End)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns value indicating if current range ends with given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean EndsWith(DateTimeRange range)
        {
            if (CheckDate(End, range.End) && range.Start > Start && range.Start < End)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /// <summary>
        /// Gets value indicating if current range is continuation of given date time range
        /// </summary>
        /// <param name="dateRange"></param>
        /// <returns></returns>
        public Boolean IsContinuationOf(DateTimeRange dateRange)
        {
            return CheckDate(Start, dateRange.End);
        }

        /// <summary>
        /// Returns value indicating if current range is equal to given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean IsEqualTo(DateTimeRange range)
        {
            if (CheckDate(Start, range.Start) && CheckDate(End, range.End))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Return value indicating if current range contains given date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public Boolean Contains(DateTime date)
        {
            if (Start < date && End > date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int CheckRange(DateTimeRange range)
        {
            // If Start date is in between range and End date is after range.End.
            if (Start >= range.Start && Start <= range.End && End > range.End)
            {
                return 0;
            }
            // If End date is in between range and Start date is before range.Start.
            else if (End >= range.Start && End <= range.End && Start < range.Start)
            {
                return 1;
            }
            // If Start and End dates are in between range.
            else if (Start >= range.Start && End <= range.End)
            {
                return 2;
            }
            // If range is in between Start and End dates.
            else if (Start <= range.Start && End >= range.End)
            {
                return 3;
            }
            // If ranges don't overlap.
            else
            {
                return 4;
            }
        }

        private Boolean CheckDate(DateTime currentDate, DateTime date)
        {
            if (currentDate == date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
