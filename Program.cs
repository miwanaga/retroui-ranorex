using System;
using Ranorex;
using Ranorex.Core.Testing;

namespace RetroTests
{
    internal static class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            Keyboard.AbortKey = System.Windows.Forms.Keys.Pause;
            try
            {
                return TestSuiteRunner.Run(typeof(Program), Environment.CommandLine);
            }
            catch (Exception exception)
            {
                Report.Error(exception.ToString());
                return -1;
            }
        }
    }
}
