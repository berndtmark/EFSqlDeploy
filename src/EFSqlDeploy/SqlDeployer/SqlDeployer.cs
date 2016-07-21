using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EFSqlDeploy.Constants;
using EFSqlDeploy.Extentions;
using EFSqlDeploy.Interfaces.SqlDeployer;

[assembly: InternalsVisibleTo("EfSqlDeploy.Tests")]
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
            var scripts = GetScripts(fileSuffix);

            scripts.ToList().ForEach(sql => ExecuteSql(sql));
        }

        public IList<string> GetScripts(string fileSuffix)
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
    }
}
