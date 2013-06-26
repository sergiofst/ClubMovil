<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Mobile/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ContentPlaceHolderID="HeaderContent" runat="server">
    <title>Club Movil</title>
</asp:Content>

<asp:Content ID="Headline1" ContentPlaceHolderID="HeadlineContent" runat="server">
	<h2 class="align-center">Bienvenido</h2>
    <p class="align-center">Seleccione un servicio:</p>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <ul>
        <% For Each row As DataRow In CType(ViewData("MenuList"), DataSet).Tables(0).Rows%>
        <li>
            <a href="<%: Url.Content(CStr(row("Url"))) %>">
            <%: row("Nombre")%>
            </a>  
        </li>
        <% Next %>
    </ul>
</asp:Content>
