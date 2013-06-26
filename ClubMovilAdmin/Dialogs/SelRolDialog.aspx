<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Dialogs/Dialogs.master" CodeBehind="SelRolDialog.aspx.vb" Inherits="ClubMovilAdmin.SelRolDialog" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="row form-inline align-right">
    <div class="row">
        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-striped table-condensed"
            PageSize="20">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <strong>
                            <asp:Literal ID="litNombre" runat="server" />
                        </strong>
                        <br />
                        <asp:Literal ID="litDescripcion" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="100px">
                    <ItemTemplate>
                        <asp:Button Text="Seleccionar" runat="server" ID="btnSeleccionar" OnClientClick="onAceptar(this);" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="form-actions align-right">
        <input type="button" value="Cancelar" onclick="onCancelar();" />
    </div>
</asp:Content>