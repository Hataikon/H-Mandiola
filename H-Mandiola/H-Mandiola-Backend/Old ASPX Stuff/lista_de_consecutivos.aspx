<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="lista_de_consecutivos.aspx.cs" Inherits="H_Mandiola_Backend.lista_de_consecutivos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col mx-auto my-auto">
            <div class="row">
                <h5>Lista de Consecutivos</h5>
            </div>
            <div class="row">
                <asp:GridView ID="listaDeConsecutivosGrid" runat="server" AutoGenerateColumns="false" > 
                    <Columns>
                        <asp:BoundField DataField="PREFIJO" HeaderText="Prefijo" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="CODIGO_CONSECUTIVO" HeaderText="Codigo Consecutivo" />
                        <asp:HyperLinkField Text="Editar" DataNavigateUrlFields="PREFIJO" DataNavigateUrlFormatString="consecutivos.aspx?id={0}" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="row">
                <asp:Button ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" />
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="Consecutivos" runat="server"></asp:SqlDataSource>
</asp:Content>
