using Fitness.Core.Entities;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.Core.Controllers
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Создать новый контроллер пользователя.
        /// </summary>
        /// <param name="user"> Пользователь приложения. </param>
        public UserController(string userName, string genderName, DateTime birthdate, double weight, double height)
        {
            // TODO: Проверка

            var gender = new Gender(genderName);
            User = new User(userName, gender, birthdate, weight, height);
        }

        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                    User = user;

                // TODO: Что делать если пользователя не прочитали?
            }
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save() 
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate)) 
            {
                formatter.Serialize(fs, User);
            }
        }
    }
}
