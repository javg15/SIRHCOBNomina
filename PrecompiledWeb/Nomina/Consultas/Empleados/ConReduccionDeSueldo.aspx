<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Consultas_Empleados_ConReduccionDeSueldo, App_Web_00vntztu" title="COBAEV - Nómina - Empleados con reducción de sueldo" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Empleados con reducción de sueldo
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="gvEmps" runat="server" EmptyDataText="No hay empleados con reducción de sueldo actualmente."
                    SkinID="SkinGridView">
                    <Columns>
                        <asp:TemplateField HeaderText="IdEmp" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IdEmp") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="N&#250;m. Emp.">
                            <ItemTemplate>
                                <asp:Label ID="lblNumEmp" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("NumEmp") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="RFC">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbRFC" runat="server" ToolTip="Seleccionar el empleado para consultas" CommandName="CmdRFC" Text='<%# Bind("RFCEmp") %>'></asp:LinkButton>
                                <ajaxToolkit:ConfirmButtonExtender ID="CBEEmpSel" runat="server" ConfirmText="¿Seleccionar empleado para consultas posteriores?"
                                            TargetControlID="lbRFC">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CURP">
                            <ItemTemplate>
                                <asp:Label ID="lblCURP" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("CURPEmp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="A. Paterno">
                            <ItemTemplate>
                                <asp:Label ID="lblApePat" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("ApePatEmp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="A. Materno">
                            <ItemTemplate>
                                <asp:Label ID="lblApeMat" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("ApeMatEmp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("NomEmp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PorcDesc" HeaderText="Porc. Desc.">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="IdQnaIni" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("IdQnaIni") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("IdQnaIni") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Inicio" HeaderText="Inicio">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="IdQnaFin" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("IdQnaFin") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("IdQnaFin") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Termino" HeaderText="Fin">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
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

