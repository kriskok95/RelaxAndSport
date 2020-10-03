namespace RelaxAndSport.Domain.Common.Models
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }

        public class Massage
        {
            public const int MinDuration = 5;
            public const int MaxDuration = 240;
            public const int MinDescriptionLength = 10;
            public const int MaxDescriptionLength = 1000;
            public const decimal MinPrice = 0;
            public const decimal MaxPrice = 200;
        }

        public class PhoneNumber
        {
            public const int MinPhoneNumberLength = 5;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"\+[0-9]*";
        }
    }
}
