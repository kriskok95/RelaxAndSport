namespace RelaxAndSport.Infrastructure.Identity
{
    using Microsoft.AspNetCore.Identity;
    using RelaxAndSport.Application.Identity;
    using RelaxAndSport.Domain.Booking.Models.Client;
    using RelaxAndSport.Domain.Common.Exceptions;

    public class User : IdentityUser, IUser
    {
        internal User(string email)
            : base(email)
        {
            this.Email = email;
        }

        public Client? Client { get; private set; }

        public void BecomeClient(Client client)
        {
            if(this.Client != null)
            {
                throw new InvalidClientException($"User '{this.UserName}' is already a client");
            }

            this.Client = client;
        }
    }
}
