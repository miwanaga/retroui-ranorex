namespace RetroTests
{
    static class Communication
    {
        public static void Run()
        {
            foreach (var method in new[] { "rbSerial", "rbModem", "rbLan" })
            {
                UI.Click(method);
                UI.Start();
                var before = UI.Status(3);
                UI.Wait(() => UI.Status(3) != before, 5, "elapsed time did not advance");
                UI.Click("btnStop");
                UI.Confirm(false);
                UI.Enabled("btnStop", true);
                UI.Enabled("btnExec", false);
                UI.Stop();
                UI.Start();
                UI.Stop();
            }
        }
    }
}
