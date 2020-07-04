namespace Fruitify.Common
{
    public static class GlobalConstants
    {
        // System
        public const string SystemName = "Fruitify";

        // Roles
        public const string AdministratorRoleName = "Administrator";
        public const string UserRoleName = "User";

        // Error Messages
        public const string CharactersCountMessage = "Полето \"{0}\", трябва да бъде с дължина между {2} и {1} символа.";
        public const string RequiredFieldMessage = "Полето \"{0}\", е задължително.";
        public const string InvalidLoginAttemptMessage = "Невалидно потребителско име, или парола.";
        public const string ComparePasswordErrorMessage = "Полето \"Парола\" и полето \"Потвърди паролата\" не съвпадат.";
    }
}
