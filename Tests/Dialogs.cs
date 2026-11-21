namespace RetroTests
{
    static class Dialogs
    {
        public static void Run()
        {
            UI.Click("btnHelp");
            Ranorex.Host.Local
                .FindSingle<Ranorex.Button>(
                    "/form[@processname='RetroUID13Win10' and @class='TMessageForm']//button[@text='OK']", 10000)
                .Click();
            UI.Click("btnClose");
            UI.Confirm(false);
            UI.Enabled("btnExec", true);
            UI.Start();
            UI.Click("btnClose");
            UI.Confirm(false);
            UI.Enabled("btnStop", true);
            UI.Click("btnClose");
            UI.Confirm(true);
            UI.Wait(() => !Ranorex.Host.Local.TryFindSingle<Ranorex.Form>(UI.Root, out remaining), 5,
                    "application did not close");
        }
        static Ranorex.Form remaining;
    }
}
