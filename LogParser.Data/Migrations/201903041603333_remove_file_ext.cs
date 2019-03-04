namespace LogParser.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_file_ext : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LocalSettings", "FileExtension");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LocalSettings", "FileExtension", c => c.String());
        }
    }
}
