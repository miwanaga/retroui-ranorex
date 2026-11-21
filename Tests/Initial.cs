using Ranorex;
namespace RetroTests
{
    static class Initial
    {
        public static void Run()
        {
            UI.Enabled("btnExec", true);
            UI.Enabled("btnStop", false);
            UI.Text("edtPort", "COM1");
            UI.Text("cmbBaud", "38400");
            foreach (var pair in new[] { new { Name = "swAuto", Value = true }, new { Name = "swLog", Value = false },
                                         new { Name = "swWarn", Value = true },
                                         new { Name = "swFull", Value = false },
                                         new { Name = "swParity", Value = false } })
            {
                var c = Host.Local.FindSingle<CheckBox>(UI.Root + "//*[@name='" + pair.Name + "']", 10000);
                UI.Check(c.Checked == pair.Value, "initial " + pair.Name);
            }
            UI.StatusText(1, "準備完了");
            UI.StatusText(2, "通信状態: 停止中");
            UI.StatusText(3, "経過時間 00:00:00");
        }
    }
}
