using System;
using System.Collections.Generic;
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
            switch (CheckCase(range))
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
                    // Nothing changes.
                    break;
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
            switch (CheckCase(range))
            {
                case 0:
                    Start = range.End;
                    break;
                case 1:
                    End = range.Start;
                    break;
                case 2:
                    // Would subtract everything.
                    break;
                case 3:
                    // Would create two different ranges.
                    break;
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
            switch (CheckCase(dateRange))
            {
                case 0:
                    End = dateRange.End;
                    break;
                case 1:
                    Start = dateRange.Start;
                    break;
                case 2:
                    // Would subtract everything.
                    break;
                case 3:
                    // Would create two different ranges.
                    break;
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
            return null;
        }

        /// <summary>
        /// Return value indicating if current range intersects with given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean IntersectsWith(DateTimeRange range)
        {
            return true;
        }

        /// <summary>
        /// Return value indicating if current range contains whole given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean Contains(DateTimeRange range)
        {
            return true;
        }

        /// <summary>
        /// Returns value indicating if current range starts with given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean StartsWith(DateTimeRange range)
        {
            return true;
        }

        /// <summary>
        /// Returns value indicating if current range ends with given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean EndsWith(DateTimeRange range)
        {
            return true;
        }
        
        /// <summary>
        /// Gets value indicating if current range is continuation of given date time range
        /// </summary>
        /// <param name="dateRange"></param>
        /// <returns></returns>
        public Boolean IsContinuationOf(DateTimeRange dateRange)
        {
            return true;
        }

        /// <summary>
        /// Returns value indicating if current range is equal to given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Boolean IsEqualTo(DateTimeRange range)
        {
            return true;
        }

        /// <summary>
        /// Return value indicating if current range contains given date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public Boolean Contains(DateTime date)
        {
            return true;
        }

        public int CheckCase(DateTimeRange range)
        {
            // If Start date is in between range and End date is after range.End then both ranges overlap and action can be taken.
            if (Start > range.Start && Start < range.End && End > range.End)
            {
                return 0;
            }
            // If End date is in between range and Start date is before range.Start then both ranges overlap and action can be taken.
            else if (End > range.Start && End < range.End && Start < range.Start)
            {
                return 1;
            }
            // If Start and End dates are in between range parameter then both ranges overlap and acton can be taken.
            else if (Start > range.Start && End < range.End)
            {
                return 2;
            }
            // If range is in between Start and End dates then both ranges overlap but nothing should happen.
            else if (Start < range.Start && End > range.End)
            {
                return 3;
            }
            // In any other unexpected case throw an exception.
            else
            {
                throw new Exception("Something went wrong.");
            }
        }
    }
}
