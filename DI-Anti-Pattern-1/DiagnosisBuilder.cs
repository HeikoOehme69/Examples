using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    class DiagnosisBuilder<TChannel>
    {
        ILifetimeScope _Scope;

        public DiagnosisBuilder()
        {
            var builder = new ContainerBuilder();
            DiagnosisMonitor.Register<TChannel>(builder);
            _Scope = builder.Build();
        }

        public DiagnosisMonitor Create() =>_Scope.Resolve<DiagnosisMonitor>(); 

        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<DiagnosisBuilder<TChannel>>().SingleInstance();
            builder.Register(scope => scope.Resolve<DiagnosisBuilder<TChannel>>().Create());
        }
    }
}
