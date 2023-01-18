<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="AdmonDetallesRecibos.aspx.vb" Inherits="ABC_Recibos_AdmonDetallesRecibos"
    Title="COBAEV - Nómina - Administrar los detalles del recibo" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucBuscaEmpleados.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Recibos de pago fuera de nómina (Administración Percepciones/Deducciones)
                </h2>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table style="vertical-align: top; width: 100%; height: 100%; text-align: left;">
                <tr>
                    <td style="vertical-align: top; width: 100%; height: 100%; text-align: left;">
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: left">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="vertical-align: middle; width: 150px">
                                                <asp:ImageButton ID="ibImprimir" runat="server" ImageUrl="~/Imagenes/Printer1.jpg"
                                                    ToolTip="Mostrar recibo para impresión" Height="40px" Width="40px" />
                                                <asp:ImageButton ID="ibDevolucion" runat="server" ImageUrl="~/Imagenes/Devolucion.jpg"
                                                    ToolTip="Generar devolución del recibo" Visible="False" Height="40px" 
                                                    Width="40px" />
                                                <asp:ImageButton ID="ibEliminarDevolucion"
                                                        runat="server" ImageUrl="~/Imagenes/EliminarDevolucion.png" ToolTip="Eliminar devolución del recibo"
                                                        Visible="False" Height="40px" Width="40px" />
                                                <asp:ImageButton ID="ibRegresar" runat="server" Height="40px" 
                                                    ImageUrl="~/Imagenes/btnRegresar.jpg" ToolTip="Regresar" Width="40px" />
                                            </td>
                                            <td style="vertical-align: middle; text-align: right;">
                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEibDevolucion" runat="server" ConfirmText="Esta operación dejará marcado el recibo como devolución, ¿Continuar?"
                                                    TargetControlID="ibDevolucion">
                                                </ajaxToolkit:ConfirmButtonExtender>
                                                <asp:ImageButton ID="iblAfectacionPago" runat="server" ImageUrl="~/Imagenes/Impresora4.jpg" ToolTip="Imprmir afectación del pago" />
                                                <asp:ImageButton ID="iblAfectacion" runat="server" Height="40px" ImageUrl="~/Imagenes/Impresora2.jpg" Width="40px" ToolTip="Imprmir afectación de gasto" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px; vertical-align: middle;">
                                                <asp:Label ID="Label7" runat="server" SkinID="SkinLblNormal" Text="Recibo: "></asp:Label>
                                            </td>
                                            <td style="vertical-align: middle">
                                                <asp:TextBox ID="tbNumRecibo" runat="server" MaxLength="4" ReadOnly="True" SkinID="SkinTextBox"
                                                    Width="60px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle; width: 150px">
                                                <asp:Label ID="Label8" runat="server" SkinID="SkinLblNormal" Text="Tipo de recibo: "></asp:Label>
                                            </td>
                                            <td style="vertical-align: middle">
                                                <asp:TextBox ID="tbTipoRecibo" runat="server" ReadOnly="True" SkinID="SkinTextBox"
                                                    Width="400px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 150px">
                                                <asp:Label ID="Label9" runat="server" SkinID="SkinLblNormal" Text="Descripción del concepto: "></asp:Label>
                                            </td>
                                            <td style="vertical-align: top">
                                                <asp:TextBox ID="tbConceptoRecibo" runat="server" MaxLength="200" Rows="3" SkinID="SkinTextBox"
                                                    TextMode="MultiLine" Width="500px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle; width: 150px; height: 22px;">
                                                <asp:Label ID="Label13" runat="server" SkinID="SkinLblNormal" Text="Quincena de aplicación: "></asp:Label>
                                            </td>
                                            <td style="vertical-align: middle; height: 22px;">
                                                <asp:TextBox ID="tbQuincena" runat="server" ReadOnly="True" SkinID="SkinTextBox"
                                                    Width="60px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle; width: 150px">
                                                <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" Text="Con cargo a: "></asp:Label>
                                            </td>
                                            <td style="vertical-align: middle">
                                                <asp:TextBox ID="tbTipoPresup" runat="server" ReadOnly="True" SkinID="SkinTextBox"
                                                    Width="250px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle; width: 150px">
                                                <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Centro de resp.: "></asp:Label>
                                            </td>
                                            <td style="vertical-align: middle">
                                                <asp:TextBox ID="tbCentResp" runat="server" ReadOnly="True" SkinID="SkinTextBox"
                                                    Width="70px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle; width: 150px">
                                                <asp:Label ID="Label14" runat="server" SkinID="SkinLblNormal" Text="Plantel: "></asp:Label>
                                            </td>
                                            <td style="vertical-align: middle">
                                                <asp:TextBox ID="tbPlantel" runat="server" ReadOnly="True" SkinID="SkinTextBox" Width="400px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: middle; width: 150px">
                                                <asp:Label ID="Label6" runat="server" SkinID="SkinLblNormal" Text="Regimen ISSSTE: "></asp:Label>
                                            </td>
                                            <td style="vertical-align: middle">
                                                <asp:TextBox ID="tbRegimenISSSTE" runat="server" ReadOnly="True" SkinID="SkinTextBox"
                                                    Width="250px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    <asp:Panel ID="pnlEmpleado" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                                        GroupingText="Recibo expedido al empleado" Width="100%">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 150px; vertical-align: middle;">
                                                    <asp:Label ID="Label10" runat="server" SkinID="SkinLblNormal" Text="Clave de cobro: "></asp:Label>
                                                </td>
                                                <td style="vertical-align: middle">
                                                    <asp:TextBox ID="tbClaveCobro" runat="server" ReadOnly="True" SkinID="SkinTextBox"
                                                        Width="200px"></asp:TextBox>
                                                    <asp:Label ID="lblIdQuincena" runat="server" Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: middle; width: 150px">
                                                    <asp:Label ID="Label11" runat="server" SkinID="SkinLblNormal" Text="R.F.C.: "></asp:Label>
                                                </td>
                                                <td style="vertical-align: middle">
                                                    <asp:TextBox ID="tbRFC" runat="server" ReadOnly="True" SkinID="SkinTextBox" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: middle; width: 150px; height: 20px;">
                                                    <asp:Label ID="Label12" runat="server" SkinID="SkinLblNormal" Text="Nombre: "></asp:Label>
                                                </td>
                                                <td style="vertical-align: middle; height: 20px;">
                                                    <asp:TextBox ID="tbNombre" runat="server" ReadOnly="True" SkinID="SkinTextBox" Width="400px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <ajaxToolkit:ConfirmButtonExtender ID="CBEbtnFinalizarRecibo" runat="server" ConfirmText="¿La información del recibo es correcta?"
                                        TargetControlID="BtnFinalizarRecibo">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                    <ajaxToolkit:ConfirmButtonExtender ID="CBEbtnGeneraRecibo" runat="server" ConfirmText="¿La información del recibo es correcta?"
                                        TargetControlID="btnGeneraRecibo">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                    <asp:Button ID="BtnFinalizarRecibo" runat="server" SkinID="SkinBoton" 
                                        Text="Finalizar captura del recibo" Visible="False" /><asp:Button
                                        ID="btnGeneraRecibo" runat="server" SkinID="SkinBoton" Text="Genera recibo" Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table style="width: 100%; height: 300px;">
                <tr>
                    <td style="vertical-align: top; width: 100%; height: 100%; text-align= left;">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 100%; text-align: left;">
                                            <ajaxToolkit:CollapsiblePanelExtender ID="CPEPercDeduc" runat="Server" CollapseControlID="TitlePanelPercDeduc"
                                                Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                                ExpandControlID="TitlePanelPercDeduc" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                                ExpandedText="(Ocultar detalles...)" ImageControlID="Image2" SuppressPostBack="true"
                                                TargetControlID="ContentPanelPercDeduc" TextLabelID="Label2">
                                            </ajaxToolkit:CollapsiblePanelExtender>
                                            <ajaxToolkit:CollapsiblePanelExtender ID="CPETotales" runat="Server" CollapseControlID="TitlePanelTotales"
                                                Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                                ExpandControlID="TitlePanelTotales" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                                ExpandedText="(Ocultar detalles...)" ImageControlID="Image3" SuppressPostBack="true"
                                                TargetControlID="ContentPanelTotales" TextLabelID="Label4">
                                            </ajaxToolkit:CollapsiblePanelExtender>
                                            <ajaxToolkit:CollapsiblePanelExtender ID="CPEDatosComplem" runat="server" CollapseControlID="TitlePanelDatosComplem"
                                                Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                                ExpandControlID="TitlePanelDatosComplem" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                                ExpandedText="(Ocultar detalles...)" ImageControlID="Image5" SuppressPostBack="true"
                                                TargetControlID="ContentPanelDatosComplem" TextLabelID="Label5">
                                            </ajaxToolkit:CollapsiblePanelExtender>
                                            <ajaxToolkit:CollapsiblePanelExtender ID="CPESubsidioCausado" runat="server" CollapseControlID="TitlePanelSubsidioCausado"
                                                Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                                                ExpandControlID="TitlePanelSubsidioCausado" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                                ExpandedText="(Ocultar detalles...)" ImageControlID="imgSubsidioCausado1" SuppressPostBack="true"
                                                TargetControlID="ContentPanelSubsidioCausado" TextLabelID="lblSubsidioCausado1">
                                            </ajaxToolkit:CollapsiblePanelExtender>
                                            <table style="width: 100%; text-align: left;" cellspacing="0" cellpadding="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                            <asp:Label ID="lblObservaciones" runat="server" SkinID="SkinLblHeader" 
                                                                Text="Observaciones a considerar" Visible="False"></asp:Label>
                                                            <asp:GridView ID="gvObservs" runat="server" AutoGenerateColumns="False" 
                                                                SkinID="SkinGridView" Width="100%" Visible="False">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Descripción de la observación" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterStyle HorizontalAlign="Left" />
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                            <asp:Panel ID="TitlePanelPercDeduc" runat="server" Width="100%" BorderWidth="1px"
                                                                BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                                Percepciones - Deducciones
                                                                <asp:Label ID="Label2" runat="server">(Mostrar detalles...)</asp:Label>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                            <asp:Panel ID="ContentPanelPercDeduc" runat="server" Width="100%" CssClass="collapsePanel">
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="vertical-align: top; width: 100%; text-align: left;">
                                                                                <asp:Label ID="Label15" runat="server" SkinID="SkinLblDatos" 
                                                                                    Text="Percepciones"></asp:Label>
                                                                                &nbsp;<asp:LinkButton ID="lbAddPerc" runat="server" SkinID="SkinLinkButton" OnClick="lbAddPerc_Click">(Agregar percepción)</asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="vertical-align: middle; width: 100%; text-align: left">
                                                                                <asp:GridView ID="gvPercepciones" runat="server" AutoGenerateColumns="False" 
                                                                                    EmptyDataText="Sin información de percepciones" 
                                                                                    OnRowDataBound="gvPercepciones_RowDataBound" SkinID="SkinGridView" 
                                                                                    Width="100%" ShowFooter="True">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="IdPercDeduc" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblIdPerc_E" runat="server" Text='<%# Bind("IdPercDeduc") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="ClavePercDeduc" HeaderText="Clave">
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                                                        </asp:BoundField>
                                                                                            <asp:BoundField DataField="NombrePercDeduc" HeaderText="Percepción" 
                                                                                                FooterText="Totales ==&gt;&nbsp;&nbsp;">
                                                                                                <FooterStyle HorizontalAlign="Right" />
                                                                                                <HeaderStyle Width="300px" HorizontalAlign="Center" />
                                                                                                <ItemStyle Width="300px" />
                                                                                            </asp:BoundField>
                                                                                        <asp:TemplateField HeaderText="Importe percepción">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblImporte_I" runat="server" 
                                                                                                    Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                    <asp:Label ID="lblTotPercs" runat="server" Text=""></asp:Label>
                                                                                            </FooterTemplate>
                                                                                            <ItemStyle HorizontalAlign="Right" Width="150px" />
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                                                            <FooterStyle HorizontalAlign="Right" Width="150px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Importe para retroactivo">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblImpParaRetro_I" runat="server" 
                                                                                                    Text='<%# Bind("ImporteParaRetroactivo", "{0:c}") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                    <asp:Label ID="lblTotPercsRetro" runat="server" Text=""></asp:Label>
                                                                                            </FooterTemplate>
                                                                                            <ItemStyle HorizontalAlign="Right" Width="150px" />
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                                                            <FooterStyle HorizontalAlign="Right" Width="150px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Importe para aguinaldo">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblImpParaAgui_I" runat="server" 
                                                                                                    Text='<%# Bind("ImporteParaAguinaldo", "{0:c}") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                    <asp:Label ID="lblTotPercsAgui" runat="server" Text=""></asp:Label>
                                                                                            </FooterTemplate>
                                                                                            <ItemStyle HorizontalAlign="Right" Width="150px" />
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                                                            <FooterStyle HorizontalAlign="Right" Width="150px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Importe gravado">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblImporteGravado" runat="server" 
                                                                                                    Text='<%# Bind("ImporteGravado", "{0:c}") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                    <asp:Label ID="lblTotPercsGrav" runat="server" Text=""></asp:Label>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                                                            <ItemStyle HorizontalAlign="Right" Width="150px" />
                                                                                            <FooterStyle HorizontalAlign="Right" Width="150px" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                                <asp:ImageButton ID="ibModificar" runat="server" 
                                                                                                    ImageUrl="~/Imagenes/Modificar.png" OnClick="ibModificar_Click" 
                                                                                                    ToolTip="Modificar" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                                <asp:ImageButton ID="ibEliminar" runat="server" 
                                                                                                    ImageUrl="~/Imagenes/Eliminar.png" OnClick="ibEliminar_Click" 
                                                                                                    ToolTip="Eliminar" />
                                                                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" 
                                                                                                    ConfirmText="Ésta operación eliminará el registro definitivamente, ¿Continuar?" 
                                                                                                    TargetControlID="ibEliminar">
                                                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle Font-Bold="False" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                            <tr>
                                                                                <td style="vertical-align: top; width: 100%; text-align: left;">
                                                                                    <br />
                                                                                    <asp:Label ID="Label16" runat="server" SkinID="SkinLblDatos" Text="Deducciones"></asp:Label>
                                                                                    &nbsp;<asp:LinkButton ID="lbAddDeduc" runat="server" OnClick="lbAddDeduc_Click" 
                                                                                        SkinID="SkinLinkButton">(Agregar deducción)</asp:LinkButton>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="vertical-align: middle; width: 100%; text-align: left">
                                                                                    <asp:GridView ID="gvDeducciones" runat="server" AutoGenerateColumns="False" 
                                                                                        EmptyDataText="Sin información de deducciones" 
                                                                                        OnRowDataBound="gvDeducciones_RowDataBound" SkinID="SkinGridView" 
                                                                                        Width="100%"  ShowFooter="True" >
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="IdPercDeduc" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblIdDeduc" runat="server" Text='<%# Bind("IdPercDeduc") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="ClavePercDeduc" HeaderText="Clave">
                                                                                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                                            <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="NombrePercDeduc" HeaderText="Deducción" 
                                                                                                FooterText="Totales ==&gt;&nbsp;&nbsp;">
                                                                                                <FooterStyle HorizontalAlign="Right" />
                                                                                                <HeaderStyle Width="300px" HorizontalAlign="Center" />
                                                                                                <ItemStyle Width="300px" />
                                                                                            </asp:BoundField>
                                                                                            <asp:TemplateField HeaderText="Importe deducción">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblImporte_I" runat="server" 
                                                                                                        Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <asp:Label ID="lblTotDeducs" runat="server" Text=""></asp:Label>
                                                                                                </FooterTemplate>
                                                                                                <ItemStyle HorizontalAlign="Right" Width="150px"/>
                                                                                                <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                                                                <FooterStyle HorizontalAlign="Right" Width="150px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Importe para retroactivo">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblImpParaRetro_I" runat="server" 
                                                                                                        Text='<%# Bind("ImporteParaRetroactivo", "{0:c}") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <asp:Label ID="lblTotDeducsRetro" runat="server" Text=""></asp:Label>
                                                                                                </FooterTemplate>
                                                                                                <ItemStyle HorizontalAlign="Right" Width="150px" />
                                                                                                <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                                                                <FooterStyle HorizontalAlign="Right" Width="150px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Importe para aguinaldo">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblImpParaAgui_I" runat="server" 
                                                                                                        Text='<%# Bind("ImporteParaAguinaldo", "{0:c}") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <asp:Label ID="lblTotDeducsAgui" runat="server" Text=""></asp:Label>
                                                                                                </FooterTemplate>
                                                                                                <ItemStyle HorizontalAlign="Right" Width="150px" />
                                                                                                <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                                                                <FooterStyle HorizontalAlign="Right" Width="150px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Importe gravado">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblImporteGravado" runat="server" 
                                                                                                        Text='<%# Bind("ImporteGravado", "{0:c}") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <FooterTemplate>
                                                                                                    <asp:Label ID="lblTotDeducsGrav" runat="server" Text=""></asp:Label>
                                                                                                </FooterTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                                                                <ItemStyle HorizontalAlign="Right" Width="150px" />
                                                                                                <FooterStyle HorizontalAlign="Right" Width="150px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:ImageButton ID="ibModificar" runat="server" 
                                                                                                        ImageUrl="~/Imagenes/Modificar.png" OnClick="ibModificar_Click1" 
                                                                                                        ToolTip="Modificar" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:ImageButton ID="ibEliminar" runat="server" 
                                                                                                        ImageUrl="~/Imagenes/Eliminar.png" OnClick="ibEliminar_Click1" 
                                                                                                        ToolTip="Eliminar" />
                                                                                                    <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" 
                                                                                                        ConfirmText="Ésta operación eliminará el registro definitivamente, ¿Continuar?" 
                                                                                                        TargetControlID="ibEliminar">
                                                                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                    <br />
                                                                                </td>
                                                                            </tr>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                            <asp:Panel ID="TitlePanelTotales" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                                BorderColor="White" CssClass="collapsePanelHeader">
                                                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                                Totales
                                                                <asp:Label ID="Label4" runat="server">(Mostrar detalles...)</asp:Label>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                            <asp:Panel ID="ContentPanelTotales" runat="server" Width="100%" CssClass="collapsePanel">
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="vertical-align: top; width: 50%; text-align: left">
                                                                                <asp:DetailsView ID="dvTotalPerc" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                                    EmptyDataText="No existen percepciones a sumar" AutoGenerateRows="False" 
                                                                                    Height="100%" Visible="False">
                                                                                    <Fields>
                                                                                        <asp:BoundField DataField="TotalPercepciones" DataFormatString="{0:c}" HeaderText="Total percepciones">
                                                                                            <HeaderStyle Width="50%"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                    </Fields>
                                                                                </asp:DetailsView>
                                                                            </td>
                                                                            <td style="vertical-align: top; width: 50%; text-align: left">
                                                                                <asp:DetailsView ID="dvTotalDeduc" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                                    EmptyDataText="No existen deducciones a sumar" AutoGenerateRows="False" 
                                                                                    Height="100%" Visible="False">
                                                                                    <Fields>
                                                                                        <asp:BoundField DataField="TotalDeducciones" DataFormatString="{0:c}" HeaderText="Total deducciones">
                                                                                            <HeaderStyle Width="50%"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                    </Fields>
                                                                                </asp:DetailsView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="vertical-align: top; width: 50%; height: 37px; text-align: center">
                                                                            </td>
                                                                            <td style="vertical-align: top; width: 50%; height: 37px; text-align: left">
                                                                                <asp:DetailsView ID="dvNetoPagar" runat="server" Width="100%" SkinID="SkinDetailsView"
                                                                                    EmptyDataText="Sin información de pago" AutoGenerateRows="False" Height="100%">
                                                                                    <Fields>
                                                                                        <asp:BoundField DataField="ImporteACobrar" DataFormatString="{0:c}" HeaderText="Neto a pagar">
                                                                                            <HeaderStyle Width="50%"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Right" Width="50%"></ItemStyle>
                                                                                        </asp:BoundField>
                                                                                    </Fields>
                                                                                </asp:DetailsView>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                            <asp:Panel ID="TitlePanelDatosComplem" runat="server" Width="100%" BorderWidth="1px"
                                                                BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                                Datos complementarios (Solo para indemnizaciones)
                                                                <asp:Label ID="Label5" runat="server">(Mostrar detalles...)</asp:Label>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                            <asp:Panel ID="ContentPanelDatosComplem" runat="server" Width="100%" CssClass="collapsePanel">
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="vertical-align: top; text-align: left; height: 37px;" colspan="2">
                                                                                <asp:GridView ID="gvDatosComplem" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen datos complementarios para el recibo."
                                                                                    PageSize="20" SkinID="SkinGridView" Width="100%" OnRowDataBound="gvDatosComplem_RowDataBound">
                                                                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                                    <EmptyDataRowStyle Font-Italic="True" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblIdRecibo" runat="server" Text='<%# Bind("IdRecibo") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="AniosDeServicio" HeaderText="A&#241;os de servicio">
                                                                                            <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="IngresoExcento" DataFormatString="{0:c}" HeaderText="Ingreso exento">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="UltimoSueldo" DataFormatString="{0:c}" HeaderText="Ultimo sueldo">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                                        </asp:BoundField>
                                                                                        <asp:BoundField DataField="ISRUltimoSueldo" DataFormatString="{0:c}" HeaderText="I.S.R. Ultimo sueldo">
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:BoundField>
                                                                                        <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                                <asp:ImageButton ID="ibEliminar" runat="server" CommandName="CmdEliminar" ImageUrl="~/Imagenes/Eliminar.png"
                                                                                                    ToolTip="Eliminar éste recibo" OnClick="ibEliminar_Click2" />
                                                                                                <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="Ésta operación eliminará el registro definitivamente, ¿Continuar?"
                                                                                                    TargetControlID="ibEliminar">
                                                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                                <asp:ImageButton ID="ibModificar" runat="server" CommandName="CmdModificar" ImageUrl="~/Imagenes/Modificar.png"
                                                                                                    ToolTip="Modificar la información de éste recibo" OnClick="ibModificar_Click2" />
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <EmptyDataTemplate>
                                                                                        <asp:LinkButton ID="lbAddDatosComplem" runat="server" Font-Bold="False" Font-Italic="False"
                                                                                            SkinID="SkinLinkButton" OnClick="lbAddDatosComplem_Click">Capturar datos complementarios</asp:LinkButton>
                                                                                    </EmptyDataTemplate>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <br />
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 100%; text-align: left" colspan="2">
                                                            <asp:Panel ID="TitlePanelSubsidioCausado" runat="server" Width="100%" BorderWidth="1px"
                                                                BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                                <asp:Image ID="imgSubsidioCausado1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                                                                Subsidio causado
                                                                <asp:Label ID="lblSubsidioCausado1" runat="server">(Mostrar detalles...)</asp:Label>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="vertical-align: top; width: 100%; text-align: left">
                                                            <asp:Panel ID="ContentPanelSubsidioCausado" runat="server" Width="100%" CssClass="collapsePanel">
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="vertical-align: top; width: 100%; height: 37px; text-align: left">
                                                                                    <asp:GridView ID="gvSubsidioCausado" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe subsidio causado."
                                                                                    PageSize="20" SkinID="SkinGridView" Width="100%">
                                                                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                                    <EmptyDataRowStyle Font-Italic="True" />
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Subsidio causado">
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="txtbxSubsidioCausado" runat="server" 
                                                                                                    Text='<%# Bind("SubsidioCausado") %>' SkinID="SkinTextBox"></asp:TextBox>
                                                                                                <asp:CompareValidator ID="CVtxtbxSubsidioCausado" runat="server" 
                                                                                                    ControlToValidate="txtbxSubsidioCausado" 
                                                                                                    ErrorMessage="El importe del Subsidio Causado debe ser un valor numérico." 
                                                                                                    Operator="DataTypeCheck" 
                                                                                                    ToolTip="El importe del Subsidio Causado debe ser un valor numérico." 
                                                                                                    Type="Double" Display="Dynamic">*</asp:CompareValidator>
                                                                                                <asp:CompareValidator ID="CVtxtbxSubsidioCausado2" runat="server" 
                                                                                                    ControlToValidate="txtbxSubsidioCausado" 
                                                                                                    ErrorMessage="El importe del Subsidio Causado debe ser mayor que cero." 
                                                                                                    Operator="GreaterThanEqual" 
                                                                                                    ToolTip="El importe del Subsidio Causado debe ser mayor que cero." 
                                                                                                    Type="Double" ValueToCompare="0" Display="Dynamic">*</asp:CompareValidator>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblSubsidioCausado" runat="server" 
                                                                                                    Text='<%# Bind("SubsidioCausado", "{0:c}") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField>
                                                                                            <EditItemTemplate>
                                                                                                <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" CommandName="Update"
                                                                                                    ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar" />
                                                                                               <asp:ImageButton ID="ibCancelar" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                                                    ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar" />
                                                                                                <ajaxToolkit:ConfirmButtonExtender ID="CBECancelar" runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                                                                                                    TargetControlID="ibGuardar">
                                                                                                </ajaxToolkit:ConfirmButtonExtender>
                                                                                            </EditItemTemplate>
                                                                                            <ItemTemplate>
                                                                                                <asp:ImageButton ID="ibModificar" runat="server" 
                                                                                                    ImageUrl="~/Imagenes/Modificar.png"
                                                                                                    ToolTip="Modificar" CausesValidation="False" CommandName="Edit" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <EmptyDataTemplate>
                                                                                        <asp:LinkButton ID="lbAddSubsidioCausado" runat="server" Font-Bold="False" Font-Italic="False"
                                                                                            SkinID="SkinLinkButton" CommandName="Edit">Capturar subsidio causado</asp:LinkButton>
                                                                                    </EmptyDataTemplate>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table>
                <tr>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Image ID="ImgExito" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                    </td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <table>
                <tr>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                    </td>
                    <td style="vertical-align: middle; text-align: left">
                        <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
