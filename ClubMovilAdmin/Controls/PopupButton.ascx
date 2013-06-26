<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PopupButton.ascx.vb" Inherits="ClubMovilAdmin.PopupButton" %>
<script type="text/javascript" >
    function <%=Me.ClientID %>_popup(url) {
        var hdnResValue = document.getElementById('<%=ValueField.ClientId%>');
        var hdnResData = document.getElementById('<%=DataField.ClientId%>');
        
        // Limpia los campos
        hdnResValue.value = null;
        hdnResData.value = null;
            
        window.returnValue = null;
        
        // Muestra el dialogo
        var result = window.showModalDialog(url ,null,'dialogWidth:500px;dialogHeight:530px');
                
        // Parche chrome
        if (result == undefined) {
            result = window.returnValue;
        }
        
        // Si existe respuesta
        if (result) {
            hdnResValue.value=result.id;
            hdnResData.value=result.data;
           
            // PostBack
            <%=Page.GetPostBackEventReference(Me, "on_change")%>;
        } else {
            hdnResValue.value = null;
            hdnResData.value = null;
        }      
    }
</script>
<asp:TextBox id="ValueField" runat="server" CssClass="hide" />
<asp:TextBox id="DataField" runat="server" CssClass="hide"/>
<input id="button" type="button" runat="server" value="Seleccionar"/>