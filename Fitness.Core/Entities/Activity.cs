using System;

namespace Fitness.Core.Entities
{
    [Serializable]
    public class Activity
    { 
        public string Name { get; }

        public double CaloriesPerMinute { get; set; }

        public Activity(string name, double caloriesPerMinute)
        {
            // TODO: Проверка

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString() => Name;
    }
}
