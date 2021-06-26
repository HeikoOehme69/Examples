using Autofac;
using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            Console.WriteLine(
            "Expected result is:\n" +
            "- heartbeat is sent over TCPIP\n" +
            "- diagnosis is sent over bluetooth\n");

            // At first we start with the example based on one single 
            // container.
            Console.WriteLine("Example1: All registering in the same container without any limitations\n");

            Monitor.RegisterWithoutAnything<TCPIPChannel, BluetoothChannel>(builder);

            using(var container = builder.Build())
            {
                var monitor = container.Resolve<Monitor>();
                monitor.Command();
            }

            Console.WriteLine();

            // Second we start with the example based on one single 
            // container with keyed reference
            Console.WriteLine("Example2: Registering in with keys\n");

            builder = new ContainerBuilder();

            Monitor.RegisterKeyBuilder<TCPIPChannel, BluetoothChannel>(builder);

            using (var container = builder.Build())
            {
                var monitor = container.Resolve<Monitor>();
                monitor.Command();
            }

            Console.WriteLine();

            // Third we start with the example based on one separated
            // lifescopes

            Console.WriteLine("Example3: Registering in with builders\n");

            builder = new ContainerBuilder();

            Monitor.RegisterWithBuilder<TCPIPChannel, BluetoothChannel>(builder);

            using (var container = builder.Build())
            {
                var monitor = container.Resolve<Monitor>();
                monitor.Command();
            }

            Console.WriteLine();
            Console.WriteLine("Press key to finish");
        }
    }
}
