<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="Consultas_Categorias_EmpleadosVigentes, App_Web_4tj0l1t0" title="COBAEV - Nómina - Empleados vigentes por categoría" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center; height: 100%;">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados vigentes por categoría
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:Label ID="LblCategoria" runat="server" Font-Strikeout="False" Font-Underline="False"
                    SkinID="SkinLblMsjExito">Categoría</asp:Label><br />
                <asp:GridView ID="gvCategoria" runat="server" SkinID="SkinGridView">
                    <Columns>
                        <asp:TemplateField HeaderText="Clave">
                            <FooterTemplate>
                                <br />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblClaveCategoria" runat="server" Text='<%# Bind("ClaveCategoria") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DescCategoria" HeaderText="Categor&#237;a" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top; height: 21px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="LblEmpsPorCatego" runat="server" Font-Strikeout="False" Font-Underline="False"
                            SkinID="SkinLblMsjExito">Empleados vigentes:</asp:Label><br />
                        <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                            EmptyDataText="No existen empleados vigentes para la categoría o no tiene permisos para visualizarlos" Font-Names="Verdana"
                            Font-Size="X-Small" PageSize="20" SkinID="SkinGridView" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="RFC">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkbtnrfc" runat="server" CommandName="CmdRFC" Text='<%# databinder.eval(container, "dataitem.rfc") %>'
                                            ToolTip="Seleccionar el empleado para consultas"></asp:LinkButton>
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
    </table>
</asp:Content>

