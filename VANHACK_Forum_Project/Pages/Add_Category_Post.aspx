<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLoggedIN.Master" AutoEventWireup="true" CodeBehind="Add_Category_Post.aspx.cs" Inherits="VANHACK_Forum_Project.Pages.Add_Category_Post" %>

<%@ Register Src="~/UserControl/UC_Add_Post.ascx" TagPrefix="uc1" TagName="UC_Add_Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UC_Add_Post runat="server" ID="UC_Add_Post1" />
</asp:Content>
