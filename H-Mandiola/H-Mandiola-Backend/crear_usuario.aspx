<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="crear_usuario.aspx.cs" Inherits="H_Mandiola_Backend.crear_usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="row">
                <h2>Crear usuarios</h2>
            </div>
            <div class="row">
            <asp:CreateUserWizard ID="crearUsuario" runat="server" OnCreatedUser="CreateUserWizard_CreatedUser">
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep" runat="server">
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                    </asp:CompleteWizardStep>
                </WizardSteps>
            </asp:CreateUserWizard>
            </div>
        </div>
    </div>
</asp:Content>
