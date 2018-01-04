<%@ Page Title="" Language="C#" MasterPageFile="~/NewUser.Master" AutoEventWireup="true" CodeBehind="Add_User_Page.aspx.cs" Inherits="VANHACK_Forum_Project.Pages.New_User.Add_User_Page" %>

<%@ Register Src="~/UserControl/UC_User_ADD.ascx" TagPrefix="uc1" TagName="UC_User_ADD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UC_User_ADD runat="server" id="UC_User_ADD" />
</asp:Content>
