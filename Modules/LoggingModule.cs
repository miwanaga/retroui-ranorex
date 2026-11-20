using Ranorex.Core.Testing;

namespace RetroTests.Modules
{
    [TestModule("308bb84b-c70b-4016-a6ac-c94288831eb8", ModuleType.UserCode, 1)]
    public sealed class LoggingModule : ITestModule
    {
        public LoggingModule()
        {
        }

        void ITestModule.Run()
        {
            UI.Run("Logging", Logging.Run);
        }
    }
}
