<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master" CodeBehind="lst_contenido_info.aspx.vb" Inherits="ClubMovilAdmin.lst_contenido_info" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Informacion de contenido</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>
            Informacion de contenido</h1>
    </div>
    <div class="row well">
            <asp:TextBox ID="tbEtiqueta" runat="server" CssClass="input-xlarge" />
            <asp:TextBox ID="tbValor" runat="server" CssClass="input-xlarge" TextMode="MultiLine" Rows="5" Columns="7" />
            <br />
            <asp:Button ID="btnAgregar" runat="server" CssClass="btn" Text="Agregar" />
    </div>
    <div class="row">
        <asp:GridView ID="gvDatos" runat="server" CssClass="table table-striped table-condensed"
            AutoGenerateColumns="false" AllowPaging="true" PageSize="20">
            <Columns>
                <asp:BoundField HeaderText="#" DataField="IdContenidoClave" ItemStyle-Width="25px" />
                <asp:BoundField HeaderText="Clave" DataField="Clave" />
                <asp:TemplateField ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
