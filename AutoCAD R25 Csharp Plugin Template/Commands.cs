[assembly: CommandClass(typeof($safeprojectname$.Commands))]

namespace $safeprojectname$
{
    public class Commands
    {
        [CommandMethod("Test")]
        public static void Test()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;

            using var tr = db.TransactionManager.StartTransaction();

            tr.Commit();
        }
    }
}
