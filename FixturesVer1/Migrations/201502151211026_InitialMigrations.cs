namespace FixturesVer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Property", "Price", c => c.Single());
        }
        
        public override void Down()
        {

        }
    }
}
