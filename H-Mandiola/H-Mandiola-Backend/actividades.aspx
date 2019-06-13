<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="actividades.aspx.cs" Inherits="H_Mandiola_Backend.actividades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <label>Informacion de la Actividad</label>
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
            <asp:textbox id="codigoBox" runat="server" ReadOnly="true"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Nombre de la Actividad</label>
        </div>
        <div class="col-2">
            <asp:textbox id="nombreBox" runat="server" ></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Descripcion de la Actividad</label>
        </div>
        <div class="col-2">
            <asp:textbox id="descripcionBox" runat="server" ></asp:textbox>
        </div>
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
            <asp:button id="borrarButton" runat="server" text="Borrar" OnClick="borrarButton_Click" />
            <asp:button id="aceptarButton" runat="server" text="Aceptar" OnClick="aceptarButton_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-2">
        </div>
        <div class="col-4">
            <asp:button id="cerrarButton" runat="server" text="Cerrar" OnClick="cerrarButton_Click" />
            <asp:button id="cargarImagenButton" runat="server" text="Cargar Imagen" />
            <div style="display:none;">
                <asp:FileUpload ID="FileUploadActividad" runat="server"/>
            </div>
        </div>
    </div>
</asp:Content>
