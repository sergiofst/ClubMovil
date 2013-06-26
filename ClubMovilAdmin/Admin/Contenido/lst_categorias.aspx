<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master" CodeBehind="lst_categorias.aspx.vb" Inherits="ClubMovilAdmin.lst_categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Usuarios</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="page-header">
        <h1>
            Categorias de contenido</h1>
    </div>
    <div class="row">
        <div class="align-right">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn" />
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="gvCategorias" runat="server" CssClass="table table-striped table-condensed"
            AutoGenerateColumns="false" AllowPaging="true" PageSize="20">
            <Columns>
                <asp:BoundField HeaderText="#" DataField="IdCategoria" ItemStyle-Width="25px" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Padre" DataField="CategoriaPadre" />
                <asp:TemplateField ItemStyle-Width="100px">
                    <ItemTemplate>
                        <div class="btn-group">
                            <button type="button" class="btn dropdown-toggle" data-toggle="dropdown">
                                Accion<span class="caret"></span></button>
                            <ul class="dropdown-menu">
                                <li>
                                    <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Editar">
                                    Editar
                                    </asp:LinkButton>
                                </li>
                                <li class="divider"></li>
                                <li>
                                    <asp:LinkButton ID="lnkEliminar" runat="server" CommandName="Eliminar">
                                    Eliminar
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
