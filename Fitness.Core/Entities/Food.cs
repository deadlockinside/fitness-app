using System;

namespace Fitness.Core.Entities
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Белки за 100 гр продукта.
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Жиры за 100 гр продукта.
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Углеводы за 100 гр продукта.
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// КАЛории за 100 гр продукта.
        /// </summary>
        public double Calories { get; set; }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food() { }

        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            // TODO: Проверка

            Name = name;
            Proteins = proteins / 100;
            Fats = fats / 100;
            Carbohydrates = carbohydrates / 100;
            Calories = calories / 100;
        }

        public override string ToString() => Name;
    }
}
