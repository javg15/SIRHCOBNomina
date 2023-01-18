<%@ Page Language="VB" enableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false" CodeFile="CompenHistoriaPlazas.aspx.vb" Inherits="CompenHistoriaPlazas" title="COBAEV - Nómina - Compensaciones, Nombramientos" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: gratificaciones extraordinarias (nombramientos a personal de solo gratificación extraordinaria)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlBusquedaDePersonas" runat="server" DefaultButton="btnBuscar">
                            <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Buscar empleados por:"></asp:Label><br />
                            <asp:DropDownList ID="ddlTipoBusqueda" runat="server" SkinID="SkinDropDownList" 
                                AutoPostBack="True">
                                <asp:ListItem Value="0">N&#250;mero de empleado</asp:ListItem>
                                <asp:ListItem Value="1">R.F.C.</asp:ListItem>
                                <asp:ListItem Value="2">Nombre</asp:ListItem>
                            </asp:DropDownList>&nbsp;<br />
                            <br />
                            <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Escriba el texto a buscar:"></asp:Label><br />
                            <asp:TextBox ID="txtStrABuscar" runat="server" SkinID="SkinTextBox" Width="362px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtStrABuscar" runat="server" ControlToValidate="txtStrABuscar"
                                Display="Dynamic" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:Button ID="btnbuscar" runat="server" SkinID="SkinBoton" Text="Buscar" /><br />
                            <br />
                            <asp:Label ID="lbltipobusqueda" runat="server" Font-Strikeout="False" Font-Underline="True"
                                SkinID="SkinLblDatos"></asp:Label><asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False"
                                    CaptionAlign="Left" EmptyDataText="No hubo coincidencias" Font-Names="Verdana"
                                    Font-Size="X-Small" PageSize="20" SkinID="SkinGridView">
                                    <Columns>
                                        <asp:TemplateField HeaderText="RFC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRFC" runat="server" Text='<%# databinder.eval(container, "dataitem.rfc") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CURP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCURP" runat="server" Text='<%# Bind("curp") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Apellido paterno">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApePat" runat="server" Text='<%# Bind("apellido_paterno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Apellido materno">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApeMat" runat="server" Text='<%# Bind("apellido_materno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("nombre") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="N&#250;mero de empleado">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("numemp") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle CssClass="dgheader" />
                                </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="left" style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UPPlazas" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblAdvertencia" runat="server" SkinID="SkinLblMsjErrores" 
                            Visible="False"></asp:Label>
                        &nbsp;<asp:LinkButton ID="lbAddPlaza" runat="server" SkinID="SkinLinkButton" 
                            Visible="False" Font-Size="Small">Agregar nombramiento</asp:LinkButton>
                        <br />
                        <br />
                        <asp:GridView ID="gvPlazas" runat="server" AutoGenerateColumns="False" 
                            SkinID="SkinGridView" Caption="Nombramientos" CaptionAlign="Left" 
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo Categoría">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEmpFuncion" runat="server" Text='<%# Bind("IdEmpFuncion") %>' 
                                             Visible="False"></asp:Label>
                                        <asp:Label ID="lblDescEmpFuncion" runat="server" Text='<%# Bind("DescEmpFuncion") %>' ></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plantel">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPlantel" runat="server" Text='<%# Bind("IdPlantel") %>' 
                                             Visible="False"></asp:Label>
                                        <asp:Label ID="lblPlantel" runat="server" Text='<%# Bind("Plantel") %>' ></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="C.T.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdCT" runat="server" Text='<%# Bind("IdCT") %>' 
                                             Visible="False"></asp:Label>
                                        <asp:Label ID="lblCT" runat="server" Text='<%# Bind("CT") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="C.T. Secundario">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdCTSec" runat="server" Text='<%# Bind("IdCTSec") %>' 
                                             Visible="False"></asp:Label>
                                        <asp:Label ID="lblCTS" runat="server" Text='<%# Bind("CTS") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Categoría">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdCategoria" runat="server" Text='<%# Bind("IdCategoria") %>' 
                                             Visible="False"></asp:Label>
                                        <asp:Label ID="lblCategoria" runat="server" Text='<%# Bind("Categoria") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Función Primaria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdFuncionPri" runat="server" Text='<%# Bind("IdFuncionPri") %>' 
                                             Visible="False"></asp:Label>
                                        <asp:Label ID="lblFuncionPri" runat="server" Text='<%# Bind("FuncionPri") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Función Secundaria">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdFuncionSec" runat="server" Text='<%# Bind("IdFuncionSec") %>' 
                                             Visible="False"></asp:Label>
                                        <asp:Label ID="lblFuncionSec" runat="server" Text='<%# Bind("FuncionSec") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inicio">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQuincenaIni" runat="server" Text='<%# Bind("IdQuincenaIni") %>' 
                                             Visible="False"></asp:Label>
                                        <asp:Label ID="lblInicio" runat="server" Text='<%# Bind("Inicio") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fin">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdQuincenaFin" runat="server" Text='<%# Bind("IdQuincenaFin") %>' 
                                             Visible="False"></asp:Label>
                                        <asp:Label ID="lblFin" runat="server" Text='<%# Bind("Fin") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Motivo baja">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdMotGralBaja" runat="server" Text='<%# Bind("IdMotGralBaja") %>' 
                                             Visible="False"></asp:Label>
                                        <asp:Label ID="lblMotivoGralBaja" runat="server" Text='<%# Bind("MotivoGralBaja") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="¿Está físicamente?">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chbkEstaFisic" runat="server" SkinID="SkinCheckBox" Enabled="false"
                                        Checked='<%# Bind("EstaFisicamente2") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="¿Dar prioridad a nombramiento de Grat. Ext.?">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chbkPrioridadNombComp" runat="server" SkinID="SkinCheckBox"  Enabled="false"
                                        Checked='<%# Bind("PrioridadNombCompen2") %>'/>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibModify" runat="server" 
                                            ImageUrl="~/Imagenes/Modificar.png" 
                                            ToolTip="Modificar información del nombramiento" 
                                            onclick="ibModify_Click" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibDelete" runat="server" 
                                            ImageUrl="~/Imagenes/Eliminar.png" 
                                            ToolTip="Eliminar nombramiento" 
                                            onclick="ibDelete_Click" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="ibDelete_CBE" runat="server" 
                                            ConfirmText="¿Está seguro de eliminar el registro?" Enabled="True" 
                                            TargetControlID="ibDelete">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvEmpleados" EventName="SelectedIndexChanged">
                        </asp:AsyncPostBackTrigger>
                        <asp:AsyncPostBackTrigger ControlID="btnbuscar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

