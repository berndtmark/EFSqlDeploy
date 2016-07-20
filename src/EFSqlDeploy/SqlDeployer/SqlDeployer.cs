using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EFSqlDeploy.Constants;
using EFSqlDeploy.Extentions;
using EFSqlDeploy.Interfaces.SqlDeployer;

namespace EFSqlDeploy.SqlDeployer
{
    public sealed class SqlDeployer : DbBase, ISqlDeployer
    {
        private readonly Assembly _assembly;

        public SqlDeployer(DbContext context) : base(context)
        {
            this._assembly = Assembly.GetCallingAssembly();
        }

        public SqlDeployer(DbContext context, Assembly scriptAssembly) : base(context)
        {
            this._assembly = scriptAssembly;
        }

        public void ApplyScripts(string fileSuffix)
        {
            var scripts = _assembly.GetFileContent(fileSuffix);

            foreach (string script in scripts)
            {
                script.Split(new string[] { SqlCommands.Go }, StringSplitOptions.RemoveEmptyEntries)
                      .Where(sql => sql.Trim().Length > 0)
                      .ToList().ForEach(sql => ExecuteSql(sql));
            }
        }
    }
}
