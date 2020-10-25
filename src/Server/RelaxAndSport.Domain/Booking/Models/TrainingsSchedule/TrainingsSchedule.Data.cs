namespace RelaxAndSport.Domain.Booking.Models.TrainingsSchedule
{
    using RelaxAndSport.Domain.Common;
    using System;
    using System.Collections.Generic;

    public class TrainingsScheduleData : IInitialData
    {
        public Type EntityType => typeof(TrainingsSchedule);

        public IEnumerable<object> GetData()
            => new List<TrainingsSchedule>
            {
                new TrainingsSchedule()
            };
    }
}
