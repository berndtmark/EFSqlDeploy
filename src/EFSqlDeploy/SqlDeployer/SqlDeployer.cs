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
    public sealed class SqlDeployer : SqlDeployerBase, ISqlDeployer 
    {
        private readonly DbContext _context;

        public SqlDeployer(DbContext context) : base(Assembly.GetCallingAssembly())
        {
            this._context = context;
        }
        
        public SqlDeployer(DbContext context, Assembly scriptAssembly) : base(scriptAssembly)
        {
            this._context = context;
        }

        public new void ApplyScripts(string fileSuffix)
        {
            base.ApplyScripts(fileSuffix);
        }

        public new IList<string> GetScripts(string fileSuffix)
        {
            return base.GetScripts(fileSuffix);
        }

        protected override void ExecuteSql(string sql)
        {
            this._context.Database.ExecuteSqlCommand(sql);
        }
    }
}
