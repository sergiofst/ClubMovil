<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master" CodeBehind="lst_contenido_fondos.aspx.vb" Inherits="ClubMovilAdmin.lst_contenido_fondos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Contenido fondos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>
            Contenido fondos</h1>
    </div>
    <div class="row well">
        <fieldset>
            <div class="control-group">
                <asp:Label ID="Label4" CssClass="control-label" AssociatedControlID="ddlAnchoImagen"
                    Text="Ancho" runat="server" />
                <div class="controls">
                    <asp:DropDownList ID="ddlAnchoImagen" runat="server" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label3" CssClass="control-label" AssociatedControlID="fuArchivo" Text="Archivo"
                    runat="server" />
                <div class="controls">
                    <asp:FileUpload ID="fuArchivo" runat="server" />
                </div>
            </div>
            <div class="form-actions align-right">
                <asp:Button ID="btnAgregar" CssClass="btn btn-primary" Text="Agregar" runat="server" />
            </div>
        </fieldset>
    </div>
    <div class="row">
        <asp:GridView ID="gvDatos" runat="server" CssClass="table table-striped table-condensed"
            AutoGenerateColumns="false" AllowPaging="true" PageSize="20">
            <Columns>
                <asp:BoundField HeaderText="Ancho" DataField="AnchoImagen" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image ID="imgArchivo" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CssClass="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
