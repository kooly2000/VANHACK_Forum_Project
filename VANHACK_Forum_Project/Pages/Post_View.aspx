<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLoggedIN.Master" AutoEventWireup="true" CodeBehind="Post_View.aspx.cs" Inherits="VANHACK_Forum_Project.Pages.Post_View" %>

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
                <div id="Reply_Date" runat="server" class="blockquote-footer"><cite title="Source Title"></cite></div>
            </div>
            <hr />
            <h4 class="display-5">Replies:</h4>
            <div id="AdminDiv" runat="server">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" />
                <span style="width: 5px !important;"></span>
                <asp:Button Text="Show/Hide Replies" CssClass="btn btn-primary" OnClick="DoSend" runat="server" />
                <br />

                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div runat="server" id="ReplyDIV" class="card">
                            <div id="Reply_Header" runat="server" class="card-header">
                                <%#Eval("name")%>   ||          
                            <asp:CheckBox ID="selectPost" runat="server" Text="Visible" Checked='<%#Eval("status")%>' ForeColor="Red" />
                            </div>
                            <div class="card-body">
                                <blockquote class="blockquote mb-0">
                                    <p id="Reply_Detail" runat="server"><%#Eval("post_txt")%> </p>
                                    <asp:HiddenField ID="hdnID" runat="server" Value='<%#Eval("id")%>' />
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
            </div>

            <br />
            <div id="UserDiv" runat="server">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" />
                <span style="width: 5px !important;"></span>

                <asp:Repeater ID="Repeater2" runat="server">
                    <ItemTemplate>
                        <div runat="server" id="ReplyDIV" class="card">
                            <div id="Reply_Header" runat="server" class="card-header">
                                <%#Eval("name")%>          
                             </div>
                            <div class="card-body">
                                <blockquote class="blockquote mb-0">
                                    <p id="Reply_Detail" runat="server"><%#Eval("post_txt")%> </p>
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
                <asp:HyperLink ID="HyperLink3" runat="server">Previous Page</asp:HyperLink>
                <asp:HyperLink ID="HyperLink4" runat="server">Next Page</asp:HyperLink>
            </div>
            <br />
            <br />
            <div>
                <h4 class="display-5">Add Reply:</h4>
                <telerik:radeditor id="Editor1" runat="server" enableresize="False" dialoghandlerurl="Telerik.Web.UI.DialogHandler.axd">
                    <content>
</content>
                    <imagemanager uploadpaths="~/attachments" viewpaths="~/attachments" />
                    <documentmanager uploadpaths="~/attachments" viewpaths="~/attachments" />
                    <flashmanager uploadpaths="~/attachments" viewpaths="~/attachments" />
                    <silverlightmanager uploadpaths="~/attachments" viewpaths="~/attachments" />
                    <mediamanager uploadpaths="~/attachments" viewpaths="~/attachments" />
                    <templatemanager uploadpaths="~/attachments" viewpaths="~/attachments" />
                    <trackchangessettings canaccepttrackchanges="False" />
                </telerik:radeditor>
                <hr />
                <asp:Button ID="btn_send" runat="server" CssClass="btn btn-success" Text="Send" OnClick="btn_send_Click" Width="100px" />

                <hr style="color: transparent !important" />

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
              <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT U.name  ,D.*  FROM 
 [Post_Details] as D
 
left  join [User] as  U on D.User_id=U.ID 
 where D.Post_id=@Id  and D.Post_typeID=2 and D.status=1
 
order by D.id desc">
                <SelectParameters>
                    <asp:ControlParameter ControlID="hdn_PostID" Name="Id" PropertyName="Value" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:HiddenField ID="hdn_PostID" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
