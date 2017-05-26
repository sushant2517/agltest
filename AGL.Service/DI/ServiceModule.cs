using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AGL.Service.Concretes;
using AGL.Service.Contracts;
using Autofac;

namespace AGL.Service.DI
{
    public class ServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new HttpClientHandler()).As<HttpMessageHandler>().SingleInstance();
            builder.RegisterType<PeopleDataService>().As<IPeopleDataService>().InstancePerLifetimeScope();
        }
    }
}
