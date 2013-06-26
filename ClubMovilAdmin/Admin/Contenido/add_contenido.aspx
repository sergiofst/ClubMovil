<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master" CodeBehind="add_contenido.aspx.vb" Inherits="ClubMovilAdmin.add_contenido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Nuevo contenido</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>
            Nuevo contenido</h1>
    </div>
    <div class="row">
        <fieldset>
           <div class="control-group">
                <asp:Label ID="Label5" CssClass="control-label" AssociatedControlID="ddlTipoContenido"
                    Text="Tipo de contenido" runat="server" />
                <div class="controls">
                    <asp:DropDownList ID="ddlTipoContenido" runat="server" DataTextField="Descripcion"
                        DataValueField="IdTipoContenido" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label1" CssClass="control-label" AssociatedControlID="tbNombre" Text="Nombre"
                    runat="server" />
                <div class="controls">
                    <asp:TextBox ID="tbNombre" runat="server" CssClass="input-xlarge" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="tbNombre"
                        runat="server" ErrorMessage="" Display="Dynamic" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label2" CssClass="control-label" AssociatedControlID="tbDescripcion"
                    Text="Descripcion" runat="server" />
                <div class="controls">
                    <asp:TextBox ID="tbDescripcion" runat="server" CssClass="input-xlarge" TextMode="MultiLine"
                        Rows="5" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbDescripcion"
                        runat="server" ErrorMessage="" Display="Dynamic" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label4" CssClass="control-label" AssociatedControlID="tbImagen" Text="Imagen"
                    runat="server" />
                <div class="controls">
                    <asp:TextBox ID="tbImagen" runat="server" CssClass="input-xlarge" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tbNombre"
                        runat="server" ErrorMessage="" Display="Dynamic" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label3" CssClass="control-label" AssociatedControlID="chkVisible" Text=""
                    runat="server" />
                <div class="controls">
                    <asp:CheckBox ID="chkVisible" runat="server" Text="Visible" />
                </div>
            </div>

            <div class="form-actions align-right">
                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar" runat="server" />
                <asp:Button ID="btnRegresar" CssClass="btn" Text="Regresar" runat="server" CausesValidation="false"/>
            </div>
        </fieldset>
    </div>
</asp:Content>