namespace RelaxAndSport.Application.Booking.Trainings.Commands.Create
{
    public class CreateTrainingOutputModel
    {
        public CreateTrainingOutputModel(int trainingId)
            => this.TrainingId = trainingId;

        public int TrainingId { get; set; }
    }
}
