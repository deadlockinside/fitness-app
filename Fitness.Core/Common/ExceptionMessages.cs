namespace Fitness.Core.Common
{
    /// <summary>
    /// Здесь собраны текста сообщений об ошибках.
    /// </summary>
    public static class ExceptionMessages
    {
        public const string InvalidUserName = "Имя не может быть пустым.";
        public const string InvalidGenderName = "Название пола не может быть пустым.";
        public const string InvalidGender = "Пол не может быть пустым.";
        public const string InvalidBirthdate = "Невозможная дата рождения.";
        public const string InvalidWeight = "Вес не может быть меньше или равен нулю.";
        public const string InvalidHeight = "Рост не может быть меньше или равен нулю.";
    }
}
