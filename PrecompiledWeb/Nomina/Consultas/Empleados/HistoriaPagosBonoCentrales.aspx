<%@ page enableeventvalidation="false" language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_BonoCentrales, App_Web_00vntztu" title="COBAEV - Nómina - Historia pagos bono de productividad por empleado" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
            <h2>
                Sistema de nómina: Historia pagos bono de productividad por empleado
            </h2>
            <asp:Panel ID="pnlBuscaEmps" runat="server">
                <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
            </asp:Panel>
            <asp:Panel ID="pnl1" runat="server" HorizontalAlign="Left">
                <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar" Font-Names="Verdana"
                    Font-Size="X-Small" GroupingText="Seleccione ejercicio" Visible="False">
                    <br />
                    <asp:DropDownList ID="ddlAños" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAños_SelectedIndexChanged"
                        SkinID="SkinDropDownList">
                    </asp:DropDownList>
                    <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" Text="Consultar"
                        ToolTip="Consultar el acumulado anual de subsidio para el empleo del empleado seleccionado"
                        Visible="False" /><br />
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnl2" runat="server"  HorizontalAlign="Left">
                <asp:Panel ID="pnlEmpInf" runat="server" HorizontalAlign="Left">
                    <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                        SkinID="SkinLblDatos">
                    </asp:Label>
                </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="CPEBonosProductividad" runat="Server" CollapseControlID="TitlePnlBonosProductividad"
                    Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                    ExpandControlID="TitlePnlBonosProductividad" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                    ExpandedText="(Ocultar detalles...)" ImageControlID="imgBonosProductividad" SuppressPostBack="true"
                    TargetControlID="ContentPnlBonosProductividad" TextLabelID="lblBonosProductividad">
                </ajaxToolkit:CollapsiblePanelExtender>
                <asp:Panel ID="TitlePnlBonosProductividad" runat="server" BorderColor="White" BorderStyle="Solid"
                    BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                    <asp:Image ID="imgBonosProductividad" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                    &nbsp;Historia de pagos de bono de productividad
                    <asp:Label ID="lblBonosProductividad" runat="server">(Mostrar detalles...)</asp:Label>
                </asp:Panel>
                <asp:Panel ID="ContentPnlBonosProductividad" runat="server" CssClass="collapsePanel"
                    Width="100%">
                    <asp:GridView ID="gvBonosProductividad" runat="server" Height="100%" 
                        SkinID="SkinGridViewEmpty" Width="100%" AutoGenerateColumns="False" 
                        ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:BoundField DataField="Importe" DataFormatString="{0:c}" HeaderText="Importe">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Impuesto" DataFormatString="{0:c}" HeaderText="Impuesto">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaDePago" DataFormatString="{0:d}" HeaderText="Fecha de pago">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <EmptyDataTemplate>
                            <asp:Label ID="lblgvBonosProductividad" runat="server" 
                                SkinID="SkinLblMsjErrores" 
                                Text="No existe información de bonos de prodcutividad pagados al empleado."></asp:Label>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
