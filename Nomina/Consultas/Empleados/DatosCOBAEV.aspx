<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="DatosCOBAEV.aspx.vb" Inherits="DatosCOBAEV"
    Title="COBAEV - Nómina - Datos laborales de los empleados" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucSearchEmps" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Información laboral)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <uc1:wucSearchEmps ID="wucSearchEmps1" runat="server" EnableViewState="true" />
                                    </td>
                                    <td style="vertical-align: top; text-align: right">
                                        &nbsp;<asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                            ToolTip="Actualizar información" Visible="False" /><br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlGral" runat="server">
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEDatosLab" runat="Server" SuppressPostBack="true"
                                            CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ImageControlID="Image1" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                            TextLabelID="Label1" Collapsed="False" CollapseControlID="TitlePanelDatosLab"
                                            ExpandControlID="TitlePanelDatosLab" TargetControlID="ContentPanelDatosLab">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEDatosPlazas" runat="Server" SuppressPostBack="true"
                                            CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ImageControlID="Image2" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                            TextLabelID="Label2" Collapsed="False" CollapseControlID="TitlePanelDatosPlazas"
                                            ExpandControlID="TitlePanelDatosPlazas" TargetControlID="ContentPanelDatosPlazas">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEDatosAcademicos" runat="Server" SuppressPostBack="true"
                                            CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ImageControlID="Image3" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                            TextLabelID="Label3" Collapsed="False" CollapseControlID="TitlePanelDatosAcademicos"
                                            ExpandControlID="TitlePanelDatosAcademicos" TargetControlID="ContentPanelDatosAcademicos">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEAntiguedad" runat="server" SuppressPostBack="true"
                                            CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ImageControlID="Image5" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                            TextLabelID="Label5" Collapsed="False" CollapseControlID="TitlePanelAntiguedad"
                                            ExpandControlID="TitlePanelAntiguedad" TargetControlID="ContentPanelAntiguedad">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPESegSoc" runat="server" SuppressPostBack="true"
                                            CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ImageControlID="ImgSegSoc" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                            TextLabelID="LblSegSoc" Collapsed="False" CollapseControlID="TitlePanelSegSoc"
                                            ExpandControlID="TitlePanelSegSoc" TargetControlID="ContentPanelSegSoc">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEPagomatico" runat="server" SuppressPostBack="true"
                                            CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ImageControlID="ImgPagomatico" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                            TextLabelID="LblPagomatico" Collapsed="False" CollapseControlID="TitlePanelPAgomatico"
                                            ExpandControlID="TitlePanelPagomatico" TargetControlID="ContentPanelPagomatico">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                            <tbody>
                                                <tr>
                                                    <td style="vertical-align: top; text-align: left" colspan="2">
                                                        <asp:Label ID="lblEmpInf" runat="server" SkinID="SkinLblDatos" Font-Underline="True"
                                                            Font-Strikeout="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelDatosLab" runat="server" Width="100%" BorderWidth="1px"
                                                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                            Datos laborales
                                                            <asp:Label ID="Label1" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="ContentPanelDatosLab" runat="server" Width="100%" HorizontalAlign="Left" CssClass="collapsePanel">
                                                            <asp:DetailsView ID="dvDatosLab" runat="server"  Width="50%" SkinID="SkinDetailsView" EmptyDataText="Sin información de datos laborales" 
                                                                AutoGenerateRows="False">
                                                                <FieldHeaderStyle Width="65%" />
                                                                <Fields>
                                                                    <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="NumEmp" HeaderText="N&#250;mero de empleado">
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="HomologaEnSemestreA" HeaderText="Homologa en semestres A">
                                                                        <HeaderStyle Wrap="True" />
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="IdCatSemA" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdCatSemA" runat="server" Text='<%# Bind("IdCatSemA") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Categoría homologada semestres A">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCatSemA" runat="server" Text='<%# Bind("ClaveCatSemA") %>' ToolTip='<%# Bind("DescCatSemA") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="ClaveZonaEcoA" 
                                                                        HeaderText="ZE para homologación Semestres A" >
                                                                    <HeaderStyle Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="HomologaEnSemestreB" HeaderText="Homologa en semestres B">
                                                                        <HeaderStyle Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="IdCatSemB" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdCatSemB" runat="server" Text='<%# Bind("IdCatSemB") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Categoría homologada semestres B">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCatSemB" runat="server" Text='<%# Bind("ClaveCatSemB") %>' ToolTip='<%# Bind("DescCatSemB") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="ClaveZonaEcoB" 
                                                                        HeaderText="ZE para homologación Semestres B" >
                                                                    <HeaderStyle Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="IdPlantel" Visible="False">
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IdPlantel") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <InsertItemTemplate>
                                                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IdPlantel") %>'></asp:TextBox>
                                                                        </InsertItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("IdPlantel") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="DescPlantel" HeaderText="Plantel (Adscripción física del empleado)" >
                                                                    <HeaderStyle Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="IdUsuario" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Analista del plantel">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblNombreAnalista" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" Wrap="False"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbModifDatosLab" runat="server">Modificar</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Fields>
                                                            </asp:DetailsView>
                                                        </asp:Panel>
                                                    </td>
                                                 </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelDatosPlazas" runat="server" Width="100%" BorderWidth="1px"
                                                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                            Plazas vigentes
                                                            <asp:Label ID="Label2" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="ContentPanelDatosPlazas" runat="server" Width="100%" CssClass="collapsePanel">
                                                            <asp:GridView ID="gvDatosPlazas" runat="server" EmptyDataText="Empleado no vigente actualmente."
                                                                Height="100%" ShowFooter="True" SkinID="SkinGridView" Width="50%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                                                        <EditItemTemplate>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Plaza(s)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPlazas" runat="server" Text='<%# Bind("Plazas") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ibDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                                                                ToolTip="Ver detalles de la plaza" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ibModificarPlaza" runat="server" CommandName="BtnModif" ImageUrl="~/Imagenes/Modificar.png"
                                                                                ToolTip="Modificar información de la plaza" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ibWarning" runat="server" ImageUrl="~/Imagenes/Warning1.png"
                                                                                ToolTip="Haga click para visualizar un listado de observaciones sobre la plaza." />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelDatosAcademicos" runat="server" Width="100%" BorderWidth="1px"
                                                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader" Visible="false"> 
                                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                            Información sobre plazas base
                                                            <asp:Label ID="Label3" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="ContentPanelDatosAcademicos" runat="server" Width="100%" 
                                                            CssClass="collapsePanel" Visible="false">
                                                            <table>
                                                                <tr>
                                                                    <td style="text-align: center">
                                                                        <asp:LinkButton ID="lbAdmonPlazasBase" runat="server" SkinID="SkinLinkButton" ToolTip="Administrar información sobre las plazas base de un empleado."
                                                                            Visible="False">Consultar</asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                    </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelAntiguedad" runat="server" Width="100%" BorderWidth="1px"
                                                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                            Antigüedad
                                                            <asp:Label ID="Label5" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                    <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="ContentPanelAntiguedad" runat="server" HorizontalAlign="Left" Width="100%" CssClass="collapsePanel">
                                                            <asp:DetailsView ID="dvAntiguedad" runat="server" SkinID="SkinDetailsView"
                                                                EmptyDataText="Sin información de antigüedad" AutoGenerateRows="False" 
                                                                Width="50%">
                                                                <FieldHeaderStyle Width="65%" />
                                                                <Fields>
                                                                    
                                                                    <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="FchIngCOBAEV" DataFormatString="{0:d}" HeaderText="Fecha de ingreso al COBAEV">
                                                                        <HeaderStyle HorizontalAlign="Left" Wrap="False"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="QnaIngCOBAEV" HeaderText="Quincena de ingreso al COBAEV">
                                                                        <HeaderStyle HorizontalAlign="Left" Wrap="False"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="AniosAnt" HeaderText="A&#241;o(s)">
                                                                        <HeaderStyle HorizontalAlign="Left" Wrap="False"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="MesesAnt" HeaderText="Mes(es)">
                                                                        <HeaderStyle HorizontalAlign="Left" Wrap="False"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="DiasAnt" HeaderText="D&#237;a(s)">
                                                                        <HeaderStyle HorizontalAlign="Left" Wrap="False"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="QuincenaCalculo" HeaderText="&#218;ltima actualizaci&#243;n">
                                                                        <HeaderStyle HorizontalAlign="Left" Wrap="False"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
                                                                    </asp:BoundField>
                                                                    <asp:CheckBoxField DataField="CobraPrimaAnt" HeaderText="Cobra prima de antig&#252;edad">
                                                                        <HeaderStyle HorizontalAlign="Left" Wrap="False"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Left" Wrap="False"></ItemStyle>
                                                                    </asp:CheckBoxField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbModifAnt" runat="server">Modificar</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                </Fields>
                                                            </asp:DetailsView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelSegSoc" runat="server" Width="100%" BorderWidth="1px" BorderStyle="Solid"
                                                            BorderColor="White" CssClass="collapsePanelHeader">
                                                            <asp:Image ID="ImgSegSoc" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                            Seguridad social
                                                            <asp:Label ID="LblSegSoc" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                      <tr>
                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                        <asp:Panel ID="ContentPanelSegSoc" runat="server" Width="100%" HorizontalAlign="Left" CssClass="collapsePanel">
                                                            <asp:DetailsView ID="dvSegSoc" runat="server" SkinID="SkinDetailsView"
                                                                Height="100%" EmptyDataText="Sin información de seguridad social" AutoGenerateRows="False"
                                                                OnDataBound="dvSegSoc_DataBound" Width="50%">
                                                                <FieldHeaderStyle Width="65%" />
                                                                <Fields>
                                                                    <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="NSS" HeaderText="N&#250;mero de seguridad social" >
                                                                    <HeaderStyle Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="R&#233;gimen pensionario">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRegimenISSSTE" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("RegimenISSSTE") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbModifSegSoc" runat="server">Modificar</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Fields>
                                                            </asp:DetailsView>
                                                        </asp:Panel>
                                                    </td>
                                                    </tr>
          
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelPagomatico" runat="server" Width="100%" BorderWidth="1px"
                                                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                            <asp:Image ID="ImgPagomatico" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg">
                                                            </asp:Image>
                                                            Forma de pago al empleado
                                                            <asp:Label ID="LblPagomatico" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                    <tr>
                                                    <td style="vertical-align: top; width: 50%; text-align: left">
                                                        <asp:Panel ID="ContentPanelPagomatico" runat="server" HorizontalAlign="Left" Width="100%" CssClass="collapsePanel">
                                                            <asp:DetailsView ID="dvPagomatico" runat="server"  SkinID="SkinDetailsView"
                                                                Height="100%" EmptyDataText="Sin información de forma de pago" AutoGenerateRows="False"
                                                                OnDataBound="dvPagomatico_DataBound" Width="50%">
                                                                <FieldHeaderStyle Width="65%" />
                                                                <Fields>
                                                                    <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="NombreCortoBanco" 
                                                                        HeaderText="Banco para depósito" >
                                                                    <HeaderStyle Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="CuentaBancaria" HeaderText="Cuenta bancaria" >
                                                                    <HeaderStyle Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:CheckBoxField DataField="IncluirEnPagomatico" HeaderText="Pagar mediante depósito">
                                                                        <HeaderStyle Wrap="False" />
                                                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                                                    </asp:CheckBoxField>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbModifPagomatico" runat="server">Modificar</asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Fields>
                                                            </asp:DetailsView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="wucSearchEmps1" EventName="PreRender" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
