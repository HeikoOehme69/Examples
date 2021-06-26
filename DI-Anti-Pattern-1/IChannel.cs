using System;
using System.Collections.Generic;
using System.Text;

namespace Example
{
    /// <summary>
    /// Communication channel used for various transport layers
    /// </summary>
    interface IChannel
    {
        /// <summary>
        /// Send a command
        /// <paramref name="command">
        /// Command to be send
        /// </paramref>
        /// </summary>
        void Command(string command);
    }
}
