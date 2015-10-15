namespace SchoolEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTeacherMaster : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClassTeachers", "TeacherMaster_Id", "dbo.TeacherMasters");
            DropForeignKey("dbo.SmsReports", "TeacherMaster_ID", "dbo.TeacherMasters");
            DropForeignKey("dbo.Teachers", "TeacherMaster_Id", "dbo.TeacherMasters");
            DropForeignKey("dbo.TeacherUploads", "TeacherMaster_Id", "dbo.TeacherMasters");
            DropIndex("dbo.Teachers", new[] { "TeacherMaster_Id" });
            DropIndex("dbo.TeacherUploads", new[] { "TeacherMaster_Id" });
            AddColumn("dbo.Teachers", "UserId", c => c.String());
            AddColumn("dbo.Teachers", "UserName", c => c.String());
            AddColumn("dbo.Teachers", "FirstName", c => c.String());
            AddColumn("dbo.Teachers", "LastName", c => c.String());
            AddColumn("dbo.Teachers", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Teachers", "Gender", c => c.Boolean());
            AddColumn("dbo.Teachers", "MotherName", c => c.String());
            AddColumn("dbo.Teachers", "FatherName", c => c.String());
            AddColumn("dbo.Teachers", "PhoneNo", c => c.String());
            AddColumn("dbo.Teachers", "MobileNo", c => c.String());
            AddColumn("dbo.Teachers", "EmailId", c => c.String());
            AddColumn("dbo.Teachers", "Nationality", c => c.String());
            AddColumn("dbo.Teachers", "StreetAddress", c => c.String());
            AddColumn("dbo.Teachers", "City", c => c.String());
            AddColumn("dbo.Teachers", "State", c => c.String());
            AddColumn("dbo.Teachers", "Country", c => c.String());
            AddColumn("dbo.Teachers", "PinCode", c => c.String());
            AddColumn("dbo.Teachers", "Qualification", c => c.String());
            AddColumn("dbo.Teachers", "ImagePath", c => c.String());
            AddColumn("dbo.Teachers", "JoiningDate", c => c.DateTime());
            AddColumn("dbo.Teachers", "EmployeeId", c => c.String());
            AddColumn("dbo.TeacherUploads", "Teacher_Id", c => c.Int());
            CreateIndex("dbo.TeacherUploads", "Teacher_Id");
            AddForeignKey("dbo.ClassTeachers", "TeacherMaster_Id", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SmsReports", "TeacherMaster_ID", "dbo.Teachers", "Id");
            AddForeignKey("dbo.TeacherUploads", "Teacher_Id", "dbo.Teachers", "Id");
            DropColumn("dbo.Teachers", "TeacherMaster_Id");
            DropColumn("dbo.TeacherUploads", "TeacherMaster_Id");
            DropTable("dbo.TeacherMasters");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TeacherMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.Boolean(),
                        MotherName = c.String(),
                        FatherName = c.String(),
                        PhoneNo = c.String(),
                        MobileNo = c.String(),
                        EmailId = c.String(),
                        Nationality = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        PinCode = c.String(),
                        Qualification = c.String(),
                        DeletedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedDate = c.DateTime(nullable: false),
                        ImagePath = c.String(),
                        JoiningDate = c.DateTime(),
                        UserId = c.String(),
                        UserName = c.String(),
                        EmployeeId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TeacherUploads", "TeacherMaster_Id", c => c.Int());
            AddColumn("dbo.Teachers", "TeacherMaster_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.TeacherUploads", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.SmsReports", "TeacherMaster_ID", "dbo.Teachers");
            DropForeignKey("dbo.ClassTeachers", "TeacherMaster_Id", "dbo.Teachers");
            DropIndex("dbo.TeacherUploads", new[] { "Teacher_Id" });
            DropColumn("dbo.TeacherUploads", "Teacher_Id");
            DropColumn("dbo.Teachers", "EmployeeId");
            DropColumn("dbo.Teachers", "JoiningDate");
            DropColumn("dbo.Teachers", "ImagePath");
            DropColumn("dbo.Teachers", "Qualification");
            DropColumn("dbo.Teachers", "PinCode");
            DropColumn("dbo.Teachers", "Country");
            DropColumn("dbo.Teachers", "State");
            DropColumn("dbo.Teachers", "City");
            DropColumn("dbo.Teachers", "StreetAddress");
            DropColumn("dbo.Teachers", "Nationality");
            DropColumn("dbo.Teachers", "EmailId");
            DropColumn("dbo.Teachers", "MobileNo");
            DropColumn("dbo.Teachers", "PhoneNo");
            DropColumn("dbo.Teachers", "FatherName");
            DropColumn("dbo.Teachers", "MotherName");
            DropColumn("dbo.Teachers", "Gender");
            DropColumn("dbo.Teachers", "DOB");
            DropColumn("dbo.Teachers", "LastName");
            DropColumn("dbo.Teachers", "FirstName");
            DropColumn("dbo.Teachers", "UserName");
            DropColumn("dbo.Teachers", "UserId");
            CreateIndex("dbo.TeacherUploads", "TeacherMaster_Id");
            CreateIndex("dbo.Teachers", "TeacherMaster_Id");
            AddForeignKey("dbo.TeacherUploads", "TeacherMaster_Id", "dbo.TeacherMasters", "Id");
            AddForeignKey("dbo.Teachers", "TeacherMaster_Id", "dbo.TeacherMasters", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SmsReports", "TeacherMaster_ID", "dbo.TeacherMasters", "Id");
            AddForeignKey("dbo.ClassTeachers", "TeacherMaster_Id", "dbo.TeacherMasters", "Id", cascadeDelete: true);
        }
    }
}
