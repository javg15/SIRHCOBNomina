<%@ Page Title="COBAEV - Registrar una nueva cuenta" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Register.aspx.vb" Inherits="Account_Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
                    <h2>
                        Creación de nuevas cuentas de usuario
                    </h2>
                    <p>
                        Complete el siguiente formulario para crear su cuenta de acceso al portal.
                    </p>
                    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>
                    <div class="accountInfo">
                        <fieldset class="register">
                            <legend>Información sobre la cuenta</legend>
                            <p>
                                <asp:Label ID="RFCLabel" runat="server" AssociatedControlID="RFCTextBox">R.F.C.:</asp:Label>
                                <asp:TextBox ID="RFCTextBox" runat="server" CssClass="textEntry" MaxLength="13"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFCRequired" runat="server" ControlToValidate="RFCTextBox" 
                                     CssClass="failureNotification" ErrorMessage="El R.F.C. es requerido para poder crear su cuenta." ToolTip="El R.F.C. es requerido para poder crear su cuenta." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="CURPLabel" runat="server" AssociatedControlID="CURPTextBox">C.U.R.P.:</asp:Label>
                                <asp:TextBox ID="CURPTextBox" runat="server" CssClass="textEntry" MaxLength="18"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CURPRequired" runat="server" ControlToValidate="CURPTextBox" 
                                     CssClass="failureNotification" ErrorMessage="La C.U.R.P. es requerida para poder crear su cuenta." ToolTip="La C.U.R.P. es requerida para poder crear su cuenta." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="NumEmpLabel" runat="server" AssociatedControlID="NumEmpTextBox">Número de empleado:</asp:Label>
                                <asp:TextBox ID="NumEmpTextBox" runat="server" CssClass="textEntry" MaxLength="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NumEmpRequired" runat="server" ControlToValidate="NumEmpTextBox" 
                                     CssClass="failureNotification" ErrorMessage="El número de empleado es requirido para poder crear su cuenta." ToolTip="El número de empleado es requirido para poder crear su cuenta." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                            <p>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="EmailTextBox">Correo electrónico:</asp:Label>
                                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="EmailTextBox" 
                                     CssClass="failureNotification" ErrorMessage="El correo electrónico es requirido para poder crear su cuenta." ToolTip="El correo electrónico es requirido para poder crear su cuenta." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </p>
                        </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Crear cuenta" 
                                 ValidationGroup="RegisterUserValidationGroup"/>
                        </p>
                    </div>
</asp:Content>