<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="estado_cliente.aspx.cs" Inherits="H_Mandiola_Backend.estado_cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <label>Informacion del Cliente</label>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Nombre</label>
        </div>
        <div class="col-2">
            <asp:textbox id="nombreBox" runat="server" ReadOnly="true"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Primer Apellido</label>
        </div>
        <div class="col-2">
            <asp:textbox id="apellido1Box" runat="server" ReadOnly="true"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Segundo Apellido</label>
        </div>
        <div class="col-2">
            <asp:textbox id="apellido2Box" runat="server" ReadOnly="true"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Correo Electronico</label>
        </div>
        <div class="col-2">
            <asp:textbox id="emailBox" runat="server" ReadOnly="true"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Nombre de Usuario</label>
        </div>
        <div class="col-2">
            <asp:textbox id="usernameBox" runat="server" ReadOnly="true"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Tipo de Habitacion</label>
        </div>
        <div class="col-2">
            <asp:textbox id="habitacionBox" runat="server" ReadOnly="true"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Dias de Visita</label>
        </div>
        <div class="col-2">
            <asp:textbox id="diasBox" runat="server" ReadOnly="true"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Estado de Reserva</label>
        </div>
        <div class="col-2">
            <asp:textbox id="reservaBox" runat="server" ReadOnly="true"></asp:textbox>
        </div>
    </div>
</asp:Content>
