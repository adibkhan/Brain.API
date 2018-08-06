using Brain.API.Managers;
using Brain.API.Managers.Interfaces;
using Funq;

namespace Brain.API.Console
{
    public class ContainerManager
    {
        public static void Register(Container container)
        {
            // Autowiring dependencies
            container.Register<IConfigManager>(x => new ConfigManager());
            container.Register<IGroupManager>(x => new GroupManager(x.Resolve<IConfigManager>()));
            container.Register<IUserManager>(x => new UserManager(x.Resolve<IConfigManager>()));
            container.Register<IBrainManager>(x => new BrainManager(x.Resolve<IGroupManager>(), x.Resolve<IUserManager>()));

        }
    }
}
