using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
namespace RetroTests
{
    public static class Screenshots
    {
        private static readonly string Session = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + "_" +
                                                 System.Diagnostics.Process.GetCurrentProcess().Id;
        private static string caseName = "Startup";
        private static int sequence;
        public static void BeginCase(string name)
        {
            caseName = name;
            sequence = 0;
        }
        private static string ReportDirectory()
        {
            var environment = Ranorex.Core.Reporting.TestReport.ReportEnvironment;
            if (environment != null && !string.IsNullOrEmpty(environment.ReportViewFilePath))
            {
                return Path.GetDirectoryName(Path.GetFullPath(environment.ReportViewFilePath));
            }
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
        }

        public static void Capture(string label)
        {
            string folder = Path.Combine(ReportDirectory(), "Screenshots", Session, caseName);
            Directory.CreateDirectory(folder);
            string safe = label;
            foreach (char c in Path.GetInvalidFileNameChars())
                safe = safe.Replace(c, '_');
            string path = Path.Combine(folder, (++sequence).ToString("D3") + "_" + safe + ".png");
            // Capture the complete virtual desktop so modal dialogs and clipped edges remain visible.
            Rectangle bounds = SystemInformation.VirtualScreen;
            using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
                }
                bitmap.Save(path, ImageFormat.Png);
            }
            Console.WriteLine("SCREENSHOT: " + path);
        }
    }
}
