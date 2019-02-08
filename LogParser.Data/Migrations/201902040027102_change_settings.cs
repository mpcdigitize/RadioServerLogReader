namespace LogParser.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_settings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LocalSettings", "FolderPath", c => c.String());
            AddColumn("dbo.LocalSettings", "FileExtension", c => c.String());
            DropColumn("dbo.LocalSettings", "SettingName");
            DropColumn("dbo.LocalSettings", "SettingValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LocalSettings", "SettingValue", c => c.String());
            AddColumn("dbo.LocalSettings", "SettingName", c => c.String());
            DropColumn("dbo.LocalSettings", "FileExtension");
            DropColumn("dbo.LocalSettings", "FolderPath");
        }
    }
}
