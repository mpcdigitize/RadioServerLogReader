namespace LogParser.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backup_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocalSettings", "BackupName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LocalSettings", "BackupName");
        }
    }
}
