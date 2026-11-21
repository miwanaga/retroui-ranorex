using System;
using System.IO;
using System.Text;
namespace RetroTests
{
    static class Logging
    {
        const string PathName = @"C:\work\RetroUI\retroui_modern.log";
        static string Read()
        {
            return File.ReadAllText(PathName, Encoding.UTF8);
        }
        public static void Run()
        {
            bool existed = File.Exists(PathName);
            byte[] original = existed ? File.ReadAllBytes(PathName) : null;
            try
            {
                UI.Toggle("chkLog", true);
                UI.Check(Read().Contains("初期化が完了しました"), "saving includes initialization history");
                UI.Start();
                UI.Wait(() => Read().Contains("[CRC OK]"), 10, "packet reception missing");
                UI.Stop();
                var saved = Read();
                UI.Check(saved.Contains("通信開始: COM1"), "start logged");
                UI.Check(saved.Contains("ユーザーにより中止されました"), "stop logged");
                UI.Toggle("chkLog", false);
                var bytes = File.ReadAllText(PathName, Encoding.UTF8);
                UI.Start();
                UI.Stop();
                UI.Check(Read() == bytes, "logging disabled leaves file unchanged");
                UI.Toggle("chkLog", true);
                UI.Check(Read().Length > saved.Length, "enabling logging saves accumulated history");
                UI.Toggle("chkLog", false);
            }
            finally
            {
                if (existed)
                    File.WriteAllBytes(PathName, original);
                else if (File.Exists(PathName))
                    File.Delete(PathName);
            }
        }
    }
}
