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
        public const string InvalidRangeMessage = "Стойността, на полето \"{0}\" трябва да бъде между {1} и {2}.";
        public const string RequiredFieldMessage = "Полето \"{0}\", е задължително.";
        public const string InvalidLoginAttemptMessage = "Невалидно потребителско име, или парола.";
        public const string ComparePasswordErrorMessage = "Полето \"Парола\" и полето \"Потвърди паролата\" не съвпадат.";
        public const string InvalidTEntityIdErrorMessage = "{0} със ID: {1} не съсществува.";
        public const string InvalidTEntityIdsErrorMessage = "Не съществува {0}, с ID, от изброените.";
        public const string DeleteProductErrorMessage = "Failed to delete {0}.";

        // Cloudinary constants
        public const string ImagesFolder = "FruitifyPics/{0}s";

        // Controllers constants
        public const int ItemsPerPage = 8;
        public const int ItemsPerPageAdmin = 11;
        public const int MorePagesToShow = 2;
        public const string AllReceiptsTitleConst = "ВСИЧКИ РЕЦЕПТИ";
        public const string AllJuicesTitleConst = "ВСИЧКИ СОКОВЕ";
        public const string AllSaladsTitleConst = "ВСИЧКИ САЛАТИ";

        // Views constants
        public const int WeekProductsCount = 4;
    }
}
