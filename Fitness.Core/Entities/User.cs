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
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        public int GenderId { get; set; }

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        public virtual Gender Gender { get; set; }

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

        /// <summary>
        /// Возраст пользователя.
        /// </summary>
        public int Age 
        { 
            get 
            {
                DateTime nowDate = DateTime.Today;

                int age = nowDate.Year - Birthdate.Year;

                if (Birthdate > nowDate.AddYears(-age))
                    age--;

                return age;
            } 
        }
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

            if (birthdate < DateTime.Parse(ValidationRules.MinBirthdate) || birthdate > DateTime.Now)
                throw new ArgumentException(ExceptionMessages.InvalidBirthdate, nameof(birthdate));

            if (weight < ValidationRules.MinWeight)
                throw new ArgumentException(ExceptionMessages.InvalidWeight, nameof(weight));

            if (height < ValidationRules.MinHeight)
                throw new ArgumentException(ExceptionMessages.InvalidHeight, nameof(height));
            #endregion

            Name = name;
            Gender = gender;
            Birthdate = birthdate;
            Weight = weight;
            Height = height;
        }

        public User() { } // для EF у моделей такой конструктор ВСЕГДА

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(ExceptionMessages.InvalidUserName, nameof(name));

            Name = name;
        }

        public override string ToString() => Name + " " + Age;
    }
}
