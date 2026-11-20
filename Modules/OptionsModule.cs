using Ranorex.Core.Testing;

namespace RetroTests.Modules
{
    [TestModule("3928e2d4-0fc5-4a86-a71a-c32628227347", ModuleType.UserCode, 1)]
    public sealed class OptionsModule : ITestModule
    {
        public OptionsModule()
        {
        }

        void ITestModule.Run()
        {
            UI.Run("Options", Options.Run);
        }
    }
}
