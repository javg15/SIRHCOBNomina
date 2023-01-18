<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="AdmonClavePlaza.aspx.vb" Inherits="AdmonClavePlaza"  StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        #divContenedorPlaza
        {
            margin-top: 10px;
        }
        
        #divContenedorPlaza div
        {
            float: left;
            margin-left: 2px;
        }
        #divDetallePlaza
        {
            clear: both;
            text-align: left;
            padding-top:10px;
        }
        #divContenedorPlaza input[type="text"]
        {
            height:19px;
        }            
        #divContenedorPlaza input[type="submit"]
        {
            height:25px;
        }          
        #divContenedorPlaza input[type="submit"]:Hover
        {
            background-color: #3366CC;
            border: #4e667d solid;
            height: 25px;
            color: white;
        }      
    </style>
    <asp:UpdatePanel ID="upMain" runat="server">
        <ContentTemplate>
            <div id="divContenedorPlaza">
                <div>
                    <asp:TextBox ID="txtbxZE" runat="server" Width="30px" 
                        ValidationGroup="grpValidaPlaza" SkinID="skinTxtBx9pt" MaxLength="2" 
                        TabIndex="1" ToolTip="Zona Económina. Ejemplo: 02"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtbxZE" runat="server" ControlToValidate="txtbxZE"
                        Display="Dynamic" ErrorMessage="Es obligatorio especificar la zona económica de la plaza."
                        Text="*" ToolTip="Es obligatorio especificar la zona económica de la plaza." ValidationGroup="grpValidaPlaza"></asp:RequiredFieldValidator>
                </div>
                <div id="divTipoPlaza">
                    <asp:TextBox ID="txtbxTipoPlaza" runat="server" Width="40px" ReadOnly="True" 
                        SkinID="skinTxtBx9pt" ValidationGroup="grpValidaPlaza" TabIndex="2" 
                        Visible="False"></asp:TextBox>
                </div>
                <div id="divDifPlaza">
                    <asp:TextBox ID="txtbxDifPlaza" runat="server" Width="30px" ReadOnly="True" 
                        SkinID="skinTxtBx9pt" ValidationGroup="grpValidaPlaza" TabIndex="3" 
                        Visible="False"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="txtbxCveCatego" runat="server" Width="50px" 
                        ValidationGroup="grpValidaPlaza" SkinID="skinTxtBx9pt" MaxLength="3" 
                        TabIndex="4" ToolTip="Categoría de la plaza. Ejemplo: 019"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtbxCveCatego" runat="server" ControlToValidate="txtbxCveCatego"
                        Display="Dynamic" ErrorMessage="Es obligatorio especificar la categoría de la plaza."
                        Text="*" ToolTip="Es obligatorio especificar la categoría de la plaza." 
                        ValidationGroup="grpValidaPlaza"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox ID="txtbxHrs" runat="server" Width="30px" SkinID="skinTxtBx9pt" 
                        ValidationGroup="grpValidaPlaza" TabIndex="5" ToolTip="Horas asociadas a la plaza. Ejemplo: 20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtbxHrs" runat="server" 
                        ControlToValidate="txtbxHrs" Display="Dynamic"
                        ErrorMessage="Es obligatorio especificar el número de horas de la plaza." 
                        Text="*" ToolTip="Es obligatorio especificar el número de horas de la plaza." 
                        ValidationGroup="grpValidaPlaza"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:TextBox ID="txtbxConsPlaza" runat="server" Width="50px" 
                        SkinID="skinTxtBx9pt" ValidationGroup="grpValidaPlaza" TabIndex="6"
                         ToolTip="Consecutivo de la plaza. Ejemplo: 00001"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtbxConsPlaza" runat="server" 
                        ControlToValidate="txtbxConsPlaza" Display="Dynamic" 
                        ErrorMessage="Es obligatorio especificar el consecutivo de la plaza." Text="*"
                         ToolTip="Es obligatorio especificar el consecutivo de la plaza."
                        ValidationGroup="grpValidaPlaza"></asp:RequiredFieldValidator>

                </div>
                <div>
                    <asp:Button ID="btnConsultaPlaza" runat="server" Text="Consulta plaza" 
                        ValidationGroup="grpValidaPlaza" TabIndex="7" />
                </div>
                <div id="divDetallePlaza">
                    <asp:DetailsView ID="dvConsultaPlaza" runat="server" SkinID="SkinDetailsView">
                        <FieldHeaderStyle Wrap="false" />
                        <RowStyle Wrap="false" />
                    </asp:DetailsView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
