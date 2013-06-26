<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master"
    CodeBehind="upd_usuario_pass.aspx.vb" Inherits="ClubMovilAdmin.upd_usuario_pass" %>

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
                <asp:Label ID="Label2" CssClass="control-label" AssociatedControlID="tbNuevoPassword"
                    Text="Nueva contraseña" runat="server" />
                <div class="controls">
                    <asp:TextBox ID="tbNuevoPassword" runat="server" CssClass="input-xlarge" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbNuevoPassword"
                        runat="server" ErrorMessage="" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbNuevoPassword"
                        ValidationExpression="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"
                        ErrorMessage="<br/>La contraseña debe tener al menos una Mayuscula, un numero y una longitud de minimo 8 caracteres"
                        Display="Dynamic" runat="server" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label3" CssClass="control-label" AssociatedControlID="tbNuevoPaswordRe"
                    Text="Verificar contraseña" runat="server" />
                <div class="controls">
                    <asp:TextBox ID="tbNuevoPaswordRe" runat="server" CssClass="input-xlarge" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbNuevoPaswordRe"
                        runat="server" ErrorMessage="" Display="Dynamic" />
                    <asp:CompareValidator ID="CompareValidator1" ControlToValidate="tbNuevoPaswordRe"
                        ControlToCompare="tbNuevoPassword" Display="Dynamic" ErrorMessage="<br/>Las contraseñas no coinciden"
                        runat="server" />
                </div>
            </div>
            <div class="form-actions">
                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar cambios" runat="server" />
                <asp:Button ID="btnRegresar" CssClass="btn" Text="Regresar" runat="server" CausesValidation="false" />
            </div>
        </fieldset>
    </div>
</asp:Content>
