using DVP.Data;
using DVP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DVP
{
    public partial class _Default : Page
    {
        private const string GridViewStateKey = "TestTable";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CreateEmptyTable();

                using (var context = new DVP.Data.ApplicationDbContext())
                {
                    var lastDraft = context.DvpDrafts
                        .OrderByDescending(d => d.Id)
                        .FirstOrDefault();

                    if (lastDraft != null)
                    {
                        ddlCustomer.SelectedValue = lastDraft.Customer;
                        txtEarnJrn.Text = lastDraft.EarnJrnNo;
                        txtProjectName.Text = lastDraft.ProjectName;
                        txtDvpNumber.Text = lastDraft.DvpNumber;
                        ddlBrakeSize.SelectedValue = lastDraft.BrakeSize;
                        ddlCategory.SelectedValue = lastDraft.Category;
                        txtRemarks.Text = lastDraft.Remarks;
                        txtRevisionNo.Text = lastDraft.RevisionNo;
                        ddlFrontRear.SelectedValue = lastDraft.FrontRear;
                        txtDvpDate.Text = lastDraft.DvpDate;
                        txtFrictionGrade.Text = lastDraft.FrictionGrade;
                        txtDvpRDate.Text = lastDraft.DvpRDate;
                        ddlReason.SelectedValue = lastDraft.Reason;
                    }
                }

                BindGrid();
            }
        }



        protected void ddlDvpMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMode = ddlDvpMode.SelectedValue;

            txtDvpNumber.Visible = (selectedMode == "New");
            ddlExistingDvpNumbers.Visible = (selectedMode == "Existing");

            if (selectedMode == "Existing")
            {
                using (var context = new DvpContext())
                {
                    var dvpNumbers = context.DvpFormEntries.Select(d => d.DvpNumber).ToList();
                    ddlExistingDvpNumbers.DataSource = dvpNumbers;
                    ddlExistingDvpNumbers.DataBind();
                }
            }
        }

        protected void ddlExistingDvpNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dvpNo = int.Parse(ddlExistingDvpNumbers.SelectedValue);

            using (var context = new ApplicationDbContext())
            {
                var form = context.DvpFormEntries.FirstOrDefault(f => f.DvpNumber == dvpNo);
                if (form != null)
                {
                    ddlCustomer.SelectedValue = form.Customer;
                    txtEarnJrn.Text = form.EarnJrn.ToString();
                    txtProjectName.Text = form.ProjectName;
                    txtDvpNumber.Text = form.DvpNumber.ToString();
                    ddlBrakeSize.SelectedValue = form.BrakeSize;
                    ddlCategory.SelectedValue = form.Category;
                    txtRemarks.Text = form.Remarks;
                    txtRevisionNo.Text = form.RevisionNo.ToString();
                    ddlFrontRear.SelectedValue = form.FrontRear;
                    txtDvpDate.Text = form.DvpDate == DateTime.MinValue ? "" : form.DvpDate.ToString("yyyy-MM-dd");
                    txtFrictionGrade.Text = form.FrictionGrade;
                    txtDvpRDate.Text = form.DvpRDate == DateTime.MinValue ? "" : form.DvpRDate.ToString("yyyy-MM-dd");
                    ddlReason.SelectedValue = form.Reason;
                }

                // Load TestDetails
                var details = context.TestDetails.Where(t => t.DvpNumber == dvpNo).ToList();
                var dt = CreateEmptyTable();
                foreach (var d in details)
                {
                    var row = dt.NewRow();
                    row["Customer"] = d.Customer;
                    row["TestName"] = d.TestName;
                    row["TDNo"] = d.TDNo;
                    row["TestCondition"] = d.TestCondition;
                    row["AcceptanceCriteria"] = d.AcceptanceCriteria;
                    row["CostPlan"] = d.TestCostPlan;
                    row["QtyPlan"] = d.QtyPlan;
                    row["DVPlan"] = d.DVPlan;
                    row["PVPlan"] = d.PVPlan;
                    row["Responsibility"] = d.Responsibility;
                    row["RemarksRow"] = d.Remarks;
                    row["CostRs"] = d.TestCostRs;
                    row["BiTestName"] = d.BiTestName;
                    row["BiTestCode"] = d.BiTestCode;
                    row["CostActual"] = d.TestCostActual;
                    row["QtyActual"] = d.QtyActual;
                    row["DVActual"] = d.DVActual;
                    row["PVActual"] = d.PVActual;
                    dt.Rows.Add(row);
                }
                ViewState[GridViewStateKey] = dt;
                BindGrid();


                var signatures = context.ApprovalSignatures.FirstOrDefault(s => s.DvpNumber == dvpNo);
                if (signatures != null)
                {
                    // ASE TEAM
                    txtSignAse.Text = signatures.SignAse;
                    txtDateAse.Text = signatures.DateAse.HasValue ? signatures.DateAse.Value.ToString("yyyy-MM-dd") : "";
                    txtGroupAse.Text = signatures.GroupAse;
                    txtSignGroupAse.Text = signatures.SignGroupAse;

                    // Core Design
                    txtSignDesign.Text = signatures.SignDesign;
                    txtDateDesign.Text = signatures.DateDesign.HasValue ? signatures.DateDesign.Value.ToString("yyyy-MM-dd") : "";
                    txtGroupDesign.Text = signatures.GroupDesign;
                    txtSignGroupDesign.Text = signatures.SignGroupDesign;

                    // Core Dyno
                    txtSignDyno.Text = signatures.SignDyno;
                    txtDateDyno.Text = signatures.DateDyno.HasValue ? signatures.DateDyno.Value.ToString("yyyy-MM-dd") : "";
                    txtGroupDyno.Text = signatures.GroupDyno;
                    txtSignGroupDyno.Text = signatures.SignGroupDyno;
                }
                else
                {
                    // Clear if no data exists
                    txtSignAse.Text = "";
                    txtDateAse.Text = "";
                    txtGroupAse.Text = "";
                    txtSignGroupAse.Text = "";

                    txtSignDesign.Text = "";
                    txtDateDesign.Text = "";
                    txtGroupDesign.Text = "";
                    txtSignGroupDesign.Text = "";

                    txtSignDyno.Text = "";
                    txtDateDyno.Text = "";
                    txtGroupDyno.Text = "";
                    txtSignGroupDyno.Text = "";
                }
            }
        }

        protected void btnNewRow_Click(object sender, EventArgs e)
        {
            DataTable dt = ViewState[GridViewStateKey] as DataTable;
            if (dt == null)
            {
                // Safety fallback: recreate the table if ViewState lost
                CreateEmptyTable();
                dt = ViewState[GridViewStateKey] as DataTable;
            }

            dt.Rows.Add(dt.NewRow());
            ViewState[GridViewStateKey] = dt;
            BindGrid();
        }


        protected void btnSaveDraft_Click(object sender, EventArgs e)
        {
            using (var context = new DVP.Data.ApplicationDbContext())
            {
                var draftData = new DvpDraftData
                {
                    Customer = ddlCustomer.SelectedValue,
                    EarnJrnNo = txtEarnJrn.Text,
                    ProjectName = txtProjectName.Text,
                    DvpNumber = txtDvpNumber.Text,
                    BrakeSize = ddlBrakeSize.SelectedValue,
                    Category = ddlCategory.SelectedValue,
                    Remarks = txtRemarks.Text,
                    RevisionNo = txtRevisionNo.Text,
                    FrontRear = ddlFrontRear.SelectedValue,
                    DvpDate = txtDvpDate.Text,
                    FrictionGrade = txtFrictionGrade.Text,
                    DvpRDate = txtDvpRDate.Text,
                    Reason = ddlReason.SelectedValue
                };

                context.DvpDrafts.Add(draftData);
                context.SaveChanges();
            }

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Draft saved successfully to the database.');", true);
        }


        private decimal? ParseDecimal(string input)
        {
            if (decimal.TryParse(input, out var result))
                return result;
            return null;
        }

        private int? ParseInt(string input)
        {
            if (int.TryParse(input, out var result))
                return result;
            return null;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                int dvpNo = string.IsNullOrWhiteSpace(txtDvpNumber.Text) ? 0 : int.Parse(txtDvpNumber.Text);

                // Save main form
                var formEntry = new DvpFormEntry
                {
                    Customer = ddlCustomer.SelectedValue,
                    EarnJrn = string.IsNullOrWhiteSpace(txtEarnJrn.Text)?0:int.Parse(txtEarnJrn.Text),
                    ProjectName = txtProjectName.Text,
                    DvpNumber = dvpNo,
                    BrakeSize = ddlBrakeSize.SelectedValue,
                    Category = ddlCategory.SelectedValue,
                    Remarks = txtRemarks.Text,
                    RevisionNo = string.IsNullOrWhiteSpace(txtRevisionNo.Text) ? 0 : int.Parse(txtRevisionNo.Text),
                    FrontRear = ddlFrontRear.SelectedValue,
                    DvpDate = string.IsNullOrWhiteSpace(txtDvpDate.Text) ? DateTime.MinValue : DateTime.Parse(txtDvpDate.Text),
                    FrictionGrade = txtFrictionGrade.Text,
                    DvpRDate = string.IsNullOrWhiteSpace(txtDvpRDate.Text) ? DateTime.MinValue : DateTime.Parse(txtDvpRDate.Text),
                    Reason = ddlReason.SelectedValue
                };

                context.DvpFormEntries.Add(formEntry);

                // Save child rows
                foreach (GridViewRow row in gvTestData.Rows)
                {
                    string selectedCustomer = (row.FindControl("ddlCustomerRow") as DropDownList)?.SelectedValue;
                    string selectedTestName = (row.FindControl("ddlTestName") as DropDownList)?.SelectedValue;

                    // First, get manual entries (some fields may remain empty)
                    string tdNo = (row.FindControl("txtTDNo") as TextBox)?.Text;
                    string testCondition = (row.FindControl("txtCondition") as TextBox)?.Text;
                    string acceptanceCriteria = (row.FindControl("txtCriteria") as TextBox)?.Text;
                    string biTestName = (row.FindControl("txtBiTestName") as TextBox)?.Text;
                    string biTestCode = (row.FindControl("txtBiTestCode") as TextBox)?.Text;
                    string costPlanText = (row.FindControl("txtCostPlan") as TextBox)?.Text;

                    // Try to fetch autofill values from dbo.TestRecords
                    using (var lookupContext = new ApplicationDbContext())
                    {
                        var record = lookupContext.TestRecords
                            .FirstOrDefault(t => t.Customer == selectedCustomer && t.Test_Name == selectedTestName);

                        if (record != null)
                        {
                            // Only overwrite if the textbox is empty
                            tdNo = string.IsNullOrWhiteSpace(tdNo) ? record.TDNo : tdNo;
                            testCondition = string.IsNullOrWhiteSpace(testCondition) ? record.TestCondition : testCondition;
                            acceptanceCriteria = string.IsNullOrWhiteSpace(acceptanceCriteria) ? record.AcceptanceCriteria : acceptanceCriteria;
                            biTestName = string.IsNullOrWhiteSpace(biTestName) ? record.BiTestName : biTestName;
                            biTestCode = string.IsNullOrWhiteSpace(biTestCode) ? record.BiTestCode : biTestCode;
                            costPlanText = string.IsNullOrWhiteSpace(costPlanText) ? (record.TestCost.HasValue ? record.TestCost.Value.ToString() : "") : costPlanText;
                        }
                    }

                    var entity = new TestDetail
                    {
                        DvpNumber = dvpNo,
                        Customer = selectedCustomer,
                        TestName = selectedTestName,
                        TDNo = tdNo,
                        TestCondition = testCondition,
                        AcceptanceCriteria = acceptanceCriteria,
                        BiTestName = biTestName,
                        BiTestCode = biTestCode,
                        TestCostPlan = ParseDecimal(costPlanText),
                        QtyPlan = ParseInt((row.FindControl("txtQtyPlan") as TextBox)?.Text),
                        DVPlan = (row.FindControl("txtDVPlan") as TextBox)?.Text,
                        PVPlan = (row.FindControl("txtPVPlan") as TextBox)?.Text,
                        Responsibility = (row.FindControl("txtResponsibility") as TextBox)?.Text,
                        Remarks = (row.FindControl("txtRemarksRow") as TextBox)?.Text,
                        TestCostRs = ParseDecimal((row.FindControl("txtCostRs") as TextBox)?.Text),
                        TestCostActual = ParseDecimal((row.FindControl("txtCostActual") as TextBox)?.Text),
                        QtyActual = ParseInt((row.FindControl("txtQtyActual") as TextBox)?.Text),
                        DVActual = (row.FindControl("txtDVActual") as TextBox)?.Text,
                        PVActual = (row.FindControl("txtPVActual") as TextBox)?.Text
                    };

                    context.TestDetails.Add(entity);
                }

                var approval = new ApprovalSignatures
                {
                    DvpNumber = dvpNo,

                    // ASE TEAM
                    SignAse = txtSignAse.Text,
                    DateAse = string.IsNullOrWhiteSpace(txtDateAse.Text) ? (DateTime?)null : DateTime.Parse(txtDateAse.Text),
                    GroupAse = txtGroupAse.Text,
                    SignGroupAse = txtSignGroupAse.Text,

                    // Core Design
                    SignDesign = txtSignDesign.Text,
                    DateDesign = string.IsNullOrWhiteSpace(txtDateDesign.Text) ? (DateTime?)null : DateTime.Parse(txtDateDesign.Text),
                    GroupDesign = txtGroupDesign.Text,
                    SignGroupDesign = txtSignGroupDesign.Text,

                    // Core Dyno
                    SignDyno = txtSignDyno.Text,
                    DateDyno = string.IsNullOrWhiteSpace(txtDateDyno.Text) ? (DateTime?)null : DateTime.Parse(txtDateDyno.Text),
                    GroupDyno = txtGroupDyno.Text,
                    SignGroupDyno = txtSignGroupDyno.Text
                };

                context.ApprovalSignatures.Add(approval);

                context.SaveChanges();
            }

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Data saved successfully.');", true);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Make all fields editable (if you used ReadOnly)
            txtEarnJrn.ReadOnly = false;
            txtProjectName.ReadOnly = false;
            txtRemarks.ReadOnly = false;
            txtRevisionNo.ReadOnly = false;
            txtFrictionGrade.ReadOnly = false;
            txtSignAse.ReadOnly = false;
            txtDateAse.ReadOnly = false;
            txtGroupAse.ReadOnly = false;
            txtSignGroupAse.ReadOnly = false;
            txtSignDesign.ReadOnly = false;
            txtDateDesign.ReadOnly = false;
            txtGroupDesign.ReadOnly = false;
            txtSignGroupDesign.ReadOnly = false;
            txtSignDyno.ReadOnly = false;
            txtDateDyno.ReadOnly = false;
            txtGroupDyno.ReadOnly = false;
            txtSignGroupDyno.ReadOnly = false;

            // Enable Save Changes
            btnSaveChanges.Enabled = true;
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            int dvpNo = int.Parse(ddlExistingDvpNumbers.SelectedValue);

            using (var context = new ApplicationDbContext())
            {
                // Update DvpFormEntry
                var formEntry = context.DvpFormEntries.FirstOrDefault(d => d.DvpNumber == dvpNo);
                if (formEntry != null)
                {
                    formEntry.Customer = ddlCustomer.SelectedValue;
                    formEntry.EarnJrn = string.IsNullOrWhiteSpace(txtEarnJrn.Text) ? 0 : int.Parse(txtEarnJrn.Text);
                    formEntry.ProjectName = txtProjectName.Text;
                    formEntry.BrakeSize = ddlBrakeSize.SelectedValue;
                    formEntry.Category = ddlCategory.SelectedValue;
                    formEntry.Remarks = txtRemarks.Text;
                    formEntry.RevisionNo = string.IsNullOrWhiteSpace(txtRevisionNo.Text) ? 0 : int.Parse(txtRevisionNo.Text);
                    formEntry.FrontRear = ddlFrontRear.SelectedValue;
                    formEntry.DvpDate = DateTime.Parse(txtDvpDate.Text);
                    formEntry.FrictionGrade = txtFrictionGrade.Text;
                    formEntry.DvpRDate = DateTime.Parse(txtDvpRDate.Text);
                    formEntry.Reason = ddlReason.SelectedValue;
                }

                // Update ApprovalSignatures
                var approval = context.ApprovalSignatures.FirstOrDefault(a => a.DvpNumber == dvpNo);
                if (approval != null)
                {
                    approval.SignAse = txtSignAse.Text;
                    approval.DateAse = string.IsNullOrWhiteSpace(txtDateAse.Text) ? (DateTime?)null : DateTime.Parse(txtDateAse.Text);
                    approval.GroupAse = txtGroupAse.Text;
                    approval.SignGroupAse = txtSignGroupAse.Text;
                    approval.SignDesign = txtSignDesign.Text;
                    approval.DateDesign = string.IsNullOrWhiteSpace(txtDateDesign.Text) ? (DateTime?)null : DateTime.Parse(txtDateDesign.Text);
                    approval.GroupDesign = txtGroupDesign.Text;
                    approval.SignGroupDesign = txtSignGroupDesign.Text;
                    approval.SignDyno = txtSignDyno.Text;
                    approval.DateDyno = string.IsNullOrWhiteSpace(txtDateDyno.Text) ? (DateTime?)null : DateTime.Parse(txtDateDyno.Text);
                    approval.GroupDyno = txtGroupDyno.Text;
                    approval.SignGroupDyno = txtSignGroupDyno.Text;
                }

                // For TestDetails: clear old rows and re-add from grid (optional)
                var oldDetails = context.TestDetails.Where(t => t.DvpNumber == dvpNo);
                context.TestDetails.RemoveRange(oldDetails);

                foreach (GridViewRow row in gvTestData.Rows)
                {
                    var entity = new TestDetail
                    {
                        DvpNumber = dvpNo,
                        Customer = (row.FindControl("ddlCustomerRow") as DropDownList)?.SelectedValue,
                        TestName = (row.FindControl("ddlTestName") as DropDownList)?.SelectedValue,
                        TDNo = (row.FindControl("txtTDNo") as TextBox)?.Text,
                        TestCondition = (row.FindControl("txtCondition") as TextBox)?.Text,
                        AcceptanceCriteria = (row.FindControl("txtCriteria") as TextBox)?.Text,
                        BiTestName = (row.FindControl("txtBiTestName") as TextBox)?.Text,
                        BiTestCode = (row.FindControl("txtBiTestCode") as TextBox)?.Text,
                        TestCostPlan = ParseDecimal((row.FindControl("txtCostPlan") as TextBox)?.Text),
                        QtyPlan = ParseInt((row.FindControl("txtQtyPlan") as TextBox)?.Text),
                        DVPlan = (row.FindControl("txtDVPlan") as TextBox)?.Text,
                        PVPlan = (row.FindControl("txtPVPlan") as TextBox)?.Text,
                        Responsibility = (row.FindControl("txtResponsibility") as TextBox)?.Text,
                        Remarks = (row.FindControl("txtRemarksRow") as TextBox)?.Text,
                        TestCostRs = ParseDecimal((row.FindControl("txtCostRs") as TextBox)?.Text),
                        TestCostActual = ParseDecimal((row.FindControl("txtCostActual") as TextBox)?.Text),
                        QtyActual = ParseInt((row.FindControl("txtQtyActual") as TextBox)?.Text),
                        DVActual = (row.FindControl("txtDVActual") as TextBox)?.Text,
                        PVActual = (row.FindControl("txtPVActual") as TextBox)?.Text
                    };

                    context.TestDetails.Add(entity);
                }

                context.SaveChanges();
            }

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Changes saved successfully.');", true);
        }


        private DataTable CreateEmptyTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DvpNumber", typeof(int));
            dt.Columns.Add("Customer", typeof(string));
            dt.Columns.Add("TestName", typeof(string));
            dt.Columns.Add("TDNo", typeof(string));
            dt.Columns.Add("TestCondition", typeof(string));
            dt.Columns.Add("AcceptanceCriteria", typeof(string));
            dt.Columns.Add("CostPlan", typeof(decimal));
            dt.Columns.Add("QtyPlan", typeof(int));
            dt.Columns.Add("DVPlan", typeof(string));
            dt.Columns.Add("PVPlan", typeof(string));
            dt.Columns.Add("Responsibility", typeof(string));
            dt.Columns.Add("RemarksRow", typeof(string));
            dt.Columns.Add("CostRs", typeof(decimal));
            dt.Columns.Add("BiTestName", typeof(string));
            dt.Columns.Add("BiTestCode", typeof(string));
            dt.Columns.Add("CostActual", typeof(decimal));
            dt.Columns.Add("QtyActual", typeof(int));
            dt.Columns.Add("DVActual", typeof(string));
            dt.Columns.Add("PVActual", typeof(string));

            ViewState[GridViewStateKey] = dt;
            return dt;
        }

        protected void gvTestData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var ddlCustomer = (DropDownList)e.Row.FindControl("ddlCustomerRow");
                if (ddlCustomer != null && ddlCustomer.Items.Count == 0)
                {
                    using (var context = new ApplicationDbContext())
                    {
                        var customers = context.TestRecords
                                               .Select(t => t.Customer)
                                               .Distinct()
                                               .OrderBy(c => c)
                                               .ToList();
                        ddlCustomer.DataSource = customers;
                        ddlCustomer.DataBind();
                        ddlCustomer.Items.Insert(0, new ListItem("--Select--", ""));
                    }
                }
            }
        }

        protected void ddlCustomerRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddlCustomer = (DropDownList)sender;
            var row = (GridViewRow)ddlCustomer.NamingContainer;
            var ddlTestName = (DropDownList)row.FindControl("ddlTestName");

            string selectedCustomer = ddlCustomer.SelectedValue;

            ddlTestName.Items.Clear();
            ddlTestName.Items.Add(new ListItem("--Select--", ""));

            var testNames = GetTestNamesForCustomer(selectedCustomer);

            if (testNames.Any())
            {
                foreach (var test in testNames)
                {
                    ddlTestName.Items.Add(new ListItem(test, test));
                }
            }
        }

        protected void ddlTestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddlTestName = (DropDownList)sender;
            var row = (GridViewRow)ddlTestName.NamingContainer;

            var ddlCustomer = (DropDownList)row.FindControl("ddlCustomerRow");
            string customer = ddlCustomer.SelectedValue;
            string testName = ddlTestName.SelectedValue;

            if (string.IsNullOrEmpty(customer) || string.IsNullOrEmpty(testName))
                return;

            using (var context = new ApplicationDbContext())
            {
                var record = context.TestRecords
                    .FirstOrDefault(t => t.Customer == customer && t.Test_Name == testName);

                if (record != null)
                {
                    ((TextBox)row.FindControl("txtTDNo")).Text = record.TDNo;
                    ((TextBox)row.FindControl("txtCondition")).Text = record.TestCondition;
                    ((TextBox)row.FindControl("txtCriteria")).Text = record.AcceptanceCriteria;
                    ((TextBox)row.FindControl("txtBiTestName")).Text = record.BiTestName;
                    ((TextBox)row.FindControl("txtBiTestCode")).Text = record.BiTestCode;
                    ((TextBox)row.FindControl("txtCostPlan")).Text = record.TestCost.HasValue ? record.TestCost.ToString() : "";
                }
                else
                {
                    // If no record found, clear the fields
                    ((TextBox)row.FindControl("txtTDNo")).Text = "";
                    ((TextBox)row.FindControl("txtCondition")).Text = "";
                    ((TextBox)row.FindControl("txtCriteria")).Text = "";
                    ((TextBox)row.FindControl("txtBiTestName")).Text = "";
                    ((TextBox)row.FindControl("txtBiTestCode")).Text = "";
                    ((TextBox)row.FindControl("txtCostPlan")).Text = "";
                }
            }
        }
            
        private List<string> GetTestNamesForCustomer(string customer)
        {
            if (string.IsNullOrEmpty(customer))
                return new List<string>();

            using (var context = new ApplicationDbContext())
            {
                return context.TestRecords
                    .Where(r => r.Customer == customer)
                    .Select(r => r.Test_Name)
                    .Distinct()
                    .OrderBy(name => name)
                    .ToList();
            }
        }




        private void BindGrid()
        {
            gvTestData.DataSource = ViewState[GridViewStateKey];
            gvTestData.DataBind();
        }
    }
}