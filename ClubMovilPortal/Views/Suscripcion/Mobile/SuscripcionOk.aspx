﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Mobile/Mobile.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Bienvenido</h2>
    <p>
        <%: Html.ActionLink("Inicio", "Index", "Home")%>
    </p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadlineContent" runat="server">
</asp:Content>
