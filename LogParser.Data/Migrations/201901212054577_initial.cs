namespace LogParser.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IpDetails",
                c => new
                    {
                        IpDetailId = c.Guid(nullable: false),
                        IpNumber = c.String(),
                        IspProvider = c.String(),
                        Country = c.String(),
                        Location = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.IpDetailId);
            
            CreateTable(
                "dbo.LogFiles",
                c => new
                    {
                        LogFileId = c.Guid(nullable: false),
                        FilePath = c.String(),
                        FileName = c.String(),
                        FileSize = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.LogFileId);
            
            CreateTable(
                "dbo.LogLines",
                c => new
                    {
                        LogLineId = c.Guid(nullable: false),
                        Date = c.String(),
                        Time = c.String(),
                        IpNumber = c.String(),
                        MediaItem = c.String(),
                        Port = c.String(),
                        IpClient = c.String(),
                        Client = c.String(),
                        ClientVersion = c.String(),
                        Platform = c.String(),
                        LogFile_LogFileId = c.Guid(),
                    })
                .PrimaryKey(t => t.LogLineId)
                .ForeignKey("dbo.LogFiles", t => t.LogFile_LogFileId)
                .Index(t => t.LogFile_LogFileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogLines", "LogFile_LogFileId", "dbo.LogFiles");
            DropIndex("dbo.LogLines", new[] { "LogFile_LogFileId" });
            DropTable("dbo.LogLines");
            DropTable("dbo.LogFiles");
            DropTable("dbo.IpDetails");
        }
    }
}
