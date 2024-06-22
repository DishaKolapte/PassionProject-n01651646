namespace PassionProject_n01651646.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pets", "AdoptionStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "AdoptionStatus", c => c.String());
        }
    }
}
