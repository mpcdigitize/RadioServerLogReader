namespace LogParser.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_type_to_guid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogLines", "LogFileId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogLines", "LogFileId", c => c.String());
        }
    }
}
