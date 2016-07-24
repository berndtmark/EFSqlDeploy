# EFSqlDeploy

EFSqlDeploy is a tool that can automate Sql deployments for the Entity Framework.

It is important to note that all Sql files need to have a Build Action of "Embedded Resource" otherwise they will not be found.

##Usage
If using EF6, there is built in functionality to execute Sql files and the SqlDeployer class can simply be instantiated.
To deploy Sql files when the application starts, add the file name suffix to the SqlDeployer in the Configuration class. 
All files ending in this suffix will be executed on the application's database when the Seed method is executed.

        protected override void Seed(MyDataContext context)
        {
            var sqlDeployer = new SqlDeployer(context);
            sqlDeployer.ApplyScripts(".proc.sql");
            sqlDeployer.ApplyScripts(".function.sql");
        }


If not using EF6, you can still use EFSqlDeploy but you will need to implement your own method to execute the Sql.
Inherit from the SqlDeployerBase class and implement the abstract ExecuteSql method.

	    public class MyClass : SqlDeployerBase 
	    {
			public MyClass() : base(Assembly.GetExecutingAssembly())
			{

			}

			public void DeploySql(string name)
			{
				base.ApplyScripts(name);
			}

	        protected override void ExecuteSql(string sql)
	        {
	            // implement sql execution.
	        }
	    }


The SqlScript class offers a method to retrieve a scripts content and replace any values if present (similar to string.Format).

        public override void Up()
        {
            Sql(SqlScript.GetSqlScript("DropConstraint.sql", "dbo.MyTable", "Column1"));
        }