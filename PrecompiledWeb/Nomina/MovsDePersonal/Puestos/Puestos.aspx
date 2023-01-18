<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="MovsDePersonal_Puestos, App_Web_ofxrrr0r" title="COBAEV - Nómina - Puestos" stylesheettheme="SkinFile" maintainscrollpositiononpostback="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<%@ Register src="../../WebControls/wucAnioQnas.ascx" tagname="wucAnioQnas" tagprefix="TP_wucAnioQnas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <script type="text/javascript">
       // It is important to place this JavaScript code after ScriptManager1
       var xPos, yPos;
       var prm = Sys.WebForms.PageRequestManager.getInstance();

       function BeginRequestHandler(sender, args) {
           if ($get('<%=pnlContent.ClientID%>') != null) {
               // Get X and Y positions of scrollbar before the partial postback
               xPos = $get('<%=pnlContent.ClientID%>').scrollLeft;
               yPos = $get('<%=pnlContent.ClientID%>').scrollTop;
           }
       }

       function EndRequestHandler(sender, args) {
           if ($get('<%=pnlContent.ClientID%>') != null) {
               // Set X and Y positions back to the scrollbar
               // after partial postback
               $get('<%=pnlContent.ClientID%>').scrollLeft = xPos;
               $get('<%=pnlContent.ClientID%>').scrollTop = yPos;
           }
       }

       prm.add_beginRequest(BeginRequestHandler);
       prm.add_endRequest(EndRequestHandler);
 </script>
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Puestos</h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <TP_wucAnioQnas:wucAnioQnas ID="wucAnioQnas1" runat="server" 
                            EnableViewState="true" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" 
                    Text="Consultar puestos" 
                    ToolTip="Consultar puestos de acuerdo a la quincena seleccionada" />
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal"></asp:Label>
                        <br />
                        <asp:Panel ID="pnlHeader" runat="server" ScrollBars="Auto" 
                            BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" >
                            <asp:Table ID="tblHeader" runat="server" BackColor="#990000" CellPadding="1" CellSpacing="0"
                                Font-Bold="True" Font-Names="Verdana" Font-Size="7.5pt" ForeColor="White" GridLines="Both"
                                Width="1000px">
                                <asp:TableRow runat="server">
                                    <asp:TableCell runat="server" HorizontalAlign="Center" Width="20px"></asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Center" Width="60px">Clave</asp:TableCell>
                                    <asp:TableCell runat="server" Width="280px">Puesto</asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Center" Width="70px">Cantidad autorizada</asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Center" Width="50px">Tipo de recurso</asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Center" Width="30px">Z.E.</asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Center" Width="50px">Tipo de puesto</asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Center" Width="100px">Modalidad educativa</asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Center" Width="70px">Basificable</asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Center" Width="50px">Nivel salarial</asp:TableCell>
                                    <asp:TableCell runat="server" HorizontalAlign="Center" Width="50px">Activo</asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:Panel>
                        <asp:Panel ID="pnlContent" runat="server" ScrollBars="Vertical" Height="600px" 
                            BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" >
                        <asp:GridView ID="gvPuestos" runat="server" CellPadding="1" SkinID="SkinGridView"
                            EmptyDataText="Información no disponible." ShowHeader="False" Width="1000px">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True" >
                                    <ItemStyle HorizontalAlign="Center" Wrap="false" Width="20px" />
                                </asp:CommandField>
                                <asp:BoundField DataField="CvePuestoCompuesta" HeaderText="Clave">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="false" Width="60px"/>
                                </asp:BoundField>
                                <asp:BoundField DataField="DescPuesto" HeaderText="Puesto">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="false" Width="280px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Cantidad Autorizada">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbCantidadAut" runat="server" 
                                            Text='<%# Bind("NumPlazasHorasAut") %>' 
                                            ToolTip="Ver plazas autorizadas del puesto en el periodo especificado" onclick="lbCantidadAut_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="false" Width="70px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="TipoDeRecurso" HeaderText="Tipo de recurso">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="false" Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CveZonaEco" HeaderText="Z.E.">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="false" Width="30px" />
                                </asp:BoundField> 
                                <asp:TemplateField HeaderText="Tipo de puesto">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCvePuestoClasif" runat="server" Text='<%# Bind("CvePuestoClasif") %>' ToolTip='<%# Bind("DescPuestoClasif") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="false" Width="50px"/>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ModalidadEducativa" HeaderText="Modalidad Educativa">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="false" Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Basificable">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkBxBasificable" runat="server" Checked='<%# Bind("Basificable") %>' Enabled="false"></asp:CheckBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="false" Width="70px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nivel salarial">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbNivSalarial" runat="server" 
                                            Text='<%# Bind("NivelSalarial") %>' 
                                            ToolTip="Ver información del Nivel Salarial en el periodo especificado" 
                                            onclick="lbNivSalarial_Click"></asp:LinkButton>
                                        <asp:Label ID="lblNivelSalarial" runat="server" 
                                            Text='<%# Bind("NivelSalarial") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="false" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Activo">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkBxActivo" runat="server" Checked='<%# Bind("Activo") %>' Enabled="false"></asp:CheckBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="false" Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnConsultar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
