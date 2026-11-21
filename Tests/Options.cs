using System.IO;

namespace RetroTests
{
    static class Options
    {
        public static void Run()
        {
            const string path = @"C:\work\RetroUI\retroui_win10.log";
            bool existed = File.Exists(path);
            byte[] original = existed ? File.ReadAllBytes(path) : null;
            try
            {
                UI.Toggle("swLog", true);
                UI.Check(bool.Parse(UI.Attr("btnOpenLog", "visible")), "open log visible");
                UI.Toggle("swLog", false);
                UI.Toggle("swWarn", false);
                UI.Toggle("swWarn", true);
                UI.Toggle("swFull", true);
                UI.Check(Ranorex.Host.Local.FindSingle<Ranorex.Form>(UI.Root, 10000)
                                 .Element.GetAttributeValueText("state") == "Maximized",
                         "maximized");
                UI.Toggle("swFull", false);
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
