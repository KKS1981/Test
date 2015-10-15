namespace SchoolEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRegistrationId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentMasters", "PinCode", c => c.String());
            DropColumn("dbo.StudentMasters", "RegistrationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentMasters", "RegistrationId", c => c.String());
            AlterColumn("dbo.StudentMasters", "PinCode", c => c.Int());
        }
    }
}
