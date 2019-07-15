<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="activos.aspx.cs" Inherits="H_Mandiola_Backend.activos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <label>Informacion del Activo</label>
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
            <label>Nombre del Activo</label>
        </div>
        <div class="col-2">
            <asp:textbox id="nombreBox" runat="server" ></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Descripcion del Activo</label>
        </div>
        <div class="col-2">
            <asp:textbox id="descripcionBox" runat="server" ></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Imagen del Activo</label>
        </div>
        <div class="col-2">
            <asp:Image ID="ImagenDeLaActivo" CssClass="img-fluid" runat="server" />
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
                <asp:FileUpload ID="FileUploadActivo" runat="server"/>
            </div>
        </div>
    </div>
</asp:Content>
