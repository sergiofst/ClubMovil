<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Mobile/Mobile.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contenido_comprar">
        <%: Html.ActionLink("Comprar", "Comprar", New With {.Id = CType(ViewData("Contenido"), DataRow)("IdContenido")})%>
    </div>
    <div class="contenido_imagenes">
        <ul>
            <% For Each row As DataRow In CType(ViewData("ContenidoImagenes"), DataSet).Tables(0).Rows%>
            <li>
                <%: Html.ContenidoImagen(row("FileName"))%>
            </li>
            <% Next%>
        </ul> 
    </div>
    <div class="contenido_descripcion">
        <%: CType(ViewData("Contenido"), DataRow)("Descripcion")%>
    </div>
    <br />
    <div class="contenido_info">
        <% For Each row As DataRow In CType(ViewData("ContenidoInfo"), DataSet).Tables(0).Rows%>
            <strong><%: CStr(row("Etiqueta"))%>:</strong>
            <br />
            <%: CStr(row("Valor"))%>
            <br />
        </li>
        <% Next%>
    </div>
    <br />
    <a href="javascript:history.back();">Regresar</a>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <title>
        <%: CType(ViewData("Contenido"), DataRow)("Nombre")%></title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadlineContent" runat="server">
    <h2>
        <%: CType(ViewData("Contenido"), DataRow)("Nombre")%></h2>
</asp:Content>
