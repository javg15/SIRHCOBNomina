<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="EjercFiscReportesConstDeSdo, App_Web_02f4ho4c" title="COBAEV - Nómina - Ejercicios Fiscales, Reportes" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Reportes (Relacionados con la declaración anual)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar"
                            Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione ejercicio">
                    <br />
                            <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlAños_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Button ID="btnConsultar" runat="server" 
                                SkinID="SkinBoton" Text="Consultar" ToolTip="Consultar el acumulado anual de subsidio para el empleo del empleado seleccionado" Visible="False" /><br />
                </asp:Panel>
                        <br />
                        <asp:Panel ID="pnlMeses" runat="server" Font-Names="Verdana" 
                            Font-Size="X-Small" GroupingText="Seleccione mes">
                            <br />
                            <asp:DropDownList ID="ddlMeses" runat="server" AutoPostBack="True" 
                                SkinID="SkinDropDownList">
                            </asp:DropDownList>
                        </asp:Panel>
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlBusquedaDePersonas" runat="server" DefaultButton="btnBuscar" Enabled="False">
                            <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Buscar empleados por:"></asp:Label><br />
                            <asp:DropDownList ID="ddlTipoBusqueda" runat="server" SkinID="SkinDropDownList">
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
                                SkinID="SkinLblDatos"></asp:Label><asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False"
                                    CaptionAlign="Left" EmptyDataText="No hubo coincidencias" Font-Names="Verdana"
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
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle CssClass="dgheader" />
                                </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvReportes" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlA&#241;os" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <br />
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal">Seleccione reporte</asp:Label></td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvReportes" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvReportes_RowDataBound"
                                        OnSelectedIndexChanged="gvReportes_SelectedIndexChanged" SkinID="SkinGridViewEmpty">
                                        <Columns>
                                            <asp:TemplateField HeaderText="IdReporte" Visible="False">
                                                <EditItemTemplate>
                                                    &nbsp;
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdReporte" runat="server" Text='<%# Bind("IdReporte") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImplicaMeses" Visible="False">
                                                <EditItemTemplate>
                                                    &nbsp;
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImplicaMeses" runat="server" Text='<%# Bind("ImplicaMeses") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ExportarAExcel" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblExportarAExcel" runat="server" Text='<%# Bind("ExportarAExcel") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ExportarAPDF" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblExportarAPDF" runat="server" Text='<%# Bind("ExportarAPDF") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImplicaFondoPresup" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImplicaFondoPresup" runat="server" Text='<%# Bind("ImplicaFondoPresup") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImplicaQuincenas" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImplicaQuincenas" runat="server" Text='<%# Bind("ImplicaQuincenas") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImplicaPlantel" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImplicaPlantel" runat="server" Text='<%# Bind("ImplicaPlantel") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ImplicaRegPenISSSTE" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImplicaRegPenISSSTE" runat="server" Text='<%# Bind("ImplicaRegPenISSSTE") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DescParaUsuario" HeaderText="Reporte" />
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ibExportPDF" runat="server" ImageUrl="~/Imagenes/PDFExport.jpg"
                                        ToolTip="Mostrar reporte en PDF" />
                                    <asp:ImageButton ID="ibExportarExcel" runat="server" ImageUrl="~/Imagenes/ExcelExport.jpg"
                                        ToolTip="Mostrar reporte en Excel" /></td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvReportes" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlA&#241;os" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="gvEmpleados" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlMeses" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                &nbsp;<br />
            </td>
        </tr>
    </table>
</asp:Content>

