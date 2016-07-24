using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EFSqlDeploy.Constants;
using EFSqlDeploy.Extentions;
using EFSqlDeploy.Interfaces.SqlDeployer;

namespace EFSqlDeploy.SqlDeployer
{
    public abstract class SqlDeployerBase
    {
        private readonly Assembly _assembly;

        public SqlDeployerBase(Assembly scriptAssembly)
        {
            this._assembly = scriptAssembly;
        }

        protected virtual void ApplyScripts(string fileSuffix)
        {
            var scripts = GetScripts(fileSuffix);

            scripts.ToList().ForEach(sql => ExecuteSql(sql));
        }

        protected virtual IList<string> GetScripts(string fileSuffix)
        {
            var scriptsContentList = new List<string>();
            var scripts = _assembly.GetFileContent(fileSuffix);

            foreach (string script in scripts)
            {
                scriptsContentList.AddRange(script.Split(new string[] { SqlCommands.Go }, StringSplitOptions.RemoveEmptyEntries)
                      .Where(sql => sql.Trim().Length > 0));
            }

            return scriptsContentList;
        }

        protected abstract void ExecuteSql(string sql);
    }
}
