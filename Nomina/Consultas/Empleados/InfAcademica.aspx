<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="InfAcademica.aspx.vb" Inherits="Consultas_Empleados_InfAcademica" Title="COBAEV - Nómina - Historia académica"
    StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Información académica)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                                    </td>
                                    <td style="vertical-align: top; text-align: right">
                                        &nbsp;<asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" /><br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <asp:panel ID="pnl1" runat="server">
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEHistoriaAcademica" runat="Server" CollapseControlID="TitlePanelHistoriaAcademica"
                                        Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                        ExpandControlID="TitlePanelHistoriaAcademica" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                                        TargetControlID="ContentPanelHistoriaAcademica" TextLabelID="Label1">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; text-align: left">
                                                    <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                                                        SkinID="SkinLblDatos"></asp:Label>
                                                    <asp:Label ID="lblRFCEmp" runat="server" Font-Strikeout="False" Font-Underline="True"
                                                        SkinID="SkinLblDatos" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; text-align: left">
                                                    <br />
                                                    <asp:LinkButton ID="lbAddRegAcad" runat="server" SkinID="SkinLinkButton">Agregar registro académico</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="TitlePanelHistoriaAcademica" runat="server" BorderColor="White" BorderStyle="Solid"
                                                        BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                        &nbsp;Historia académica
                                                        <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:Panel ID="ContentPanelHistoriaAcademica" runat="server" CssClass="collapsePanel"
                                                        Width="100%">
                                                        <asp:GridView ID="gvHistoriaAcademica" runat="server" CellPadding="1" OnRowDataBound="gvHistoriaAcademica_RowDataBound"
                                                            OnSelectedIndexChanged="gvHistoriaAcademica_SelectedIndexChanged" SkinID="SkinGridView"
                                                            Width="100%" EmptyDataText="Sin estudios registrados.">
                                                            <Columns>
                                                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:CommandField>
                                                                <asp:TemplateField HeaderText="IdEstudio" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblIdEstudio_E" runat="server" Text='<%# Bind("IdEstudio") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdEstudio" runat="server" Text='<%# Bind("IdEstudio") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IdNivel" Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblIdNivelf_E" runat="server" Text='<%# Bind("IdNivel") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIdNivel" runat="server" Text='<%# Bind("IdNivel") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Tipo de estudio">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescNivel" runat="server" Text='<%# Bind("DescNivel") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDescNivel_E" runat="server" Text='<%# Bind("DescNivel") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Inst. Educ">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInstEduc" runat="server" Text='<%# Bind("institucion") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblInstEduc_E" runat="server" Text='<%# Eval("institucion") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Abrev. Prof.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAbrevProf" runat="server" Text='<%# Bind("SiglasINI") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblAbrevProf_E" runat="server" Text='<%# Eval("SiglasINI") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Carrera">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescCarrera" runat="server" Text='<%# Bind("DescCarrera") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblDescCarrera_E" runat="server" Text='<%# Eval("DescCarrera") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Titulado">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkBxTitulado" runat="server" Checked='<%# Bind("Titulado") %>'
                                                                            Enabled="False" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:CheckBox ID="ChkBxTitulado_E" runat="server" Checked='<%# Bind("Titulado") %>' />
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Núm. Ced. Prof.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNumCedProf" runat="server" Text='<%# Bind("NumCedProf") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblNumCedProf_E" runat="server" Text='<%# Eval("NumCedProf") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Estudios<br />incompletos">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkBxIncompleta" runat="server" Checked='<%# Bind("Incompleta") %>'
                                                                            Enabled="False" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:CheckBox ID="ChkBxIncompleta_E" runat="server" Checked='<%# Bind("Incompleta") %>' />
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Cursando<br/>actualmente">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkBxCursando" runat="server" Checked='<%# Bind("Cursando") %>'
                                                                            Enabled="False" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:CheckBox ID="ChkBxCursando_E" runat="server" Checked='<%# Bind("Cursando") %>' />
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Ult. Niv.<br />Estudios">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkBxUltNivEstudios" runat="server" Checked='<%# Bind("UltNivEstudios") %>'
                                                                            Enabled="False" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:CheckBox ID="ChkBxUltNivEstudios_E" runat="server" Checked='<%# Bind("UltNivEstudios") %>' />
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Fecha exp. doc.">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha", "{0:d}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="tbFecha_E" runat="server" MaxLength="10" SkinID="SkinTextBox" Text='<%# Bind("Fecha", "{0:d}") %>'></asp:TextBox>
                                                                        <ajaxToolkit:TextBoxWatermarkExtender ID="tbFchPago_E_TextBoxWatermarkExtender" runat="server"
                                                                            Enabled="True" TargetControlID="tbFchPago_E" WatermarkCssClass="WaterMark" WatermarkText="dd/mm/aaaa">
                                                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                                                        <asp:RequiredFieldValidator ID="RFVtbFcecha_E" runat="server" ControlToValidate="tbFecha_E"
                                                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ToolTip="Fecha requerida."></asp:RequiredFieldValidator>
                                                                        <asp:CompareValidator ID="CVtbFecha_E" runat="server" ControlToValidate="tbFecha_E"
                                                                            Display="Dynamic" ErrorMessage="Error en la fecha." Operator="DataTypeCheck"
                                                                            Type="Date"></asp:CompareValidator>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" CommandName="Edit"
                                                                            ImageUrl="~/Imagenes/Modificar.png" ToolTip="Modificar" OnClick="ibEditar_Click" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" CommandName="Update"
                                                                            ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar" />
                                                                        &nbsp;<asp:ImageButton ID="ibCancelar" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar" />
                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBECancelar" runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                                                                            TargetControlID="ibGuardar">
                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                    </EditItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" CommandName="Delete"
                                                                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" OnClick="ibEliminar_Click" />
                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                                                                            TargetControlID="ibEliminar">
                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    </asp:panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
