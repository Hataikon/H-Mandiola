<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="consecutivos.aspx.cs" Inherits="H_Mandiola_Backend.consecutivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <label>Informacion del Consecutivo</label>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Descripcion</label>
        </div>
        <div class="col-2">
            <asp:dropdownlist id="descripcionDropdown" runat="server">
                <asp:listitem text="Actividades" value="paises"></asp:listitem>
                <asp:listitem text="Activos" value="aerolineas"></asp:listitem>
                <asp:listitem text="Habitaciones" value="puertas"></asp:listitem>
                <asp:listitem text="Precios" value="boletos"></asp:listitem>
            </asp:dropdownlist>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Consecutivo</label>
        </div>
        <div class="col-2">
            <asp:textbox id="consecutivoBox" runat="server"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Posee prefijo</label>
        </div>
        <div class="col-2">
            <asp:checkbox id="prefijoCheckBox" Checked="false" runat="server" OnCheckedChanged="prefijoCheckBox_CheckedChanged" AutoPostBack="true" ></asp:checkbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Prefijo</label>
        </div>
        <div class="col-2">
            <asp:textbox id="prefijoBox" ReadOnly="true" runat="server"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Posee rango</label>
        </div>
        <div class="col-2">
            <asp:checkbox id="rangoCheckBox" Checked="false" runat="server" OnCheckedChanged="rangoCheckBox_CheckedChanged" AutoPostBack="true" ></asp:checkbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Rango inicial</label>
        </div>
        <div class="col-2">
            <asp:textbox id="rangoInicialBox" ReadOnly="true" runat="server"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
            <label>Rango Final</label>
        </div>
        <div class="col-2">
            <asp:textbox id="rangoFinalBox" ReadOnly="true" runat="server"></asp:textbox>
        </div>
    </div>
    <div class="row">
        <div class="col-2">
        </div>
        <div class="col-4">
            <asp:button id="aceptarButton" runat="server" text="Aceptar" OnClick="aceptarButton_Click" />
            <asp:button id="cancelarButton" runat="server" text="Cancelar" OnClick="cancelarButton_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-2">
        </div>
        <div class="col-4">
            <div class ="row my-5 mx-auto">
                <asp:button id="nuevoButton" runat="server" text="Nuevo" OnClick="nuevoButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
