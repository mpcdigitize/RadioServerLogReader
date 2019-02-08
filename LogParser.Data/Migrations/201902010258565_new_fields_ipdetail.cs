namespace LogParser.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_fields_ipdetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IpDetails", "Alias", c => c.String());
            AddColumn("dbo.IpDetails", "IsHidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IpDetails", "IsHidden");
            DropColumn("dbo.IpDetails", "Alias");
        }
    }
}
