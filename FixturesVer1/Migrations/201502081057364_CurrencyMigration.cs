namespace FixturesVer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrencyMigration : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.PropertyDetails DROP CONSTRAINT DF__PropertyD__Curre__47DBAE45");
            AlterColumn("dbo.PropertyDetails", "Currency", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PropertyDetails", "Currency", c => c.Single(nullable: false));
        }
    }
}
