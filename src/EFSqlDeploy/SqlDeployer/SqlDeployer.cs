using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EFSqlDeploy.Interfaces.SqlDeployer;

namespace EFSqlDeploy.SqlDeployer
{
    public class SqlDeployer : DbBase, ISqlDeployer
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

        public bool ApplyScripts(string fileSuffix)
        { 
            throw new NotImplementedException();
        }
    }
}
