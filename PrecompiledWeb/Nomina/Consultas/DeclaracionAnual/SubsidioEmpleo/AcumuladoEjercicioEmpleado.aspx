<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="SubsidioEmpleoAcumuladoEjercicioEmpleado, App_Web_2grzxr1z" title="COBAEV - Nómina - Subsidio para el empleo acumulado por empleado" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/JavaScript" language="JavaScript">
        function pageLoad() {
            var manager = Sys.WebForms.PageRequestManager.getInstance();
            manager.add_endRequest(endRequest);
            manager.add_beginRequest(OnBeginRequest);
        }

        function OnBeginRequest(sender, args) {
            $get('ParentDiv').className = 'modalBackground2';
        }

        function endRequest(sender, args) {
            $get('ParentDiv').className = '';
        }

        function CancelPostBack() {
            var objMan = Sys.WebForms.PageRequestManager.getInstance();
            if (objMan.get_isInAsyncPostBack())
                objMan.abortPostBack();
        }
    </script>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="500" DynamicLayout="true">
        <ProgressTemplate>
            <div id="ParentDiv">
            </div>
            <div id="div1" runat="server" align="center" valign="middle" style="width: 100%;
                height: 200%; position: absolute; left: 0; top: 0; visibility: visible; vertical-align: middle;
                background-color: White; z-index: 10; filter: alpha(opacity=40);">
            </div>
            <div id="div2" runat="server" align="center" valign="middle" style="width: 250px;
                height: 100px; position: absolute; left: 40%; top: 40%; visibility: visible;
                vertical-align: middle; border-style: inset; border-color: black; background-color: White;
                z-index: 20">
                <br />
                <table>
                    <tr>
                        <td style="vertical-align: middle; text-align: center;">
                            <asp:Image runat="server" ID="img1" ImageUrl="~/Imagenes/Spinner2.gif" />
                        </td>
                        <td style="vertical-align: middle; text-align: center;">
                            <asp:Label runat="server" ID="lblMsjEspera" Text="Por favor espere..." SkinID="SkinLblMsjExito"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="vertical-align: middle; text-align: center;">
                            <asp:Button runat="server" ID="btnCancelar" OnClientClick="javascript:CancelPostBack(); return false;"
                                SkinID="SkinBoton" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true">
                            </uc1:wucBuscaEmpleados>
                        </td>
                        <td style="vertical-align: top; text-align: right">
                            &nbsp;<asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                ToolTip="Actualizar información" /><br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar" Font-Names="Verdana"
                            Font-Size="X-Small" GroupingText="Seleccione año">
                            <br />
                            <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" Text="Consultar"
                                ToolTip="Consultar el acumulado anual de subsidio para el empleo del empleado seleccionado" /><br />
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnl1" runat="server">
                        <asp:Label ID="lblMsj" runat="server" SkinID="SkinLblDatos"></asp:Label><br />
                        <asp:GridView ID="gvAcumulado" runat="server" CellPadding="1" SkinID="SkinGridView"
                            Width="50%" EmptyDataText="Sin información">
                            <Columns>
                                <asp:BoundField DataField="SubsidioParaEmpleo" DataFormatString="{0:c}" HeaderText="Importe quincenal">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Quincena" HeaderText="Quincena">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OrigenInf" HeaderText="Origen">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:GridView ID="gvTotalAcumulado" runat="server" CellPadding="1" SkinID="SkinGridView"
                            EmptyDataText="Sin información.">
                            <Columns>
                                <asp:BoundField DataField="SubsidioParaEmpleoAcumulado" DataFormatString="{0:c}"
                                    HeaderText="Importe total acumulado">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Right" Wrap="False" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                    </Triggers>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                    <asp:Panel ID="pnl2" runat="server">
                        <asp:CheckBox ID="ChkBxSubsidioParaEmpleo" runat="server" EnableViewState="False"
                            SkinID="SkinCheckBox" Text="No aplicar subsidio para el empleo en " />
                        <asp:Label ID="lblAnio" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
                        <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" SkinID="SkinBoton"
                            Text="Modificar" />&nbsp;<asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click"
                                SkinID="SkinBoton" Text="Guardar" />
                        <ajaxToolkit:ConfirmButtonExtender ID="CBESubsidioParaEmpleo" runat="server" ConfirmText="¿Está seguro de realizar la operación?"
                            TargetControlID="btnGuardar">
                        </ajaxToolkit:ConfirmButtonExtender>
                    </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" EventName="PreRender" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
