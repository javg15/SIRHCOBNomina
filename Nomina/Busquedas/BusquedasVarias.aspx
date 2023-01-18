<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="BusquedasVarias.aspx.vb" Inherits="BusquedasVarias"
    Title="COBAEV - Nómina - Búsquedas varias" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPMain" runat="server" RenderMode="Block">
        <ContentTemplate>
            <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
            <table style="width: 100%; vertical-align: top;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: right">
                        <h2>
                            Sistema de nómina: Búsquedas varias
                        </h2>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlBusquedaDePersonas" runat="server" GroupingText="Búsqueda de información"
                Width="100%" HorizontalAlign="Left" DefaultButton="btnbuscar">
                <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Buscar información por:"></asp:Label><br />
                <asp:DropDownList ID="ddlTipoBusqueda" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;<br />
                <br />
                <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Escriba el texto a buscar:"></asp:Label><br />
                <asp:TextBox ID="txtStrABuscar" runat="server" SkinID="SkinTextBox" 
                    Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtStrABuscar" runat="server" ControlToValidate="txtStrABuscar"
                    Display="Dynamic" ErrorMessage="El nombre a buscar es obligatorio." SetFocusOnError="True"
                    ToolTip="El nombre a buscar es obligatorio.">*</asp:RequiredFieldValidator>
                <asp:Button ID="btnbuscar" runat="server" SkinID="SkinBoton" Text="Buscar" /><br />
                <br />
                <asp:Label ID="lbltipobusqueda" runat="server" Font-Strikeout="False" Font-Underline="True"
                    SkinID="SkinLblDatos"></asp:Label>
                <asp:GridView ID="gvResultadoBusqueda" 
                    runat="server" AutoGenerateColumns="False"
                        CaptionAlign="Left" EmptyDataText="No existen datos bajo ese criterio de búsqueda o no tiene permisos de visualización sobre ellos."
                        Font-Names="Verdana" Font-Size="X-Small" PageSize="20" 
                    SkinID="SkinGridView" Width="100%">
                        <Columns>
                             <asp:TemplateField HeaderText="R.F.C.">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnRFCEmp" runat="server" CommandName="CmdRFCEmp" Text='<%# databinder.eval(container, "dataitem.RFCEmp") %>'
                                        ToolTip="Seleccionar el empleado para consultas"></asp:LinkButton>
                                    <ajaxToolkit:ConfirmButtonExtender ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                        TargetControlID="lnkbtnRFCEmp">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="C.U.R.P." Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCURPEmp" runat="server" Text='<%# Bind("CURPEmp") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Num. Emp." Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("NumEmp") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
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
                                    <asp:Label ID="lblNombreEmp" runat="server" Text='<%# Bind("NomEmp") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Banco">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombreCortoBanco" runat="server" Text='<%# Bind("NombreCortoBanco") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cuenta bancaria">
                                <ItemTemplate>
                                    <asp:Label ID="lblCuentaBancaria" runat="server" Text='<%# Bind("CuentaBancaria") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Forma de cobro">
                                <ItemTemplate>
                                    <asp:Label ID="lblFormaDeCobro" runat="server" Text='<%# Bind("FormaDeCobro") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Número de recibo">
                                <ItemTemplate>
                                    <asp:Label ID="lblNumRecibo" runat="server" Text='<%# Bind("NumRecibo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Información encontrada en">
                                <ItemTemplate>
                                    <asp:Label ID="lblTipoDeInf" runat="server" Text='<%# Bind("TipoDeInf") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Utilizada por última vez">
                                <ItemTemplate>
                                    <asp:Label ID="lblUltQnaUtilizada" runat="server" Text='<%# Bind("UltVezUtilizada") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Estatus del recibo fuera de nómina">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescEstatusRecibo" runat="server" Text='<%# Bind("DescEstatusRecibo") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="dgheader" />
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
