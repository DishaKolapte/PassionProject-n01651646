namespace PassionProject_n01651646.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inquiry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inquiries", "PetName", c => c.String());
            AddColumn("dbo.Inquiries", "Username", c => c.String());
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String());
            DropColumn("dbo.Inquiries", "Username");
            DropColumn("dbo.Inquiries", "PetName");
        }
    }
}
