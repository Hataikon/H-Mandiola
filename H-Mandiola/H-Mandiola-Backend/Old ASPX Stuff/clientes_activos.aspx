<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="clientes_activos.aspx.cs" Inherits="H_Mandiola_Backend.clientes_activos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h5>Clientes Activos</h5>
    </div>
    <div class="row">
        <div class="col">
            <asp:DropDownList ID="nacionalidadDropDown" runat="server">
                <asp:ListItem Text="Costa Rica" Value="cr"></asp:ListItem>
                <asp:ListItem Text="Suiza" Value="sw"></asp:ListItem>
                <asp:ListItem Text="Italia" Value="it"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col">
            <asp:Button ID="filtrarButton" runat="server" Text="Filtrar" OnClick="filtrarButton_Click" />
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="clientesActivosGrid" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="USUARIO" HeaderText="Codigo" />
                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                <asp:BoundField DataField="HABITACION" HeaderText="Habitacion" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
