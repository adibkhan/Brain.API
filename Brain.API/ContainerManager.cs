using Funq;
using Brain.API.Managers.Interfaces;
using Brain.API.Managers;

namespace Brain.API
{
    public class ContainerManager
    {
        public static void Register (Container container)
        {
            container.Register<IConfigManager>(x => new ConfigManager());

            container.Register<IBrainManager>(x => new BrainManager(x.Resolve<IConfigManager>()));
        }

    }
}