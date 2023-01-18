<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="ABCEjerciciosFiscales, App_Web_wdwpyhsd" title="COBAEV - Nómina - ABC Ejercicios Fiscales" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<%@ Register src="../../WebControls/wucSearchEmps.ascx" tagname="wucSearchEmps" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
    .modalBackground
    {
        background-color:Silver;
        filter: alpha(opacity=60);
        opacity: 0.5;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: maroon;
        padding-top: 5px;
        padding-left: 5px;
        padding-right: 15px;
        width: 1000px;
        height: 500px;
    }
 </style>
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: ABC Ejercicios Fiscales
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbCrearNuevoEjerFisc" runat="server" 
                            SkinID="SkinLinkButton" CausesValidation="False">Crear nuevo ejercicio fiscal</asp:LinkButton><ajaxToolkit:ConfirmButtonExtender
                            ID="CBECrearNuevoEjerFisc" runat="server" ConfirmText="La operación solicitada creará un nuevo ejercicio fiscal en la Base de datos, ¿Continuar?"
                            TargetControlID="lbCrearNuevoEjerFisc">
                        </ajaxToolkit:ConfirmButtonExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvEjersFisc" EventName="RowUpdating" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
    <asp:GridView ID="gvEjersFisc" runat="server" CellPadding="1" SkinID="SkinGridView" Width="100%" 
    OnSelectedIndexChanged="gvEjersFisc_SelectedIndexChanged" 
                            OnRowCancelingEdit="gvEjersFisc_RowCancelingEdit" 
                            OnRowEditing="gvEjersFisc_RowEditing" OnRowDeleting="gvEjersFisc_RowDeleting" 
                            OnRowUpdating="gvEjersFisc_RowUpdating" 
                            OnRowDataBound="gvEjersFisc_RowDataBound">
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="Ejercicio">
                <ItemTemplate>
                    <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblAnioE" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estatus">
                <EditItemTemplate>
                    <asp:CheckBox ID="chbxConcluidoE" runat="server" Text="Concluido" Checked='<%# Bind("Concluido") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chbxConcluido" runat="server" Checked='<%# Bind("Concluido") %>' Enabled="False" Text="Concluido" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Solicitudes de no aplicación de subsidio para el empleo">
                <EditItemTemplate>
                    <asp:CheckBox ID="chbxCapNoSubsidioE" runat="server" Text="Permite captura"
                        Checked='<%# Bind("PermiteCapturaNoSubsidio") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chbxCapNoSubsidio" runat="server" Text="Permite captura"
                        Checked='<%# Bind("PermiteCapturaNoSubsidio") %>' Enabled="False" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Solicitudes de constancias de sueldos">
                <EditItemTemplate>
                    <asp:CheckBox ID="chbxCapDeConstSdosE" runat="server" Text="Permite captura"
                        Checked='<%# Bind("PermiteCapturaDeConstancias") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chbxCapDeConstSdos" runat="server" Text="Permite captura"
                        Checked='<%# Bind("PermiteCapturaDeConstancias") %>' Enabled="False" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Fecha de registro de Declaración Anual ante el SAT">
                <EditItemTemplate>
                    <asp:TextBox ID="txtbxFechaSATE" runat="server" MaxLength="10" 
                        SkinID="SkinTextBox" Text='<%# Bind("FechaSAT", "{0:d}") %>'></asp:TextBox>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="txtbxFechaSATE_TextBoxWatermarkExtender" 
                        runat="server" Enabled="True" TargetControlID="txtbxFechaSATE" 
                        WatermarkCssClass="WaterMark" WatermarkText="dd/mm/aaaa">
                    </ajaxToolkit:TextBoxWatermarkExtender>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtbxFechaSATE" Display="Dynamic" 
                        ErrorMessage="(Fecha incorrecta)" Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFechaSAT" runat="server" Text='<%# Bind("FechaSAT", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Folio de operación SAT de registro Declaración Anual">
                <EditItemTemplate>
                    <asp:TextBox ID="txtbxFolioOperacionSATE" runat="server" MaxLength="10" 
                        SkinID="SkinTextBox" Text='<%# Bind("FolioOperacionSAT") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblFolioOperacionSAT" runat="server" Text='<%# Bind("FolioOperacionSAT") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IdEmpFirmante" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblIdEmpFirmante" runat="server" Text='<%# Bind("IdEmpFirmante") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Wrap="True" />
                <EditItemTemplate>
                    <asp:Label ID="lblIdEmpFirmanteE" runat="server" Text='<%# Bind("IdEmpFirmante") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Firmante de las constancias de sueldos">
                <EditItemTemplate>
                    <asp:Label ID="lblNombreFirmanteE" runat="server" Text='<%# Bind("NombreFirmante") %>'></asp:Label>
                    <asp:ImageButton ID="ibEditarFirmante" runat="server" CausesValidation="False"
                        ImageUrl="~/Imagenes/Modificar.png" ToolTip="Cambiar firmante" 
                        onclick="ibEditarFirmante_Click" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblNombreFirmante" runat="server" Text='<%# Bind("NombreFirmante") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" CommandName="Update"
                        ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar" />&nbsp;<asp:ImageButton
                            ID="ibCancelar" runat="server" CausesValidation="False" CommandName="Cancel"
                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="CBECancelar" runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                        TargetControlID="ibGuardar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" CommandName="Edit"
                        ImageUrl="~/Imagenes/Modificar.png" ToolTip="Modificar" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" CommandName="Delete"
                        ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                        TargetControlID="ibEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvEjersFisc" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="gvEjersFisc" EventName="RowEditing" />
                        <asp:AsyncPostBackTrigger ControlID="gvEjersFisc" EventName="RowCancelingEdit" />
                        <asp:AsyncPostBackTrigger ControlID="gvEjersFisc" EventName="RowDeleting" />
                        <asp:AsyncPostBackTrigger ControlID="gvEjersFisc" EventName="RowUpdating" />
                        <asp:AsyncPostBackTrigger ControlID="lbCrearNuevoEjerFisc" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <ajaxToolkit:ModalPopupExtender ID="ibEditarFirmante_MPE" runat="server" 
                    DynamicServicePath="" Enabled="True" 
                    PopupControlID="pnlBuscarEmp" DropShadow="true" 
                    TargetControlID="btnOpenModalPopUp1" BackgroundCssClass="modalBackground" CancelControlID="btnCloseModalPopUp1" >
                </ajaxToolkit:ModalPopupExtender>
                <asp:Button ID="btnCloseModalPopUp1" runat="server" Text="Cerrar" style="display:none"/>
                <asp:Button ID="btnOpenModalPopUp1" runat="server" Text="Cerrar" style="display:none"/>
                <asp:Panel ID="pnlBuscarEmp" runat="server" CssClass="modalPopup" align="center" Width="100%" >
                    <asp:UpdatePanel ID="UPModalPopUp1" runat="server">
                    <ContentTemplate>
                        <table style="width:100%">
                            <tr>
                                <td colspan="2" style="text-align: left; width:100%;">
                                    <uc1:wucSearchEmps ID="wucSearchEmps2" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"  style="text-align: left">
                                    <asp:Button ID="btnGuardar" runat="server" 
                                        SkinID="SkinBoton" Text="Guardar" 
                                        ToolTip="Guardar al empleado seleccionado como nuevo firmante." />
                                    <ajaxToolkit:ConfirmButtonExtender ID="btnGuardar_ConfirmButtonExtender" 
                                        runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?" Enabled="True" TargetControlID="btnGuardar">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                    &nbsp;<asp:Button ID="btnCerrar" runat="server" CausesValidation="False" 
                                        OnClick="btnCerrar_Click" SkinID="SkinBoton" Text="Cancelar" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"  style="text-align: left">
                                    <asp:ValidationSummary ID="VSNuevosValores" runat="server" 
                                        ShowMessageBox="True" ShowSummary="False" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

