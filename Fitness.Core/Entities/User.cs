using Fitness.Core.Common;
using System;

namespace Fitness.Core.Entities
{
    /// <summary>
    /// Пользователь приложения.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Вес пользователя.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост пользователя.
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя пользователя. </param>
        /// <param name="gender"> Пол пользователя. </param>
        /// <param name="birthdate"> Дата рождения пользователя. </param>
        /// <param name="weight"> Вес пользователя. </param>
        /// <param name="height"> Рост пользователя. </param>
        public User(string name, Gender gender, DateTime birthdate, double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(ExceptionMessages.InvalidUserName, nameof(name));

            if (gender is null)
                throw new ArgumentNullException(ExceptionMessages.InvalidGender, nameof(gender));

            if (birthdate < DateTime.Parse("01.01.1900") || birthdate > DateTime.Now)
                throw new ArgumentException(ExceptionMessages.InvalidBirthdate, nameof(birthdate));

            if (weight <= 0)
                throw new ArgumentException(ExceptionMessages.InvalidWeight, nameof(weight));

            if (height <= 0)
                throw new ArgumentException(ExceptionMessages.InvalidHeight, nameof(height));
            #endregion

            Name = name;
            Gender = gender;
            Birthdate = birthdate;
            Weight = weight;
            Height = height;
        }
    }
}
