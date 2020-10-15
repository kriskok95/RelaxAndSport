namespace RelaxAndSport.Application.Booking.TrainingsAppointments.Commands.Create
{
    public class CreateTrainingAppointmentOutputModel
    {
        public CreateTrainingAppointmentOutputModel(int trainingAppointmentId)
            => this.TrainingAppointmentId = trainingAppointmentId;

        public int TrainingAppointmentId { get; set; }
    }
}
