<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="lista_de_precios.aspx.cs" Inherits="H_Mandiola_Backend.lista_de_precios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col mx-auto my-auto">
            <div class="row">
                <h5>Lista de Precios</h5>
            </div>
            <div class="row">
                <asp:GridView ID="listaDePreciosGrid" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="CODIGO" HeaderText="Codigo" />
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:HyperLinkField Text="Editar" DataNavigateUrlFields="CODIGO" DataNavigateUrlFormatString="precios.aspx?id={0}" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="row">
                <asp:Button ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
