<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Mobile/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
    <title>Club Movil</title>
</asp:Content>

<asp:Content ID="Headline1" ContentPlaceHolderID="HeadlineContent" runat="server">
    <h2>
        <%: CType(ViewData("Categoria"), DataRow)("Nombre")%></h2>
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <ul>
        <% For Each row As DataRow In CType(ViewData("ContenidoList"), DataSet).Tables(0).Rows%>
        <li>
            <%: Html.ProductPreviewLink(row("IdContenido"), row("Nombre"), row("Imagen"))%>
        </li>
        <% Next %>
    </ul>
    <br />
    <a href="javascript:history.back();" >Regresar</a>
</asp:Content>
