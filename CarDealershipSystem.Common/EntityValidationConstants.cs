namespace CarDealershipSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class ApplicationUser
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 15;
        }

        public static class Seller
        {
            public const int LocationCountryMinLength = 2;
            public const int LocationCountryMaxLength = 50;

            public const int LocationCityMinLength = 2;
            public const int LocationCityMaxLength = 50;

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class Car 
        {
            public const int MakeMinLength = 2;
            public const int MakeMaxLength = 30;

            public const int ModelMinLength = 2;
            public const int ModelMaxLength = 30;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 5000;

            public const int ImageUrlMaxLength = 2048;

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "1000000000";
        }

        public static class FuelType
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 20;
        }

        public static class TransmissionType
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 20;
        }

        public static class Extra
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 20;
        }

        public static class User 
        {
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;

            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 15;
        }
    }
}
