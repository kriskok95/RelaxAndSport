﻿namespace RelaxAndSport.Infrastructure.Booking.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using RelaxAndSport.Application.Booking.MassagesSchedule;
    using RelaxAndSport.Domain.Booking.Models.MassagesAppointments;
    using RelaxAndSport.Domain.Booking.Models.MassagesSchedule;
    using RelaxAndSport.Domain.Booking.Repositories;
    using RelaxAndSport.Infrastructure.Common.Persistence;
    using System.Threading.Tasks;

    internal class MassagesScheduleRepository : DataRepository<IBookingDbContext, MassagesSchedule>,
        IMassagesScheduleDomainRepository,
        IMassagesScheduleQueryRepository
    {
        private readonly IMapper mapper;

        public MassagesScheduleRepository(
           IBookingDbContext db,
           IMapper mapper)
           : base(db)
           => this.mapper = mapper;

        public async Task AddMassageAppointment(MassageAppointment massageAppointment)
        {
            var massageSchedule = await this.Data
                .MassagesSchedules
                .FirstOrDefaultAsync();

            massageSchedule.AddMassageAppointment(massageAppointment);
        }

        public async Task<MassagesSchedule> GetMassagesSchedule()
            => await this.Data
            .MassagesSchedules
            .Include(ms => ms.MassageAppointments)
            .FirstOrDefaultAsync();
    }
}
