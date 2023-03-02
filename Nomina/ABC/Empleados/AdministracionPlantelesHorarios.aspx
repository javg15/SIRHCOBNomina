<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="AdministracionPlantelesHorarios.aspx.vb" Inherits="AdministracionPlantelesHorarios"
    Title="COBAEV - Nómina - Administrar horarios de planteles" StylesheetTheme="SkinFile"
    MaintainScrollPositionOnPostback="true"  %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<%@ Register src="../../WebControls/wucMuestraErrores.ascx" tagname="wucMuestraErrores" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Administrar horarios de plantel
                </h2>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="hidId" runat="server" />
                <asp:hiddenfield ID="hidIdPlantelesHorarios" runat="server"></asp:hiddenfield>
                <asp:TextBox ID="hidIdPlantel" runat="server" BackColor="White" ForeColor="White" Width="1px" BorderColor="White" BorderStyle="None" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="CVIdEmp" runat="server"
                    ControlToValidate="hidIdPlantel" Display="Dynamic" ErrorMessage="Seleccione el plantel a afectar"
                    ToolTip="Seleccione el plantel a afectar" Type="Text"
                    ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                <p class="pLabel">
                    <asp:Label ID="lblPlantelHead" runat="server" CssClass="pLabel" Text="Plantel:"></asp:Label>
                </p>
                <p class="pTextBox">
                    <asp:Label ID="lblPlantel" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label>
                </p>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="MVMain" runat="server">
                <asp:View ID="vwMain" runat="server">
                    <asp:Panel ID="pnlHoras" runat="server" GroupingText="" Visible="true" HorizontalAlign="Left">
                        <asp:LinkButton ID="lbBackPlanteles" runat="server" Font-Bold="False"
                            SkinID="SkinLinkButton" ToolTip="Agregar horario" ForeColor="#003300" PostBackUrl="../../Consultas/Planteles/wfPlanteles.aspx?TipoOperacion=4">Regresar a planteles</asp:LinkButton>
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="lbAgregarHorario" runat="server" Font-Bold="False"
                            SkinID="SkinLinkButton" ToolTip="Agregar horario" ForeColor="#003300">Agregar horario</asp:LinkButton>
                    </asp:Panel>
                    <br /><br />
                    <asp:GridView ID="gvHoras" runat="server" EmptyDataText="No hay horarios registrados actualmente."
                                    SkinID="SkinGridView">
                        <Columns>
                            <asp:TemplateField HeaderText="" Visible="True">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdPlantelesHorarios" runat="server" Text='<%# Bind("IdPlantelesHorarios") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Plantel" Visible="True">
                                <ItemTemplate>
                                    <asp:Label ID="lblPlantel" runat="server" Text='<%# Bind("Plantel") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Inicio" Visible="True">
                                <ItemTemplate>
                                    <asp:Label ID="lblInicio" runat="server" Text='<%# Bind("Inicio") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Término" Visible="True">
                                <ItemTemplate>
                                    <asp:Label ID="lblTermino" runat="server" Text='<%# Bind("Termino") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                        CausesValidation="false" ToolTip="Modificar la información del registro." OnClick="ibModificar_Click" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:View>
                <asp:View ID="vwHorariosEd" runat="server">
                                <asp:Panel ID="pnlEd" runat="server">
                                    <div class="accountInfo">
                                        <fieldset id="fsEd">
                                            <div class="panelIzquierda">
                                                <asp:Panel ID="pnlEdCampos" runat="server">
                                                    <p class="pLabel">
                                                        <asp:Label ID="lblInicio" runat="server" CssClass="pLabel" Text="Hora de inicio:">
                                                        </asp:Label>
                                                    </p>
                                                    <p class="pTextBox">
                                                        <asp:TextBox ID="txtInicio" runat="server" AutoPostBack="True" type="time" ValidationGroup="Guardar"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="txtbxFechaIni_RFV" runat="server" ControlToValidate="txtInicio" 
                                                            Display="Dynamic" ErrorMessage="La hora inicial es requerida." ToolTip="La hora inicial es requerida." 
                                                            ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                                    </p>
                                                    <p class="pLabel">
                                                        <asp:Label ID="lblFin" runat="server" CssClass="pLabel" Text="Hora de t&#233;rmino:">
                                                        </asp:Label>
                                                    </p>
                                                    <p class="pTextBox">
                                                        <asp:TextBox ID="txtTermino" runat="server" AutoPostBack="True" type="time" ValidationGroup="Guardar"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="txtbxFechaFin_RFV" runat="server" ControlToValidate="txtTermino" Display="Dynamic" 
                                                            ErrorMessage="La hora final es requerida." ToolTip="La hora final es requerida." 
                                                            ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="txtbxFechaFin_CV2" runat="server" ControlToCompare="txtInicio" 
                                                            ControlToValidate="txtTermino" Display="Dynamic" 
                                                            ErrorMessage="La hora final debe ser mayor o igual que la hora inicial." Operator="GreaterThanEqual" 
                                                            ToolTip="La hora final de la incidencia debe ser mayor o igual que La hora inicial." Type="String" 
                                                            ValidationGroup="Guardar">*</asp:CompareValidator>
                                                    </p>
                                                </asp:Panel>
                                            </div>
                                        </fieldset>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel1" runat="server">
                                    <div id="divBotones">
                                        <p class="submitButton">
                                            <asp:Button ID="btnGuardarModifes" runat="server" SkinID="SkinBoton" Text="Guardar"
                                                ToolTip="Guardar cambios y regresar a la pantalla de consulta de reducciones." 
                                                CausesValidation="True"   ValidationGroup="Guardar"/>
                                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="La opción seleccionada realizará cambios en la Base de Datos Institucional, ¿Continuar?"
                                                Enabled="True" TargetControlID="btnGuardarModifes">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                            <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" SkinID="SkinBoton"
                                                Text="Cancelar" ToolTip="Regresar a la pantalla de consulta de reducciones." />
                                            <asp:ValidationSummary
                                                ID="VSGrupoGuardarI" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Guardar" EnableClientScript="False" />
                                        </p>
                                    </div>
                                </asp:Panel>
                            </asp:View>
                            <asp:View ID="viewExito" runat="server">
                                <table>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: left">
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                                        </td>
                                        <td style="vertical-align: middle; text-align: left">
                                            <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
                                            <br />
                                            <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server"
                                                SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                                <asp:GridView ID="gvObservsPlaza" runat="server" AutoGenerateColumns="False" 
                                    Caption="Observaciones" SkinID="SkinGridView" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="Observacion" HeaderText="Observaciones" />
                                    </Columns>
                                </asp:GridView>
                                <br />
                            </asp:View>
                            <asp:View ID="viewError" runat="server">
                                <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                                <uc3:wucMuestraErrores ID="wucMuestraErrores1" runat="server" />
                                <div id="divBotonesErrores">
                                    <p class="submitButton">
                                        <asp:Button ID="btnReintentarOp" runat="server" Text="Reintentar operación" ToolTip=""
                                            />
                                        <asp:Button ID="btnCancelarOp" runat="server" Text="Continuar con otra operación en el sistema" 
                                            ToolTip="" 
                                            PostBackUrl="~/Consultas/Planteles/wfPlanteles.aspx?TipoOperacion=4" />
                                    </p>
                                </div>
                            </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
