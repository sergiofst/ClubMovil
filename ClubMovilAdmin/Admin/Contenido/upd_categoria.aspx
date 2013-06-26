<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master" CodeBehind="upd_categoria.aspx.vb" Inherits="ClubMovilAdmin.upd_categoria" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Editar categoria</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>
            Editar categoria</h1>
    </div>
    <div class="row-fluid">
        <fieldset>
            <div class="control-group">
                <asp:Label ID="Label3" CssClass="control-label" AssociatedControlID="litIdCategoria"
                    Text="Id" runat="server" />
                <div class="controls">
                    <asp:Literal id="litIdCategoria" runat="server" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label1" CssClass="control-label" AssociatedControlID="tbNombre"
                    Text="Nombre" runat="server" />
                <div class="controls">
                    <asp:TextBox id="tbNombre" runat="server" CssClass="input-xlarge" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="tbNombre"
                        runat="server" ErrorMessage="El campo es requerido" Display="Dynamic" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label2" CssClass="control-label" AssociatedControlID="tbDescripcion"
                    Text="Descripcion" runat="server" />
                <div class="controls">
                    <asp:TextBox id="tbDescripcion" runat="server" CssClass="input-xlarge" TextMode="MultiLine" Rows="5" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbDescripcion"
                        runat="server" ErrorMessage="El campo es requerido" Display="Dynamic" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label ID="Label3" CssClass="control-label" AssociatedControlID="ddlPadre"
                    Text="Padre" runat="server" />
                <div class="controls">
                    <asp:DropDownList id="ddlPadre" runat="server" DataTextField="Name" DataValueField="IdIssuerCategory" AppendDataBoundItems="true">
                        <asp:ListItem Text="(Ninguno)" Value="0" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-actions align-right">
                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar" runat="server" />
                <asp:Button ID="btnRegresar" CssClass="btn" Text="Regresar" runat="server" />
            </div>
        </fieldset>
    </div>
</asp:Content>