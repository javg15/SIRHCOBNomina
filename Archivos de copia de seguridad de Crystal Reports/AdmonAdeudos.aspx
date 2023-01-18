<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageBlanca.master"
    AutoEventWireup="false" CodeFile="AdmonAdeudos.aspx.vb" Inherits="ABC_Nomina_AdmonAdeudos"
    Title="COBAEV - Nómina - Administrar adeudos quincenales" StylesheetTheme="SkinFile" %>

<%@ Register Src="../../WebControls/wucSearchEmps2.ascx" TagName="wucSearchEmps2"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <div>
        <table style="width: 100%; height: 100%">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Administración de adeudos quincenales
                </h2>
            </td>
        </tr>
            <tr>
                <td>
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="viewOperacion" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="1" BackColor="#FFFBD6" BorderColor="#FFDFAD"
                                        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" FinishCompleteButtonText="Guardar"
                                        Font-Italic="False" Height="300px" OnNextButtonClick="Wizard1_NextButtonClick"
                                        Width="100%" OnFinishButtonClick="Wizard1_FinishButtonClick" HeaderText="Empleado"
                                        OnPreviousButtonClick="Wizard1_PreviousButtonClick" 
                                        OnSideBarButtonClick="Wizard1_SideBarButtonClick">
                                        <WizardSteps>
                                            <asp:WizardStep runat="server" Title="Empleado">
                                                <uc1:wucSearchEmps2 ID="wucSearchEmps2" runat="server" />
                                            </asp:WizardStep>
                                            <asp:WizardStep runat="server" Title="Tipo de adeudo">
                                                <asp:Label ID="lblTipoAdeudo" runat="server" SkinID="SkinLblNormal" Text="Tipo de adeudo:"></asp:Label>
                                                <br />
                                                <asp:DropDownList ID="ddlTipoDeAdeudo" runat="server" SkinID="SkinDropDownList">
                                                </asp:DropDownList>
                                                <br />
                                            </asp:WizardStep>
                                            <asp:WizardStep runat="server" Title="Per&#237;odo">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td colspan="2" style="text-align: left">
                                                                    <asp:Label ID="Label4" runat="server" SkinID="SkinLblNormal" Text="Período adeudo"></asp:Label>
                                                                </td>
                                                                <td colspan="1" style="text-align: left">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label1" runat="server" Text="Aplicación" SkinID="SkinLblNormal"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label2" runat="server" Text="Inicio" SkinID="SkinLblNormal"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Fin"></asp:Label>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlQnaAplic" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                                        Width="100px">
                                                                    </asp:DropDownList>
                                                                    <asp:HiddenField ID="hfQnaAplic" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlQnaIni" runat="server" SkinID="SkinDropDownList" Width="100px">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlQnaAplic" EventName="SelectedIndexChanged" />
                                                                            <asp:AsyncPostBackTrigger ControlID="btnUpdQnaIni" EventName="Click" />
                                                                            <asp:AsyncPostBackTrigger ControlID="btnUpdQnaFin" EventName="Click" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td>
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlQnaFin" runat="server" SkinID="SkinDropDownList" Width="100px">
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:AsyncPostBackTrigger ControlID="ddlQnaAplic" EventName="SelectedIndexChanged" />
                                                                            <asp:AsyncPostBackTrigger ControlID="btnUpdQnaFin" EventName="Click" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnRest" runat="server" CausesValidation="False" SkinID="SkinBoton"
                                                                        Text="Restablecer" ToolTip="Restablecer valores iniciales" ValidationGroup="Grupo1" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnRest" EventName="Click" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label5" runat="server" SkinID="SkinLblNormal" Text="Quincenas adeudadas"></asp:Label>
                                                        </td>
                                                        <td style="width: 25px">
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label6" runat="server" SkinID="SkinLblNormal" Text="Restar a quincena final"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtbxNumQnas" runat="server" MaxLength="2" SkinID="SkinTextBox"
                                                                ValidationGroup="Grupo1" Width="50px">1</asp:TextBox>
                                                            <asp:Button ID="btnUpdQnaIni" runat="server" SkinID="SkinBoton" Text="Actualizar"
                                                                ToolTip="Actualizar la quincena inicial del per&#237;odo de adeudo" ValidationGroup="Grupo1" /><ajaxToolkit:FilteredTextBoxExtender
                                                                    ID="FTBENumQnas" runat="server" FilterType="Numbers" TargetControlID="txtbxNumQnas"
                                                                    Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            <asp:RangeValidator ID="RVNumQnas" runat="server" ControlToValidate="txtbxNumQnas"
                                                                Display="Dynamic" ErrorMessage="Rango v&#225;lido [1-99]" Font-Size="Small" MaximumValue="99"
                                                                MinimumValue="1" Type="Integer" ValidationGroup="Grupo1"></asp:RangeValidator>
                                                            <asp:RequiredFieldValidator ID="RFVNumQnas" runat="server" ControlToValidate="txtbxNumQnas"
                                                                Display="Dynamic" ErrorMessage="Valor requerido" Font-Size="Small" ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="width: 25px">
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtbxQnasARestar" runat="server" MaxLength="2" SkinID="SkinTextBox"
                                                                ValidationGroup="Grupo2" Width="50px">1</asp:TextBox>
                                                            <asp:Label ID="Label7" runat="server" SkinID="SkinLblNormal" Text="quincena(s)"></asp:Label>
                                                            <asp:Button ID="btnUpdQnaFin" runat="server" SkinID="SkinBoton" Text="Actualizar"
                                                                ToolTip="Actualizar la quincena final del per&#237;odo de adeudo" /><ajaxToolkit:FilteredTextBoxExtender
                                                                    ID="FTBEQnasARestar" runat="server" FilterType="Numbers" TargetControlID="txtbxQnasARestar"
                                                                    Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            <asp:RangeValidator ID="RVQnasARestar" runat="server" ControlToValidate="txtbxQnasARestar"
                                                                Display="Dynamic" ErrorMessage="Rango v&#225;lido [1-99]" Font-Size="Small" MaximumValue="99"
                                                                MinimumValue="1" Type="Integer" ValidationGroup="Grupo2"></asp:RangeValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="vertical-align: top;">
                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:GridView ID="gvQnasDias" runat="server" Caption="Días a pagar por quincena"
                                                                        SkinID="SkinGridView" Visible="False" Width="300px" CellPadding="0">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincena") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Quincena" HeaderText="Quincena">
                                                                                <ItemStyle Width="50px" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="D&#237;as a pagar">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtbxNumDias" runat="server" MaxLength="2" SkinID="SkinTextBox"
                                                                                        Text='<%# Bind("NumDias") %>' Width="50px"></asp:TextBox>
                                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBENumDias" runat="server" FilterType="Numbers"
                                                                                        TargetControlID="txtbxNumDias">
                                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                                    <asp:RangeValidator ID="RVNumDias" runat="server" ControlToValidate="txtbxNumDias"
                                                                                        Display="Dynamic" ErrorMessage="Valores permitidos [0-15]" MaximumValue="15"
                                                                                        MinimumValue="0" Type="Integer"></asp:RangeValidator>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Width="250px" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle Wrap="True" />
                                                                    </asp:GridView>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:WizardStep>
                                            <asp:WizardStep runat="server" Title="Carga horaria">
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gvCargaHoraria" runat="server" AutoGenerateColumns="False" EmptyDataText="Empleado administrativo (no se requiere carga horaria) o Docente sin carga horaria definida."
                                                            SkinID="SkinGridViewEmpty" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chbxHora" runat="server" SkinID="SkinCheckBox" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IdHora" Visible="False">
                                                                    <EditItemTemplate>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdHora" runat="server" Text='<%# Bind("IdHora") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Plantel">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPlantel" runat="server" Text='<%# Bind("ClavePlantel") %>' ToolTip='<%# Bind("NombrePlantel") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="NombreMateria" HeaderText="Materia">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Horas" HeaderText="Horas">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Grupo" HeaderText="Grupo">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Tipo hora">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTipoHora" runat="server" Text='<%# Bind("TipoHora") %>' ToolTip='<%# Bind("DescCategoria") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Estatus hora">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEstatusHora" runat="server" Text='<%# Bind("AbrevEstatus") %>'
                                                                            ToolTip='<%# Bind("DescEstatus") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ClaveCategoria" HeaderText="Clave categor&#237;a" Visible="False">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="DescCategoria" HeaderText="Categor&#237;a" Visible="False">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Nombramiento">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombramiento" runat="server" Text='<%# Bind("AbrevNombramiento") %>'
                                                                            ToolTip='<%# Bind("DescNombramiento") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="N&#243;mina">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTipoNomina" runat="server" Text='<%# Bind("AbrevTipoNomina") %>'
                                                                            ToolTip='<%# Bind("DescTipoNomina") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Semestre" HeaderText="Semestre">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="QnaIni" HeaderText="Inicio">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="QnaFin" HeaderText="Fin">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="Wizard1" EventName="NextButtonClick" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </asp:WizardStep>
                                            <asp:WizardStep runat="server" Title="Finalizar">
                                                <asp:Label ID="lblFinalizar" runat="server" SkinID="SkinLblNormal" Text="Para terminar la captura/modificaci&#243;n/eliminaci&#243;n del adeudo, haga click en el bot&#243;n correspondiente."></asp:Label>
                                                &nbsp;&nbsp;<br />
                                                <asp:HiddenField ID="hfNoGuardar" runat="server" Value="1" />
                                            </asp:WizardStep>
                                        </WizardSteps>
                                        <SideBarButtonStyle ForeColor="White" />
                                        <NavigationButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid"
                                            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                                        <SideBarStyle BackColor="#990000" Font-Size="0.9em" VerticalAlign="Top" HorizontalAlign="Left"
                                            Wrap="True" Width="15%" />
                                        <HeaderStyle BackColor="#FFCC66" BorderColor="#FFFBD6" BorderStyle="Solid" BorderWidth="2px"
                                            Font-Bold="True" Font-Size="0.9em" ForeColor="#333333" HorizontalAlign="Center" />
                                        <StepStyle VerticalAlign="Top" Width="85%" />
                                        <NavigationStyle HorizontalAlign="Left" />
                                    </asp:Wizard>
                                    <asp:Panel ID="pnlExito" runat="server" Visible="False">
                                        <table>
                                            <tr>
                                                <td style="vertical-align: middle; text-align: left">
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                                                </td>
                                                <td style="vertical-align: middle; text-align: left">
                                                    <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito" Text="Operación realizada exitosamente."></asp:Label><br />
                                                    <br />
                                                    <asp:LinkButton ID="lbCerrar" runat="server" SkinID="SkinLinkButton">Cerrar ventana</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlError" runat="server" Visible="False">
                                        <table>
                                            <tr>
                                                <td style="vertical-align: middle; text-align: left">
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                                                </td>
                                                <td style="vertical-align: middle; text-align: left">
                                                    <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label><br />
                                                    <br />
                                                    <asp:LinkButton ID="lbContinuar" runat="server" SkinID="SkinLinkButton" Visible="False">Continuar</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Wizard1" EventName="NextButtonClick" />
                                    <asp:AsyncPostBackTrigger ControlID="Wizard1" EventName="PreviousButtonClick" />
                                    <asp:AsyncPostBackTrigger ControlID="Wizard1" EventName="FinishButtonClick" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
