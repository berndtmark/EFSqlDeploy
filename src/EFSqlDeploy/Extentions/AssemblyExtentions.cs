using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EFSqlDeploy.Extentions
{
    internal static class AssemblyExtentions
    {
        internal static IList<string> GetFileContent(this Assembly assembly, string fileSuffix)
        {
            List<string> fileContent = new List<string>();

            IEnumerable files = assembly.GetManifestResourceNames()
                            .Where(mr => mr.EndsWith(fileSuffix, StringComparison.OrdinalIgnoreCase));

            foreach (string file in files)
            {
                using (Stream stream = assembly.GetManifestResourceStream(file))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        fileContent.Add(reader.ReadToEnd());
                    }
                }
            }

            return fileContent;
        }
    }
}
