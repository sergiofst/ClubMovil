<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master" CodeBehind="lst_contenido.aspx.vb" Inherits="ClubMovilAdmin.lst_contenido" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Contenidos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="span9 align-right">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn" />
        </div>
    </div>
    <div class="row">
        <div class="span9">
        <asp:GridView ID="gvDatos" runat="server" CssClass="table table-striped table-condensed"
            AutoGenerateColumns="false" AllowPaging="true" PageSize="20">
            <Columns>
                <asp:BoundField HeaderText="#" DataField="IdContenido" ItemStyle-Width="25px" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:TemplateField ItemStyle-Width="100px">
                    <ItemTemplate>
                        <div class="btn-group">
                            <button type="button" class="btn dropdown-toggle btn-mini" data-toggle="dropdown">
                                Accion<span class="caret"></span></button>
                            <ul class="dropdown-menu b">
                                <li>
                                    <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Editar">
                                    Editar
                                    </asp:LinkButton>
                                </li>
                                <li class="divider"></li>
                                <li>
                                    <asp:LinkButton ID="lnkCategorias" runat="server" CommandName="Categorias">
                                    Categorias
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnkClaves" runat="server" CommandName="Claves">
                                    Claves
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnkInfo" runat="server" CommandName="Informacion">
                                    Informacion
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnkImagenes" runat="server" CommandName="Imagenes">
                                    Imagenes
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnkArchivos" runat="server" CommandName="Archivos">
                                    Archivos
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
    </div>
</asp:Content>

