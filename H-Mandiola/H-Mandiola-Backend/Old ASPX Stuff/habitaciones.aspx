<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="habitaciones.aspx.cs" Inherits="H_Mandiola_Backend.habitaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <label>Informacion de la Habitacion</label>
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
            <label>Numero de la Habitacion</label>
        </div>
        <div class="col-2">
            <asp:TextBox ID="nombreBox" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Descripcion de la Habitacion</label>
        </div>
        <asp:DropDownList ID="habitacionDropDown" runat="server">
            <asp:ListItem Text="Normal" Value="normal"></asp:ListItem>
            <asp:ListItem Text="Deluxe" Value="deluxe"></asp:ListItem>
            <asp:ListItem Text="Condominio" Value="condominio"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Imagen de la Actividad</label>
        </div>
        <div class="col-2">
            <asp:Image ID="ImagenDeLaActividad" CssClass="img-fluid" runat="server" />
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
            <asp:Button ID="cargarImagenButton" runat="server" Text="Cargar Imagen" />
            <div style="display: none;">
                <asp:FileUpload ID="FileUploadActividad" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
