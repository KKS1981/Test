namespace SchoolEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TecherGenderNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TeacherMasters", "Gender", c => c.Boolean());
            AlterColumn("dbo.SectionLabels", "Name", c => c.String(nullable: false));
            DropColumn("dbo.ClassLabels", "ShortName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClassLabels", "ShortName", c => c.String());
            AlterColumn("dbo.SectionLabels", "Name", c => c.String());
            AlterColumn("dbo.TeacherMasters", "Gender", c => c.Boolean(nullable: false));
        }
    }
}
