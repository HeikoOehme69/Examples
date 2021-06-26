using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    class HeartbeatBuilder<TChannel>
    {
        ILifetimeScope _Scope;

        public HeartbeatBuilder()
        {
            var builder = new ContainerBuilder();
            HeartbeatMonitor.Register<TChannel>(builder);
            _Scope = builder.Build();
        }

        public HeartbeatMonitor Create() => _Scope.Resolve<HeartbeatMonitor>(); 

        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<HeartbeatBuilder<TChannel>>().SingleInstance();
            builder.Register(scope => scope.Resolve<HeartbeatBuilder<TChannel>>().Create());
        }
    }
}
