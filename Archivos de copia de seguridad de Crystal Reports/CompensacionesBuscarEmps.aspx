<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="CompensacionesBuscarEmps.aspx.vb" Inherits="CompensacionesBuscarEmps" Title="COBAEV - Nómina - Compensaciones (Nivel empleado)"
    StylesheetTheme="SkinFile" EnableEventValidation="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
            <table style="width: 100%;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: right">
                        <h2>
                            Sistema de nómina: Compensaciones mensuales (Nivel empleado)
                        </h2>
                    </td>
                </tr>
            </table>
            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
            <asp:MultiView ID="MVMain" runat="server">
                <asp:View ID="VABCCompen" runat="server">
                    <asp:Panel ID="pnl1" runat="server" GroupingText="" Visible="false" HorizontalAlign="Left">
                        <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" SkinID="SkinDropDownList">
                        </asp:DropDownList>
                        <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" Text="Consultar"
                            ToolTip="Consultar pagos mensuales recibidos por el empleado en el año seleccionado."
                            CausesValidation="False" />
                    </asp:Panel>
                    <asp:Panel ID="pnl2" runat="server" GroupingText="" Visible="false" HorizontalAlign="Left">
                        <div style="text-align: right">
                            <asp:LinkButton ID="lbAddCompen" runat="server" CausesValidation="False">Asignar compensación</asp:LinkButton>
                        </div>
                        <asp:GridView ID="gvHistoriaCompe" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen compensaciones para el empleado en el año indicado."
                            SkinID="SkinGridView" ShowFooter="True" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Año">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mes" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdMes" runat="server" Text='<%# Bind("IdMes") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="NombreMes" HeaderText="Mes">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Adic">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdicional" runat="server" Text='<%# Bind("Adicional") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo de pago">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdicionalDescripcion" runat="server" Text='<%# Bind("AdicionalDescripcion") %>'></asp:Label></ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo de pago" Visible="false">
                                    <FooterTemplate>
                                        Totales ==&gt;<br />
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblComentarios" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label></ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Importe Recibido">
                                    <FooterTemplate>
                                        <asp:Label ID="lblImporteTotal" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label></FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblImporte" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                    <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                    <FooterStyle Wrap="False" HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Importe P.A.">
                                    <FooterTemplate>
                                        <asp:Label ID="lblImporteTotalPA" runat="server" Text='<%# Bind("ImportePA", "{0:c}") %>'></asp:Label></FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblImportePA" runat="server" Text='<%# Bind("ImportePA", "{0:c}") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                    <FooterStyle Wrap="False" HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Importe Total">
                                    <FooterTemplate>
                                        <asp:Label ID="lblImporteTotalR" runat="server" Text='<%# Bind("ImporteTR", "{0:c}") %>'></asp:Label></FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblImporteTR" runat="server" Text='<%# Bind("ImporteTR", "{0:c}") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                    <FooterStyle Wrap="False" HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Meses amparados por pago">
                                    <FooterTemplate>
                                        <asp:Label ID="lblMesesQueAmparaPagoT" runat="server" Text='<%# Bind("MesesQueAmparaPago") %>'></asp:Label></FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMesesQueAmparaPago" runat="server" Text='<%# Bind("MesesQueAmparaPago") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    <FooterStyle Wrap="False" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FormaDePago" HeaderText="Forma de pago">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Banco" HeaderText="Banco">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CuentaBancaria" HeaderText="Cuenta bancaria">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Origen">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrigen" runat="server" Text='<%# Bind("TipoCompensacion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TipoDeNomina" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTipoDeNomina" runat="server" Text='<%# Bind("TipoDeNomina") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FechaDePago" HeaderText="Fecha de pago" DataFormatString="{0:d}">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="CEnter" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTieneObserv" runat="server" Text='<%# Bind("TieneObservacion") %>'
                                            ToolTip='<%# Bind("Observaciones") %>' SkinID="SkinLblMsjErrores"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PermiteCambios" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPermiteCambios" runat="server" Text='<%# Bind("PermiteCambios") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                            CausesValidation="false" ToolTip="Modificar la información del registro." OnClick="ibModificar_Click" /></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                            CausesValidation="false" ToolTip="Eliminar registro." 
                                            onclick="ibEliminar_Click" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="ibEliminar_CBE" runat="server" 
                                            ConfirmText="La opción seleccionada eliminará el registro de la Base de Datos Institucional, ¿Continuar?" Enabled="True" TargetControlID="ibEliminar">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Panel ID="pnl3" runat="server" GroupingText="Beneficiarios de pensión alimenticia asociados al empleado"
                            Visible="true">
                            <div style="text-align: right">
                                <asp:LinkButton ID="lbAddBPA" runat="server" CausesValidation="False">Nuevo beneficiario (Pensión alimenticia)</asp:LinkButton>
                            </div>
                            <asp:GridView ID="gvBPA" runat="server" AutoGenerateColumns="False" EmptyDataText="El empleado no tiene beneficiarios de pensión alimenticia registrados en el año seleccionado."
                                SkinID="SkinGridView" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Clave de cobro">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClaveCobro" runat="server" Text='<%# Bind("ClaveCobro") %>'></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Apellido paterno">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApePatBPA" runat="server" Text='<%# Bind("ApePatBPA") %>'></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Apellido materno">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApeMatBPA" runat="server" Text='<%# Bind("ApeMatBPA") %>'></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNombreBPA" runat="server" Text='<%# Bind("NombreBPA") %>'></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibDetalle" runat="server" CausesValidation="false" ImageUrl="~/Imagenes/Detalles.gif"
                                                ToolTip="Consultar detalle de pagos realizados al beneficiario durante el año seleccionado."
                                                OnClick="ibDetalle_Click" /></ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <asp:Panel ID="pnl4" runat="server" GroupingText="" Visible="false" HorizontalAlign="Left">
                            <div style="text-align: right">
                                <asp:LinkButton ID="lbAddCompenBPA" runat="server" CausesValidation="False">Asignar compensación (Pensión alimenticia)</asp:LinkButton>
                            </div>
                            <asp:GridView ID="gvHistoriaCompe2" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen compensaciones relacionadas con el beneficiario en el año indicado."
                                SkinID="SkinGridView" ShowFooter="True" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Año">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mes" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdMes" runat="server" Text='<%# Bind("IdMes") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NombreMes" HeaderText="Mes">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Adic">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdicional" runat="server" Text='<%# Bind("Adicional") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo de pago">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdicionalDescripcion" runat="server" Text='<%# Bind("AdicionalDescripcion") %>'></asp:Label></ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tipo de pago" Visible="false">
                                        <FooterTemplate>
                                            Total ==&gt;<br />
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblComentarios" runat="server" Text='<%# Bind("Comentarios") %>'></asp:Label></ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Importe">
                                        <FooterTemplate>
                                            <asp:Label ID="lblImporteTotal" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label></FooterTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblImporte" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                        <FooterStyle Wrap="False" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="Meses amparados por pago">
                                    <FooterTemplate>
                                        <asp:Label ID="lblMesesQueAmparaPagoT" runat="server" Text='<%# Bind("MesesQueAmparaPago") %>'></asp:Label></FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMesesQueAmparaPago" runat="server" Text='<%# Bind("MesesQueAmparaPago") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    <FooterStyle Wrap="False" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                    <asp:BoundField DataField="FormaDePago" HeaderText="Forma de pago">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Banco" HeaderText="Banco">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CuentaBancaria" HeaderText="Cuenta bancaria">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                <asp:TemplateField HeaderText="Origen">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrigen" runat="server" Text='<%# Bind("TipoCompensacion") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TipoDeNomina" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTipoDeNomina" runat="server" Text='<%# Bind("TipoDeNomina") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                    <asp:BoundField DataField="FechaDePago" HeaderText="Fecha de pago" DataFormatString="{0:d}">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="CEnter" />
                                    </asp:BoundField>
                               <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTieneObserv" runat="server" Text='<%# Bind("TieneObservacion") %>'
                                            ToolTip='<%# Bind("Observaciones") %>' SkinID="SkinLblMsjErrores"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PermiteCambios" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPermiteCambios" runat="server" Text='<%# Bind("PermiteCambios") %>'></asp:Label></ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                            CausesValidation="false" ToolTip="Modificar la información del registro." 
                                            onclick="ibModificar_Click1"  /></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                            CausesValidation="false" ToolTip="Eliminar registro." onclick="ibEliminar_Click1" 
                                           />
                                        <ajaxToolkit:ConfirmButtonExtender ID="ibEliminar_CBE" runat="server" 
                                            ConfirmText="La opción seleccionada eliminará el registro de la Base de Datos Institucional, ¿Continuar?" Enabled="True" TargetControlID="ibEliminar">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </asp:Panel>
                </asp:View>
                <asp:View ID="VCCompen" runat="server">
                    <asp:Panel ID="pnl5" runat="server" GroupingText="" HorizontalAlign="Left" Enabled="false">
                        <div class="accountInfo">
                            <fieldset id="fsCaptura">
                                <!--<legend>
                                    <asp:Label ID="lblEmpInf2" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                                </legend>-->
                                <div class="panelIzquierda">
                                    <p class="pLabel">
                                        <asp:Label ID="lblTipoOperacion" runat="server" CssClass="pLabel" Text="Tipo de operación:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxTipoOperacion" runat="server" MaxLength="20" CssClass="textEntry"
                                            Enabled="false"></asp:TextBox>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblAdicional" runat="server" CssClass="pLabel" Text="Número de nómina (Adicional):"></asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:DropDownList ID="ddlNumeroDeNominas" runat="server" CssClass="textEntry" 
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblImporteCompen" runat="server" CssClass="pLabel" Text="Importe de la compensación:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxImporte" runat="server" MaxLength="10" CssClass="textEntry"></asp:TextBox>
                                        <asp:CompareValidator ID="txtbxImporte_CV" runat="server" ControlToValidate="txtbxImporte"
                                            Display="Dynamic" ErrorMessage="Importe incorrecto." Operator="DataTypeCheck"
                                            Type="Currency" ToolTip="Importe incorrecto." Text="*"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="txtbxImporte_RFV" runat="server" ControlToValidate="txtbxImporte"
                                            Display="Dynamic" Text="*" ToolTip="El importe de la compensación es obligatorio."
                                            ErrorMessage="El importe de la compensación es obligatorio.">
                                        </asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="txtbxImporte_CV2" runat="server" ControlToValidate="txtbxImporte"
                                            Display="Dynamic" ErrorMessage="Importe incorrecto. No puede ser cero o menor que cero."
                                            Operator="GreaterThan" ToolTip="Importe incorrecto. No puede ser cero o menor que cero."
                                            Type="Currency" ValueToCompare="0" Text="*"></asp:CompareValidator>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblClaveCobro" runat="server" CssClass="pLabel" Text="Clave de cobro:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxClaveCobro" runat="server" MaxLength="8" CssClass="textEntry"
                                            Enabled="false"></asp:TextBox>
                                    </p>
                                    <p class="pLabel">
                                    </p>
                                    <p class="pTextBox">
                                        <asp:CheckBox runat="server" ID="ChBxPagarConCheque" Text="Pagar mediante cheque"
                                            AutoPostBack="True" />
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblBancos" runat="server" CssClass="pLabel" Text="Banco para la transferencia bancaria:"></asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:DropDownList ID="ddlBancos" runat="server" CssClass="textEntry" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ddlBancos_RFV" runat="server" ControlToValidate="ddlBancos"
                                            Display="Dynamic" ErrorMessage="Seleccionar el banco para la transferencia bancaria es obligatorio."
                                            InitialValue="3" ToolTip="Seleccionar el banco para la transferencia bancaria es obligatorio."
                                            Text="*" Enabled="false">
                                        </asp:RequiredFieldValidator>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblCtaBanc" runat="server" CssClass="pLabel" Text="Cuenta bancaria:"></asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxCtaBancaria" runat="server" MaxLength="18" CssClass="textEntry"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="txtbxCtaBancaria_REV" runat="server" ValidationExpression=""
                                            ControlToValidate="txtbxCtaBancaria" Display="Dynamic" ErrorMessage="*" ToolTip="">
                                        </asp:RegularExpressionValidator>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtbxCtaBancaria_FTE" runat="server" FilterType="Numbers"
                                            TargetControlID="txtbxCtaBancaria" ValidChars="">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="txtbxCtaBancaria_RFV" runat="server" ControlToValidate="txtbxCtaBancaria"
                                            Display="Dynamic" ErrorMessage="La captura de la cuenta para la transferencia bancaria es obligatoria."
                                            ToolTip="La captura de la cuenta para la transferencia bancaria es obligatoria."
                                            Text="*">
                                        </asp:RequiredFieldValidator>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblMesesAmparados" runat="server" CssClass="pLabel" Text="Meses amparados con el pago:"></asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:DropDownList ID="ddlMesesAmp" runat="server" CssClass="textEntry">
                                        </asp:DropDownList>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblObservs" runat="server" CssClass="pLabel" Text="Observaciones:"></asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxObservs" runat="server" Columns="100" MaxLength="100" CssClass="textEntry"></asp:TextBox>
                                    </p>
                                </div>
                            </fieldset>
                        </div>
                        <div id="divBotones">
                            <p class="submitButton">
                                <asp:Button ID="btnGuardarModif" runat="server" SkinID="SkinBoton" Text="Guardar"
                                    ToolTip="Guardar cambios y regresar a la pantalla de consulta de compensaciones."
                                    CausesValidation="True" />
                                <ajaxToolkit:ConfirmButtonExtender ID="btnGuardarModif_CBE" runat="server" ConfirmText="La opción seleccionada realizará cambios en la Base de Datos Institucional, ¿Continuar?"
                                    Enabled="True" TargetControlID="btnGuardarModif">
                                </ajaxToolkit:ConfirmButtonExtender>
                                <asp:Button ID="btnCancelar1" runat="server" CausesValidation="False" SkinID="SkinBoton"
                                    Text="Cancelar" ToolTip="Regresar a la pantalla de consulta de compensaciones." />
                            </p>
                        </div>
                    </asp:Panel>
                </asp:View>
                <asp:View ID="VCBPA" runat="server">
                    <asp:Panel ID="pnl6" runat="server" GroupingText="" HorizontalAlign="Left" Enabled="false">
                        <div class="accountInfo">
                            <fieldset id="fsCapturaBPA">
                                <!--<legend>
                                    <asp:Label ID="lblEmpInf2BPA" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                                </legend>-->
                                <div class="panelIzquierda">
                                    <p class="pLabel">
                                        <asp:Label ID="lblTipoOperacionBPA" runat="server" CssClass="pLabel" Text="Tipo de operación:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxTipoOperacionBPA" runat="server" MaxLength="20" CssClass="textEntry"
                                            Enabled="false"></asp:TextBox>
                                    </p>
                                   <p class="pLabel">
                                        <asp:Label ID="lblApePatBPA" runat="server" CssClass="pLabel" Text="Apellido paterno:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxApePatBPA" runat="server" CssClass="textEntry"
                                            Enabled="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="txtbxApePatBPA_RFV" runat="server" ControlToValidate="txtbxApePatBPA"
                                            Display="Dynamic" Text="*"
                                            ToolTip="El apellido paterno del beneficiario es obligatorio."
                                            ErrorMessage="El apellido paterno del beneficiario es obligatorio." Enabled="True"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtbxApePatBPA_FTBE" runat="server" ValidChars=" ñÑáÁéÉíÍóÓúÚ"
                                            FilterType="Custom, UppercaseLetters, LowercaseLetters" TargetControlID="txtbxApePatBPA">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <ajaxToolkit:AutoCompleteExtender ID="txtbxApePatBPA_ACE" runat="server" EnableCaching="true"
                                            MinimumPrefixLength="2" ServiceMethod="BuscarApellidos" ServicePath="~/WSBusquedas.asmx"
                                            TargetControlID="txtbxApePatBPA" FirstRowSelected="True">
                                        </ajaxToolkit:AutoCompleteExtender>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblApeMatBPA" runat="server" CssClass="pLabel" Text="Apellido materno:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxApeMatBPA" runat="server" CssClass="textEntry"
                                            Enabled="true"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtbxApeMatBPA_FTBE" runat="server" ValidChars=" ñÑáÁéÉíÍóÓúÚ"
                                            FilterType="Custom, UppercaseLetters, LowercaseLetters" TargetControlID="txtbxApeMatBPA">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <ajaxToolkit:AutoCompleteExtender ID="txtbxApeMatBPA_ACE" runat="server" EnableCaching="true"
                                            MinimumPrefixLength="2" ServiceMethod="BuscarApellidos" ServicePath="~/WSBusquedas.asmx"
                                            TargetControlID="txtbxApeMatBPA" FirstRowSelected="True">
                                        </ajaxToolkit:AutoCompleteExtender>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblNombreBPA" runat="server" CssClass="pLabel" Text="Nombre:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxNombreBPA" runat="server" CssClass="textEntry" Enabled="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="txtbxNombreBPA_RFV" runat="server" ControlToValidate="txtbxNombreBPA"
                                            Display="Dynamic" Text="*"
                                            ToolTip="El nombre del beneficiario es obligatorio."
                                            ErrorMessage="El nombre del beneficiario es obligatorio." Enabled="True"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtbxNombreBPA_FTBE" runat="server" ValidChars=" ñÑáÁéÉíÍóÓúÚ"
                                            FilterType="Custom, UppercaseLetters, LowercaseLetters" TargetControlID="txtbxNombreBPA">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <ajaxToolkit:AutoCompleteExtender ID="txtbxNombreBPA_ACE" runat="server" EnableCaching="true"
                                            MinimumPrefixLength="2" ServiceMethod="BuscarNombres" ServicePath="~/WSBusquedas.asmx"
                                            TargetControlID="txtbxNombreBPA" FirstRowSelected="True">
                                        </ajaxToolkit:AutoCompleteExtender>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblAdicionalBPA" runat="server" CssClass="pLabel" Text="Número de nómina (Adicional):"></asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:DropDownList ID="ddlNumeroDeNominasBPA" runat="server" CssClass="textEntry" 
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblImportePA" runat="server" CssClass="pLabel" Text="Importe de la pensión alimenticia:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxImportePA" runat="server" MaxLength="10" CssClass="textEntry"></asp:TextBox>
                                        <asp:CompareValidator ID="txtbxImporteBPA_CV" runat="server" ControlToValidate="txtbxImportePA"
                                            Display="Dynamic" ErrorMessage="Importe incorrecto." Operator="DataTypeCheck"
                                            Type="Currency" ToolTip="Importe incorrecto." Text="*"></asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="txtbxImporteBPA_RFV" runat="server" ControlToValidate="txtbxImportePA"
                                            Display="Dynamic" Text="*" ToolTip="El importe de la pensión alimenticia es obligatorio."
                                            ErrorMessage="El importe de la pensión alimenticia es obligatorio.">
                                        </asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="txtbxImporteBPA_CV2" runat="server" ControlToValidate="txtbxImportePA"
                                            Display="Dynamic" ErrorMessage="Importe incorrecto. No puede ser cero o menor que cero."
                                            Operator="GreaterThan" ToolTip="Importe incorrecto. No puede ser cero o menor que cero."
                                            Type="Currency" ValueToCompare="0" Text="*"></asp:CompareValidator>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblClaveCobroBPA" runat="server" CssClass="pLabel" Text="Clave de cobro:">
                                        </asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxClaveCobroBPA" runat="server" MaxLength="8" CssClass="textEntry"
                                            Enabled="false"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtbxClaveCobroBPA_FTBE" runat="server" FilterType="Numbers"
                                            TargetControlID="txtbxClaveCobroBPA" ValidChars="">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="txtbxClaveCobroBPA_RFV" runat="server" ControlToValidate="txtbxClaveCobroBPA"
                                            Display="Dynamic" ErrorMessage="La captura de la clave de cobro es obligatoria."
                                            ToolTip="La captura de la clave de cobro es obligatoria."
                                            Text="*">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="txtbxClaveCobroBPAREV" runat="server" ControlToValidate="txtbxClaveCobroBPA"
                                            ErrorMessage="La clave de cobro debe estar conformado de 8 dígitos." 
                                             ToolTip="La clave de cobro debe estar conformado de 8 dígitos."  Display="Dynamic" 
                                            ValidationExpression="\d{8}">*</asp:RegularExpressionValidator>
                                    </p>
                                    <p class="pLabel">
                                    </p>
                                    <p class="pTextBox">
                                        <asp:CheckBox runat="server" ID="ChBxPagarConChequeBPA" Text="Pagar mediante cheque"
                                            AutoPostBack="True" />
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblBancosBPA" runat="server" CssClass="pLabel" Text="Banco para la transferencia bancaria:"></asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:DropDownList ID="ddlBancosBPA" runat="server" CssClass="textEntry" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ddlBancosBPA_RFV" runat="server" ControlToValidate="ddlBancosBPA"
                                            Display="Dynamic" ErrorMessage="Seleccionar el banco para la transferencia bancaria es obligatorio."
                                            InitialValue="3" ToolTip="Seleccionar el banco para la transferencia bancaria es obligatorio."
                                            Text="*" Enabled="false">
                                        </asp:RequiredFieldValidator>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblCtaBancBPA" runat="server" CssClass="pLabel" Text="Cuenta bancaria:"></asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxCtaBancariaBPA" runat="server" MaxLength="18" CssClass="textEntry"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="txtbxCtaBancariaBPA_REV" runat="server" ValidationExpression=""
                                            ControlToValidate="txtbxCtaBancariaBPA" Display="Dynamic" ErrorMessage="*" ToolTip="">
                                        </asp:RegularExpressionValidator>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="txtbxCtaBancariaBPA_FTE" runat="server" FilterType="Numbers"
                                            TargetControlID="txtbxCtaBancariaBPA" ValidChars="">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="txtbxCtaBancariaBPA_RFV" runat="server" ControlToValidate="txtbxCtaBancariaBPA"
                                            Display="Dynamic" ErrorMessage="La captura de la cuenta para la transferencia bancaria es obligatoria."
                                            ToolTip="La captura de la cuenta para la transferencia bancaria es obligatoria."
                                            Text="*">
                                        </asp:RequiredFieldValidator>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblMesesAmparadosBPA" runat="server" CssClass="pLabel" Text="Meses amparados con el pago:"></asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:DropDownList ID="ddlMesesAmpBPA" runat="server" CssClass="textEntry">
                                        </asp:DropDownList>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblObservsBPA" runat="server" CssClass="pLabel" Text="Observaciones:"></asp:Label>
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxObservsBPA" runat="server" Columns="100" MaxLength="100" CssClass="textEntry"></asp:TextBox>
                                    </p>
                                </div>
                            </fieldset>
                        </div>
                        <div id="divBotonesBPA">
                            <p class="submitButton">
                                <asp:Button ID="btnGuardarModifBPA" runat="server" SkinID="SkinBoton" Text="Guardar"
                                    ToolTip="Guardar cambios y regresar a la pantalla de consulta de compensaciones."
                                    CausesValidation="True" />
                                <ajaxToolkit:ConfirmButtonExtender ID="btnGuardarModifBPA_CBE" runat="server" ConfirmText="La opción seleccionada realizará cambios en la Base de Datos Institucional, ¿Continuar?"
                                    Enabled="True" TargetControlID="btnGuardarModifBPA">
                                </ajaxToolkit:ConfirmButtonExtender>
                                <asp:Button ID="btnCancelarBPA" runat="server" CausesValidation="False" SkinID="SkinBoton"
                                    Text="Cancelar" ToolTip="Regresar a la pantalla de consulta de compensaciones." />
                            </p>
                        </div>
                    </asp:Panel>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
