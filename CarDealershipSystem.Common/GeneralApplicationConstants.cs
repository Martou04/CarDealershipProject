namespace CarDealershipSystem.Common
{
    public static class GeneralApplicationConstants
    {
        public const int ReleaseYear = 2024;

        public const int DefaultPage = 1;
        public const int EntitiesPerPage = 4;

        public const string AdminAreaName = "Admin";
        public const string AdminRoleName = "Admin";
        public const string DevelopmentAdminEmail = "admin@cardealership.bg";

        public const string UsersCacheKey = "UsersCache";
        public const int UsersCacheDurationMinutes = 5;

        public const string OnlineUsersCookieName = "IsOnline";
        public const int LastActivityBeforeOffLineMinutes = 10;
    }
}