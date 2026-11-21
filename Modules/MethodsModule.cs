using Ranorex.Core.Testing;

namespace RetroTests.Modules
{
    [TestModule("1ceff938-9bc2-47b2-a1bd-3659efbe61e9", ModuleType.UserCode, 1)]
    public sealed class MethodsModule : ITestModule
    {
        public MethodsModule()
        {
        }

        void ITestModule.Run()
        {
            UI.Run("Methods", Methods.Run);
        }
    }
}
