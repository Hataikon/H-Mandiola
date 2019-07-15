<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="detalle_usuarios.aspx.cs" Inherits="H_Mandiola_Backend.detalle_usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-8">
            <div class="row">
                <h3>Lista de Usuarios</h3>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class ="col-4">
                            <asp:ListBox ID="userList" runat="server" Width="150px" Height="300px" DataSourceID="UsuariosLista" DataTextField="UserName" DataValueField="UserName" OnSelectedIndexChanged="userList_SelectedIndexChanged" AutoPostBack="True">
                            </asp:ListBox>
                            <asp:SqlDataSource ID="UsuariosLista" runat="server" ConnectionString="<%$ ConnectionStrings:aspnetdbConnectionString %>" SelectCommand="SELECT [UserId], [UserName] FROM [vw_aspnet_Users]"></asp:SqlDataSource>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aspnetdbConnectionString %>" SelectCommand="SELECT [UserName] FROM [vw_aspnet_Users]"></asp:SqlDataSource>
                        </div>
                        <div class ="col-4">
                            <asp:CheckBoxList ID="roleList" runat="server" DataSourceID="ListaRoles" DataTextField="RoleName" DataValueField="RoleName">    
                            </asp:CheckboxList>
                            <asp:SqlDataSource ID="ListaRoles" runat="server" ConnectionString="<%$ ConnectionStrings:aspnetdbConnectionString %>" SelectCommand="SELECT [RoleId], [RoleName] FROM [vw_aspnet_Roles]"></asp:SqlDataSource>
                            <asp:Button ID="ActualizaRoles" runat="server" Text="Actualizar Roles" OnClick="ActualizaRoles_Click" />
                            <div id="prueba" runat="server"></div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>