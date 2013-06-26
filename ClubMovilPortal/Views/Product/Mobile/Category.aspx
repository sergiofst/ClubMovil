<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Mobile/Mobile.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <ul>
        <% For Each row As DataRow In CType(ViewData("Products"), DataSet).Tables(0).Rows%>
        <li>
            <img src= "<%: Html.ResolveContentUrl(row("Image"))%>" alt="<%:row("Name") %>"/>
            <%: CStr(row("Name"))%>
        </li>
        <% Next%>
    </ul>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <title>
        <%: CType(ViewData("Category"), DataRow)("Name")%></title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadlineContent" runat="server">
    <h2>
        <%: CType(ViewData("Category"), DataRow)("Name")%></h2>
</asp:Content>
