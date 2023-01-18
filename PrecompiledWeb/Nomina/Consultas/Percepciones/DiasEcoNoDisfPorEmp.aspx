<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="DiasEcoNoDisfPorEmp, App_Web_nszpy5ff" title="COBAEV - Nómina - Días Económicos No Disfrutados" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="text-align: left; width: 100%;" colspan="2">
                <h2>
                    Sistema de nómina: empleados, historia de Solicitudes/pagos de Días Económicos No
                    Disfrutados</h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdPnlMain" runat="server">
        <ContentTemplate>
            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewHistoria" runat="server">
                    <asp:Panel ID="pnlQuincenas" runat="server" DefaultButton="btnConsultarEmps" Font-Names="Verdana"
                        Font-Size="X-Small" GroupingText="Seleccione año para consulta" HorizontalAlign="Left">
                        <p>
                            <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <asp:Button ID="btnConsultarEmps" runat="server" SkinID="SkinBoton" Text="Consultar"
                                OnClick="btnConsultarEmps_Click" ToolTip="Consultar solicitudes/pagos en el año seleccionado." />
                        </p>
                    </asp:Panel>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEClave181" runat="Server" TextLabelID="Label1"
                        TargetControlID="ContentPanelClave181" SuppressPostBack="true" ImageControlID="Image1"
                        ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ExpandControlID="TitlePanelClave181" CollapsedText="(Mostrar detalles...)"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" Collapsed="False" CollapseControlID="TitlePanelClave181">
                    </ajaxToolkit:CollapsiblePanelExtender>
                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEClave181_2" runat="Server" TextLabelID="lblClave181_2"
                        TargetControlID="ContentPanelClave181_2" SuppressPostBack="true" ImageControlID="imgClave181_2"
                        ExpandedText="(Ocultar detalles...)" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                        ExpandControlID="TitlePanelClave181_2" CollapsedText="(Mostrar detalles...)"
                        CollapsedImage="~/Imagenes/expand_blue.jpg" Collapsed="False" CollapseControlID="TitlePanelClave181_2">
                    </ajaxToolkit:CollapsiblePanelExtender>
                    <asp:Panel ID="TitlePanelClave181" runat="server" Width="100%" BorderWidth="1px"
                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader" 
                        HorizontalAlign="Left">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                        &nbsp;Solicitudes de pago de días económicos no disfrutados
                        <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                    </asp:Panel>
                    <asp:Panel ID="ContentPanelClave181" runat="server" Width="100%" CssClass="collapsePanel">
                        <asp:GridView ID="gvDiasEcoNoDisf" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información."
                            SkinID="SkinGridView" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="PagoSolicitado" HeaderText="Pago solicitado">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Número de empleado" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("NumEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RFC" Visible="False">
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
                                <asp:TemplateField HeaderText="Apellido paterno" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApePat" runat="server" Text='<%# Bind("ApePatEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido materno" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApeMat" runat="server" Text='<%# Bind("ApeMatEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NomEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="FechaRegistro" DataFormatString="{0:d}" 
                                    HeaderText="Fecha de solicitud">
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
                    <asp:Panel ID="TitlePanelClave181_2" runat="server" Width="100%" BorderWidth="1px"
                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader" 
                        HorizontalAlign="Left">
                        <asp:Image ID="imgClave181_2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                        &nbsp;Pagos recibidos de días económicos no disfrutados
                        <asp:Label ID="lblClave181_2" runat="server">(Mostrar detalles...)</asp:Label>
                    </asp:Panel>
                    <asp:Panel ID="ContentPanelClave181_2" runat="server" Width="100%" CssClass="collapsePanel">
                        <asp:GridView ID="gvDiasEcoNoDisf_2" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información."
                            SkinID="SkinGridView" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="Importe" DataFormatString="{0:c}" 
                                    HeaderText="Importe">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdQuincenaAplicacion" HeaderText="IdQuincenaAplicacion" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Quincena" HeaderText="Pago recibido en Quincena">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaDePago" DataFormatString="{0:d}" 
                                    HeaderText="Fecha de pago">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FormaDePago" HeaderText="Forma de pago">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones sobre el pago">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataRowStyle Font-Italic="True" />
                        </asp:GridView>
                    </asp:Panel>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
