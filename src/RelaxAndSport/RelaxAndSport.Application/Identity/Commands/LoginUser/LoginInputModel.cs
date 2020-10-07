namespace RelaxAndSport.Application.Identity.Commands.LoginUser
{
    public abstract class LoginInputModel
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}
