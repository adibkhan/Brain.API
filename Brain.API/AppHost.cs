using System;
using Funq;
using ServiceStack;
using ServiceStack.Api.Swagger;
using Brain.API.ServiceDefinition;

namespace Brain.API
{
    public class AppHost : AppHostBase
    {

        public AppHost() : base(ServiceDefinitionInfo.Name, ServiceDefinitionInfo.Assembly) { }

        public override void Configure(Container container)
        {
            InitializePlugins(container);
            ContainerManager.Register(container);
        }

        private void InitializePlugins(Container container)
        {
            Plugins.Add(new SwaggerFeature());

        }
    }
}