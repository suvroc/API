using System.Windows.Forms;

namespace AnyStatus.API
{
    public class FolderEditor : FileEditor
    {
        protected override string GetPath()
        {
            var folderBrowser = new FolderBrowserDialog();

            folderBrowser.ShowDialog();

            return folderBrowser.SelectedPath;
        }
    }
}