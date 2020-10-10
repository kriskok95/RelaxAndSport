namespace RelaxAndSport.Application.Booking.Massages.Commands.Create
{
    public class CreateMassageOutputModel
    {
        public CreateMassageOutputModel(int massageId)
            => this.MassageId = massageId;

            public int MassageId { get; }
    }
}
