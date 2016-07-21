using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EFSqlDeploy.SqlDeployer;
using Moq;
using NUnit.Framework;

namespace EfSqlDeploy.Tests
{
    [TestFixture]
    public class SqlDeployerTests
    {
        [Test]
        public void SqlDepoyer_GetScripts_OnEmptyScript_ScriptIgnored()
        {
            var dbContext = new Mock<DbContext>();

            var sqlDeployer = new SqlDeployer(dbContext.Object, Assembly.GetExecutingAssembly());
            var results = sqlDeployer.GetScripts("empty.sql");

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void SqlDepoyer_GetScripts_OnTwoScriptsPresent_TwoScriptsReturned()
        {
            var dbContext = new Mock<DbContext>();

            var sqlDeployer = new SqlDeployer(dbContext.Object, Assembly.GetExecutingAssembly());
            var results = sqlDeployer.GetScripts(".proc.sql");

            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void SqlDepoyer_GetScripts_OnOneScriptWithGoSeparator_TwoScriptsReturned()
        {
            var dbContext = new Mock<DbContext>();

            var sqlDeployer = new SqlDeployer(dbContext.Object, Assembly.GetExecutingAssembly());
            var results = sqlDeployer.GetScripts("go.sql");

            Assert.AreEqual(2, results.Count);
        }
    }
}
