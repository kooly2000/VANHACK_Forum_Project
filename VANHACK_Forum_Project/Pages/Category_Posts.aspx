<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLoggedIN.Master" AutoEventWireup="true" CodeBehind="Category_Posts.aspx.cs" Inherits="VANHACK_Forum_Project.Pages.Category_Posts" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .rgMasterTable{
            font-size:16px  !important;

        }
        .rgHeader{
            font-weight:bold !important;
        }
    </style>
    <h1 class="mt-4"><asp:Label ID="lblCategoryTitle" runat="server" ></asp:Label> Posts </h1>   
    <telerik:radajaxloadingpanel runat="server" skin="Default"></telerik:radajaxloadingpanel>
    <div style="float:right; "></div>

    <telerik:radgrid id="radgrid1" RenderMode="Lightweight" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource1" GridLines="Both" GroupPanelPosition="Top" Skin="Bootstrap" 
        Font-Size="X-Large" AllowFilteringByColumn="True" AllowPaging="True" PageSize="20" AllowSorting="True" style="margin-top: 0px"   OnBatchEditCommand="RadGrid1_BatchEditCommand"  >
 <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
        <mastertableview  CommandItemDisplay="TopAndBottom"  autogeneratecolumns="False" EditMode="Batch"  datakeynames="Id" datasourceid="SqlDataSource1" allowfilteringbycolumn="False" allowpaging="False" pagesize="10">
                            
            <CommandItemSettings   ShowAddNewRecordButton="false"    RefreshText="Refresh" CancelChangestext="Cancel Changes" SaveChangestext="Save changes"  />           
            <BatchEditingSettings  OpenEditingEvent="Click" EditType="Cell" />

            <Columns>
                
                <telerik:GridTemplateColumn UniqueName="RowNo" HeaderText="#" AllowFiltering="false">
                    <ItemTemplate>
                        <%# (Container.ItemIndex+1).ToString() %>

                    </ItemTemplate>
                    <HeaderStyle Width="30px" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn    HeaderText="Title" AllowFiltering="true" ReadOnly="True" FilterControlAltText="Filter Title column" SortExpression="Title" UniqueName="Title">
                    <ItemTemplate>
                        <a href='/Pages/Post_View.aspx?Pageindex=1&ID=<%# Eval("ID") %>'> <%# Eval("Title") %></a>
                                
                     </ItemTemplate>
                    <HeaderStyle Width="40%" />
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn DataField="Name" DataType="System.Int32" FilterControlAltText="Filter Name column" HeaderText="Written by" ReadOnly="True" SortExpression="Name" UniqueName="Name">
                    <HeaderStyle Width="20%" />
                </telerik:GridBoundColumn>
            
                <telerik:GridBoundColumn DataField="Update_Date" DataType="System.DateTime"  ReadOnly="True" FilterControlAltText="Filter Update_Date column" HeaderText="Latest activity" SortExpression="Update_Date" UniqueName="Update_Date">
                     <HeaderStyle Width="25%" />
                </telerik:GridBoundColumn>
                   <telerik:GridCheckBoxColumn UniqueName="ShowHideCHCK"   DataField="status"  HeaderText="Status" AllowFiltering="true">
            <%--        <ItemTemplate >
                       <asp:CheckBox ID="PostFlag"   CommandName="chkbocCheck" AutoPostBack="true"  runat="server" Checked='<%# (bool)Eval("status")%>'></asp:CheckBox>
                        <input type="checkbox" runat="server"  AutoPostBack="true" />
                    </ItemTemplate>--%>
                    <HeaderStyle   />
                       <ItemStyle HorizontalAlign="Center" />
                </telerik:GridCheckBoxColumn>
            </Columns>
        </mastertableview>
    </telerik:radgrid>
    <asp:HiddenField ID="hdn_Category_id" runat="server" />
    <br />

    <telerik:radgrid id="radgrid2" runat="server" CellSpacing="-1" DataSourceID="SqlDataSource2" GridLines="Both" GroupPanelPosition="Top" Skin="Bootstrap" 
        Font-Size="X-Large" AllowFilteringByColumn="True" AllowPaging="True" PageSize="20" AllowSorting="True" style="margin-top: 0px" Visible="False"    >
 <GroupingSettings CollapseAllTooltip="Collapse all groups"></GroupingSettings>
        <mastertableview    autogeneratecolumns="False"    datakeynames="Id" datasourceid="SqlDataSource2" allowfilteringbycolumn="False" allowpaging="False" pagesize="10">
                             

            <Columns>
                
                <telerik:GridTemplateColumn UniqueName="RowNo" HeaderText="#" AllowFiltering="false">
                    <ItemTemplate>
                        <%# (Container.ItemIndex+1).ToString() %>

                    </ItemTemplate>
                    <HeaderStyle Width="30px" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn    HeaderText="Title" AllowFiltering="true" ReadOnly="True" FilterControlAltText="Filter Title column" SortExpression="Title" UniqueName="Title">
                    <ItemTemplate>
                        <a href='/Pages/Post_View.aspx?Pageindex=1&ID=<%# Eval("ID") %>'> <%# Eval("Title") %></a>
                                
                     </ItemTemplate>
                    <HeaderStyle Width="40%" />
                </telerik:GridTemplateColumn>

                <telerik:GridBoundColumn DataField="Name" DataType="System.Int32" FilterControlAltText="Filter Name column" HeaderText="Written by" ReadOnly="True" SortExpression="Name" UniqueName="Name">
                    <HeaderStyle Width="20%" />
                </telerik:GridBoundColumn>
            
                <telerik:GridBoundColumn DataField="Update_Date" DataType="System.DateTime"  ReadOnly="True" FilterControlAltText="Filter Update_Date column" HeaderText="Latest activity" SortExpression="Update_Date" UniqueName="Update_Date">
                     <HeaderStyle Width="25%" />
                </telerik:GridBoundColumn>
 
            </Columns>
        </mastertableview>

<FilterMenu RenderMode="Lightweight"></FilterMenu>

<HeaderContextMenu RenderMode="Lightweight"></HeaderContextMenu>
    </telerik:radgrid>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT P.id,p.title ,p.update_date,p.status,U.Name, count(D.Post_id)  as CountPosts FROM 
[Post] as P left join [Post_Details] as D
  on P.ID=D.Post_id  and D.Post_typeID=2
 inner join [User] as  U on P.User_id=U.ID 
 where P.Category_Id=@Category_Id
group by P.id,p.title ,D.post_id,p.update_date,p.status ,U.Name
order by p.update_date desc">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdn_Category_id" DbType="Int32" Name="Category_Id" PropertyName="Value" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT P.id,p.title ,p.update_date,p.status,U.Name, count(D.Post_id)  as CountPosts FROM 
[Post] as P left join [Post_Details] as D
  on P.ID=D.Post_id  and D.Post_typeID=2
 inner join [User] as  U on P.User_id=U.ID 
 where P.Category_Id=@Category_Id and P.status=1
group by P.id,p.title ,D.post_id,p.update_date,p.status ,U.Name
order by p.update_date desc">
        <SelectParameters>
            <asp:ControlParameter ControlID="hdn_Category_id" DbType="Int32" Name="Category_Id" PropertyName="Value" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
