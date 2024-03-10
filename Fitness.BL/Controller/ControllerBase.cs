using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    public abstract class ControllerBase
    {
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter(); //Вызываем инструмент форматирования
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate)) 
            {

                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)//Реализация для еды => небезопасна
                                                                          //нужно строить T через IEnumerable, так как доступ извне есть
                                                                          //и можно через тот же clear почистить весь list
                {
                    return items;
                }
                else
                {
                    return default(T);//иначе возвращаем пустой список 
                }
            }
        }
    }
}