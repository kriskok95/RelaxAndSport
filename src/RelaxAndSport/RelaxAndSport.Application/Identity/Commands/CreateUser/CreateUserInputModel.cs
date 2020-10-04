namespace RelaxAndSport.Application.Identity.Commands.CreateUser
{
    public abstract class CreateUserInputModel
    {
        public string Email { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}
