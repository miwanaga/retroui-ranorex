using System;
using Ranorex;
using Ranorex.Core.Testing;

namespace RetroTests
{
    internal static class Program
    {
        internal static ConsoleLog Log;
        [STAThread]
        public static int Main(string[] args)
        {
            Keyboard.AbortKey = System.Windows.Forms.Keys.Pause;
            using (Log = new ConsoleLog())
            {
            try
            {
                return TestSuiteRunner.Run(typeof(Program), Environment.CommandLine);
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine(exception);
                Report.Error(exception.ToString());
                return -1;
            }
            finally
            {
                Log.BindReport();
            }
            }
        }
    }
}
