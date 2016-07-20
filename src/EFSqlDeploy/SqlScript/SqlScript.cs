using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EFSqlDeploy.Extentions;

namespace EFSqlDeploy.SqlScript
{
    public static class SqlScript
    {
        public static string GetSqlScript(string fileName, params string[] replacementValues)
        {
            var script = Assembly.GetCallingAssembly().GetFileContent(fileName);

            if (script.Count == 0)
            {
                throw new ArgumentException("No script found.");
            }

            if (script.Count > 1)
            {
                throw new ArgumentException("More than 1 script was found matching this name.");
            }

            return string.Format(script.First(), replacementValues);
        }
    }
}
