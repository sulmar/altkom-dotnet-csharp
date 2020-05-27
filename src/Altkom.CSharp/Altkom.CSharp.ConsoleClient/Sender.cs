using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.CSharp.ConsoleClient
{
    public class Sender
    {        
        public void Send(string message)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sending... {message}");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sent.");
        }
    }
}
