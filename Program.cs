using RetroTests;
class Program
{
    [System.STAThread] static int Main()
    {
        try
        {
            UI.Run("Initial",Initial.Run);
            UI.Run("Methods",Methods.Run);
            UI.Run("Communication",Communication.Run);
            UI.Run("Options",Options.Run);
            UI.Run("Logging",Logging.Run);
            UI.Run("Dialogs",Dialogs.Run);
            return 0;
        }
        catch(System.Exception e)
        {
            System.Console.Error.WriteLine(e);
            return 1;
        }
    }
}
