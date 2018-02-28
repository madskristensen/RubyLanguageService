using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using RubyLanguageService.ToolWindow;
using Task = System.Threading.Tasks.Task;

namespace RubyLanguageService
{
    internal static class ReferenceWindowsCommand
    {
        public const int CommandId = 0x0100;
        public static readonly Guid CommandSet = new Guid("35933dd5-e131-401e-8b2c-17338f1b804c");

        public static async Task InitializeAsync(AsyncPackage package)
        {
            var commandService = (IMenuCommandService)await package.GetServiceAsync(typeof(IMenuCommandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand((sender, e) => ShowToolWindow(package, sender, e), menuCommandID);
            commandService.AddCommand(menuItem);
        }

        private static void ShowToolWindow(AsyncPackage package, object sender, EventArgs e)
        {
            package.JoinableTaskFactory.RunAsync(async () =>
            {
                ToolWindowPane window = await package.ShowToolWindowAsync(
                    typeof(ReferenceWindow),
                    0,
                    create: true,
                    cancellationToken: package.DisposalToken);
            });
        }
    }
}
