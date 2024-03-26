[assembly: ExtensionApplication(typeof($safeprojectname$.ExtensionApplication))]

namespace $safeprojectname$
{
    internal class ExtensionApplication : IExtensionApplication
    {
        public void Initialize()
        {
            Application.Idle += OnIdle;
        }

        private void OnIdle(object? sender, EventArgs e)
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            if (doc != null)
            {
                Application.Idle -= OnIdle;
                doc.Editor.WriteMessage("\n$safeprojectname$ loaded.\n");
            }
        }

        public void Terminate()
        { }
    }
}
