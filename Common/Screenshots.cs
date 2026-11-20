using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
namespace RetroTests {
 public static class Screenshots {
  private static readonly string Session = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + "_" + System.Diagnostics.Process.GetCurrentProcess().Id;
  private static string caseName = "Startup";
  private static int sequence;
  public static void BeginCase(string name) { caseName = name; sequence = 0; }
  private static string ProjectRoot() {
   var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
   while (directory != null) {
    if (File.Exists(Path.Combine(directory.FullName, "RetroUID7Ranorex.csproj"))) return directory.FullName;
    directory = directory.Parent;
   }
   throw new DirectoryNotFoundException("Cannot locate RetroUID7Ranorex.csproj above executable; run from the project bin folder.");
  }
  public static void Capture(string label) {
   string folder = Path.Combine(ProjectRoot(), "Screenshots", Session, caseName);
   Directory.CreateDirectory(folder);
   string safe = label;
   foreach (char c in Path.GetInvalidFileNameChars()) safe = safe.Replace(c, '_');
   string path = Path.Combine(folder, (++sequence).ToString("D3") + "_" + safe + ".png");
   // Capture the complete virtual desktop so modal dialogs and clipped edges remain visible.
   Rectangle bounds = SystemInformation.VirtualScreen;
   using (var bitmap = new Bitmap(bounds.Width, bounds.Height)) {
    using (Graphics graphics = Graphics.FromImage(bitmap)) {
     graphics.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
    }
    bitmap.Save(path, ImageFormat.Png);
   }
   Console.WriteLine("SCREENSHOT: " + path);
  }
 }
}
