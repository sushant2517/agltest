using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGL.Service.DI;
using Autofac;

namespace AGL.App.DI
{
    public class AppModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<ServiceModule>();
            builder.RegisterType<Processor>().AsSelf().InstancePerLifetimeScope();
        }
    }
}
