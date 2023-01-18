<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ABCAniosMesesCompe.aspx.vb" Inherits="Admon_ABCAniosMesesCompe"
    Title="COBAEV - Nómina - Compensaciones mensuales (Administración de pagos)"
    StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Compensaciones mensuales (Administración de pagos)
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <table style="width: 100%; vertical-align: top;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: left">
                        <asp:Panel ID="pnlAños" runat="server" Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione año">
                            <br />
                            <asp:DropDownList ID="ddlAños" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; vertical-align: top;">
                        <asp:LinkButton ID="lbAddMesAdic" runat="server" SkinID="SkinLinkButton">Agregar mes adicional</asp:LinkButton>
                        <ajaxToolkit:ConfirmButtonExtender ID="lbAddMesAdic_ConfirmButtonExtender" runat="server"
                            ConfirmText="La operación solicitada realizará modificaciones en la Base de datos, ¿Continuar?"
                            Enabled="True" TargetControlID="lbAddMesAdic">
                        </ajaxToolkit:ConfirmButtonExtender>
                        &nbsp;<br />
                        <asp:GridView ID="gvAniosMesesCompe" runat="server" CellPadding="1" OnRowCancelingEdit="gvAniosMesesCompe_RowCancelingEdit"
                            OnRowDataBound="gvAniosMesesCompe_RowDataBound" OnRowDeleting="gvAniosMesesCompe_RowDeleting"
                            OnRowEditing="gvAniosMesesCompe_RowEditing" OnRowUpdating="gvAniosMesesCompe_RowUpdating"
                            OnSelectedIndexChanged="gvAniosMesesCompe_SelectedIndexChanged" SkinID="SkinGridView"
                            Width="100%">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="Año">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblAnio_E" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdMes" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdMes" runat="server" Text='<%# Bind("IdMes") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdMes_E" runat="server" Text='<%# Bind("IdMes") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mes">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMes" runat="server" Text='<%# Bind("NombreMes") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="blMes_E" runat="server" Text='<%# Eval("NombreMes") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Adic.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdicional" runat="server" Text='<%# Bind("Adicional") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="True" />
                                    <EditItemTemplate>
                                        <asp:Label ID="lblAdicional_E" runat="server" Text='<%# Bind("Adicional") %>'></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cerrado">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="ChkBxEstatus_E" runat="server" Checked='<%# Bind("Cerrado") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkBxEstatus" runat="server" Checked='<%# Bind("Cerrado") %>' Enabled="False" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ISR<br />Recalculado">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkBxISRRecalculado" runat="server" Checked='<%# Bind("ISRRecalculado") %>'
                                            Enabled="False" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="ChkBxISRRecalculado_E" runat="server" Checked='<%# Bind("ISRRecalculado") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha<br />de pago">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbFchPago_E" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                            Text='<%# Bind("FechaDePago", "{0:d}") %>' Width="100px"></asp:TextBox>
                                        <ajaxToolkit:TextBoxWatermarkExtender ID="tbFchPago_E_TextBoxWatermarkExtender" runat="server"
                                            Enabled="True" TargetControlID="tbFchPago_E" WatermarkCssClass="WaterMark" WatermarkText="dd/mm/aaaa">
                                        </ajaxToolkit:TextBoxWatermarkExtender>
                                        <asp:RequiredFieldValidator ID="RFVtbFchPago_E" runat="server" ControlToValidate="tbFchPago_E"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ToolTip="Fecha de pago requerida."></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CVtbFchPago_E" runat="server" ControlToValidate="tbFchPago_E"
                                            Display="Dynamic" ErrorMessage="Error en la fecha." Operator="DataTypeCheck"
                                            Type="Date"></asp:CompareValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFchPago" runat="server" Text='<%# Bind("FechaDePago", "{0:d}") %>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mes<br />ord.">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="ChkBxMesNormal_E" runat="server" Checked='<%# Bind("MesNormal") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkBxMesNormal" runat="server" Checked='<%# Bind("MesNormal") %>'
                                            Enabled="False" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mes ord<br />(compl.)">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="ChkBxMesComp_E" runat="server" Checked='<%# Bind("Complementaria") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkBxMesComp" runat="server" Checked='<%# Bind("Complementaria") %>'
                                            Enabled="False" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Observaciones">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbComentarios_E" runat="server" Width="150px" MaxLength="100" SkinID="SkinTextBox"
                                            Text='<%# Bind("Comentarios") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblComentarios" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("Comentarios") %>' Width="150px"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Afectación">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbNumAfect1_E" runat="server" Width="100px" MaxLength="20" SkinID="SkinTextBox"
                                            Text='<%# Bind("NumAfect1") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumAfect1" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("NumAfect1") %>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Afectación<br />(2)" Visible="false">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbNumAfect2_E" runat="server" Width="100px" MaxLength="20" SkinID="SkinTextBox"
                                            Text='<%# Bind("NumAfect2") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumAfect2" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("NumAfect2") %>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descripción del pago">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbDescDelPago_E" runat="server" Width="200px" MaxLength="200" SkinID="SkinTextBox"
                                            Text='<%# Bind("DescDelPago") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTieneDescDelPago" runat="server" Text='<%# Bind("TieneDescDelPago") %>'
                                            ToolTip='<%# Bind("DescDelPago") %>' SkinID="SkinLblMsjErrores"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" CommandName="Update"
                                            ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar" />
                                        &nbsp;<asp:ImageButton ID="ibCancelar" runat="server" CausesValidation="False" CommandName="Cancel"
                                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBECancelar" runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                                            TargetControlID="ibGuardar">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" CommandName="Edit"
                                            ImageUrl="~/Imagenes/Modificar.png" ToolTip="Modificar" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" CommandName="Delete"
                                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                                            TargetControlID="ibEliminar">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibAddAnioMesCompe" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Add2.png"
                                            OnClick="ibAddAnioMesCompe_Click" ToolTip="Crear listado de compensaciones para el siguiente mes." />
                                        <ajaxToolkit:ConfirmButtonExtender ID="ibAddAnioMesCompe_ConfirmButtonExtender" runat="server"
                                            ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                                            Enabled="True" TargetControlID="ibAddAnioMesCompe">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SigMesCreado" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSigMesCreado" runat="server" Text='<%# Bind("SigMesCreado") %>'></asp:Label>
                                        <asp:CheckBox ID="ChkBxSigMesCreado" runat="server" Checked='<%# Bind("SigMesCreado") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
