<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="lista_estado_cliente.aspx.cs" Inherits="H_Mandiola_Backend.lista_estado_cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col mx-auto my-auto">
            <div class="row">
                <h5>Estado de los Clientes</h5>
            </div>
            <div class="row">
                <asp:GridView ID="listaDeEstadosGrid" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                        <asp:BoundField DataField="Booking ID" HeaderText="Booking ID" />
                        <asp:BoundField DataField="Cancelado" HeaderText="Estado de Cancelacion" />
                        <asp:HyperLinkField Text="Detalle" DataNavigateUrlFields="Booking ID" DataNavigateUrlFormatString="estado_cliente.aspx?id={0}" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="row">
                <asp:Button ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
