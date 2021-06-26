using Autofac;

namespace Example
{
    class DiagnosisMonitor
    {
        IChannel _channel;

        public DiagnosisMonitor(IChannel channel)
        {
            _channel = channel;
        }

        public void Command()
        {
            _channel.Command("Send me a diagnosis");
        }

        public static void Register<TChannel>(ContainerBuilder builder)
        {
            builder.RegisterType<TChannel>().As<IChannel>();
            builder.RegisterType<DiagnosisMonitor>();
        }

        public static void RegisterWithKey<TChannel>(ContainerBuilder builder, string key)
        {
            builder.RegisterType<TChannel>().Keyed<IChannel>(key);
            builder.Register(ctx => new DiagnosisMonitor(ctx.ResolveKeyed<IChannel>(key)));
        }
    }
}
