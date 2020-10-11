namespace RelaxAndSport.Domain.Common.Models
{
    using RelaxAndSport.Domain.Booking.Exceptions;
    using System;

    public class DateTimeRange : ValueObject
    {
        internal DateTimeRange(DateTime start, DateTime end)
        {
            Validate(start, end);

            Start = start;
            End = end;
        }

        internal DateTimeRange(DateTime start, TimeSpan duration)
            : this(start, start.Add(duration))
        {
        }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public int DurationInMinutes()
            => (End - Start).Minutes;

        public DateTimeRange NewEnd(DateTime newEnd)
            => new DateTimeRange(Start, newEnd);

        public DateTimeRange NewDuration(TimeSpan newDuration)
            => new DateTimeRange(Start, newDuration);

        public DateTimeRange NewStart(DateTime newStart)
            => new DateTimeRange(newStart, End);

        public bool Overlaps(DateTimeRange dateTimeRange)
            => Start < dateTimeRange.End &&
            End > dateTimeRange.Start;

        private void Validate(DateTime startDate, DateTime endDate)
            => ValidateEndDate(startDate, endDate);

        private void ValidateEndDate(DateTime startDate, DateTime endDate)
            => Guard.AgainstDateRange<InvalidDateTimeRangeException>(
                startDate,
                endDate,
                nameof(startDate));
    }
}
