<%@ Page Title="" Language="C#" MasterPageFile="~/NewUser.Master" AutoEventWireup="true" CodeBehind="Post_View_NRU.aspx.cs" Inherits="VANHACK_Forum_Project.Pages.New_User.Post_View_NRU" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h1 class="mt-4"></h1>

            <div class="jumbotron">


                <h5 class="display-5" id="Post_Title_Div" runat="server"></h5>
                <div class="lead" id="Post_Content_Div" runat="server">
                </div>
                <br />
                <div id="Reply_Date" runat="server" class="blockquote-footer">Hello<cite title="Source Title"></cite></div>
            </div>
            <hr />
            <h4 class="display-5">Replies:</h4>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" />

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div runat="server" id="ReplyDIV"  class="card">
                        <div id="Reply_Header" runat="server" class="card-header">
                            <%#Eval("name")%>
                        </div>
                        <div class="card-body">
                            <blockquote class="blockquote mb-0">
                                <p id="Reply_Detail" runat="server"><%#Eval("post_txt")%></p>
                                <footer id="Reply_Date" runat="server" class="blockquote-footer"><%#Eval("create_date")%><cite title="Source Title"></cite></footer>
                            </blockquote>
                        </div>
                    </div>
         <br />
           
                </ItemTemplate>
                <FooterTemplate>
                    <div class="container" runat="server" visible='<%# Repeater1.Items.Count == 0 %>'>
                        <br />
                     <p class="alert alert-warning" role="alert">No replies yet! </p> 
                        </div>
                  </FooterTemplate>
            </asp:Repeater>
            <asp:HyperLink ID="linkPrev" runat="server">Previous Page</asp:HyperLink>
            <asp:HyperLink ID="linkNext" runat="server">Next Page</asp:HyperLink>
            <br />
            <br />
            <div>
             <hr />
                   
              <hr style="color:transparent !important" />
              
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT U.name  ,D.*  FROM 
 [Post_Details] as D
 
left  join [User] as  U on D.User_id=U.ID 
 where D.Post_id=@Id  and D.Post_typeID=2
 
order by D.id desc">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hdn_PostID" Name="Id" PropertyName="Value" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:HiddenField ID="hdn_PostID" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
