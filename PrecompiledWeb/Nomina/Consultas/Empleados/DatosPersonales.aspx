<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Empleados_DatosPersonales, App_Web_00vntztu" title="COBAEV - Nómina - Datos personales de los empleados" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Información personal)
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
                                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                                    </td>
                                    <td style="vertical-align: top; text-align: right">
                                        &nbsp;<asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" />
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
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEDatosPers" runat="Server" TargetControlID="ContentPanelDatosPers"
                                        ExpandControlID="TitlePanelDatosPers" CollapseControlID="TitlePanelDatosPers"
                                        Collapsed="False" TextLabelID="Label1" ExpandedText="(Ocultar detalles...)" CollapsedText="(Mostrar detalles...)"
                                        ImageControlID="Image1" ExpandedImage="~/Imagenes/collapse_blue.jpg" CollapsedImage="~/Imagenes/expand_blue.jpg"
                                        SuppressPostBack="true">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEDatosDom" runat="Server" TargetControlID="ContentPanelDatosDom"
                                        ExpandControlID="TitlePanelDatosDom" CollapseControlID="TitlePanelDatosDom" Collapsed="False"
                                        TextLabelID="Label2" ExpandedText="(Ocultar detalles...)" CollapsedText="(Mostrar detalles...)"
                                        ImageControlID="Image2" ExpandedImage="~/Imagenes/collapse_blue.jpg" CollapsedImage="~/Imagenes/expand_blue.jpg"
                                        SuppressPostBack="true">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server" TargetControlID="ContentPanelDatosDomFis"
                                        ExpandControlID="TitlePanelDatosDomFis" CollapseControlID="TitlePanelDatosDomFis" Collapsed="False"
                                        TextLabelID="Label3" ExpandedText="(Ocultar detalles...)" CollapsedText="(Mostrar detalles...)"
                                        ImageControlID="Image3" ExpandedImage="~/Imagenes/collapse_blue.jpg" CollapsedImage="~/Imagenes/expand_blue.jpg"
                                        SuppressPostBack="true">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPEDatosValidados" runat="Server" TargetControlID="ContentPanelDatosValidados"
                                        ExpandControlID="TitlePanelDatosValidados" CollapseControlID="TitlePanelDatosValidados"
                                        Collapsed="False" TextLabelID="LblDatosValidados1" ExpandedText="(Ocultar detalles...)"
                                        CollapsedText="(Mostrar detalles...)" ImageControlID="ImgDatosValidados1" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                        CollapsedImage="~/Imagenes/expand_blue.jpg" SuppressPostBack="true">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <ajaxToolkit:CollapsiblePanelExtender ID="CPESinUsar" runat="Server" TargetControlID="ContentPanelSinUsar"
                                        ExpandControlID="TitlePanelSinUsar" CollapseControlID="TitlePanelSinUsar" Collapsed="False"
                                        TextLabelID="LblSinUsar1" ExpandedText="(Ocultar detalles...)" CollapsedText="(Mostrar detalles...)"
                                        ImageControlID="ImgSinUsar1" ExpandedImage="~/Imagenes/collapse_blue.jpg" CollapsedImage="~/Imagenes/expand_blue.jpg"
                                        SuppressPostBack="true">
                                    </ajaxToolkit:CollapsiblePanelExtender>
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td style="vertical-align: top; text-align: left" colspan="2">
                                                    <asp:Label ID="lblEmpInf" runat="server" SkinID="SkinLblDatos" Font-Strikeout="False"
                                                        Font-Underline="True"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 50%; text-align: left">
                                                    <asp:Panel ID="TitlePanelDatosPers" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Datos personales
                                                        <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                                <td style="vertical-align: top; width: 50%; text-align: left">
                                                    <asp:Panel ID="TitlePanelDatosDom" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Domicilio
                                                        <asp:Label ID="Label2" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 50%; text-align: left">
                                                    <asp:Panel ID="ContentPanelDatosPers" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:DetailsView ID="dvDatosPers" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                            AutoGenerateRows="False" EmptyDataText="Sin información de datos personales">
                                                            <Fields>
                                                                <asp:TemplateField HeaderText="R.F.C.">
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("RFCEmp") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <InsertItemTemplate>
                                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("RFCEmp") %>'></asp:TextBox>
                                                                    </InsertItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRFCEmp" runat="server" Text='<%# Bind("RFCEmp") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="CURPEmp" HeaderText="C.U.R.P.">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ApePatEmp" HeaderText="Apellido paterno">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ApeMatEmp" HeaderText="Apellido materno">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NomEmp" HeaderText="Nombre">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="DescSexo" HeaderText="Sexo">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NomNacionalidad" HeaderText="Nacionalidad">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="DescEdoCivil" HeaderText="Estado civ&#237;l">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NomEdo" HeaderText="Estado">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FecNacEmp" DataFormatString="{0:d}" HeaderText="Fecha de nacimiento">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Mama" HeaderText="&#191;Es mam&#225;?" />
                                                                <asp:BoundField DataField="Email" HeaderText="Correo electrónico">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbModifDatosPers" runat="server" ToolTip="Modificar los datos personales del empleado"
                                                                            CausesValidation="true">Modificar</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Fields>
                                                        </asp:DetailsView>
                                                    </asp:Panel>
                                                </td>
                                                <td style="vertical-align: top; width: 50%; text-align: left">
                                                    <asp:Panel ID="ContentPanelDatosDom" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:DetailsView ID="dvDatosDom" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                            AutoGenerateRows="False" EmptyDataText="Sin información de domicilio">
                                                            <Fields>
                                                                <asp:BoundField DataField="CalleDom" HeaderText="Calle">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NumExtDom" HeaderText="N&#250;mero exterior">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NumIntDom" HeaderText="N&#250;mero interior">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NomCol" HeaderText="Colonia">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NomLoc" HeaderText="Localidad">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NomMun" HeaderText="Municipio">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NomEdoDom" HeaderText="Estado">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CodPosDom" HeaderText="C&#243;digo postal">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbModificar" runat="server" CausesValidation="true">Modificar</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Fields>
                                                        </asp:DetailsView>
                                                    </asp:Panel>
                                                <!-- ADDALEXIS - CODIGO PARA AGREGAR DOMICILIO FISCAL -->
                                                    <asp:Panel ID="TitlePanelDatosDomFis" runat="server" Width="100%" BorderWidth="1px"
                                                        BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                        Domicilio Fiscal
                                                        <asp:Label ID="Label3" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                    <asp:Panel ID="ContentPanelDatosDomFis" runat="server" Width="100%">
                                                        <asp:DetailsView ID="dvDatosDomFis" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                            AutoGenerateRows="False" EmptyDataText="Sin información de domicilio">
                                                            <Fields>
                                                                <asp:BoundField DataField="CalleDomFis" HeaderText="Calle">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NumExtDomFis" HeaderText="N&#250;mero exterior">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NumIntDomFis" HeaderText="N&#250;mero interior">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NomColFis" HeaderText="Colonia">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NomLocFis" HeaderText="Localidad">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NomMunFis" HeaderText="Municipio">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="NomEdoDomFis" HeaderText="Estado">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="CodPosDomFis" HeaderText="C&#243;digo postal">
                                                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                                                    <ItemStyle Wrap="False"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbModificarFis" runat="server" CausesValidation="true">Modificar</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Fields>
                                                        </asp:DetailsView>
                                                    </asp:Panel>
                                                <!-- ADDALEXIS - CODIGO PARA AGREGAR DOMICILIO FISCAL -->
                                                </td> 
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 50%; text-align: left">
                                                    <asp:Panel ID="TitlePanelDatosValidados" runat="server" Width="100%" Height="100%"
                                                        BorderWidth="1px" BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="ImgDatosValidados1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                                                        </asp:Image>
                                                        ¿Información validada?
                                                        <asp:Label ID="LblDatosValidados1" runat="server">(Mostrar detalles...)</asp:Label>
                                                        <br />
                                                        (Uso exclusivo de seguridad social)
                                                    </asp:Panel>
                                                </td>
                                                <td style="vertical-align: top; width: 50%; text-align: left">
                                                    <asp:Panel ID="TitlePanelSinUsar" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                        BorderColor="White" CssClass="collapsePanelHeader">
                                                        <asp:Image ID="ImgSinUsar1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                                                        </asp:Image>
                                                        Sin usar
                                                        <asp:Label ID="LblSinUsar1" runat="server">(Mostrar detalles...)</asp:Label>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: top; width: 50%; text-align: left">
                                                    <asp:Panel ID="ContentPanelDatosValidados" runat="server" Width="100%" CssClass="collapsePanel">
                                                        <asp:CheckBox ID="ChkBxDatosValidados" runat="server" SkinID="SkinCheckBox" Text="Suspensión de pago por información incompleta"
                                                            EnableViewState="False" CausesValidation="True" Enabled="False" />&nbsp;<asp:Button
                                                                ID="btnModificarSuspenderPagoQnal" runat="server" OnClick="btnModificarSuspenderPagoQnal_Click"
                                                                SkinID="SkinBoton" Text="Modificar" />
                                                        <asp:Button ID="btnGuardarSuspenderPagoQnal" runat="server" OnClick="btnGuardarSuspenderPagoQnal_Click"
                                                            SkinID="SkinBoton" Text="Guardar" />
                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBErSuspenderPagoQnal" runat="server" ConfirmText="¿Está seguro de realizar la operación?"
                                                            TargetControlID="btnGuardarSuspenderPagoQnal">
                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                    </asp:Panel>
                                                </td>
                                                <td style="vertical-align: top; width: 50%; text-align: left">
                                                    <asp:Panel ID="ContentPanelSinUsar" runat="server" Width="100%" CssClass="collapsePanel">
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                                    <asp:AsyncPostBackTrigger ControlID="btnGuardarSuspenderPagoQnal" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
