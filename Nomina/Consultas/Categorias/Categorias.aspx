<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="Categorias.aspx.vb" Inherits="Consultas_Categorias"
    Title="COBAEV - Nómina - Categorías" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Categorías</h2>
            </td>
        </tr>
    </table>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewCategosTodas" runat="server">
            <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
                <tr>
                    <td style="text-align: left">
                        <asp:Label ID="Label2" runat="server" Text="Seleccione las opciones para consultar categorías"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="float: left; text-align: left; padding-top: 5px;">
                            <asp:DropDownList ID="ddlFiltroCatego" runat="server">
                                <asp:ListItem Selected="True" Value="0">Todas las categorías</asp:ListItem>
                                <asp:ListItem Value="3">Categorías directivas</asp:ListItem>
                                <asp:ListItem Value="1">Categorías administrativas</asp:ListItem>
                                <asp:ListItem Value="2">Categorías docentes</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:DropDownList ID="ddlFiltroEstatus" runat="server">
                                <asp:ListItem Value="0">Activas/Inactivas</asp:ListItem>
                                <asp:ListItem Selected="True" Value="1">Activas</asp:ListItem>
                                <asp:ListItem Value="2">Inactivas</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:DropDownList ID="ddlFiltroTipoPresup" runat="server">
                                <asp:ListItem Selected="True" Value="0">Presupuesto regular/Recursos propios (con EMSAD)</asp:ListItem>
                                <asp:ListItem Value="1">Presupuesto regular</asp:ListItem>
                                <asp:ListItem Value="2">RecursosPropios</asp:ListItem>
                                <asp:ListItem Value="3">Presupuesto regular (Solo EMSAD)</asp:ListItem>
                                <asp:ListItem Value="4">RecursosPropios (Solo EMSAD)</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;<asp:Button ID="btnConsultar" runat="server" Text="Consultar" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; vertical-align: top;">

                                <asp:GridView ID="gvCategorias" runat="server" CellPadding="1" SkinID="SkinGridView"
                                    Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="IdCategoria" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdCategoria" runat="server" Text='<%# Bind("IdCategoria") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CveIdentificadorPuesto" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCveIdentificadorPuesto" runat="server" Text='<%# Bind("CveIdentificadorPuesto") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ClaveCategoria" HeaderText="Clave (COBAEV)">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Clave Oficial">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCveOfi" Visible="false" runat="server" Text='<%# Bind("CvePuesto") %>'></asp:Label>
                                                <asp:LinkButton ID="lbCveOfi" runat="server" Text='<%# Bind("CvePuesto") %>' OnClick="lbCveOfi_Click"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DescCategoria" HeaderText="Descripción categor&#237;a">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescTipoPlaza" HeaderText="Tipo categor&#237;a">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Activa" HeaderText="Activa">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RecursosPropios" HeaderText="Fondo Presup.">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EMSAD" HeaderText="EMSAD">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SdoMensualZona2" HeaderText="Sdo. Mensual ZE 02" DataFormatString="{0:c}">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SdoMensualZona3" HeaderText="Sdo. Mensual ZE 03" DataFormatString="{0:c}">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Clave compuesta" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCvePuestoCompuesta" Visible="true" runat="server" Text='<%# Bind("CvePuestoCompuesta") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Percepciones">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibPercPorCatego" runat="server" ImageUrl="~/Imagenes/Money.gif"
                                                    ToolTip="Ver percepciones ordinarias asociadas a la categoría" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Empleados">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEmpsPorCatego" runat="server" ImageUrl="~/Imagenes/Empleado.jpg"
                                                    ToolTip="Ver empleados vigentes por categoría" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewCategoDetalle" runat="server">
        <div class="accountInfo">
            <fieldset id="fsCapturaConsulta">
                    <legend>
                        <asp:Label ID="lblEmpInfConsulta" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                    </legend>
                    <div class="pnlCompleto">
                        <asp:DetailsView ID="dvCategoDetalles" runat="server" Height="50px" 
                            SkinID="SkinDetailsView" AutoGenerateRows="False" 
                            HeaderText="Información detallada de la categoría" 
                            HorizontalAlign="Center">
                            <Fields>
                                <asp:BoundField DataField="ClavePuesto" HeaderText="Clave oficial:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescPuesto" HeaderText="Descripción de la categoría:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescIdentificadorPuesto" HeaderText="DescIdentificadorPuesto:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CveGpo" HeaderText="CveGpo:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescGrupo" HeaderText="DescGrupo:" >
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CveRama" HeaderText="CveRama:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescRama" HeaderText="DescRama:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Horas" HeaderText="Horas asociadas a la plaza:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PlazaJornadaHora" HeaderText="Plaza Jornada/Hora-Semana-Mes:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NumPlazasHorasAutZonaE02" HeaderText="Plazas autorizadas Zona 02:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NumPlazasHorasAutZonaE03" HeaderText="Plazas autorizadas Zona 03:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                            </Fields>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <RowStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:DetailsView>
                    </div>
                    </fieldset
            </div>
            <div id="divBotonesConsulta">
                <p class="submitButton">
                    <asp:Button ID="btnCancelar2" runat="server" Text="Regresar" ToolTip="Regresar a consultar categorías"
                        TabIndex="24" />
                </p>
            </div>
        </asp:View>
    </asp:MultiView>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
