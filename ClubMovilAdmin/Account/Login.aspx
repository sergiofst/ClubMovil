<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master/Default.Master"
    CodeBehind="Login.aspx.vb" Inherits="ClubMovilAdmin.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Inicio de sesion</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row-fluid">
        <div class="login-wrapper">
            <div class="page-header">
                <h1>
                    Inicio de sesion</h1>
            </div>
            <fieldset>
                <div class="control-group">
                    <asp:Label ID="Label1" CssClass="control-label" AssociatedControlID="tbUsuario" Text="Usuario"
                        runat="server" />
                    <div class="controls">
                        <asp:TextBox ID="tbUsuario" CssClass="input-xlarge" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbUsuario"
                            runat="server" ErrorMessage="" Display="Dynamic" />
                    </div>
                </div>
                <div class="control-group">
                    <asp:Label ID="Label2" CssClass="control-label" AssociatedControlID="tbPassword"
                        Text="Contraseña" runat="server" />
                    <div class="controls">
                        <asp:TextBox ID="tbPassword" CssClass="input-xlarge" runat="server" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbPassword"
                            runat="server" ErrorMessage="" Display="Dynamic" />
                    </div>
                </div>
                <div class="form-actions">
                    <asp:Button ID="btnIniciar" CssClass="btn btn-primary" Text="Iniciar" runat="server" />
                </div>
            </fieldset>
        </div>
    </div>
</asp:Content>
