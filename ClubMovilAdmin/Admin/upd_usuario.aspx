<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master"
    CodeBehind="upd_usuario.aspx.vb" Inherits="ClubMovilAdmin.upd_usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Actualizar usuario</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row-fluid">
        <div class="page-header">
            <h1>
                Editar usuario</h1>
        </div>
    </div>
    <div class="row-fluid">
        <fieldset>
            <div class="control-group">
                <asp:Label ID="Label7" CssClass="control-label" AssociatedControlID="litlitIdUsuarioIssuer" Text="Id"
                    runat="server" />
                <div class="controls">
                    <asp:Literal ID="litIdUsuario" runat="server" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label5" CssClass="control-label" AssociatedControlID="tbNombre"
                    Text="Nombre" runat="server" />
                <div class="controls">
                    <asp:TextBox ID="tbNombre" runat="server" CssClass="input-xlarge" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="tbNombre"
                        runat="server" ErrorMessage="" Display="Dynamic" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label1" CssClass="control-label" AssociatedControlID="tbUsuario"
                    Text="Usuario" runat="server" />
                <div class="controls">
                    <asp:TextBox ID="tbUsuario" runat="server" CssClass="input-xlarge" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbUsuario"
                        runat="server" ErrorMessage="" Display="Dynamic" />
                </div>
            </div>
            <div class="form-actions align-right">
                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar" runat="server" />
                <asp:Button ID="btnRegresar" CssClass="btn" Text="Regresar" runat="server" CausesValidation="false" />
                <asp:Button ID="btnEliminar" CssClass="btn btn-danger" Text="Eliminar" runat="server" CausesValidation="false" />
            </div>
        </fieldset>
    </div>
</asp:Content>
