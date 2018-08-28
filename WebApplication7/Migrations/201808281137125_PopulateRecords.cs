namespace WebApplication7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRecords : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Customers VALUES ('Ahmed')");
            Sql("INSERT INTO dbo.Customers VALUES ('Mostafa')");
        }
        
        public override void Down()
        {
        }
    }
}
