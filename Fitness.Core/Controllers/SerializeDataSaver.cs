using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.Core.Controllers
{
    public class SerializeDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            var formatter = new BinaryFormatter();

            var fileName = typeof(T) + ".dat";

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<T> items)
                    return items;

                return new List<T>();
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            var formatter = new BinaryFormatter();

            var fileName = typeof(T) + ".dat";

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
