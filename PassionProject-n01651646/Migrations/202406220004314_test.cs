namespace PassionProject_n01651646.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inquiries", "UserId", "dbo.Users");
            DropIndex("dbo.Inquiries", new[] { "UserId" });
            RenameColumn(table: "dbo.Inquiries", name: "UserId", newName: "User_UserId");
            AlterColumn("dbo.Inquiries", "User_UserId", c => c.Int());
            CreateIndex("dbo.Inquiries", "User_UserId");
            AddForeignKey("dbo.Inquiries", "User_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inquiries", "User_UserId", "dbo.Users");
            DropIndex("dbo.Inquiries", new[] { "User_UserId" });
            AlterColumn("dbo.Inquiries", "User_UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Inquiries", name: "User_UserId", newName: "UserId");
            CreateIndex("dbo.Inquiries", "UserId");
            AddForeignKey("dbo.Inquiries", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
