using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFSqlDeploy.SqlScript;
using NUnit.Framework;

namespace EfSqlDeploy.Tests.Tests
{
    [TestFixture]
    public class SqlScriptTests
    {
        [Test]
        public void SqlScript_WithMoreThanOneFileFound_ExceptionThrown()
        {
            Assert.Throws<ArgumentException>(() => SqlScript.GetSqlScript("Proc.sql"));
        }

        [Test]
        public void SqlScript_WithNoScriptFound_ExceptionThrown()
        {
            Assert.Throws<ArgumentException>(() => SqlScript.GetSqlScript("missing.proc.sql"));
        }

        [Test]
        public void SqlScript_ScriptTextReturned()
        {
            var result = SqlScript.GetSqlScript("One.proc.sql");

            Assert.AreEqual("CREATE", result.ToString().Substring(0, 6));
        }

        [Test]
        public void SqlScript_WithReplacementValues_ValuesReplaced()
        {
            var result = SqlScript.GetSqlScript("Two.proc.sql", "Success");

            Assert.AreEqual("Success", result.Substring(result.Length - 7));
        }
    }
}
