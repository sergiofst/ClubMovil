<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Mobile/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <title>
        <%: CType(ViewData("Product"), DataRow)("Name")%></title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadlineContent" runat="server">
    <h2>
        <%: CType(ViewData("Product"), DataRow)("Name")%></h2>
</asp:Content>
