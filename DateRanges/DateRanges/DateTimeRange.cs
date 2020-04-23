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
            return null;
        }

        /// <summary>
        /// Subtracts given range from current range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public DateTimeRange[] Subtract(DateTimeRange range)
        {
            return null;
        }

        /// <summary>
        /// Merges current range with given range
        /// If ranges doesn't intersect, they are merged as longest period possible to create
        /// </summary>
        /// <param name="dateRange"></param>
        public DateTimeRange Merge(DateTimeRange dateRange)
        {
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
    }
}
