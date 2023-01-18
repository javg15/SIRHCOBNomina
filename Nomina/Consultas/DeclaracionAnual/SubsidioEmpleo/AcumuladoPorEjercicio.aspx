<%@ Page Language="VB" enableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false" CodeFile="AcumuladoPorEjercicio.aspx.vb" Inherits="SubsidioEmpleoAcumuladoEjercicio" title="COBAEV - Nómina - Subsidio para el empleo acumulado por ejercicio" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucBuscaEmpleados.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
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
            <td style="vertical-align: top; text-align: left">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="500" DynamicLayout="true">
                                <ProgressTemplate>
                                    <div id="ParentDiv">
                                    </div>
                                    <div id="div1" runat="server" align="center" valign="middle" style="width: 100%; height: 200%; position: absolute;left: 0;top: 0;visibility:visible;vertical-align:middle;background-color:White;z-index:10; filter: alpha(opacity=40);">
                                    </div>
                                    <div id="div2" runat="server" align="center" valign="middle" style="width: 250px; height: 100px; position: absolute;left: 40%;top: 40%;visibility:visible;vertical-align:middle;border-style:inset;border-color:black;background-color:White;z-index:20">
                                        <br />
                                        <table>
                                            <tr>
                                                <td style="vertical-align: middle; text-align:center;">
                                                    <asp:Image runat="server" id="img1" ImageUrl="~/Imagenes/Spinner2.gif" />
                                                </td>
                                                <td style="vertical-align: middle; text-align:center;">
                                                    <asp:Label runat="server" id="lblMsjEspera" Text="Por favor espere..." SkinID="SkinLblMsjExito" ></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="vertical-align: middle; text-align:center;">
                                                    <asp:Button runat="server" id="btnCancelar" OnClientClick="javascript:CancelPostBack(); return false;" SkinID="SkinBoton" Text="Cancelar" />
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
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar"
                            Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione año">
                    <br />
                            <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <asp:Button ID="btnConsultar" runat="server" 
                                SkinID="SkinBoton" Text="Consultar" ToolTip="Consultar el acumulado anual de subsidio para el empleo del empleado seleccionado" /><br />
                </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:Label ID="lblMsj" runat="server" SkinID="SkinLblDatos"></asp:Label><br />
    <asp:GridView ID="gvAcumulado" runat="server" CellPadding="1" SkinID="SkinGridView" Width="50%" EmptyDataText="Sin información">
        <Columns>
            <asp:BoundField DataField="SubsidioParaEmpleo" DataFormatString="{0:c}" HeaderText="Importe quincenal">
                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                <ItemStyle HorizontalAlign="Right" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Quincena" HeaderText="Quincena">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
                        <br />
                        <asp:GridView ID="gvTotalAcumulado" runat="server" CellPadding="1" SkinID="SkinGridView" EmptyDataText="Sin información." >
                            <Columns>
                                <asp:BoundField DataField="SubsidioParaEmpleoAcumulado" DataFormatString="{0:c}"
                                    HeaderText="Importe total acumulado">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                </asp:BoundField>
        </Columns>
    </asp:GridView>
                        <br />
                        <asp:Label ID="lblMsj2" runat="server" SkinID="SkinLblDatos"></asp:Label><br />
                        <asp:GridView ID="gvListadoEmps" runat="server" AutoGenerateColumns="False" SkinID="SkinGridView" OnRowCommand="gvListadoEmps_RowCommand" OnRowDataBound="gvListadoEmps_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="R.F.C.">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkBtnRFC" runat="server" CommandName="CmdRFC" Text='<%# Bind("RFCEmp") %>'></asp:LinkButton><ajaxToolkit:ConfirmButtonExtender
                                            ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                            TargetControlID="LnkBtnRFC">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Num. Emp.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("NumEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="C.U.R.P.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCURP" runat="server" Text='<%# Bind("CURPEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="A. Paterno">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApePat" runat="server" Text='<%# Bind("ApePatEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="A. Materno">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApeMat" runat="server" Text='<%# Bind("ApeMatEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NomEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plantel">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlantel" runat="server" Text='<%# Bind("ClavePlantel") %>' ToolTip='<%# Bind("DescPlantel") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

