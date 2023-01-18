<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="BuscarBeneficiarios.aspx.vb" Inherits="PenAlimBuscarBeneficiarios"
    Title="COBAEV - Nómina - Pensión alimenticia, búsqueda de beneficiarios" StylesheetTheme="SkinFile" %>

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
                            Sistema de nómina: Pensión Alimenticia (Búsqueda de beneficiarios)
                        </h2>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlBusquedaDePersonas" runat="server" GroupingText="Pensión Alimenticia, búsqueda de beneficiarios"
                Width="100%" HorizontalAlign="Left" DefaultButton="btnbuscar">
                <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Buscar beneficiarios por:"></asp:Label><br />
                <asp:DropDownList ID="ddlTipoBusqueda" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                    <asp:ListItem Value="0" Enabled="False">N&#250;mero de empleado</asp:ListItem>
                    <asp:ListItem Value="1" Enabled="False">R.F.C.</asp:ListItem>
                    <asp:ListItem Value="2">Nombre</asp:ListItem>
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
                    SkinID="SkinLblDatos"></asp:Label><asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False"
                        CaptionAlign="Left" EmptyDataText="No existen beneficiarios de pensión alimenticia bajo ese criterio de búsqueda o no tiene permisos de visualización sobre ellos."
                        Font-Names="Verdana" Font-Size="X-Small" PageSize="20" SkinID="SkinGridView">
                        <Columns>
                            <asp:TemplateField HeaderText="Apellido paterno (Beneficiario)">
                                <ItemTemplate>
                                    <asp:Label ID="lblApePatBPA" runat="server" Text='<%# Bind("ApePatBPA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Apellido materno (Beneficiario)">
                                <ItemTemplate>
                                    <asp:Label ID="lblApeMatBPA" runat="server" Text='<%# Bind("ApeMatBPA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre (Beneficiario)">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombreBPA" runat="server" Text='<%# Bind("NombreBPA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RFC (Empleado)">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnRFCEmp" runat="server" CommandName="CmdRFCEmp" Text='<%# databinder.eval(container, "dataitem.RFCEmp") %>'
                                        ToolTip="Seleccionar el empleado para consultas"></asp:LinkButton>
                                    <ajaxToolkit:ConfirmButtonExtender ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                        TargetControlID="lnkbtnRFCEmp">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CURP (Empleado)" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCURPEmp" runat="server" Text='<%# Bind("CURPEmp") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NumEmp (Empleado)" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("NumEmp") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Apellido paterno (Empleado)">
                                <ItemTemplate>
                                    <asp:Label ID="lblApePatEmp" runat="server" Text='<%# Bind("ApePatEmp") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Apellido materno (Empleado)">
                                <ItemTemplate>
                                    <asp:Label ID="lblApeMatEmp" runat="server" Text='<%# Bind("ApeMatEmp") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre (Empleado)">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombreEmp" runat="server" Text='<%# Bind("NomEmp") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="dgheader" />
                    </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
