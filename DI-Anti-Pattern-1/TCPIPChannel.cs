using Autofac;
using System;

namespace Example
{
    /// <summary>
    /// Implementation of a TCPIP channel
    /// </summary>
    class TCPIPChannel : IChannel
    {
        public void Command(string command)
        {
            Console.WriteLine($"TCPIP: {command}");
        }
    }
}
