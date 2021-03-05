using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PathVisualizer
{

    /// <summary>
    /// Button that stores a <see cref="DirectoryInfo"/> as a data context.
    /// When clicked on this button, it will open Windows explorer in the folder
    /// represented by the DirectoryInfo. If it represents a file, it will be
    /// selected. New instance of Windows explorer is opened on each click.
    /// </summary>
    internal class FileOpenButton : Button
    {
        private readonly DirectoryInfo _directoryInfo;

        internal FileOpenButton(DirectoryInfo directoryInfo)
        {
            this._directoryInfo = directoryInfo;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (File.Exists(_directoryInfo.FullName))
                Process.Start("explorer.exe", "/select," + _directoryInfo.FullName);
            else
                Process.Start("explorer.exe", "/n," + _directoryInfo.FullName);
        }

    }
}
