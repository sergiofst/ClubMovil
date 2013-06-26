<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master"
    CodeBehind="lst_contenido_imagenes.aspx.vb" Inherits="ClubMovilAdmin.lst_contenido_imagenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Imagenes de contenido</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>
            Imagenes de contenido</h1>
    </div>
    <div class="row well">
        <div class="input-append">
            <asp:FileUpload ID="fuImagen" runat="server" />
            <asp:Button ID="btnAgregarImagen" runat="server" CssClass="btn" Text="Agregar" />
        </div>
    </div>
    <div class="row">
        <asp:Repeater ID="rptImagenes" runat="server">
            <ItemTemplate>
                <div class="thumb pull-left">
                    <div class="thumb_imagen">
                        <asp:Image ID="imgImagen" runat="server" />
                    </div>
                    <div class="thumb_actions align-center">
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" class="btn btn-danger" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clearfix">
            &nbsp;</div>
        <br />
    </div>
</asp:Content>
