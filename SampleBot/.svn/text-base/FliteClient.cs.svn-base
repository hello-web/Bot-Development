using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SampleBot
{
    class FliteClient
    {
        private readonly string path;

        public FliteClient(string path)
        {
            this.path = path;
        }

        public void Speak(string text, string voice)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = this.path;
            startInfo.UseShellExecute = false;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			
			string tempFileName = Path.GetTempFileName();
			File.WriteAllText(tempFileName, text);
			
            startInfo.Arguments = String.Format("{0} -voice {1}", tempFileName, voice);

            using (Process process = Process.Start(startInfo))
            {
                process.WaitForExit();
            }
			
			File.Delete(tempFileName);
        }
    }
}
