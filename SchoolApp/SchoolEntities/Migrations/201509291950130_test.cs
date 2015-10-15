namespace SchoolEntities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ActivityGradeDescriptiveIndicators", newName: "DescriptiveIndicatorActivityGrades");
            DropForeignKey("dbo.Fees", "StudentMaster_Id", "dbo.StudentMasters");
            DropForeignKey("dbo.Charges", "Fee_Id", "dbo.Fees");
            DropForeignKey("dbo.Discounts", "Fee_Id", "dbo.Fees");
            DropForeignKey("dbo.Payments", "Fee_Id", "dbo.Fees");
            DropForeignKey("dbo.FeeTemplates", "Charge_Id", "dbo.ChargeTemplates");
            DropForeignKey("dbo.FeeTemplates", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.FeeTemplates", "StudentMaster_Id", "dbo.StudentMasters");
            DropIndex("dbo.Fees", new[] { "StudentMaster_Id" });
            DropIndex("dbo.Charges", new[] { "Fee_Id" });
            DropIndex("dbo.Discounts", new[] { "Fee_Id" });
            DropIndex("dbo.Payments", new[] { "Fee_Id" });
            DropIndex("dbo.FeeTemplates", new[] { "Charge_Id" });
            DropIndex("dbo.FeeTemplates", new[] { "Class_Id" });
            DropIndex("dbo.FeeTemplates", new[] { "StudentMaster_Id" });
            DropIndex("dbo.ActivityGradeDescriptiveIndicators", new[] { "ActivityGrade_Id" });
            DropIndex("dbo.ActivityGradeDescriptiveIndicators", new[] { "DescriptiveIndicator_Id" });
            DropPrimaryKey("dbo.DescriptiveIndicatorActivityGrades");
            AlterColumn("dbo.StudentMasters", "UserId", c => c.String());
            AlterColumn("dbo.TeacherMasters", "UserId", c => c.String());
            AddPrimaryKey("dbo.DescriptiveIndicatorActivityGrades", new[] { "DescriptiveIndicator_Id", "ActivityGrade_Id" });
            CreateIndex("dbo.DescriptiveIndicatorActivityGrades", "DescriptiveIndicator_Id");
            CreateIndex("dbo.DescriptiveIndicatorActivityGrades", "ActivityGrade_Id");
            DropColumn("dbo.SectionLabels", "ShortName");
            DropTable("dbo.Fees");
            DropTable("dbo.Charges");
            DropTable("dbo.Discounts");
            DropTable("dbo.Payments");
            DropTable("dbo.ChargeTemplates");
            DropTable("dbo.FeeTemplates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FeeTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        ShowAlways = c.Boolean(nullable: false),
                        IsRefundable = c.Boolean(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 12, scale: 4),
                        Charge_Id = c.Int(),
                        Class_Id = c.Int(),
                        StudentMaster_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChargeTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        Name = c.String(),
                        Code = c.String(maxLength: 6),
                        StartPeriodicty = c.String(maxLength: 1),
                        StartPeriodCycle = c.Int(nullable: false),
                        Periodicity = c.String(maxLength: 1),
                        PeriodCycle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsRealised = c.Boolean(nullable: false),
                        RealisedDate = c.DateTime(),
                        Notes = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        IsBounced = c.Boolean(),
                        BankName = c.String(),
                        ChequeNumber = c.String(),
                        IssueDate = c.DateTime(),
                        BranchAddress = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Fee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        Name = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Units = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChargeTemplateId = c.Int(nullable: false),
                        Fee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Charges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        Name = c.String(),
                        Rate = c.Decimal(nullable: false, precision: 12, scale: 4),
                        Units = c.Decimal(nullable: false, precision: 12, scale: 4),
                        Total = c.Decimal(nullable: false, precision: 12, scale: 4),
                        ChargeTemplateId = c.Int(nullable: false),
                        Fee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        DeletedDate = c.DateTime(),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        GenerateDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        Notes = c.String(),
                        StudentMaster_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SectionLabels", "ShortName", c => c.String());
            DropIndex("dbo.DescriptiveIndicatorActivityGrades", new[] { "ActivityGrade_Id" });
            DropIndex("dbo.DescriptiveIndicatorActivityGrades", new[] { "DescriptiveIndicator_Id" });
            DropPrimaryKey("dbo.DescriptiveIndicatorActivityGrades");
            AlterColumn("dbo.TeacherMasters", "UserId", c => c.Int());
            AlterColumn("dbo.StudentMasters", "UserId", c => c.Int());
            AddPrimaryKey("dbo.DescriptiveIndicatorActivityGrades", new[] { "ActivityGrade_Id", "DescriptiveIndicator_Id" });
            CreateIndex("dbo.ActivityGradeDescriptiveIndicators", "DescriptiveIndicator_Id");
            CreateIndex("dbo.ActivityGradeDescriptiveIndicators", "ActivityGrade_Id");
            CreateIndex("dbo.FeeTemplates", "StudentMaster_Id");
            CreateIndex("dbo.FeeTemplates", "Class_Id");
            CreateIndex("dbo.FeeTemplates", "Charge_Id");
            CreateIndex("dbo.Payments", "Fee_Id");
            CreateIndex("dbo.Discounts", "Fee_Id");
            CreateIndex("dbo.Charges", "Fee_Id");
            CreateIndex("dbo.Fees", "StudentMaster_Id");
            AddForeignKey("dbo.FeeTemplates", "StudentMaster_Id", "dbo.StudentMasters", "Id");
            AddForeignKey("dbo.FeeTemplates", "Class_Id", "dbo.Classes", "Id");
            AddForeignKey("dbo.FeeTemplates", "Charge_Id", "dbo.ChargeTemplates", "Id");
            AddForeignKey("dbo.Payments", "Fee_Id", "dbo.Fees", "Id");
            AddForeignKey("dbo.Discounts", "Fee_Id", "dbo.Fees", "Id");
            AddForeignKey("dbo.Charges", "Fee_Id", "dbo.Fees", "Id");
            AddForeignKey("dbo.Fees", "StudentMaster_Id", "dbo.StudentMasters", "Id");
            RenameTable(name: "dbo.DescriptiveIndicatorActivityGrades", newName: "ActivityGradeDescriptiveIndicators");
        }
    }
}
