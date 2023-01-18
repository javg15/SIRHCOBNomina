<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="Consultas_Nomina_DetallePago, App_Web_xh1ifbg5" title="COBAEV - Nómina - Detalle de pago" theme="SkinFile" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 100%" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Información detallada del pago
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <table align="center">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:GridView ID="gvInfEmp" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información del empleado."
                                SkinID="SkinGridView">
                                <Columns>
                                    <asp:BoundField DataField="NumEmp" HeaderText="N.E.">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
<asp:BoundField DataField="RFC" HeaderText="R.F.C.">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
</asp:BoundField>
                                    <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido Paterno">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido Materno">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:GridView ID="gvDetallePago" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe detalle de pago."
                                SkinID="SkinGridView">
                                <Columns>
                                    <asp:BoundField DataField="Horas" HeaderText="Horas">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ClaveCategoria" HeaderText="Categor&#237;a">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DescCategoria" HeaderText="Descripci&#243;n categor&#237;a">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ClaveZonaEco" HeaderText="Zona econ&#243;mica">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <br />
                            <asp:Label ID="lblMsjHistoriaDetallePagoHoras" runat="server" SkinID="SkinLblNormal" 
                                Text="Forma en que la carga horaria participó para el pago."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                                    <asp:GridView ID="gvHistoriaDetallePagoHoras" runat="server" 
                                        AutoGenerateColumns="False" 
                                        EmptyDataText="Información no disponible o no necesaria." 
                                        SkinID="SkinGridView">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Catego. pagada">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatPagada" runat="server" 
                                                        Text='<%# Bind("ClaveCategoriaPago") %>' 
                                                        ToolTip='<%# Bind("DescCategoriaPago") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Hrs ocup.">
                                                <HeaderTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text="Hrs" 
                                                        ToolTip="Horas ocupadas de la materia para el pago de la categoría."></asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHrsOcupMat" runat="server" Text='<%# Bind("HorasPago") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="20px" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ZonaEcoPago" HeaderText="ZE Pago">
                                            <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IdHora" HeaderText="IdHora">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Materia" HeaderText="Materia">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Hrs">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblHrsMateriaHeader" runat="server" 
                                                        ToolTip="Horas asociadas a la materia.">Hrs</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHrsMateria" runat="server" Text='<%# Bind("HorasMateria") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nomb.">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblNombHeader" runat="server" ToolTip="Nombramiento">Nomb</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNomb" runat="server" Text='<%# Bind("AbrevNombramiento") %>' 
                                                        ToolTip='<%# Bind("DescNombramiento") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Grupo" HeaderText="Gpo">
                                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Tipo hora">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTipoHora" runat="server" Text='<%# Bind("TipoHora") %>' 
                                                        ToolTip='<%# Bind("Categoria") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nómina">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTipoNomina" runat="server" 
                                                        Text='<%# Bind("AbrevTipoNomina") %>' 
                                                        ToolTip='<%# Bind("DescTipoNomina") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pl.">
                                                <HeaderTemplate>
                                                    <asp:Label ID="lblPlantelHeader" runat="server" ToolTip="Plantel">Pl.</asp:Label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPlantel" runat="server" Text='<%# Bind("ClavePlantel") %>' 
                                                        ToolTip='<%# Bind("DescPlantel") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="25px" />
                                                <ItemStyle HorizontalAlign="Center" Width="25px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ZonaEcoPlantel" HeaderText="ZE Pl.">
                                            <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QnaIni" HeaderText="Inicio">
                                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QnaFin" HeaderText="Fin">
                                            <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <br />
                            <asp:Label ID="lblMsjHistoriaDetallePagoHoras0" runat="server" SkinID="SkinLblNormal" 
                                
                                Text="Forma en que la carga horaria participó para el pago (Resumen plazas)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:GridView ID="gvHistDetePagoHorasResumenPlazas" runat="server" 
                                AutoGenerateColumns="False" EmptyDataText="No existe detalle de pago para generar resumen de plazas."
                                SkinID="SkinGridView">
                                <Columns>
                                    <asp:BoundField DataField="ClaveCategoriaPago" HeaderText="Categor&#237;a">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DescCategoriaPago" HeaderText="Descripci&#243;n categor&#237;a">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="HorasPago" HeaderText="Horas">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AbrevNombramiento" HeaderText="Nombramiento">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ZonaEcoPago" HeaderText="Zona econ&#243;mica">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: center">
                            <br />
                            <asp:GridView ID="gvDiasPagados" runat="server" AutoGenerateColumns="False" EmptyDataText="No existe información de días pagados."
                                SkinID="SkinGridView">
                                <Columns>
                                    <asp:BoundField DataField="Quincena" HeaderText="Quincena">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Dias" HeaderText="D&#237;as pagados">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: center">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
    <asp:LinkButton ID="lbCerrar" runat="server" SkinID="SkinLinkButton">Cerrar ventana</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>

