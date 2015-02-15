namespace FixturesVer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyDetails", "Currency", c => c.String());
            AddColumn("dbo.PropertyDetails", "Availability", c => c.String());
            AddColumn("dbo.PropertyDetails", "AvailabilityFromDate", c => c.DateTime());
            AddColumn("dbo.PropertyDetails", "AvailabilityToDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PropertyDetails", "AvailabilityToDate");
            DropColumn("dbo.PropertyDetails", "AvailabilityFromDate");
            DropColumn("dbo.PropertyDetails", "Availability");
            DropColumn("dbo.PropertyDetails", "Currency");
        }
    }
}
