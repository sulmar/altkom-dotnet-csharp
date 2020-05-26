using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.CSharp.ConsoleClient
{

    public class PrinterEventArgs : EventArgs
    {
        public int Level { get; private set; }

        public PrinterEventArgs(int level)
        {
            this.Level = level;
        }
    }

    public class LaserPrinter
    {
        public void Print(string barcode, int copies = 1)
        {
            for (int copy = 0; copy < copies; copy++)
            {
                WriteLog($"Printing... {barcode}");            

                Thread.Sleep(TimeSpan.FromSeconds(1));

                WriteLog("Printed.");
            }

            // decimal cost = copies * 0.99m;

            decimal? cost = CalculateCost?.Invoke(copies);

            if (cost.HasValue)
            {
                WriteLog($"Cost {cost}");
            }

            PaperOut?.Invoke();

            LowLevel?.Invoke(this, new PrinterEventArgs(50));


        }

        //public delegate void LogDelegate(string message);
        //public LogDelegate Log { get; set; }

        public Action<string> Log { get; set; }

        //public delegate decimal CalculateCostDelegate(int copies);
        //public CalculateCostDelegate CalculateCost { get; set; }

        public Func<int, decimal> CalculateCost { get; set; }

        public delegate void PaperOutDelegate();
        public event PaperOutDelegate PaperOut;

        //public delegate void LowLevelDelegate(object sender, EventArgs args);
        //public event LowLevelDelegate LowLevel;

        // public event EventHandler LowLevel;

        //public delegate void LowLevelDelegate(object sender, PrinterEventArgs args);
        //public event LowLevelDelegate LowLevel;

        public event EventHandler<PrinterEventArgs> LowLevel;

        private void WriteLog(string message)
        {
            Delegate[] delegates = Log?.GetInvocationList();

            Log?.Invoke(message);
        }
    }

    public class Printer
    {
        public void Print(string barcode)
        {
            LogConsole($"Printing... {barcode}");
            LogFile($"Printing... {barcode}");
            LogEmail($"Printing... {barcode}");

            Thread.Sleep(TimeSpan.FromSeconds(1));

            LogConsole("Printed.");
            LogFile("Printed.");
            LogEmail("Printed.");
        }

        private void LogConsole(string message)
        {
            Console.WriteLine(message);
        }

        private void LogFile(string message)
        {
            File.AppendAllText(@"c:\temp\altkom.log", message);
        }

        private void LogEmail(string message)
        {
            Console.WriteLine($"Send email {message}");
        }

    }
}
