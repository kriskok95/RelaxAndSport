namespace RelaxAndSport.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using RelaxAndSport.Application.Identity;

    public class User : IdentityUser, IUser
    {
        internal User(string firstName, string lastName, string email)
            :base(email)

        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
