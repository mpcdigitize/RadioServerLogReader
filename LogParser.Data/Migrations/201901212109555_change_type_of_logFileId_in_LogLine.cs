namespace LogParser.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_type_of_logFileId_in_LogLine : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LogLines", "LogFile_LogFileId", "dbo.LogFiles");
            DropIndex("dbo.LogLines", new[] { "LogFile_LogFileId" });
            AddColumn("dbo.LogLines", "LogFileId", c => c.String());
            DropColumn("dbo.LogLines", "LogFile_LogFileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LogLines", "LogFile_LogFileId", c => c.Guid());
            DropColumn("dbo.LogLines", "LogFileId");
            CreateIndex("dbo.LogLines", "LogFile_LogFileId");
            AddForeignKey("dbo.LogLines", "LogFile_LogFileId", "dbo.LogFiles", "LogFileId");
        }
    }
}
