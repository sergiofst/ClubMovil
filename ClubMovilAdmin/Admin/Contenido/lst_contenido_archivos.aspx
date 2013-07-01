<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master"
    CodeBehind="lst_contenido_archivos.aspx.vb" Inherits="ClubMovilAdmin.lst_contenido_archivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Archivos de contenido</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>
            Archivos de contenido</h1>
    </div>
    <div class="row well">
        <fieldset>
            <div class="control-group">
                <asp:Label ID="Label4" CssClass="control-label" AssociatedControlID="tbNuevoGrupo"
                    Text="Grupo" runat="server" />
                <div class="controls">
                    <asp:TextBox ID="tbNuevoGrupo" runat="server" CssClass="input-xlarge" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbNuevoGrupo"
                        runat="server" ErrorMessage="" Display="Dynamic" />
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
                <asp:BoundField HeaderText="#" DataField="IdContenidoArchivo" ItemStyle-Width="25px" />
                <asp:BoundField HeaderText="Grupo" DataField="Grupo" />
                <asp:BoundField HeaderText="Archivo" DataField="Archivo" />
                <asp:TemplateField ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
