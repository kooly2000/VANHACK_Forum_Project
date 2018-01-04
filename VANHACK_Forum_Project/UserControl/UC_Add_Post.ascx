<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Add_Post.ascx.cs" Inherits="VANHACK_Forum_Project.UserControl.UC_Add_Post" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<br />
<div class="form-group">
    <label for="inputTitle" class="control-label">Post Title</label>
    <input type="text" runat="server"   class="form-control" id="inputTitle" placeholder="Enter post title"  required width="60%">
    <div class="help-block with-errors"></div>
</div>
<telerik:radeditor id="Editor1" runat="server" enableresize="False" dialoghandlerurl="Telerik.Web.UI.DialogHandler.axd" width="100%">
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
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Editor1" ErrorMessage="You have to write something in the post!!" ForeColor="Red"></asp:RequiredFieldValidator>
<br />

<asp:Button ID="btn_send" runat="server" CssClass="btn btn-success" OnClick="btn_send_Click" Text="Send" Width="100px" />

<asp:HiddenField ID="hdn__Category_IdAP" runat="server" />


