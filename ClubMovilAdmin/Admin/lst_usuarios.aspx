<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master" CodeBehind="lst_usuarios.aspx.vb" Inherits="ClubMovilAdmin.lst_usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Usuarios</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="span6 form-inline">
            <asp:TextBox ID="tbBuscar" runat="server" CssClass="input-medium" />
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn"/>
        </div>
        <div class="span3 form-inline align-right">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn" />
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="gvDatos" runat="server" CssClass="table table-striped table-condensed"
            AutoGenerateColumns="false" AllowPaging="true" PageSize="20">
            <Columns>
                <asp:BoundField HeaderText="#" DataField="IdUsuario" ItemStyle-Width="25px" />
                <asp:BoundField HeaderText="Usuario" DataField="Usuario" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:TemplateField ItemStyle-Width="100px">
                    <ItemTemplate>
                        <div class="btn-group">
                            <button type="button" class="btn btn-small dropdown-toggle" data-toggle="dropdown">
                                Accion<span class="caret"></span></button>
                            <ul class="dropdown-menu">
                                <li>
                                    <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Editar">
                                    Editar
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnkRoles" runat="server" CommandName="Editar">
                                    Roles
                                    </asp:LinkButton>
                                </li>
                                <li class="divider"></li>
                                <li>
                                    <asp:LinkButton ID="lnkPassword" runat="server" CommandName="Password">
                                    Contraseña
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
