<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="cambiar_contrasena.aspx.cs" Inherits="H_Mandiola_Backend.cambiar_contrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-8">
            <div class="row">
                <h3>Cambiar Contraseña</h3>
            </div>
            <div class="row">
                <asp:ChangePassword ID="cambiarContrasena" runat="server" OnChangedPassword="cambiarContrasena_ChangedPassword"></asp:ChangePassword>
            </div>
        </div>
    </div>
</asp:Content>
