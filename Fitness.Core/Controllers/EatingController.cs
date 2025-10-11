using Fitness.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.Core.Controllers
{
    public class EatingController : ControllerBase
    {
        private User _user;

        public List<Food> Foods { get; }
        public Eating Eating { get; }

        public EatingController(User user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight) 
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);

            if (product is null) 
            { 
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else 
            { 
                Eating.Add(product, weight);
            }
        }

        private List<Food> GetAllFoods() => Load<Food>();

        private Eating GetEating() => Load<Eating>().FirstOrDefault() ?? new Eating(_user);

        private void Save() => Save();
    }
}
