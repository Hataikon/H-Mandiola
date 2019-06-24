<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="precios.aspx.cs" Inherits="H_Mandiola_Backend.precios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <label>Informacion del Precio</label>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Consecutivo</label>
        </div>
        <div class="col-2">
            <asp:DropDownList ID="ConsecutivoList" runat="server" OnSelectedIndexChanged="ConsecutivoList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Codigo</label>
        </div>
        <div class="col-2">
            <asp:TextBox ID="codigoBox" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Tipo De Precio</label>
        </div>
        <asp:DropDownList ID="precioDropDown" runat="server">
            <asp:ListItem Text="Habitacion Normal" Value="normal"></asp:ListItem>
            <asp:ListItem Text="Habitacion Deluxe" Value="deluxe"></asp:ListItem>
            <asp:ListItem Text="Habitacion Condominio" Value="condominio"></asp:ListItem>
            <asp:ListItem Text="Licor" Value="normal"></asp:ListItem>
            <asp:ListItem Text="Bebidas Gaseosas" Value="deluxe"></asp:ListItem>
            <asp:ListItem Text="Bebidas Naturales" Value="condominio"></asp:ListItem>
            <asp:ListItem Text="Dulces" Value="condominio"></asp:ListItem>
            <asp:ListItem Text="Helados" Value="condominio"></asp:ListItem>
            <asp:ListItem Text="Flores" Value="condominio"></asp:ListItem>
            <asp:ListItem Text="Tartas" Value="condominio"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Precio</label>
        </div>
        <div class="col-2">
            <asp:TextBox ID="precioBox" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
        </div>
        <div class="col-4">
            <asp:Button ID="borrarButton" runat="server" Text="Borrar" OnClick="borrarButton_Click" />
            <asp:Button ID="aceptarButton" runat="server" Text="Aceptar" OnClick="aceptarButton_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-2">
        </div>
        <div class="col-4">
            <asp:Button ID="cerrarButton" runat="server" Text="Cerrar" OnClick="cerrarButton_Click" />
        </div>
    </div>
</asp:Content>
