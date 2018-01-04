<%@ Page Title="" Language="C#" MasterPageFile="~/NewUser.Master" AutoEventWireup="true" CodeBehind="Login_Default.aspx.cs" Inherits="VANHACK_Forum_Project.Pages.New_User.Login_Default" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-4">Forum Categories</h1>                     
        <table class="table-hover" style="width:100%">
                           <tr runat="server"   id="tr_header">
                               <td>Category Title</td>
                                
                               <td style="width:150px;">Post Count</td>     
                               
                           </tr>
                </table>
      <telerik:radtreelist   runat="server"     DataKeyNames="Id" DataSourceID="SqlDataSource1" ParentDataKeyNames="Category_Main" ID="RDTREE_LST" AutoGenerateColumns="False" OnItemCreated="RDTREE_LST_ItemCreated" OnLoad="RDTREE_LST_Load" Font-Size="X-Large" Skin="Metro" OnItemDataBound="RDTREE_LST_ItemDataBound"  >
        <Columns>
        
               <telerik:TreeListTemplateColumn  DataField="Category_Title" UniqueName="Category_Title"  >
                   <itemTemplate>
                       <table class="table-hover" style="width:100%">
                         
                           <tr>
                      
                                   <asp:Label ID="lbl_CategID1" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                                  
                               <td  >
                                   <a href='/Pages/New_User/Category_Post_NRU.aspx?ID=<%# Eval("Id") %>'> <span><%# Eval("Category_Title") %></span></a>
                                       
                               </td>
                                
                               <td  style="width:150px;">                       
                                   <asp:Label ID="lbl_PostCount" runat="server"    Font-Bold="True"></asp:Label>
                               </td>
                      
                           </tr>
                       </table>
                       

                     </itemTemplate>
                 
            </telerik:TreeListTemplateColumn>
            
        </Columns>
    </telerik:radtreelist>
    <hr />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Id], [Category_Main], [Category_Title], [Status] FROM [Category]"></asp:SqlDataSource>
  
</asp:Content>
