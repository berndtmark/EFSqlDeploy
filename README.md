# EFSqlDeploy

EFSqlDeploy is a tool that can automate Sql deployments for Entity Framework (current EF6 is supported).

It is important to note that all Sql files need to have a Build Action of "Embedded Resource" otherwise they will not be found.

##Usage
To deploy Sql files when the application starts, add the file name suffix to the SqlDeployer in the Configuration class. 
All files ending in this suffix will be executed on the application's database when the Seed method is executed.

        protected override void Seed(MyDataContext context)
        {
            var sqlDeployer = new SqlDeployer(context);
            sqlDeployer.ApplyScripts(".proc.sql");
            sqlDeployer.ApplyScripts(".function.sql");
        }

The SqlScript class offers a method to retrieve a scripts content and replace any values if present (similar to string.Format).

        public override void Up()
        {
            Sql(SqlScript.GetSqlScript("DropConstraint.sql", "dbo.MyTable", "Column1"));
        }
