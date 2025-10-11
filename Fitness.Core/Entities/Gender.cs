using Fitness.Core.Common;
using System;

namespace Fitness.Core.Entities
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }

        /// <summary>
        /// Название пола.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name"> Название пола. </param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(ExceptionMessages.InvalidGenderName, nameof(name));

            Name = name;
        }

        public Gender() { }
    }
}
