using System.Collections.Generic;

namespace Fitness.Core.Controllers
{
    public abstract class ControllerBase
    {
        protected IDataSaver manager = new DatabaseDataSaver();

        protected void Save<T>(List<T> item) where T : class => manager.Save(item);

        protected List<T> Load<T>() where T : class => manager.Load<T>();
    }
}
