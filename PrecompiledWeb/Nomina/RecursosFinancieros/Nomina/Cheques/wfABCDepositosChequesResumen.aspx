<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="wfABCDepositosChequesResumen, App_Web_xpfamm0l" title="COBAEV - Nómina - ABC Resumen depósitos-cheques" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="~/WebControls/wucMuestraErrores.ascx" TagName="wucMuestraErrores"
    TagPrefix="uc3" %>
<%@ Register Src="~/WebControls/wucCalendario.ascx" TagName="wucCalendario" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
            <table style="width: 100%; vertical-align: top;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: right">
                        <h2>
                            Sistema de nómina: Resumen relación depósitos-cheques quincenales/mensuales</h2>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlTiposDeCheques" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                GroupingText="Seleccione tipo de pago" HorizontalAlign="Left">
                <asp:DropDownList ID="ddlTiposDeCheques" runat="server" SkinID="SkinDropDownList"
                    AutoPostBack="True">
                    <asp:ListItem Value="N" Text="Nómina"></asp:ListItem>
                    <asp:ListItem Value="NPA" Text="Nómina (Pensión alimenticia)"></asp:ListItem>
                    <asp:ListItem Value="R" Text="Recibos"></asp:ListItem>
                    <asp:ListItem Value="C" Text="Compensaciones"></asp:ListItem>
                    <asp:ListItem Value="CPA" Text="Compensaciones (Pensión alimenticia)"></asp:ListItem>
                </asp:DropDownList>
                <asp:Image ID="imgCheckTipoCheque" runat="server" ImageUrl="~/Imagenes/check.png"
                    Visible="False" />
                <asp:Image ID="imgNoCheckTipoCheque" runat="server" ImageUrl="~/Imagenes/nocheck.png"
                    Visible="False" />
            </asp:Panel>
            <asp:Panel ID="pnlAños" runat="server" Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione año"
                HorizontalAlign="Left">
                <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Image ID="imgCheckAnio" runat="server" ImageUrl="~/Imagenes/check.png" Visible="False" />
                <asp:Image ID="imgNoCheckAnio" runat="server" ImageUrl="~/Imagenes/nocheck.png" Visible="False" />
            </asp:Panel>
            <asp:Panel ID="pnlMeses" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                GroupingText="Seleccione mes" HorizontalAlign="Left">
                <asp:DropDownList ID="ddlMeses" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Image ID="imgCheckMes" runat="server" ImageUrl="~/Imagenes/check.png" Visible="False" />
                <asp:Image ID="imgNoCheckMes" runat="server" ImageUrl="~/Imagenes/nocheck.png" Visible="False" />
            </asp:Panel>
            <asp:Panel ID="pnlQnas" runat="server" Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione quincena"
                HorizontalAlign="Left" Visible="false">
                <asp:DropDownList ID="ddlQnas" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Image ID="imgCheckQna" runat="server" ImageUrl="~/Imagenes/check.png" Visible="False" />
                <asp:Image ID="imgNoCheckQna" runat="server" ImageUrl="~/Imagenes/nocheck.png" Visible="False" />
            </asp:Panel>
            <asp:Panel ID="pnlBancos" runat="server" Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione banco"
                HorizontalAlign="Left" Visible="false">
                <asp:DropDownList ID="ddlBancosDeposito" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Image ID="imgCheckBanco" runat="server" ImageUrl="~/Imagenes/check.png" />
            </asp:Panel>
            <asp:Panel ID="pnldivBotonesErrores" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                BorderStyle="None">
                <div id="divBotones1">
                    <p class="submitButton">
                        <asp:Button ID="btnConsultar" runat="server" Text="Aplicar parámetros de consulta"
                            ToolTip="" />
                        <asp:Button ID="btnCambiarPrmsCons" runat="server" Text="Cambiar parámetros de consulta"
                            ToolTip="" />
                    </p>
                </div>
            </asp:Panel>
            <asp:MultiView ID="mvCheques" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewCheques" runat="server">
                    <asp:GridView ID="gvCheques" runat="server" SkinID="SkinGridView" EmptyDataText="Los parámetros de consulta no regresaron ningún valor."
                        AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="IdQuincena" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincena") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Anio" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdMes" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdMes" runat="server" Text='<%# Bind("IdMes") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Adicional" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdicional" runat="server" Text='<%# Bind("Adicional") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quincena">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuincenaObservs" runat="server" Text='<%# Bind("QuincenaObservs") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ImporteNeto">
                                <ItemTemplate>
                                    <asp:Label ID="lblImporteNeto" runat="server" Text='<%# Bind("ImporteNeto", "{0:c}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdBanco" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdBanco" runat="server" Text='<%# Bind("IdBanco") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Banco depósito">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombreCortoBanco" runat="server" Text='<%# Bind("NombreCortoBanco") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de pago" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipoPago" runat="server" Text='<%# Bind("TipoPago") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Número Cheque/Videomático">
                                <ItemTemplate>
                                    <asp:Label ID="lblNumCheque" runat="server" Text='<%# Bind("NumCheque") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comentarios">
                                <ItemTemplate>
                                    <asp:Label ID="lblComentarios" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibCapturar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Captura1.jpg"
                                        ToolTip="Capturar información inicial sobre el cheque." OnClick="ibCapturar_Click" CommandArgument="1" />
                                    <asp:ImageButton ID="ibModificar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Modificar.png"
                                        ToolTip="Modificar información capturada sobre el cheque." OnClick="ibCapturar_Click" CommandArgument="0" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TipoCheque" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipoCheque" runat="server" Text='<%# Bind("TipoCheque") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:View>
                <asp:View ID="viewCaptura" runat="server">
                <asp:Panel ID="pnlCheque" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                    GroupingText="Registros a consultar o modificar" HorizontalAlign="Left">
                    <asp:GridView ID="gvCheque" runat="server" SkinID="SkinGridView" EmptyDataText="Los parámetros de consulta no regresaron ningún valor."
                        AutoGenerateColumns="False"
                        Width="100%">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblSelAll" runat="server" Text="Seleccionar todos"></asp:Label>
                                    <br />
                                    <asp:CheckBox ID="chkbxSelecAll" runat="server" AutoPostBack="True" 
                                        oncheckedchanged="chkbxSelecAll_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkbxSelec" runat="server" AutoPostBack="True" 
                                        oncheckedchanged="chkbxSelec_CheckedChanged">
                                    </asp:CheckBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id_Emp_BenefPA" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId_Emp_BenefPA" runat="server" Text='<%# Bind("Id_Emp_BenefPA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdQuincena" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdQuincena" runat="server" Text='<%# Bind("IdQuincena") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Anio" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdMes" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdMes" runat="server" Text='<%# Bind("IdMes") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Adicional" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdicional" runat="server" Text='<%# Bind("Adicional") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdPlantel" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdPlantel" runat="server" Text='<%# Bind("IdPlantel") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdRecibo" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdRecibo" runat="server" Text='<%# Bind("IdRecibo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Num. Recibo">
                                <ItemTemplate>
                                    <asp:Label ID="lblNumRecibo" runat="server" Text='<%# Bind("NumRecibo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="R.F.C.">
                                <ItemTemplate>
                                    <asp:Label ID="lblRFCEmp" runat="server" Text='<%# Bind("RFCEmp") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Apellido paterno">
                                <ItemTemplate>
                                    <asp:Label ID="lblApePatEmp" runat="server" Text='<%# Bind("ApePatEmp") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Apellido materno">
                                <ItemTemplate>
                                    <asp:Label ID="lblApeMatEmp" runat="server" Text='<%# Bind("ApeMatEmp") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:Label ID="lblNomEmp" runat="server" Text='<%# Bind("NomEmp") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comentarios">
                                <ItemTemplate>
                                    <asp:Label ID="lblComentarios" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ImporteNeto">
                                <ItemTemplate>
                                    <asp:Label ID="lblImporteNeto" runat="server" Text='<%# Bind("ImporteNeto", "{0:c}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Adscripción">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescPlAdscrip" runat="server" Text='<%# Bind("CvePlAdscrip") %>'
                                        ToolTip='<%# Bind("DescPlAdscrip") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Radicar a">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescPlRadic" runat="server" Text='<%# Bind("CvePlRadic") %>' ToolTip='<%# Bind("DescPlRadic") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tipo de pago">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipoPago" runat="server" Text='<%# Bind("TipoPago") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Número Cheque/Videomático">
                                <ItemTemplate>
                                    <asp:Label ID="lblNumCheque" runat="server" Text='<%# Bind("NumCheque") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ibCapturar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Captura1.jpg"
                                        ToolTip="Capturar información sobre el cheque."></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TipoCheque" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipoCheque" runat="server" Text='<%# Bind("TipoCheque") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="IdBanco" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblIdBanco" runat="server" Text='<%# Bind("IdBanco") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CuentaPagadora" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCuentaPagadora" runat="server" Text='<%# Bind("CuentaPagadora") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FechaEmision" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaEmision" runat="server" Text='<%#  Bind("FechaEmision", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FechaPagoCheque" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaPagoCheque" runat="server" Text='<%#  Bind("FechaPagoCheque", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ObservsCheque" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblObservsCheque" runat="server" Text='<%#  Bind("ObservsCheque") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cancelado" Visible="false">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkbxCancelado" runat="server" Checked='<%#  Bind("Cancelado") %>'>
                                    </asp:CheckBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FechaCancelacion" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaCancelacion" runat="server" Text='<%#  Bind("FechaCancelacion", "{0:d}") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlABCCheque" HorizontalAlign="Left">
                        <div class="accountInfo">
                            <fieldset id="fsCaptura">
                                <div class="panelIzquierda">
                                    <p class="pLabel">
                                        <asp:Label ID="lblBancos" runat="server" CssClass="pLabel" Enabled="False" Text="Bancos:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:DropDownList ID="ddlBancos" runat="server" CssClass="textEntry" 
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblCtasPag" runat="server" CssClass="pLabel" Enabled="False" Text="Cuenta pagadora:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:DropDownList ID="ddlCtasPag" runat="server" CssClass="textEntry">
                                        </asp:DropDownList>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblNumCheque" runat="server" CssClass="pLabel" Text="Número de cheque o videomático:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxNumCheque" runat="server" CssClass="textEntry"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="txtbxNumCheque_RFV" runat="server" ControlToValidate="txtbxNumCheque"
                                            Display="Dynamic" ErrorMessage="El número de cheque es requerido."
                                            ValidationGroup="NuevoDia" ToolTip="El número de cheque es requerido.">*</asp:RequiredFieldValidator>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblFechaEmision" runat="server" CssClass="pLabel"
                                            Text="Fecha de emisión del cheque:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxFechaEmision" runat="server" MaxLength="10" CssClass="textEntry"
                                            ValidationGroup="NuevoDia" AutoPostBack="True"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtbxFechaEmision_CE" runat="server" 
                                            Enabled="True" TargetControlID="txtbxFechaEmision">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="txtbxFechaEmision_RFV" runat="server" ControlToValidate="txtbxFechaEmision"
                                            Display="Dynamic" ErrorMessage="La fecha de emisión del cheque es requerida."
                                            ValidationGroup="NuevoDia" ToolTip="La fecha de emisión del cheque es requerida.">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="txtbxFechaEmision_CV" runat="server" ControlToValidate="txtbxFechaEmision"
                                            Display="Dynamic" ErrorMessage="La fecha de emisión del cheque es incorrecta."
                                            Operator="DataTypeCheck" Type="Date" ValidationGroup="NuevoDia" ToolTip="La fecha de emisión del cheque es incorrecta.">*</asp:CompareValidator>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblFechaPagoCheque" runat="server" CssClass="pLabel" Text="Fecha de pago del cheque:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxFechaPagoCheque" runat="server" CssClass="textEntry" MaxLength="10"
                                            ValidationGroup="NuevoDia"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtbxFechaPagoCheque_CE" runat="server" 
                                            Enabled="True" TargetControlID="txtbxFechaPagoCheque">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="txtbxFechaPagoCheque_RFV" runat="server" ControlToValidate="txtbxFechaPagoCheque"
                                            Display="Dynamic" ErrorMessage="La fecha de pago del cheque es requerida." ToolTip="La fecha de pago del cheque es requerida."
                                            ValidationGroup="NuevoDia" Enabled="false">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="txtbxFechaPagoCheque_CV" runat="server" ControlToValidate="txtbxFechaPagoCheque"
                                            Display="Dynamic" ErrorMessage="La fecha de pago del cheque es incorrecta." Operator="DataTypeCheck"
                                            ToolTip="La fecha de pago del cheque es incorrecta." Type="Date" ValidationGroup="NuevoDia">*</asp:CompareValidator>
                                        <asp:CompareValidator ID="txtbxFechaFin_CV2" runat="server" ControlToCompare="txtbxFechaEmision"
                                            ControlToValidate="txtbxFechaPagoCheque" Display="Dynamic" ErrorMessage="La fecha de pago debe ser mayor o igual que la fecha de emisión."
                                            Operator="GreaterThanEqual" ToolTip="La fecha de pago debe ser mayor o igual que la fecha de emisión."
                                            Type="Date" ValidationGroup="NuevoDia">*</asp:CompareValidator>
                                    </p>
                                    <p class="pLabel">
                                    </p>
                                    <p class="pTextBox">
                                        <asp:CheckBox runat="server" ID="chkbxChequeCancel" 
                                            Text="Cancelar/Cheque cancelado" 
                                            AutoPostBack="True"/>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblFechaCancelacion" runat="server" CssClass="pLabel" Text="Fecha de cancelación del cheque:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxFechaCancelacion" runat="server" AutoPostBack="True" CssClass="textEntry"
                                            MaxLength="10" ValidationGroup="NuevoDia" enabled="false"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtbxFechaCancelacion_CE" runat="server" 
                                            Enabled="True" TargetControlID="txtbxFechaCancelacion">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="txtbxFechaCancelacion_RFV" runat="server" ControlToValidate="txtbxFechaCancelacion"
                                            Display="Dynamic" ErrorMessage="La fecha de cancelación del cheque es requerida." ToolTip="La fecha de cancelación del cheque es requerida."
                                            ValidationGroup="NuevoDia" Enabled="false">*</asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="txtbxFechaCancelacion_CV" runat="server" ControlToValidate="txtbxFechaCancelacion"
                                            Display="Dynamic" ErrorMessage="La fecha de cancelación del cheque es incorrecta."
                                            Operator="DataTypeCheck" ToolTip="La fecha de cancelación del cheque es incorrecta."
                                            Type="Date" ValidationGroup="NuevoDia" enabled="false">*</asp:CompareValidator>
                                        <asp:CompareValidator ID="txtbxFechaCancelacion_CV2" runat="server" ControlToCompare="txtbxFechaEmision"
                                            ControlToValidate="txtbxFechaCancelacion" Display="Dynamic" ErrorMessage="La fecha de cancelación debe ser mayor o igual que la fecha de emisión."
                                            Operator="GreaterThanEqual" ToolTip="La fecha de cancelación debe ser mayor o igual que la fecha de emisión."
                                            Type="Date" ValidationGroup="NuevoDia" enabled="false">*</asp:CompareValidator>
                                        <asp:CompareValidator ID="txtbxFechaCancelacion_CV3" runat="server" ControlToCompare="txtbxFechaPagoCheque"
                                            ControlToValidate="txtbxFechaCancelacion" Display="Dynamic" ErrorMessage="La fecha de cancelación debe ser mayor o igual que la fecha de pago."
                                            Operator="GreaterThanEqual" ToolTip="La fecha de pago debe ser mayor o igual que la fecha de pago."
                                            Type="Date" ValidationGroup="NuevoDia" enabled="false">*</asp:CompareValidator>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblObservs" runat="server" CssClass="pLabel" Text="Observaciones:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxObservs" runat="server" CssClass="textEntry"></asp:TextBox>
                                    </p>
                                </div>
                            </fieldset>
                        </div>
                        <div id="divBotones2">
                            <p class="submitButton">
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                                    ToolTip="Guardar los datos capturados." ValidationGroup="NuevoDia" />
                                <ajaxToolkit:ConfirmButtonExtender ID="btnGuardar_CBE" runat="server" 
                                    ConfirmText="¿Datos correctos?" Enabled="True" TargetControlID="btnGuardar">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </p>
                        </div>
                    </asp:Panel>
                </asp:View>
                <asp:View ID="viewErrores" runat="server">
                    <uc3:wucMuestraErrores ID="wucMuestraErrores" runat="server" />
                    <div id="divBotones3">
                        <p class="submitButton">
                            <asp:Button ID="btnContinuar" runat="server" Text="Regresar a pantalla de captura"
                                ToolTip="" />
                            <asp:Button ID="btnContinuar0" runat="server" Text="Regresar a pantalla de consulta"
                                ToolTip="" />
                        </p>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
