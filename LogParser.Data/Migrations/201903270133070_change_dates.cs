namespace LogParser.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_dates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogLines", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogLines", "Date", c => c.String());
        }
    }
}
