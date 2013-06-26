<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master"
    CodeBehind="add_usuario.aspx.vb" Inherits="ClubMovilAdmin.add_usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Nuevo usuario</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>
            Nuevo usuario</h1>
    </div>
    <div class="row">
        <fieldset>
            <div class="control-group">
                <asp:Label ID="Label3" CssClass="control-label" AssociatedControlID="tbUsuario" Text="Usuario"
                    runat="server" />
                <div class="controls form-inline">
                    <asp:TextBox ID="tbUsuario" runat="server" CssClass="input-xlarge" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbUsuario"
                        runat="server" ErrorMessage="" Display="Dynamic" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label1" CssClass="control-label" AssociatedControlID="tbNombre" Text="Nombre"
                    runat="server" />
                <div class="controls form-inline">
                    <asp:TextBox ID="tbNombre" runat="server" CssClass="input-xlarge" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbNombre"
                        runat="server" ErrorMessage="" Display="Dynamic" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label2" CssClass="control-label" AssociatedControlID="tbPassword" Text="Password"
                    runat="server" />
                <div class="controls form-inline">
                    <asp:TextBox ID="tbPassword" runat="server" CssClass="input-xlarge" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="tbPassword"
                        runat="server" ErrorMessage="" Display="Dynamic" />
                </div>
            </div>
            <div class="form-actions align-right">
                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar" runat="server" />
                <asp:Button ID="btnRegresar" CssClass="btn" Text="Regresar" runat="server" CausesValidation="false" />
            </div>
        </fieldset>
    </div>
</asp:Content>
