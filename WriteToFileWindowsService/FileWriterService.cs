using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WriteToFileWindowsService
{
    public class FileWriterService : WriteToFileWindowsService.IFileWriterService
    {
        public void WriteLine(string p)
        {
            using (var stream = new StreamWriter(@"c:\temp\samplefile.txt", true))
            {
                stream.WriteLine(p);
            }
        }
    }
}
