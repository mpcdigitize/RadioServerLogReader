namespace LogParser.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newSetting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocalSettings",
                c => new
                    {
                        SettingId = c.Guid(nullable: false),
                        SettingName = c.String(),
                        SettingValue = c.String(),
                    })
                .PrimaryKey(t => t.SettingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LocalSettings");
        }
    }
}
