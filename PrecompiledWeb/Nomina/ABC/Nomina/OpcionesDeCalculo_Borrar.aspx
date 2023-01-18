<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="ABC_Nomina_OpcionesDeCalculo_Borrar, App_Web_sogedhgo" title="COBAEV - Nómina - Opciones de cálculo" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="../../WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Cálculo de nóminas quincenales
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Panel ID="pnlOpcionesDeCalculo" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                    GroupingText="Seleccione quincena para cálculo">
                    <br />
                    &nbsp;
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            &nbsp;<asp:DropDownList ID="ddlQnasParaCalculo" runat="server" SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <asp:Button ID="btnCalcular" runat="server" SkinID="SkinBoton" Text="Calcular" OnClick="btnCalcular_Click" /><ajaxToolkit:ConfirmButtonExtender
                                ID="CBEBtnCalcular" runat="server" ConfirmText="¿Está seguro de iniciar el cálculo?"
                                TargetControlID="btnCalcular">
                            </ajaxToolkit:ConfirmButtonExtender>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnCalcular" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                            <asp:AsyncPostBackTrigger ControlID="lbNuevoCalculo" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbNuevoCalculoPorPlantel" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="WucBuscaEmpleados1" 
                                EventName="PreRender" />
                        </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
    <table style="width: 100%" align="center">
        <tr>
            <td align="center">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="viewCalculoGeneral" runat="server">
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                            <ProgressTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image ID="imgCalculando" runat="server" ImageUrl="~/Imagenes/Spinner2.gif" Visible="False" />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCalculando" runat="server" SkinID="SkinLblMsjExito" Text="Calculando nómina, por favor espere..."
                                                Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                             <asp:Panel ID="pnlGeneral" runat="server">
                                <table align="center">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; text-align: left" rowspan="2">
                                                &nbsp;</td>
                                            <td style="text-align: center">
                                                <asp:Image ID="imgCalculando_Op2" runat="server" 
                                                    ImageUrl="~/Imagenes/spinner.gif" Visible="False" />
                                                &nbsp;<asp:Label ID="lblPlantel" runat="server" SkinID="SkinLblMsjExito" Text="Preparando entorno para iniciar el cálculo, por favor espere..."
                                                    Visible="False"></asp:Label>
                                                <asp:Label ID="lblPlantel2" runat="server" Font-Size="Small" Font-Names="Verdana"
                                                    ForeColor="Navy" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center; height: 37px;">
                                                <asp:Label ID="lblEmpleado" runat="server" SkinID="SkinLblMsjExito" Visible="False"></asp:Label>
                                                <asp:Label ID="lblEmpleado2" runat="server" Font-Size="Small" Font-Names="Verdana"
                                                    ForeColor="Navy" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                 <asp:Label ID="lblCalcFin" runat="server" SkinID="SkinLblMsjExito" 
                                     Text="Cálculo finalizado." Visible="False"></asp:Label>
                                 <br />
                                 <asp:GridView ID="gvErrores3" runat="server" 
                                     Caption="Errores durante el cálculo" EmptyDataText="Sin errores" 
                                     SkinID="SkinGridView" Width="100%">
                                     <Columns>
                                         <asp:BoundField DataField="RFC" HeaderText="RFC" />
                                         <asp:BoundField DataField="Descripcion" HeaderText="Error">
                                         <HeaderStyle HorizontalAlign="Left" />
                                         <ItemStyle HorizontalAlign="Left" />
                                         </asp:BoundField>
                                     </Columns>
                                 </asp:GridView>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick"></asp:AsyncPostBackTrigger>
                                <asp:AsyncPostBackTrigger ControlID="btnCalcular" EventName="Click"></asp:AsyncPostBackTrigger>
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:Timer ID="Timer1" runat="server" Enabled="False" Interval="1000">
                        </asp:Timer>
                    </asp:View>
                    <asp:View ID="viewCalculoPlantel" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlPlantel1" runat="server">
                                <table align="center">
                                    <tr>
                                        <td colspan="2" style="text-align: left;">
                                            <asp:Label ID="lblSelPlantel_Op1" runat="server" SkinID="SkinLblMsjExito" Text="Seleccione plantel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: left">
                                            <asp:DropDownList ID="ddlPlanteles" runat="server" SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox ID="ChkBxCalculoHaciaAdelante" runat="server" SkinID="SkinCheckBox"
                                                Text="Calcular nómina del plantel seleccionado en adelante" />
                                        </td>
                                    </tr>
                                </table>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnCalcular" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                            <asp:Panel ID="pnlPlantel2" runat="server">
                                <table align="center">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: middle; text-align: center" rowspan="1">
                                                <asp:Image ID="imgCalculando_Op1" runat="server" 
                                                    ImageUrl="~/Imagenes/spinner.gif" Visible="False" />
                                                <asp:Label ID="lblPlantel_Op1" runat="server" SkinID="SkinLblMsjExito" 
                                                    Text="Preparando entorno para iniciar el cálculo, por favor espere..." 
                                                    Visible="False"></asp:Label>
                                                <asp:Label ID="lblPlantel2_Op1" runat="server" Font-Names="Verdana" 
                                                    Font-Size="Small" ForeColor="Navy" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <asp:Label ID="lblEmpleado_Op1" runat="server" SkinID="SkinLblMsjExito" 
                                                    Visible="False"></asp:Label>
                                                <asp:Label ID="lblEmpleado2_Op1" runat="server" Font-Names="Verdana" 
                                                    Font-Size="Small" ForeColor="Navy" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="1" style="vertical-align: top; text-align: center">
                                                <br />
                                                <asp:LinkButton ID="lbNuevoCalculoPorPlantel" runat="server" OnClick="lbNuevoCalculoPorPlantel_Click"
                                                    SkinID="SkinLinkButton" Visible="False">Realizar nuevo cálculo</asp:LinkButton>
                                                <br />
                                                <br />
                                                <asp:GridView ID="gvErrores2" runat="server" 
                                                    Caption="Errores durante el cálculo" EmptyDataText="Sin errores" 
                                                    SkinID="SkinGridView" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="RFC" HeaderText="RFC" />
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Error">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer3" EventName="Tick" />
                                <asp:AsyncPostBackTrigger ControlID="btnCalcular" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="lbNuevoCalculoPorPlantel" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:Timer ID="Timer3" runat="server" Enabled="False" Interval="1000">
                        </asp:Timer>
                    </asp:View>
                    <asp:View ID="viewCalculoPersona" runat="server">
                        <table style="width: 100%" align="center">
                            <tr>
                            <td align="center">
                                <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" />
                            </td>
                            </tr>
                        </table>
                        <asp:Timer ID="Timer2" runat="server" Enabled="False" Interval="1000">
                        </asp:Timer>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="pnlPorPersona" runat="server">
                                <br />
                                <asp:Label ID="lblCalculoPersonaFinalizado" runat="server" SkinID="SkinLblMsjExito"
                                    Text="Cálculo finalizado." Visible="False"></asp:Label>
                                &nbsp;<asp:LinkButton ID="lbNuevoCalculo" runat="server" OnClick="lbNuevoCalculo_Click"
                                    SkinID="SkinLinkButton" Visible="False">Realizar nuevo cálculo</asp:LinkButton>
                                <br />
                                <asp:GridView ID="gvErrores1" runat="server" 
                                    Caption="Errores durante el cálculo" EmptyDataText="No hubo errores" 
                                    SkinID="SkinGridView" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="RFC" HeaderText="RFC" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Error">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnCalcular" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <table align="center">
                                    <tbody>
                                        <tr>
                                            <td style="vertical-align: top; text-align: left" rowspan="2">
                                                <asp:Image ID="imgCalcuandoPersona" runat="server" ImageUrl="~/Imagenes/spinner.gif" />
                                            </td>
                                            <td style="text-align: left">
                                                <asp:Label ID="lblCalculandoPersona" runat="server" SkinID="SkinLblMsjExito" Text="Calculando, por favor espere..."></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
</asp:Content>
