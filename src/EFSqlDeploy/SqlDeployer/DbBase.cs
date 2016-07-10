using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EFSqlDeploy.SqlDeployer
{
    public abstract class DbBase
    {
        private readonly DbContext _context;

        public DbBase(DbContext context)
        {
            this._context = context;
        }

        protected virtual void ExecuteSql(string sql)
        {
            _context.Database.ExecuteSqlCommand(sql);
        }
    }
}
