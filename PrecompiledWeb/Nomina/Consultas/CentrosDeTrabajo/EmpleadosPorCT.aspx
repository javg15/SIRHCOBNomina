<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="Administracion_EmpleadosPorCT, App_Web_0dtt50oc" title="COBAEV - Nómina - Empleados por centro de trabajo" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados vigentes por centro de trabajo
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Label ID="LblCT" runat="server" Font-Strikeout="False" Font-Underline="False"
                    SkinID="SkinLblMsjExito">Centro de trabajo:</asp:Label><br />
                <asp:GridView ID="gvCT" runat="server" SkinID="SkinGridView">
                    <Columns>
                        <asp:BoundField DataField="ClaveCT" HeaderText="Clave" />
                        <asp:BoundField DataField="NombreCT" HeaderText="Centro de trabajo" />
                        <asp:BoundField DataField="DescTipoCT" HeaderText="Tipo" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="LblEmpsPorCT" runat="server" Font-Strikeout="False" Font-Underline="False"
                            SkinID="SkinLblMsjExito">Empleados:</asp:Label><br />
                        <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                            EmptyDataText="No existen empleados o no tiene permisos para visualizarlos" Font-Names="Verdana" Font-Size="X-Small"
                            PageSize="20" SkinID="SkinGridView" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="RFC">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnrfc" runat="server" CommandName="CmdRFC" Text='<%# databinder.eval(container, "dataitem.rfc") %>' ToolTip="Seleccionar el empleado para consultas"></asp:LinkButton>
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                            TargetControlID="lnkbtnrfc">
                                        </ajaxToolkit:ConfirmButtonExtender>
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
                                <asp:TemplateField HeaderText="Funci&#243;n">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmpFuncion" runat="server" Text='<%# Bind("EmpFuncion") %>'></asp:Label>
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
                                <asp:BoundField DataField="NombreFuncionPri" HeaderText="Funci&#243;n primaria" />
                                <asp:BoundField DataField="NombreFuncionSec" HeaderText="Funci&#243;n secundaria" />
                            </Columns>
                            <HeaderStyle CssClass="dgheader" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

