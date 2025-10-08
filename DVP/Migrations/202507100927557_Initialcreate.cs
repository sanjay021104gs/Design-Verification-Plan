namespace DVP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApprovalSignatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DvpNumber = c.Int(nullable: false),
                        SignAse = c.String(),
                        DateAse = c.DateTime(),
                        GroupAse = c.String(),
                        SignGroupAse = c.String(),
                        SignDesign = c.String(),
                        DateDesign = c.DateTime(),
                        GroupDesign = c.String(),
                        SignGroupDesign = c.String(),
                        SignDyno = c.String(),
                        DateDyno = c.DateTime(),
                        GroupDyno = c.String(),
                        SignGroupDyno = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DvpDraftDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer = c.String(),
                        EarnJrnNo = c.String(),
                        ProjectName = c.String(),
                        DvpNumber = c.String(),
                        BrakeSize = c.String(),
                        Category = c.String(),
                        Remarks = c.String(),
                        RevisionNo = c.String(),
                        FrontRear = c.String(),
                        DvpDate = c.String(),
                        FrictionGrade = c.String(),
                        DvpRDate = c.String(),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DvpFormEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer = c.String(),
                        EarnJrn = c.Int(nullable: false),
                        ProjectName = c.String(),
                        DvpNumber = c.Int(nullable: false),
                        BrakeSize = c.String(),
                        Category = c.String(),
                        Remarks = c.String(),
                        RevisionNo = c.Int(nullable: false),
                        FrontRear = c.String(),
                        DvpDate = c.DateTime(nullable: false),
                        FrictionGrade = c.String(),
                        DvpRDate = c.DateTime(nullable: false),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DvpNumber = c.Int(nullable: false),
                        Customer = c.String(maxLength: 100),
                        TestName = c.String(maxLength: 100),
                        TDNo = c.String(maxLength: 50),
                        TestCondition = c.String(maxLength: 200),
                        AcceptanceCriteria = c.String(maxLength: 200),
                        TestCostPlan = c.Decimal(precision: 18, scale: 2),
                        QtyPlan = c.Int(),
                        DVPlan = c.String(maxLength: 50),
                        PVPlan = c.String(maxLength: 50),
                        Remarks = c.String(maxLength: 300),
                        TestCostActual = c.Decimal(precision: 18, scale: 2),
                        QtyActual = c.Int(),
                        DVActual = c.String(maxLength: 50),
                        PVActual = c.String(maxLength: 50),
                        BiTestName = c.String(),
                        BiTestCode = c.String(),
                        Responsibility = c.String(),
                        TestCostRs = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
           
            
        }
        
        public override void Down()
        {
           
            DropTable("dbo.TestDetails");
            DropTable("dbo.DvpFormEntries");
            DropTable("dbo.DvpDraftDatas");
            DropTable("dbo.ApprovalSignatures");
        }
    }
}
