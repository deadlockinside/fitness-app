using System.Collections.Generic;

namespace Fitness.Core.Controllers
{
    public interface IDataSaver
    {
        void Save<T>(List<T> item) where T : class;
        List<T> Load<T>() where T : class;
    }
}
