<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Posts.ascx.cs" Inherits="VANHACK_Forum_Project.UserControl.UC_Posts" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div id="Post_Div" runat="server"   >
<telerik:radgrid runat="server"   DataSourceID="SqlDataSource1" GroupPanelPosition="Top" Skin="Bootstrap" ID="RadGrid_Posts">
<GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
    <mastertableview autogeneratecolumns="False" datakeynames="Id" datasourceid="SqlDataSource1">
        <Columns>
            <telerik:GridBoundColumn  DataField="Id" DataType="System.Int32" FilterControlAltText="Filter Id column" HeaderText="Id" ReadOnly="True" SortExpression="Id" UniqueName="Id" Visible="False">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Category_Id" DataType="System.Int32" FilterControlAltText="Filter Category_Id column" HeaderText="Category_Id" SortExpression="Category_Id" UniqueName="Category_Id" Visible="False">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Title" FilterControlAltText="Filter Title column" HeaderText="Title" SortExpression="Title" UniqueName="Title">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="Date_Created" FilterControlAltText="Filter Date_Created column" HeaderText="Date Created" SortExpression="Date_Created" UniqueName="Date_Created">
            </telerik:GridBoundColumn>
        </Columns>
    </mastertableview>
</telerik:radgrid>
    </div>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Id, Category_Id, Title, Date_Created FROM Post WHERE (Status = 1 and Category_id=@Category_id)">
    <SelectParameters>
        <asp:ControlParameter ControlID="hdn_Category_Id" Name="Category_id" PropertyName="Value" />
    </SelectParameters>
</asp:SqlDataSource>

<asp:HiddenField ID="hdn_Category_Id" runat="server" />


