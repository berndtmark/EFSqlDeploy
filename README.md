# EFSqlDeploy

EFSqlDeploy is a tool that can automate Sql deployments for Entity Framework. The SQL files will run on the server when the application is started.

It is important to note that all Sql files need to have a Build Action of "Embedded Resource" otherwise they will not be included in the dll and will not be found.

--

To deploy files when the application starts, add the file name suffix to the SqlDeployer in the Configuration class. 
All files ending in this suffix will be executed on the application's database.

        protected override void Seed(MyDataContext context)
        {
            var sqlDeployer = new SqlDeployer(context);
            sqlDeployer.ApplySqlScripts(".proc.sql");
            sqlDeployer.ApplySqlScripts(".function.sql");
        }

The SqlScript class offers a method to retrieve a scripts content and replace any values if present (similar to string.Format).

        public override void Up()
        {
            Sql(SqlScript.GetSqlScript("DropConstraint.sql", "dbo.MyTable", "Column1"));
        }
