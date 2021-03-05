using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Windows.Forms;
using System.IO;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(PathVisualizer.DebuggerSide),
    typeof(VisualizerObjectSource),
    Target = typeof(System.String),
    Description = "Visualizes the string (if possible) as a clickable path that opens explorer.")]

namespace PathVisualizer
{

    internal static class Extensions
    {
        internal static List<DirectoryInfo> Split(this DirectoryInfo path)
        {
            if (path == null) throw new ArgumentNullException("path");
            var ret = new List<DirectoryInfo>();
            if (path.Parent != null) ret.AddRange(Split(path.Parent));
            ret.Add(path);
            return ret;
        }
    }


    public class DebuggerSide : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            ShowForm(objectProvider.GetObject().ToString());
        }

        public static void TestShowVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(DebuggerSide));
            visualizerHost.ShowVisualizer();
        }

        private static void ShowForm(string text)
        {
            if (!(File.Exists(text) || Directory.Exists(text)))
                return;

            DirectoryInfo di = new DirectoryInfo(text);
            List<DirectoryInfo> directoryInfos = di.Split();

            Form prompt = new Form();
            prompt.Text = "Path Visualizer";
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.WrapContents = false;
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            foreach (var directoryInfo in directoryInfos)
            {
                var button = new FileOpenButton(directoryInfo) { Text = directoryInfo.Name };
                button.AutoSize = true;
                flowLayoutPanel.Controls.Add(button);
            }

            prompt.Controls.Add(flowLayoutPanel);
            prompt.AutoSize = true;
            prompt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            prompt.ShowDialog();
        }

    }
}
