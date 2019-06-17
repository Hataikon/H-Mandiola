<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="bitacora.aspx.cs" Inherits="H_Mandiola_Backend.bitacora" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col mx-auto my-auto">
            <div class="row">
                <h5>Bitacora</h5>
            </div>
            <div class="row">
                <div class="col-4">
                    <div class="row">
                        <label>Persona</label>
                        <asp:TextBox ID="personaTextbox" runat="server" OnTextChanged="personaTextbox_TextChanged" AutoPostBack="true"></asp:TextBox>
                    </div>
                    <div class="row">
                        <label>Tipo de accion</label>
                        <asp:DropDownList ID="listAccion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="listAccion_SelectedIndexChanged">
                            <asp:ListItem Text="Todas" Value="Todas"></asp:ListItem>
                            <asp:ListItem Text="Agregar" Value="Agregar"></asp:ListItem>
                            <asp:ListItem Text="Eliminar" Value="Eliminar"></asp:ListItem>
                            <asp:ListItem Text="Modificar" Value="Modificar"></asp:ListItem>                            
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtStart" Text="Fecha de Inicio" runat="server" OnTextChanged="textBox1_TextChanged" AutoPostBack="true"></asp:TextBox>  
                    <ajaxToolkit:CalendarExtender ID="calendarStart" PopupButtonID="imgPopup" runat="server" TargetControlID="txtStart" Format="dd/MM/yyyy" />
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtEnd" Text="Fecha de Fin" runat="server" OnTextChanged="textBox2_TextChanged" AutoPostBack="true"></asp:TextBox>  
                    <ajaxToolkit:CalendarExtender ID="calendarEnd" PopupButtonID="imgPopup" runat="server" TargetControlID="txtEnd" Format="dd/MM/yyyy" />
                </div>
            </div>
            <div class="row">
                <asp:GridView ID="bitacoraGridView" OnRowDataBound="bitacoraGridView_RowDataBound" OnSelectedIndexChanged="bitacoraGridView_SelectedIndexChanged" runat="server">
                </asp:GridView>
                <asp:LinkButton Text="" ID="btnopen" runat="server" />
                <ajaxToolkit:ModalPopupExtender ID="ExtraModal" PopupControlID="Panel1" TargetControlID="btnopen" runat="server" OkControlID="btnclose"></ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid">
                    <div style="background-color:white;">
                        <asp:Label ID="lblDetail" runat="server" Text=""></asp:Label><br />
                        <asp:LinkButton Text="Cerrar" ID="btnclose" runat="server" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
