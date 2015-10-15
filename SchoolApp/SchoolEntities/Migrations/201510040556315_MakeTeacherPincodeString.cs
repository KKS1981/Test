namespace SchoolEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeTeacherPincodeString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TeacherMasters", "PinCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TeacherMasters", "PinCode", c => c.Int());
        }
    }
}
