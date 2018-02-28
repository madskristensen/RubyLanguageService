using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using RubyLanguageService.ToolWindow;
using Task = System.Threading.Tasks.Task;

namespace RubyLanguageService
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ReferenceWindow), Style = VsDockStyle.Tabbed, Window = ReferenceWindow.WindowGuidString)]
    [Guid(VSPackage.PackageGuidString)]
    public sealed class VSPackage : AsyncPackage
    {
        public const string PackageGuidString = "ff4f80de-da63-4ca8-9f09-acf70fdc5cb5";

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // Switch to main thread to register commands
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            await ReferenceWindowsCommand.InitializeAsync(this);
        }

        public override IVsAsyncToolWindowFactory GetAsyncToolWindowFactory(Guid toolWindowType)
        {
            if (toolWindowType.Equals(new Guid(ReferenceWindow.WindowGuidString)))
            {
                return this;
            }

            return null;
        }

        protected override string GetToolWindowTitle(Type toolWindowType, int id)
        {
            if (toolWindowType == typeof(ReferenceWindow))
            {
                return ReferenceWindow.Title;
            }

            return base.GetToolWindowTitle(toolWindowType, id);
        }

        /// <summary>
        /// Returns an object that is passed into the constructor of <see cref="ReferenceWindow"/>.
        /// </summary>
        protected override async Task<object> InitializeToolWindowAsync(Type toolWindowType, int id, CancellationToken cancellationToken)
        {
            await Task.Delay(4000); // simulate long running initialization
            return ReferenceWindow.Title;
        }
    }
}
