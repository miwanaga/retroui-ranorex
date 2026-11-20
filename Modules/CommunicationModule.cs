using Ranorex.Core.Testing;

namespace RetroTests.Modules
{
    [TestModule("747e16b2-1401-4299-85ff-3e4ba468d09f", ModuleType.UserCode, 1)]
    public sealed class CommunicationModule : ITestModule
    {
        public CommunicationModule()
        {
        }

        void ITestModule.Run()
        {
            UI.Run("Communication", Communication.Run);
        }
    }
}
