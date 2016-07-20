using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EFSqlDeploy.Interfaces.SqlDeployer
{
    public interface ISqlDeployer
    {
        void ApplyScripts(string fileSuffix);
    }
}
