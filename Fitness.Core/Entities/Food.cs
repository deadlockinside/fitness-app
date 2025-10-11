using System;

namespace Fitness.Core.Entities
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки за 100 гр продукта.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры за 100 гр продукта.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеводы за 100 гр продукта.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// КАЛории за 100 гр продукта.
        /// </summary>
        public double Calories { get; }

        private double _caloriesByOneGramm => Calories / 100;
        private double _proteinsByOneGramm => Proteins / 100;
        private double _fatsByOneGramm => Fats / 100;
        private double _carbohydrates => Carbohydrates / 100;

        public Food(string name) : this(name, 0, 0, 0, 0) { }

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
