<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master"
    CodeBehind="lst_contenido_claves.aspx.vb" Inherits="ClubMovilAdmin.lst_contenido_claves" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Claves de contenido</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>
            Claves de contenido</h1>
    </div>
    <div class="row well">
        <div class="input-append">
            <asp:TextBox ID="tbNuevaClave" runat="server" CssClass="input-xlarge" />
            <asp:Button ID="btnAgregarClave" runat="server" CssClass="btn" Text="Agregar" />
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="gvDatos" runat="server" CssClass="table table-striped table-condensed"
            AutoGenerateColumns="false" AllowPaging="true" PageSize="20">
            <Columns>
                <asp:BoundField HeaderText="#" DataField="IdContenidoClave" ItemStyle-Width="25px" />
                <asp:BoundField HeaderText="Clave" DataField="Clave" />
                <asp:TemplateField ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
