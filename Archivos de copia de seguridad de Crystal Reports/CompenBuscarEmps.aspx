<%@ Page Language="VB" enableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master" 
AutoEventWireup="false" CodeFile="CompenBuscarEmps.aspx.vb" Inherits="CompenBuscarEmps" 
title="COBAEV - Nómina - Compensaciones, Búsqueda de empleados" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Compensaciones (Búsqueda de empleados)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Label ID="Label4" runat="server" SkinID="SkinLblHeader" 
                    Text="Compensaciones, búsqueda de empleados"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlBusquedaDePersonas" runat="server" DefaultButton="btnBuscar">
                            <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Buscar empleados por:"></asp:Label><br />
                            <asp:DropDownList ID="ddlTipoBusqueda" runat="server" SkinID="SkinDropDownList" 
                                AutoPostBack="True">
                                <asp:ListItem Value="0">N&#250;mero de empleado</asp:ListItem>
                                <asp:ListItem Value="1">R.F.C.</asp:ListItem>
                                <asp:ListItem Value="2">Nombre</asp:ListItem>
                            </asp:DropDownList>&nbsp;<br />
                            <br />
                            <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Escriba el texto a buscar:"></asp:Label><br />
                            <asp:TextBox ID="txtStrABuscar" runat="server" SkinID="SkinTextBox" Width="362px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtStrABuscar" runat="server" ControlToValidate="txtStrABuscar"
                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:Button ID="btnbuscar" runat="server" SkinID="SkinBoton" Text="Buscar" /><br />
                            <br />
                            <asp:Label ID="lbltipobusqueda" runat="server" Font-Strikeout="False" Font-Underline="True"
                                SkinID="SkinLblDatos"></asp:Label><asp:GridView ID="gvEmpleados" 
                                runat="server" AutoGenerateColumns="False"
                                    CaptionAlign="Left" 
                                EmptyDataText="No existen empleados con compensación bajo ese criterio de búsqueda." Font-Names="Verdana"
                                    Font-Size="X-Small" PageSize="20" SkinID="SkinGridView">
                                    <Columns>
                                        <asp:TemplateField HeaderText="RFC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRFC" runat="server" Text='<%# databinder.eval(container, "dataitem.rfc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CURP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCURP" runat="server" Text='<%# Bind("curp") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Apellido paterno">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApePat" runat="server" Text='<%# Bind("apellido_paterno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Apellido materno">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApeMat" runat="server" Text='<%# Bind("apellido_materno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="N&#250;mero de empleado">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("numemp") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Origen" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOrigen" runat="server" Text='<%# Bind("Origen") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle CssClass="dgheader" />
                                </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left;">
                <br />
                <asp:UpdatePanel ID="UPPlazas" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvAnios" runat="server" AutoGenerateColumns="False" 
                            SkinID="SkinGridView" 
                            Caption="Años en los que ha tenido compensación el empleado seleccionado" 
                            EmptyDataText="El empleado seleccionado nunca ha tenido compensación." 
                            Width="50%">
                            <Columns>
                                <asp:TemplateField HeaderText="Año">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibDetalle" runat="server" 
                                            ImageUrl="~/Imagenes/Detalles.gif" 
                                            ToolTip="Consultar detalle de pagos durante el año." 
                                        />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle Wrap="True" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvEmpleados" EventName="SelectedIndexChanged">
                        </asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="btnbuscar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

