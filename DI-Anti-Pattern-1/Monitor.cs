using Autofac;
using Autofac.Core;

namespace Example
{
    /// <summary>
    /// Monitor class that provides monitoring of complex systems
    /// </summary>
    class Monitor
    {
        HeartbeatMonitor _heartbeat;
        DiagnosisMonitor _diagnosis;

        public Monitor(HeartbeatMonitor heartbeat,
                       DiagnosisMonitor diagnosis)
        {
            _heartbeat = heartbeat;
            _diagnosis = diagnosis;
        }1

        public void Command()
        {
            _heartbeat.Command();
            _diagnosis.Command();
        }

        public static void RegisterWithoutAnything<TChannelHeartbeat, TChannelDiagnosis>(ContainerBuilder builder)
        {
            DiagnosisMonitor.Register<TChannelDiagnosis>(builder);
            HeartbeatMonitor.Register<TChannelHeartbeat>(builder);
            builder.RegisterType<Monitor>();
        }

        public static void RegisterKeyBuilder<TChannelHeartbeat, TChannelDiagnosis>(ContainerBuilder builder)
        {
            DiagnosisMonitor.RegisterWithKey<TChannelDiagnosis>(builder, "Diagnosis");
            HeartbeatMonitor.RegisterWithKey<TChannelHeartbeat>(builder, "Heartbeat");
            builder.RegisterType<Monitor>();
        }

        public static void RegisterWithBuilder<TChannelHeartbeat, TChannelDiagnosis>(ContainerBuilder builder)
        {
            DiagnosisBuilder<TChannelDiagnosis>.Register(builder);
            HeartbeatBuilder<TChannelHeartbeat>.Register(builder);
            builder.RegisterType<Monitor>();
        }
    }
}
