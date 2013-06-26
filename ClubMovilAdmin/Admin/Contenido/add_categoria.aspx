<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master" CodeBehind="add_categoria.aspx.vb" Inherits="ClubMovilAdmin.add_categoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Nueva categoria</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>
            Nueva categoria</h1>
    </div>
    <div class="row">
        <fieldset>
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
                <asp:Label ID="Label4" CssClass="control-label" AssociatedControlID="ddlPadre"
                    Text="Padre" runat="server" />
                <div class="controls">
                    <asp:DropDownList ID="ddlPadre" runat="server" DataTextField="Nombre" DataValueField="IdCategoria"
                        AppendDataBoundItems="true">
                        <asp:ListItem Text="(Ninguno)" Value="0" />
                    </asp:DropDownList>
                </div>
            </div>


            <div class="form-actions align-right">
                <asp:Button ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar" runat="server" />
                <asp:Button ID="btnRegresar" CssClass="btn" Text="Regresar" runat="server" CausesValidation="false"/>
            </div>
        </fieldset>
    </div>
</asp:Content>
