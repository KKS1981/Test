namespace SchoolEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "RollNo", c => c.String());
            AlterColumn("dbo.HealthInformations", "VisionL", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.HealthInformations", "VisionR", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.HealthInformations", "Dental", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HealthInformations", "Dental", c => c.String());
            AlterColumn("dbo.HealthInformations", "VisionR", c => c.String());
            AlterColumn("dbo.HealthInformations", "VisionL", c => c.String());
            AlterColumn("dbo.Students", "RollNo", c => c.Int());
        }
    }
}
