<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="consulta_errores.aspx.cs" Inherits="H_Mandiola_Backend.consulta_errores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h5>Errores</h5>
    </div>
    <div class="row">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="col-4">
            <asp:TextBox ID="txtStart" Text="Fecha de Inicio" runat="server" AutoPostBack="true" OnTextChanged="txtStart_TextChanged"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="calendarStart" PopupButtonID="imgPopup" runat="server" TargetControlID="txtStart" Format="dd/MM/yyyy" />
        </div>
        <div class="col-4">
            <asp:TextBox ID="txtEnd" Text="Fecha de Fin" runat="server" AutoPostBack="true" OnTextChanged="txtEnd_TextChanged"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="calendarEnd" PopupButtonID="imgPopup" runat="server" TargetControlID="txtEnd" Format="dd/MM/yyyy" />
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="errorGridView" OnRowDataBound="errorGridView_RowDataBound" runat="server">
        </asp:GridView>
    </div>
</asp:Content>
