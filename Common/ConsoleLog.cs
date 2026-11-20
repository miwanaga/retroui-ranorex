using System;
using System.IO;
using System.Text;
using Ranorex.Core.Reporting;

namespace RetroTests
{
    internal sealed class ConsoleLog : IDisposable
    {
        private readonly TextWriter originalOut = Console.Out;
        private readonly TextWriter originalError = Console.Error;
        private readonly StringBuilder pending = new StringBuilder();
        private readonly object gate = new object();
        private StreamWriter file;

        public ConsoleLog()
        {
            Console.SetOut(new MirrorWriter(this, originalOut));
            Console.SetError(new MirrorWriter(this, originalError));
        }

        public void BindReport()
        {
            lock (gate)
            {
                if (file != null) return;
                var environment = TestReport.ReportEnvironment;
                if (environment == null || string.IsNullOrEmpty(environment.ReportViewFilePath)) return;
                string path = Path.ChangeExtension(environment.ReportViewFilePath, ".txt");
                Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(path)));
                file = new StreamWriter(path, false, new UTF8Encoding(true));
                file.NewLine = "\r\n";
                file.AutoFlush = true;
                file.Write(pending.ToString());
                pending.Clear();
                originalOut.WriteLine("Console log: " + path);
            }
        }

        public void Dispose()
        {
            Console.SetOut(originalOut);
            Console.SetError(originalError);
            lock (gate)
            {
                if (file != null) file.Dispose();
                else originalError.WriteLine("Console log was not saved because Ranorex did not initialize a report.");
            }
        }

        private sealed class MirrorWriter : TextWriter
        {
            private readonly ConsoleLog owner;
            private readonly TextWriter destination;
            public MirrorWriter(ConsoleLog owner, TextWriter destination)
            {
                this.owner = owner;
                this.destination = destination;
                NewLine = "\r\n";
            }
            public override Encoding Encoding { get { return Encoding.UTF8; } }
            public override void Write(char value)
            {
                lock (owner.gate)
                {
                    destination.Write(value);
                    if (owner.file == null) owner.pending.Append(value);
                    else owner.file.Write(value);
                }
            }
            public override void Write(string value)
            {
                lock (owner.gate)
                {
                    destination.Write(value);
                    if (owner.file == null) owner.pending.Append(value);
                    else owner.file.Write(value);
                }
            }
            public override void Flush()
            {
                lock (owner.gate)
                {
                    destination.Flush();
                    if (owner.file != null) owner.file.Flush();
                }
            }
        }
    }
}
