<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="habitaciones_listas.aspx.cs" Inherits="H_Mandiola_Backend.habitaciones_listas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h5>Habitaciones Listas</h5>
    </div>
    <div class="row">
        <div class="col">
            <asp:DropDownList ID="listasDropDown" runat="server">
                <asp:ListItem Text="Listas" Value="listas"></asp:ListItem>
                <asp:ListItem Text="No Listas" Value="no_listas"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col">
            <asp:Button ID="filtrarButton" runat="server" Text="Filtrar" OnClick="filtrarButton_Click" />
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="habitacionesListasGrid" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="CODIGO" HeaderText="Codigo" />
                <asp:BoundField DataField="NUMERO" HeaderText="Numero" />
                <asp:BoundField DataField="DETALLE" HeaderText="Detalle" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
