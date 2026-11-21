using System.IO;

namespace RetroTests
{
    static class Options
    {
        public static void Run()
        {
            const string path = @"C:\work\RetroUI\retroui_modern.log";
            bool existed = File.Exists(path);
            byte[] original = existed ? File.ReadAllBytes(path) : null;
            try
            {
                UI.Toggle("chkLog", true);
                UI.Check(bool.Parse(UI.Attr("btnOpenLog", "visible")), "open log visible");
                UI.Toggle("chkLog", false);
                UI.Toggle("chkWarn", false);
                UI.Toggle("chkWarn", true);
                UI.Toggle("chkFull", true);
                UI.Check(Ranorex.Host.Local.FindSingle<Ranorex.Form>(UI.Root, 10000)
                                 .Element.GetAttributeValueText("state") == "Maximized",
                         "maximized");
                UI.Toggle("chkFull", false);
                UI.Check(Ranorex.Host.Local.FindSingle<Ranorex.Form>(UI.Root, 10000)
                                 .Element.GetAttributeValueText("state") == "Normal",
                         "normal");
            }
            finally
            {
                if (existed)
                    File.WriteAllBytes(path, original);
                else if (File.Exists(path))
                    File.Delete(path);
            }
        }
    }
}
