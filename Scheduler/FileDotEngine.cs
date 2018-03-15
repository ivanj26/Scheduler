using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace Scheduler
{
    public sealed class FileDotEngine : IDotEngine
    {
        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
            //"\\Documents\\dotengine\\image";
            //string output = Application.StartupPath + "\\image\\image.png";
            string output = Application.StartupPath + "\\image\\image";
            if (!Directory.Exists(Application.StartupPath + "\\image")) {
                Directory.CreateDirectory(Application.StartupPath + "\\image");
            }

            File.WriteAllText(output, dot);
            var args = string.Format(@"""{0}"" -Tpng -O ", output);
            Process process = new Process();
            process.StartInfo.FileName = Application.StartupPath + "\\dotengine\\dot.exe";
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;

            process.Start();
            process.WaitForExit(1000);
            return output;
        }
    }
}