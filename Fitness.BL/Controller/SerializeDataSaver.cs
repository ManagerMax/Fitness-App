using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    class SerializeDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            var formatter = new BinaryFormatter(); //Вызываем инструмент форматирования
            var fileName = typeof(T).Name;

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {

                if (fs.Length > 0 && formatter.Deserialize(fs) is List<T> items)//Реализация для еды => небезопасна
                                                                          //нужно строить T через IEnumerable, так как доступ извне есть
                                                                         //и можно через тот же clear почистить весь list
                {
                    return items;
                }
                else
                {
                    return new List<T>();//иначе возвращаем пустой список 
                }
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            var fileName = typeof(T).Name;
            var formatter = new BinaryFormatter(); //Вызываем инструмент форматирования

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}   