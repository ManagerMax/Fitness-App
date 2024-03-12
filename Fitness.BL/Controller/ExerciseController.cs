using CodeBlogFitness.BL.Controller;
using Fitness.BL.Logic;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class ExerciseController : ControllerBase //чтобы наследовать методы сериализации данных в файл и их десиарелизацию
    {
        public List<Exercise> Exercises;
        public List<Activity> Activities;
        private readonly User user;

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть null", nameof(user));

            Exercises = GetExercises();
            Activities = GetActivities();
        }

        private List<Activity> GetActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        private List<Exercise> GetExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }

        public void Add (Activity activity, DateTime begin, DateTime finish)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            
            if (act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, finish, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, finish, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }
    }
}