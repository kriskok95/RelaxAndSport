namespace RelaxAndSport.Domain.Booking.Models.MassagesSchedule
{
    using RelaxAndSport.Domain.Common;
    using System;
    using System.Collections.Generic;

    public class MassagesScheduleData : IInitialData
    {
        public Type EntityType => typeof(MassagesSchedule);

        public IEnumerable<object> GetData()
            => new List<MassagesSchedule>
            {
                new MassagesSchedule()
            };
    }
}
