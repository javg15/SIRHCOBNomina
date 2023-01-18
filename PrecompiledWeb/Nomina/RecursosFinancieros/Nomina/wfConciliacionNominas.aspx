<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="wfConciliacionNominas, App_Web_vivguihd" title="COBAEV - Nómina - Conciliación nóminas" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="~/WebControls/wucMuestraErrores.ascx" TagName="wucMuestraErrores"
    TagPrefix="uc3" %>
<%@ Register Src="~/WebControls/wucCalendario.ascx" TagName="wucCalendario" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
            <table style="width: 100%; vertical-align: top;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: right">
                        <h2>
                            Sistema de nómina: Conciliación de nóminas quincenales/mensuales
                        </h2>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlTiposDeCheques" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                GroupingText="Seleccione tipo de pago a conciliar" HorizontalAlign="Left">
                <asp:DropDownList ID="ddlTiposDeCheques" runat="server" SkinID="SkinDropDownList"
                    AutoPostBack="True">
                    <asp:ListItem Value="N" Text="Nóminas"></asp:ListItem>
                    <asp:ListItem Value="C" Text="Compensaciones"></asp:ListItem>
                </asp:DropDownList>
                <asp:Image ID="imgCheckTipoCheque" runat="server" ImageUrl="~/Imagenes/check.png"
                    Visible="False" />
                <asp:Image ID="imgNoCheckTipoCheque" runat="server" ImageUrl="~/Imagenes/nocheck.png"
                    Visible="False" />
            </asp:Panel>
            <asp:Panel ID="pnlAños" runat="server" Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione año"
                HorizontalAlign="Left">
                <asp:DropDownList ID="ddlAños" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Image ID="imgCheckAnio" runat="server" ImageUrl="~/Imagenes/check.png" Visible="False" />
                <asp:Image ID="imgNoCheckAnio" runat="server" ImageUrl="~/Imagenes/nocheck.png" Visible="False" />
            </asp:Panel>
            <asp:Panel ID="pnlMeses" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                GroupingText="Seleccione mes" HorizontalAlign="Left">
                <asp:DropDownList ID="ddlMeses" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Image ID="imgCheckMes" runat="server" ImageUrl="~/Imagenes/check.png" Visible="False" />
                <asp:Image ID="imgNoCheckMes" runat="server" ImageUrl="~/Imagenes/nocheck.png" Visible="False" />
            </asp:Panel>
            <asp:Panel ID="pnlCompenAfectacion" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                GroupingText="Seleccione Afectación" HorizontalAlign="Left">
                <asp:DropDownList ID="ddlCompenAfect" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Image ID="imgCheckCompenAfect" runat="server" ImageUrl="~/Imagenes/check.png" Visible="False" />
                <asp:Image ID="imgNoCheckCompenAfect" runat="server" ImageUrl="~/Imagenes/nocheck.png" Visible="False" />
            </asp:Panel>
            <asp:Panel ID="pnlQnas" runat="server" Font-Names="Verdana" Font-Size="X-Small" GroupingText="Seleccione quincena"
                HorizontalAlign="Left">
                <asp:DropDownList ID="ddlQnas" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Image ID="imgCheckQna" runat="server" ImageUrl="~/Imagenes/check.png" Visible="False" />
                <asp:Image ID="imgNoCheckQna" runat="server" ImageUrl="~/Imagenes/nocheck.png" Visible="False" />
            </asp:Panel>
            <asp:Panel ID="pnldivBotonesErrores" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                BorderStyle="None">
                <div id="divBotones1">
                    <p class="submitButton">
                        <asp:Button ID="btnConsultar" runat="server" Text="Aplicar parámetros de consulta"
                            ToolTip="" />
                        <asp:Button ID="btnCambiarPrmsCons" runat="server" Text="Cambiar parámetros de consulta"
                            ToolTip="" />
                    </p>
                </div>
            </asp:Panel>
            <asp:MultiView ID="mvCheques" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewCheques" runat="server">
            <asp:Panel ID="pnldivBotonesErrores2" runat="server" Font-Names="Verdana" Font-Size="X-Small"
                BorderStyle="None">
                <div id="divBotones2">
                    <p class="submitButton">
                    <asp:Button ID="btnExportarEXCEL" runat="server" 
                        Text="Visualizar reporte en EXCEL" ToolTip="" />
                    </p>
                </div>
            </asp:Panel>
                    <asp:GridView ID="gvConciliacion" runat="server" SkinID="SkinGridView" 
                        EmptyDataText="Los parámetros de consulta no regresaron ningún valor." 
                        Width="100%" ShowFooter="true" Visible="false">
                        <Columns>
                            <asp:BoundField DataField="ClavePlantel" HeaderText="Clave plantel">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DescPlantel" HeaderText="Descripción plantel">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Comentarios" HeaderText="Comentarios">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TipoPago" HeaderText="Tipo de pago">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ImporteNomina" DataFormatString="{0:c}" 
                                HeaderText="Importe nómina">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ImportePensionAlim" DataFormatString="{0:c}" 
                                HeaderText="Importe P.A.">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ImporteTotalRadicacion" DataFormatString="{0:c}" 
                                HeaderText="Importe Total">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
