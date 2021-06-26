using Autofac;

namespace Example
{
    /// <summary>
    /// Implementation of a hearbeat monitor
    /// </summary>
    class HeartbeatMonitor
    {
        IChannel _channel;

        public HeartbeatMonitor(IChannel channel)
        {
            _channel = channel;
        }

        public void Command()
        {
            _channel.Command("Send me a heartbeat");
        }

        public static void Register<TChannel>(ContainerBuilder builder)
        {
            builder.RegisterType<TChannel>().As<IChannel>();
            builder.RegisterType<HeartbeatMonitor>();
        }

        public static void RegisterWithKey<TChannel>(ContainerBuilder builder, string key)
        {
            builder.RegisterType<TChannel>().Keyed<IChannel>(key);
            builder.Register(ctx => new HeartbeatMonitor(ctx.ResolveKeyed<IChannel>(key)));
        }
    }
}
