using Ranorex.Core.Testing;

namespace RetroTests.Modules
{
    [TestModule("0e163353-8afb-42fb-9ada-5064b43fc1f0", ModuleType.UserCode, 1)]
    public sealed class InitialModule : ITestModule
    {
        public InitialModule()
        {
        }

        void ITestModule.Run()
        {
            UI.Run("Initial", Initial.Run);
        }
    }
}
