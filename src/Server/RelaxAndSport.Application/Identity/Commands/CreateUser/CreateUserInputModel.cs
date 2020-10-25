namespace RelaxAndSport.Application.Identity.Commands.CreateUser
{
    using System.ComponentModel.DataAnnotations;

    using static RelaxAndSport.Domain.Common.Models.ModelConstants.Common;

    public abstract class CreateUserInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; } = default!;

        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; } = default!;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = default!;

        [Required]
        [MinLength(MinPasswordLength)]
        public string Password { get; set; } = default!;
    }
}
