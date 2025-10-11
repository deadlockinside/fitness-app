using Fitness.Core.Common;
using Fitness.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.Core.Controllers
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователи приложения.
        /// </summary>
        public List<User> Users { get; set; }

        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создать новый контроллер пользователя.
        /// </summary>
        /// <param name="userName"> Пользователь приложения. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException(ExceptionMessages.InvalidUserName, nameof(userName));

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault( u => u.Name == userName);

            if (CurrentUser is null) 
            { 
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
                    return users;

                return new List<User>();
            }
        }

        public void SetNewUserData(string genderName, DateTime birthdate, double weight = ValidationRules.MinWeight, double height = ValidationRules.MinHeight) 
        {
            // TODO: Проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.Birthdate = birthdate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save() 
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate)) 
            {
                formatter.Serialize(fs, Users);
            }
        }
    }
}
