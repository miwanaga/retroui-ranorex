namespace RetroTests
{
    static class Methods
    {
        public static void Run()
        {
            UI.Click("rbModem");
            UI.Text("edtPort", "COM3");
            UI.Enabled("cmbBaud", true);
            UI.Enabled("swParity", true);
            UI.Click("rbLan");
            UI.Text("edtPort", "192.168.1.10:8080");
            UI.Enabled("cmbBaud", false);
            UI.Enabled("swParity", false);
            UI.Click("rbSerial");
            UI.Text("edtPort", "COM1");
            UI.Enabled("cmbBaud", true);
            UI.Enabled("swParity", true);
            UI.Toggle("swParity", true);
            UI.Toggle("swParity", false);
        }
    }
}
