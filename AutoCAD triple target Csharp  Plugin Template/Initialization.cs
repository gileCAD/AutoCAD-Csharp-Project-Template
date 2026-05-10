using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AcCoreAp = Autodesk.AutoCAD.ApplicationServices.Core.Application;

[assembly: ExtensionApplication(typeof($safeprojectname$.Initialization))]

namespace $safeprojectname$
{
    internal class Initialization : IExtensionApplication
    {
        public void Initialize()
        {
            AcCoreAp.Idle += OnIdle;
        }

        private void OnIdle(object sender, EventArgs e)
        {
            var doc = AcCoreAp.DocumentManager.MdiActiveDocument;
            if (doc != null)
            {
                AcCoreAp.Idle -= OnIdle;
				try
				{
                    doc.Editor.WriteMessage("\n$projectname$ loaded.\n");
				}
				catch (System.Exception ex)
				{
					doc.Editor.WriteMessage($"\nError: {ex.Message}\n");
				}
            }
        }

        public void Terminate()
        { }
    }
}
