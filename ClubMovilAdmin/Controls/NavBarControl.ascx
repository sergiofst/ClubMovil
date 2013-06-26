<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NavBarControl.ascx.vb"
    Inherits="ClubMovilAdmin.NavBarControl" %>

<div class="navbar navbar-inverse ">
    <div class="navbar-inner">
        <button type="button" class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
            <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar">
            </span>
        </button>
        <a class="brand" href="#">ClubMovil</a>
        <cma:IsInRoleControl RoleName="Administrador" runat="server">
            <ul class="nav">
                <li><a href="~/Admin/Default.aspx" runat="server">Administrador</a></li>
            </ul>
        </cma:IsInRoleControl>

        <div class="nav-collapse collapse">
            <asp:LoginView ID="LoginView1" runat="server">
                <LoggedInTemplate>
                    <ul class="nav pull-right">
                        <li class="dropdown "><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                            <%=GetUserName() %>
                            <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li><a id="A1" href="~/Private/Default.aspx" runat="server">Inicio</a></li>
                                <li><a id="A2" href="~/Profile/upd_password.aspx" runat="server">Cambiar contraseña</a></li>
                                <li class="divider"></li>
                                <li><a id="A3" href="~/Account/Logout.aspx" runat="server">Cerrar sesion</a> </li>
                            </ul>
                        </li>
                    </ul>
                </LoggedInTemplate>
                <AnonymousTemplate>
                    <li>&nbsp;</li>
                </AnonymousTemplate>
            </asp:LoginView>
        </div>
        <!--/.nav-collapse -->
    </div>
    <!-- /.navbar-inner -->
</div>
<!-- /.navbar -->
