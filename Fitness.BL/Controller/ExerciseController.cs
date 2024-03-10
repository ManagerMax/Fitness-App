using Fitness.BL.Logic;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    public class ExerciseController : ControllerBase //чтобы наследовать методы сериализации данных в файл и их десиарелизацию
    {
        private const string Excercise_File = "excercise.dat";
        private const string Activitie_File = "activitie.dat";
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
            return Load<List<Activity>>(Activitie_File) ?? new List<Activity>();
        }

        private List<Exercise> GetExercises()
        {
            return Load<List<Exercise>>(Excercise_File) ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(Excercise_File, Exercises);
            Save(Activitie_File, Activities);
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