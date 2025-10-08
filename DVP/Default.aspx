<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="DVP._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DVP Form</title>
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
            padding: 4px;
        }
        html,body{
            margin:0;
            padding:0;

        }
      
    
        h2{
            margin-left:30px;
        }
   
    </style>
</head>
<body>
   
        <div style="width:99%; height:50px; background: linear-gradient(to right,#EDAB46,#175EAA); display:flex; align-items:center; padding:10px 20px;">
            <img src="Images/logo.png" alt="Logo" style="height:50px; width:auto;" />
                </div>
    <form id="form1" runat="server">
    

        <h2>  Design Verification Plan (DVP) & Report (DVP&R)</h2>
        
        <table>
            <tr>
                <td>Customer:</td>
                <td><asp:DropDownList ID="ddlCustomer" runat="server">
                   <asp:ListItem Text="FCA" Value="FCA" />
                        <asp:ListItem Text="HKMC" Value="HKMC" />
                        <asp:ListItem Text="Honda" Value="Honda" />
                        <asp:ListItem Text="Mahindra" Value="Mahindra" />
                        <asp:ListItem Text="MSIL" Value="MSIL" />
                        <asp:ListItem Text="Nissan" Value="Nissan" />
                        <asp:ListItem Text="PSA" Value="PSA" />
                        <asp:ListItem Text="Renault" Value="Renault" />
                        <asp:ListItem Text="TML" Value="TML" />
                        <asp:ListItem Text="Toyota" Value="Toyota" />
                        <asp:ListItem Text="VW" Value="VW" />
                        <asp:ListItem Text="ZF" Value="ZF" />
                        <asp:ListItem Text="BI_Internal" Value="BI_Internal" />

                </asp:DropDownList></td>
                <td>EARN / JRN NO:</td>
                <td><asp:TextBox ID="txtEarnJrn" runat="server" /></td>
                <td>Project Name:</td>
                <td><asp:TextBox ID="txtProjectName" runat="server" /></td>
            </tr>
            <tr>

                
    <td>DVP/DVP & R No:</td>
    <td>
        <asp:DropDownList ID="ddlDvpMode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDvpMode_SelectedIndexChanged">
            <asp:ListItem Text="Select" Value="" />
            <asp:ListItem Text="New" Value="New" />
            <asp:ListItem Text="Existing" Value="Existing" />
        </asp:DropDownList><br />

        <asp:TextBox ID="txtDvpNumber" runat="server" Visible="true" />
        <asp:DropDownList ID="ddlExistingDvpNumbers" runat="server" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="ddlExistingDvpNumbers_SelectedIndexChanged" />
    </td>


             
                 <td>Brake Size:</td>
 <td><asp:DropDownList ID="ddlBrakeSize" runat="server">
     <asp:ListItem Text="240mm" />
     <asp:ListItem Text="260mm" />
 </asp:DropDownList></td>
                
            </tr>
            <tr>
                <td>Category:</td>
                <td><asp:DropDownList ID="ddlCategory" runat="server">
                    <asp:ListItem Text="Caliper assy" />
                    <asp:ListItem Text="Disc assy" />
                </asp:DropDownList></td>
                <td>Remarks:</td>
                <td><asp:TextBox ID="txtRemarks" runat="server" /></td>
                <td>DVP Revision No:</td>
                <td><asp:TextBox ID="txtRevisionNo" runat="server" /></td>
            </tr>
            <tr>
                <td>Front / Rear:</td>
                <td><asp:DropDownList ID="ddlFrontRear" runat="server">
                    <asp:ListItem Text="Front" />
                    <asp:ListItem Text="Rear" />
                </asp:DropDownList></td>
                <td>DVP Date:</td>
                <td><asp:TextBox ID="txtDvpDate" runat="server" TextMode="Date" /></td>
            </tr>
            <tr>
                <td>Friction Grade:</td>
                <td><asp:TextBox ID="txtFrictionGrade" runat="server" /></td>
                <td>DVP & R Date:</td>
                <td><asp:TextBox ID="txtDvpRDate" runat="server" TextMode="Date" /></td>
            </tr>
            <tr>
                <td>Reason for DVP:</td>
                <td colspan="3"><asp:DropDownList ID="ddlReason" runat="server" Width="100%">
                    <asp:ListItem Text="Validation" />
                    <asp:ListItem Text="Design Change" />
                </asp:DropDownList></td>
            </tr>
        </table>

        <br />

        <table>
            <tr>
                <th>Team Name</th>
                <th>Sign</th>
                <th>DATE</th>
                <th>Group heads</th>
                <th>Sign</th>
            </tr>
            <tr>
                <td>ASE TEAM</td>
                <td><asp:TextBox ID="txtSignAse" runat="server" /></td>
                <td><asp:TextBox ID="txtDateAse" runat="server" TextMode="Date" /></td>
                <td><asp:TextBox ID="txtGroupAse" runat="server" /></td>
                <td><asp:TextBox ID="txtSignGroupAse" runat="server" /></td>
            </tr>
            <tr>
                <td>Core Design</td>
                <td><asp:TextBox ID="txtSignDesign" runat="server" /></td>
                <td><asp:TextBox ID="txtDateDesign" runat="server" TextMode="Date" /></td>
                <td><asp:TextBox ID="txtGroupDesign" runat="server" /></td>
                <td><asp:TextBox ID="txtSignGroupDesign" runat="server" /></td>
            </tr>
            <tr>
                <td>Core Dyno</td>
                <td><asp:TextBox ID="txtSignDyno" runat="server" /></td>
                <td><asp:TextBox ID="txtDateDyno" runat="server" TextMode="Date" /></td>
                <td><asp:TextBox ID="txtGroupDyno" runat="server" /></td>
                <td><asp:TextBox ID="txtSignGroupDyno" runat="server" /></td>
            </tr>
        </table>

        <br />
        <div style = "margin-left:30px">
        <asp:Button ID="btnNewRow" runat="server" Text="New" OnClick="btnNewRow_Click" />
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" OnClick="btnSaveChanges_Click" Enabled="false" />

        <asp:Button ID="btnSaveDraft" runat="server" Text="Save Draft" OnClick="btnSaveDraft_Click" />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </div>
        <br /><br />
       <div style="width:99%; overflow-x:auto;">

       <asp:GridView ID="gvTestData" runat="server" AutoGenerateColumns="False" ShowHeader="true">
    <Columns>
        <asp:TemplateField HeaderText="SL.No">
            <ItemTemplate>
                <asp:Label ID="lblSLNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>' />
            </ItemTemplate>
        </asp:TemplateField>
     
        <asp:TemplateField HeaderText="DVP Number">
    <ItemTemplate>
        <asp:Label ID="lblDvpNumber" runat="server" Text='<%# Bind("DvpNumber") %>' />
    </ItemTemplate>
    </asp:TemplateField>



      <asp:TemplateField HeaderText="Customer">
    <ItemTemplate>
        <asp:DropDownList 
            ID="ddlCustomerRow" 
            runat="server" 
            AutoPostBack="True" 
            OnSelectedIndexChanged="ddlCustomerRow_SelectedIndexChanged">
            <asp:ListItem Text="--Select--" Value="" />
            <asp:ListItem Text="FCA" Value="FCA" />
            <asp:ListItem Text="HKMC" Value="HKMC" />
            <asp:ListItem Text="Honda" Value="Honda" />
            <asp:ListItem Text="Mahindra" Value="Mahindra" />
            <asp:ListItem Text="MSIL" Value="MSIL" />
            <asp:ListItem Text="Nissan" Value="Nissan" />
            <asp:ListItem Text="PSA" Value="PSA" />
            <asp:ListItem Text="Renault" Value="Renault" />
            <asp:ListItem Text="TML" Value="TML" />
            <asp:ListItem Text="Toyota" Value="Toyota" />
            <asp:ListItem Text="VW" Value="VW" />
            <asp:ListItem Text="ZF" Value="ZF" />
            <asp:ListItem Text="BI_Internal" Value="BI_Internal" />
        </asp:DropDownList>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Test Name">
    <ItemTemplate>
        <asp:DropDownList 
            ID="ddlTestName" 
            runat="server" 
            AutoPostBack="True" 
            OnSelectedIndexChanged="ddlTestName_SelectedIndexChanged">
            <asp:ListItem Text="--Select--" Value="" />
        </asp:DropDownList>
    </ItemTemplate>
