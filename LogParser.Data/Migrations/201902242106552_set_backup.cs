namespace LogParser.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class set_backup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocalSettings", "BackupFolder", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LocalSettings", "BackupFolder");
        }
    }
}
