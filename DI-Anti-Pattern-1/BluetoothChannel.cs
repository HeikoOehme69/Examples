using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    /// <summary>
    /// Implementation of a bluetooth channel
    /// </summary>
    class BluetoothChannel : IChannel
    {
        public void Command(string command)
        {
            Console.WriteLine($"Bluetooth: {command}");
        }
    }
}
