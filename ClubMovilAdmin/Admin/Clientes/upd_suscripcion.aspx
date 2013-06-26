<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Admin.master" CodeBehind="upd_suscripcion.aspx.vb" Inherits="ClubMovilAdmin.upd_suscripcion" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Editar suscripcion</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>
            Editar suscripcion</h1>
    </div>
    <div class="row-fluid">
        <fieldset>
            <div class="control-group">
                <asp:Label CssClass="control-label" AssociatedControlID="litIdSuscripcion"
                    Text="Id" runat="server" />
                <div class="controls">
                    <asp:Literal id="litIdSuscripcion" runat="server" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label  CssClass="control-label" AssociatedControlID="litTelefono"
                    Text="Telefono" runat="server" />
                <div class="controls">
                    <asp:Literal id="litTelefono" runat="server" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label  CssClass="control-label" AssociatedControlID="litFechaSuscripcion"
                    Text="Fecha de suscripcion" runat="server" />
                <div class="controls">
                    <asp:Literal id="litFechaSuscripcion" runat="server" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label CssClass="control-label" AssociatedControlID="litFechaRenovacion"
                    Text="Fecha de renovacion" runat="server" />
                <div class="controls">
                    <asp:Literal id="litFechaRenovacion" runat="server" />
                </div>
            </div>
            <div class="control-group">
                <asp:Label  CssClass="control-label" AssociatedControlID="ddlEstatus"
                    Text="Estatus" runat="server" />
                <div class="controls">
                    <asp:DropDownList id="ddlEstatus" runat="server" >
                        <asp:ListItem Text="Cancelada" Value="0" />
                        <asp:ListItem Text="Baja" Value="1" />
                        <asp:ListItem Text="Pendiente" Value="2" />
                        <asp:ListItem Text="Activa" Value="3" />
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
