namespace EFTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeadNameMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "HeadName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "HeadName");
        }
    }
}
