using Brain.API.ServiceDefinition;
using Funq;
using ServiceStack;
using ServiceStack.Api.Swagger;

namespace Brain.API.Console
{
    public class AppHost : AppSelfHostBase
    {
        public AppHost() : base(ServiceDefinitionInfo.Name, ServiceDefinitionInfo.Assembly) { }

        public override void Configure(Container container)
        {
            ContainerManager.Register(container);
            InitializePlugins(container);
        }

        private void InitializePlugins(Container container)
        {
            Plugins.Add(new SwaggerFeature());

        }
    }
}
