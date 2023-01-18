<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="ABC_Compensaciones_RecalculoCompensaciones, App_Web_ns2nwdvl" title="COBAEV - Nómina - Recálculo de compensaciones" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Assembly="AjaxControls" Namespace="AjaxControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/JavaScript" language="JavaScript">
function pageLoad()
{       
   var manager = Sys.WebForms.PageRequestManager.getInstance();
   manager.add_endRequest(endRequest);
   manager.add_beginRequest(OnBeginRequest);
}

function OnBeginRequest(sender, args)
{     
    $get('ParentDiv').className ='modalBackground2';    
} 

function endRequest(sender, args)
{
    $get('ParentDiv').className ='';
}  

function CancelPostBack() {
    var objMan = Sys.WebForms.PageRequestManager.getInstance();
    if (objMan.get_isInAsyncPostBack())
        objMan.abortPostBack();
}
</script>
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: left;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar"
                            Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione año">
                    <br />
                            <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                            </asp:DropDownList>
                </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="500" DynamicLayout="true">
                    <ProgressTemplate>
                        <div id="ParentDiv">
                        </div>
                        <div id="div1" runat="server" align="center" style="z-index: 10; filter: alpha(opacity=40);
                            left: 0px; visibility: visible; vertical-align: middle; width: 100%; position: absolute;
                            top: 0px; height: 200%; background-color: white" valign="middle">
                        </div>
                        <div id="div2" runat="server" align="center" style="z-index: 20; border-left-color: black;
                            left: 40%; visibility: visible; border-bottom-color: black; vertical-align: middle;
                            width: 250px; border-top-style: inset; border-top-color: black; border-right-style: inset;
                            border-left-style: inset; position: absolute; top: 40%; height: 100px; background-color: white;
                            border-right-color: black; border-bottom-style: inset" valign="middle">
                            <br />
                            <table>
                                <tr>
                                    <td style="vertical-align: middle; text-align: center">
                                        <asp:Image ID="img1" runat="server" ImageUrl="~/Imagenes/Spinner2.gif" />
                                    </td>
                                    <td style="vertical-align: middle; text-align: center">
                                        <asp:Label ID="lblMsjEspera" runat="server" SkinID="SkinLblMsjExito" Text="Por favor espere..."></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="vertical-align: middle; text-align: center">
                                        <asp:Button ID="btnCancelar" runat="server" OnClientClick="javascript:CancelPostBack(); return false;"
                                            SkinID="SkinBoton" Text="Cancelar" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlMeses" runat="server"
                            Font-Names="Verdana" Font-Size="X-Small" GroupingText="Meses pagados durante el año">
                            <br />
                            <asp:DropDownList ID="ddlMeses" runat="server" SkinID="SkinDropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlMeses_SelectedIndexChanged">
                            </asp:DropDownList></asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlA&#241;os" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                            <asp:Button ID="btnConsultar" runat="server" 
                                SkinID="SkinBoton" Text="Consultar" ToolTip="Consultar información relacionada con el año y mes seleccionados" />
                        <asp:Button ID="btnRecalcular" runat="server" 
                                SkinID="SkinBoton" OnClick="btnRecalcular_Click" />
                        <ajaxToolkit:ConfirmButtonExtender ID="CBEBtnRecalcular" runat="server" ConfirmText="¿Está seguro de realizar el proceso de recálculo I.S.R.?"
                            TargetControlID="btnRecalcular">
                        </ajaxToolkit:ConfirmButtonExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnRecalcular" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ddlMeses" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMsj" runat="server" SkinID="SkinLblDatos"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left;"><ajaxToolkit:CollapsiblePanelExtender ID="CPEReportes" runat="server"
                    CollapseControlID="TitlePanelReportes" Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg"
                    CollapsedText="(Mostrar detalles...)" ExpandControlID="TitlePanelReportes" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                    ExpandedText="(Ocultar detalles...)" ImageControlID="Img1PnlRep" SuppressPostBack="true"
                    TargetControlID="ContentPanelReportes" TextLabelID="Lbl1PnlRep">
            </ajaxToolkit:CollapsiblePanelExtender>
                <asp:Panel ID="TitlePanelReportes" runat="server" BorderColor="White" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                    <asp:Image ID="Img1PnlRep" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                    Reportes
                    <asp:Label ID="Lbl1PnlRep" runat="server">(Mostrar detalles...)</asp:Label>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Panel ID="ContentPanelReportes" runat="server" CssClass="collapsePanel"
                    Width="100%">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <table align="left">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal">Seleccione reporte</asp:Label></td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:GridView ID="gvReportes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvReportes_SelectedIndexChanged"
                                            SkinID="SkinGridViewEmpty">
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
                                                <asp:BoundField DataField="DescParaUsuario" HeaderText="Reporte" />
                                            <asp:TemplateField HeaderText="ExportarAPDF" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblExportarAPDF" runat="server" Text='<%# Bind("ExportarAPDF") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                <asp:CommandField ShowSelectButton="True" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ibImprimir" runat="server" ImageUrl="~/Imagenes/PDFExport.jpg"
                                            ToolTip="Mostrar reporteen PDF" />
                                        <asp:ImageButton ID="ibExportarExcel" runat="server" ImageUrl="~/Imagenes/ExcelExport.jpg"
                                            ToolTip="Mostrar reporte en Excel" /></td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            &nbsp;
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="gvReportes" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="btnRecalcular" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