</asp:TemplateField>


        <asp:TemplateField HeaderText="TD / Specification No">
            <ItemTemplate>
                <asp:TextBox ID="txtTDNo" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Test Condition">
            <ItemTemplate>
                <asp:TextBox ID="txtCondition" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Acceptance Criteria">
            <ItemTemplate>
                <asp:TextBox ID="txtCriteria" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Test Cost in Lakhs (Plan)">
            <ItemTemplate>
                <asp:TextBox ID="txtCostPlan" runat="server" TextMode="Number" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Qty (Plan)">
            <ItemTemplate>
                <asp:TextBox ID="txtQtyPlan" runat="server" TextMode="Number" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="DV Plan">
            <ItemTemplate>
                <asp:TextBox ID="txtDVPlan" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="PV Plan">
            <ItemTemplate>
                <asp:TextBox ID="txtPVPlan" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

   
        <asp:TemplateField HeaderText="Responsibility">
            <ItemTemplate>
                <asp:TextBox ID="txtResponsibility" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Remarks">
            <ItemTemplate>
                <asp:TextBox ID="txtRemarksRow" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Test Cost in Rs">
            <ItemTemplate>
                <asp:TextBox ID="txtCostRs" runat="server" TextMode="Number" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="BI Test Name">
            <ItemTemplate>
                <asp:TextBox ID="txtBiTestName" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="BI Test Code">
            <ItemTemplate>
                <asp:TextBox ID="txtBiTestCode" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Test Cost in Lakhs (Actual)">
            <ItemTemplate>
                <asp:TextBox ID="txtCostActual" runat="server" TextMode="Number" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Qty (Actual)">
            <ItemTemplate>
                <asp:TextBox ID="txtQtyActual" runat="server" TextMode="Number" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="DV (Actual)">
            <ItemTemplate>
                <asp:TextBox ID="txtDVActual" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="PV (Actual)">
            <ItemTemplate>
                <asp:TextBox ID="txtPVActual" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

 </div>

    </form>
</body>
</html>