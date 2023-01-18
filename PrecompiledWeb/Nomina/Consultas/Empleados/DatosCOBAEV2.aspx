<%@ page enableeventvalidation="false" language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Empleados_DatosCOBAEV2, App_Web_00vntztu" title="COBAEV - Nómina - Datos laborales de los empleados" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucSearchEmps" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Información laboral)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <uc1:wucSearchEmps ID="wucSearchEmps1" runat="server" EnableViewState="true" />
                                    </td>
                                    <td style="vertical-align: top; text-align: right">
                                        &nbsp;<asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" Visible="False" /><br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlGral" runat="server">
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEDatosLab" runat="Server" SuppressPostBack="true"
                                            CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ImageControlID="Image1" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                            TextLabelID="Label1" Collapsed="False" CollapseControlID="TitlePanelDatosLab"
                                            ExpandControlID="TitlePanelDatosLab" TargetControlID="ContentPanelDatosLab">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEAntiguedad" runat="server" SuppressPostBack="true"
                                            CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ImageControlID="Image5" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                            TextLabelID="Label5" Collapsed="False" CollapseControlID="TitlePanelAntiguedad"
                                            ExpandControlID="TitlePanelAntiguedad" TargetControlID="ContentPanelAntiguedad">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPESegSoc" runat="server" SuppressPostBack="true"
                                            CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ImageControlID="ImgSegSoc" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                            TextLabelID="LblSegSoc" Collapsed="False" CollapseControlID="TitlePanelSegSoc"
                                            ExpandControlID="TitlePanelSegSoc" TargetControlID="ContentPanelSegSoc">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEPagomatico" runat="server" SuppressPostBack="true"
                                            CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ImageControlID="ImgPagomatico" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                            TextLabelID="LblPagomatico" Collapsed="False" CollapseControlID="TitlePanelPAgomatico"
                                            ExpandControlID="TitlePanelPagomatico" TargetControlID="ContentPanelPagomatico">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                            <tbody>
                                                <tr>
                                                    <td style="vertical-align: top; text-align: left" colspan="2">
                                                        <asp:Label ID="lblEmpInf" runat="server" SkinID="SkinLblDatos" Font-Underline="True"
                                                            Font-Strikeout="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelDatosLab" runat="server" Width="100%" BorderWidth="1px"
                                                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                            Datos laborales
                                                            <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="ContentPanelDatosLab" runat="server" Width="100%" HorizontalAlign="Left" CssClass="collapsePanel">
                                                            <asp:DetailsView ID="dvDatosLab" runat="server"  Width="50%" SkinID="SkinDetailsView" EmptyDataText="Sin información de datos laborales" 
                                                                AutoGenerateRows="False">
                                                                <FieldHeaderStyle Width="65%" />
                                                                <Fields>
                                                                    <asp:BoundField DataField="Nombramiento actual o más reciente" HeaderText="Nombramiento actual o más reciente">
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Adhesión sindical actual o más reciente" HeaderText="Adhesión sindical actual o más reciente">
                                                                        <HeaderStyle Wrap="True" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Empleado de BASE" 
                                                                        HeaderText="Empleado de BASE" >
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Adhesión sindical BASE" HeaderText="Adhesión sindical BASE">
                                                                        <HeaderStyle Wrap="False" />
                                                                     <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Comentarios" 
                                                                        HeaderText="Comentarios" >
                                                                    <HeaderStyle Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                </Fields>
                                                            </asp:DetailsView>
                                                        </asp:Panel>
                                                    </td>
                                                 </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelAntiguedad" runat="server" BorderColor="White" 
                                                            BorderStyle="Solid" BorderWidth="1px" CssClass="collapsePanelHeader" 
                                                            Width="100%">
                                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                            Antigüedad
                                                            <asp:Label ID="Label5" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="ContentPanelAntiguedad" runat="server" CssClass="collapsePanel" 
                                                            Width="100%" HorizontalAlign="Left">
                                                            <asp:DetailsView ID="dvAntiguedad" runat="server" AutoGenerateRows="False" 
                                                                EmptyDataText="Sin información de antigüedad" SkinID="SkinDetailsView" 
                                                                Width="50%">
                                                                <FieldHeaderStyle Width="65%" />
                                                                <Fields>
                                                                    <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="FchIngCOBAEV" DataFormatString="{0:d}" 
                                                                        HeaderText="Fecha de ingreso al COBAEV">
                                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="false"/>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="QnaIngCOBAEV" 
                                                                        HeaderText="Quincena de ingreso al COBAEV">
                                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="AniosAnt" HeaderText="Año(s)">
                                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false"  />
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="MesesAnt" HeaderText="Mes(es)">
                                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false"  />
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DiasAnt" HeaderText="Día(s)">
                                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false"  />
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="QuincenaCalculo" HeaderText="Última actualización">
                                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                                    </asp:BoundField>
                                                                    <asp:CheckBoxField DataField="CobraPrimaAnt" 
                                                                        HeaderText="Cobra prima de antigüedad">
                                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="false" />
                                                                    </asp:CheckBoxField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbModifAnt" runat="server">Modificar</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Fields>
                                                            </asp:DetailsView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelSegSoc" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                            BorderColor="White" CssClass="collapsePanelHeader">
                                                            <asp:Image ID="ImgSegSoc" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                            Seguridad social
                                                            <asp:Label ID="LblSegSoc" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="ContentPanelSegSoc" runat="server" Width="100%" CssClass="collapsePanel"
                                                            HorizontalAlign="Left">
                                                            <asp:DetailsView ID="dvSegSoc" runat="server" SkinID="SkinDetailsView"
                                                                EmptyDataText="Sin información de seguridad social" AutoGenerateRows="False"
                                                                OnDataBound="dvSegSoc_DataBound" Width="50%">
                                                                <FieldHeaderStyle Width="65%" />
                                                                <Fields>
                                                                    <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="NSS" HeaderText="N&#250;mero de seguridad social" >
                                                                    <HeaderStyle Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="R&#233;gimen pensionario">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRegimenISSSTE" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("RegimenISSSTE") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbModifSegSoc" runat="server">Modificar</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Fields>
                                                            </asp:DetailsView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelPagomatico" runat="server" Width="100%" BorderWidth="1px"
                                                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                            <asp:Image ID="ImgPagomatico" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                                                            </asp:Image>
                                                            Forma de pago al empleado
                                                            <asp:Label ID="LblPagomatico" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="ContentPanelPagomatico" runat="server" Width="100%" CssClass="collapsePanel"
                                                             HorizontalAlign="Left">
                                                            <asp:DetailsView ID="dvPagomatico" runat="server" SkinID="SkinDetailsView"
                                                                Height="100%" EmptyDataText="Sin información de pagomático" AutoGenerateRows="False"
                                                                OnDataBound="dvPagomatico_DataBound" Width="50%">
                                                                <FieldHeaderStyle Width="65%" />
                                                                <Fields>
                                                                    <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="NombreCortoBanco" 
                                                                        HeaderText="Banco para depósito" >
                                                                    <HeaderStyle Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="CuentaBancaria" HeaderText="Cuenta bancaria" >
                                                                    <HeaderStyle Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:CheckBoxField DataField="IncluirEnPagomatico" HeaderText="Pagar mediante depósito">
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                                                    </asp:CheckBoxField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbModifPagomatico" runat="server">Modificar</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Fields>
                                                            </asp:DetailsView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="wucSearchEmps1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
