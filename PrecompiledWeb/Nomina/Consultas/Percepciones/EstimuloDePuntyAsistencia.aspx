<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Percepciones_EstimuloDePuntyAsistencia, App_Web_nszpy5ff" title="COBAEV - Nómina - Estímulos de puntualidad y asistencia" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
    <tr>
        <td style="text-align: left; width: 100%;" colspan="2">
            <h2>
                Sistema de nómina: Solicitudes de Estímulo por puntualidad y asistencia
            </h2>
        </td>
    </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlQuincenas" runat="server" DefaultButton="btnConsultarEmps" Font-Names="Verdana"
                                        Font-Size="X-Small" 
                                        GroupingText="Consulta de solicitudes por Año-Parte">
                                        <br />
                                        <asp:Label ID="Label7" runat="server" SkinID="SkinLblNormal" 
                                            Text="Seleccione año"></asp:Label>
                                        &nbsp;<asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList" 
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlAños_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <br />
                                        <br />
                                        <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" 
                                            Text="Seleccione parte"></asp:Label>
                                        &nbsp;<asp:DropDownList ID="ddlPartes" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                        <asp:Button ID="btnConsultarEmps" runat="server" SkinID="SkinBoton" 
                                            Text="Consultar empleados" OnClick="btnConsultarEmps_Click" /><br />
                                        <br />
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEEstPuntYAsist" runat="Server" TextLabelID="Label1"
                                        TargetControlID="ContentPanelEstPuntYAsist" SuppressPostBack="true" ImageControlID="Image1"
                                        ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        ExpandControlID="TitlePanelEstPuntYAsist" CollapsedText="(Mostrar detalles...)"
                                        CollapsedImage="~/Imagenes/expand_blue.jpg" Collapsed="False" CollapseControlID="TitlePanelEstPuntYAsist">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                    <asp:ImageButton ID="ibExportarExcel1" runat="server" 
                                                        ImageUrl="~/Imagenes/ExcelExport.jpg" 
                                                        ToolTip="Generar archivo en Excel (XLSX)" />
                                                    <ajaxToolkit:ConfirmButtonExtender ID="ibExportarExcel1_ConfirmButtonExtender" 
                                                        runat="server" 
                                                        ConfirmText="¿Está seguro de haber seleccionado la información correctamente?" 
                                                        Enabled="True" TargetControlID="ibExportarExcel1">
                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="TitlePanelEstPuntYAsist" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        &nbsp;Solicitudes de Estímulos por Puntualidad y Asistencia
                                                        <asp:Label ID="Label1" runat="server">
        (Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:Panel ID="ContentPanelEstPuntYAsist" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:GridView ID="gvEstPuntYAsist" runat="server" Width="100%" SkinID="SkinGridView"
                                                            EmptyDataText="No existe información." AutoGenerateColumns="False">
                                                            <Columns>
                                                                <asp:BoundField DataField="Anio" HeaderText="Año">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Parte" HeaderText="Parte">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="N&#250;mero de empleado">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("NumEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="RFC">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbRFC" runat="server" CommandName="CmdRFC" Text='<%# Bind("RFCEmp") %>'></asp:LinkButton>
                                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                                                            TargetControlID="lbRFC">
                                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CURP">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCURP" runat="server" Text='<%# Bind("CURPEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Apellido paterno">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApePat" runat="server" Text='<%# Bind("ApePatEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Apellido materno">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApeMat" runat="server" Text='<%# Bind("ApeMatEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Nombre">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NomEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha de Registro" 
                                                                    DataFormatString="{0:d}">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Plantel" HeaderText="Plantel">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Eliminar" Visible="False">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibEliminar" runat="server" CommandName="CmdEliminar" ImageUrl="~/Imagenes/Eliminar.png" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataRowStyle Font-Italic="True" />
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                    <asp:ImageButton ID="ibExportarExcel2" runat="server" 
                                                        ImageUrl="~/Imagenes/ExcelExport.jpg" 
                                                        ToolTip="Generar archivo en Excel (XLSX)" />
                                                    <ajaxToolkit:ConfirmButtonExtender ID="ibExportarExcel_CBE" runat="server" 
                                                        ConfirmText="¿Está seguro de haber seleccionado la información correctamente?" 
                                                        Enabled="True" TargetControlID="ibExportarExcel2">
                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnConsultarEmps" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="gvEstPuntYAsist" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
