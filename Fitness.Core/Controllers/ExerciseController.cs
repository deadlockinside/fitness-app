using Fitness.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.Core.Controllers
{
    public class ExerciseController : ControllerBase
    {
        private const string ExercisesFileName = "exercises.dat";
        private const string ActivitiesFileName = "activities.dat";

        private readonly User _user;

        public List<Exercise> Exercises;
        public List<Activity> Activities;

        public ExerciseController(User user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities() => Load<List<Activity>>(ActivitiesFileName) ?? new List<Activity>();

        public void Add(Activity activity, DateTime begin, DateTime end) 
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act is null) 
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, _user);
                Exercises.Add(exercise);
            }
            else 
            {
                var exercise = new Exercise(begin, end, act, _user);
                Exercises.Add(exercise);
            }

            Save();
        }

        private List<Exercise> GetAllExercises() => Load<List<Exercise>>(ExercisesFileName) ?? new List<Exercise>();

        private void Save()
        {
            Save(ExercisesFileName, Exercises);
            Save(ActivitiesFileName, Activities);
        }
    }
}
