using Fitness.BL.Logic;
using System;

namespace Fitness.BL.Model
{
    [Serializable] //так как будем сериализовать данные в файл 
    public class Exercise
    {
        #region свойства
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        #endregion

        /// <summary>
        /// Конструктор Exercise
        /// </summary>
        /// <param name="Start"> Время начала упражнения </param>
        /// <param name="Finish"> Время окончания упражнения </param>
        /// <param name="Activity"> Наименование активности </param>
        /// <param name="user"> Пользователь </param>
        /// 
        public Exercise() { }
        public Exercise (DateTime Start, DateTime Finish, Activity Activity, User user)
        {
            //TODO: ПРОВЕРКА

            this.Start = Start;
            this.Finish = Finish;
            this.Activity = Activity;
            User = user;
        }
    }
}