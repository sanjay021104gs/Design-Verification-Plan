namespace DVP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialcreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TestDetails", "Customer", c => c.String());
            AlterColumn("dbo.TestDetails", "TestName", c => c.String());
            AlterColumn("dbo.TestDetails", "TDNo", c => c.String());
            AlterColumn("dbo.TestDetails", "TestCondition", c => c.String());
            AlterColumn("dbo.TestDetails", "AcceptanceCriteria", c => c.String());
            AlterColumn("dbo.TestDetails", "DVPlan", c => c.String());
            AlterColumn("dbo.TestDetails", "PVPlan", c => c.String());
            AlterColumn("dbo.TestDetails", "Remarks", c => c.String());
            AlterColumn("dbo.TestDetails", "DVActual", c => c.String());
            AlterColumn("dbo.TestDetails", "PVActual", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TestDetails", "PVActual", c => c.String(maxLength: 50));
            AlterColumn("dbo.TestDetails", "DVActual", c => c.String(maxLength: 50));
            AlterColumn("dbo.TestDetails", "Remarks", c => c.String(maxLength: 300));
            AlterColumn("dbo.TestDetails", "PVPlan", c => c.String(maxLength: 50));
            AlterColumn("dbo.TestDetails", "DVPlan", c => c.String(maxLength: 50));
            AlterColumn("dbo.TestDetails", "AcceptanceCriteria", c => c.String(maxLength: 200));
            AlterColumn("dbo.TestDetails", "TestCondition", c => c.String(maxLength: 200));
            AlterColumn("dbo.TestDetails", "TDNo", c => c.String(maxLength: 50));
            AlterColumn("dbo.TestDetails", "TestName", c => c.String(maxLength: 100));
            AlterColumn("dbo.TestDetails", "Customer", c => c.String(maxLength: 100));
        }
    }
}
