<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="ABC_Recibos_AdmonRecibosBAK, App_Web_5lgpnrst" title="COBAEV - Nómina - Administrar recibos" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <div>
                <table style="width: 100%; height: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: right">
                            <h2>
                                Recibos de pago fuera de nómina (Administración)
                            </h2>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="viewEditar" runat="server">
                                    <asp:DetailsView ID="dvRecibo" runat="server" AutoGenerateRows="False" CellPadding="1"
                                        DefaultMode="Edit" HeaderText="Datos del recibo" SkinID="SkinDetailsView">
                                        <Fields>
                                            <asp:TemplateField HeaderText="IdRecibo" Visible="False">
                                                <HeaderStyle Wrap="False" />
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblIdRecibo" runat="server" Text='<%# Bind("IdRecibo") %>'></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Número de recibo">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="tbNumRecibo" runat="server" MaxLength="4" ReadOnly="True" SkinID="SkinTextBox"
                                                        Text='<%# Bind("NumRecibo") %>' Width="80px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tipo de recibo">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblIdTipoRecibo" runat="server" Text='<%# Bind("IdTipoRecibo") %>'
                                                        Visible="False"></asp:Label>
                                                    <asp:DropDownList ID="ddlTiposDeRecibos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTiposDeRecibos_SelectedIndexChanged"
                                                        SkinID="SkinDropDownList" Visible="False">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="R.F.C.">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="tbRFC" runat="server" ReadOnly="True" SkinID="SkinTextBox" Text='<%# Bind("RFCEmp") %>'
                                                        Width="200px"></asp:TextBox>
                                                    </ContentTemplate>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Empleado">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlNombre" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNombre_SelectedIndexChanged"
                                                        SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Clave de cobro">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>' Visible="False"></asp:Label>
                                                    <asp:TextBox ID="tbPlaza" runat="server" MaxLength="8" ReadOnly="True" SkinID="SkinTextBox"
                                                        Text='<%# Bind("Plaza") %>' Width="200px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFVtbPlaza" runat="server" ControlToValidate="tbPlaza"
                                                        Display="None" ErrorMessage="Clave de cobro requerida."></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="REVtbPlaza" runat="server" ControlToValidate="tbPlaza"
                                                        Display="None" ErrorMessage="Clave de cobro incorrecta." ValidationExpression="\d{8}"></asp:RegularExpressionValidator>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTBEtbPlaza" runat="server" FilterType="Numbers"
                                                        TargetControlID="tbPlaza">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha de pago:">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="tbFecha" runat="server"  MaxLength="10" SkinID="SkinTextBox" Text='<%# Bind("Fecha","{0:d}") %>'
                                                        Width="100px"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="tbFecha_CE" runat="server" TargetControlID="tbFecha">
                                                    </ajaxToolkit:CalendarExtender>
                                                    &nbsp;<asp:ImageButton ID="ibFecha" runat="server" CausesValidation="False" CssClass="ibFechNac"
                                                        ImageUrl="~/Imagenes/Fecha.png" OnClick="ibFecha_Click" Visible="False" />
                                                    <asp:HiddenField ID="hfFecha" runat="server" Value='<%# Bind("Fecha","{0:d}") %>' />
                                                    <asp:CompareValidator ID="tbFecha_CV" runat="server"
                                                        ControlToValidate="tbFecha" ErrorMessage="La fecha de pago no puede ser menor a la fecha inicial de la quincena."
                                                        Operator="GreaterThanEqual" ToolTip="La fecha de pago no puede ser menor a la fecha inicial de la quincena."
                                                        Type="Date" Display="Dynamic">*</asp:CompareValidator>
                                                    <asp:CompareValidator ID="tbFecha_CV2" runat="server" ControlToValidate="tbFecha"
                                                        ErrorMessage="La fecha de pago es incorrecta." Operator="DataTypeCheck" ToolTip="La fecha de pago es incorrecta."
                                                        Type="Date" Display="Dynamic">*</asp:CompareValidator>
                                                    <asp:RequiredFieldValidator ID="tbFecha_RFV" runat="server" ControlToValidate="tbFecha"
                                                        Display="Dynamic" ErrorMessage="La fecha de pago es obligatoria." ToolTip="La fecha de pago es obligatoria.">*</asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    &nbsp;
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Año">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <HeaderStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Estatus">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblIdEstatusRecibo" runat="server" Text='<%# Bind("IdEstatusRecibo") %>'
                                                        Visible="False"></asp:Label>
                                                    <asp:Label ID="lblDescEstatusRecibo" runat="server" Text='<%# Bind("DescEstatusRecibo") %>'
                                                        Visible="False"></asp:Label>
                                                    <asp:DropDownList ID="ddlEstatusRecibos" runat="server" SkinID="SkinDropDownList"
                                                        Visible="False">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Comentarios">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="tbConceptoRecibo" runat="server" MaxLength="200" Rows="3" SkinID="SkinTextBox"
                                                        Text='<%# Bind("ObservacionesRecibo") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle VerticalAlign="Top" />
                                                <ItemStyle VerticalAlign="Top" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quincena de aplicación">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlQuincena" runat="server" SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <HeaderStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fecha inicio quincena:" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtbxFechaIniQna" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                        Width="100px"></asp:TextBox>
                                                </EditItemTemplate>
                                                <HeaderStyle Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Fondo presupuestal">
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlFondosPresup" runat="server" SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Periodo de adeudo">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="ChckBxImplicaAdeudo" runat="server" AutoPostBack="True" OnCheckedChanged="ChckBxImplicaAdeudo_CheckedChanged"
                                                        Text="Definir un periodo de adeudo diferente" />
                                                    <br />
                                                    <asp:Panel ID="pnlAdeudo" runat="server" Enabled="False">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" Text="Inicio"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Fin"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="txtbxQnaIni" runat="server" MaxLength="6" SkinID="SkinTextBox" Width="80px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtbxQnaFin" runat="server" MaxLength="6" SkinID="SkinTextBox" Width="80px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtbxQnaIni"
                                                        ControlToValidate="txtbxQnaFin" Display="None" ErrorMessage="Error en las quincenas del adeudo."
                                                        Operator="GreaterThanEqual" SetFocusOnError="True"></asp:CompareValidator>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                        FilterType="Numbers" TargetControlID="txtbxQnaIni">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                        FilterType="Numbers" TargetControlID="txtbxQnaFin">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtbxQnaIni"
                                                        Display="None" ErrorMessage="Error en la quincena inicial." SetFocusOnError="True"
                                                        ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtbxQnaFin"
                                                        Display="None" ErrorMessage="Error en la quincena final." SetFocusOnError="True"
                                                        ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False">
                                                <EditItemTemplate>
                                                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="SkinBoton"
                                                        Text="Guardar" />
                                                    <ajaxToolkit:ConfirmButtonExtender ID="CBEbtnGuardar" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                        TargetControlID="btnGuardar">
                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" />
                                                </EditItemTemplate>
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                        </Fields>
                                        <HeaderStyle Font-Names="Verdana" Font-Size="Small" />
                                    </asp:DetailsView>
                                </asp:View>
                                <asp:View ID="viewExito" runat="server">
                                    <table>
                                        <tr>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                                            </td>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito" Text="Operación realizada exitosamente."></asp:Label>
                                                <br />
                                                <asp:Label ID="lblNumRecibo" runat="server" SkinID="SkinLblMsjExito" Text="Su número de recibo es el ==&gt; "
                                                    Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="viewError" runat="server">
                                    <table>
                                        <tr>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                                            </td>
                                            <td style="vertical-align: middle; text-align: left">
                                                <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
