using Ranorex.Core.Testing;

namespace RetroTests.Modules
{
    [TestModule("eacb9ddf-4879-4292-8e77-e282875b6fc0", ModuleType.UserCode, 1)]
    public sealed class DialogsModule : ITestModule
    {
        public DialogsModule()
        {
        }

        void ITestModule.Run()
        {
            UI.Run("Dialogs", Dialogs.Run);
        }
    }
}
