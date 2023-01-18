<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="InconsistenciasSobreCargaHoraria, App_Web_moehzfda" title="COBAEV - Nómina - Inconsistencias en carga horaria" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados (Inconsistencias basadas en carga horaria)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ibActualizar" runat="server" ImageUrl="~/Imagenes/Refresh.jpg"
                                ToolTip="Actualizar información" />
                        </td>
                        <td style="text-align: right">
                            <asp:LinkButton ID="lbVentanaInd" runat="server" SkinID="SkinLinkButton" Visible="False">Ver en ventana independiente</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvInconsistencias" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                            Font-Names="Verdana" Font-Size="X-Small" PageSize="20" SkinID="SkinGridView"
                            Width="100%">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdSemestre" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdSemestre" runat="server" Text='<%# Bind("IdSemestre") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RFC">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnrfc" runat="server" CommandName="CmdRFC" Text='<%# databinder.eval(container, "dataitem.rfcemp") %>'
                                            ToolTip="Seleccionar el empleado para consultas"></asp:LinkButton>
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                            TargetControlID="lnkbtnrfc">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CURP">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCURP" runat="server" Text='<%# Bind("CURPEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido paterno">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApePat" runat="server" Text='<%# Bind("ApePatEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido materno">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApeMat" runat="server" Text='<%# Bind("ApeMatEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NomEmp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Número de empleado">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("numemp") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plantel">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlantel" runat="server" Text='<%# Bind("ClavePlantel") %>' ToolTip='<%# Bind("DescPlantel") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibWarning" runat="server" ImageUrl="~/Imagenes/Warning1.png" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="dgheader" />
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ibActualizar" EventName="Click" />
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
