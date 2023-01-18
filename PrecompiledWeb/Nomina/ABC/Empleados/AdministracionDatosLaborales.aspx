<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="ABC_Empleados_AdministracionDatosLaborales, App_Web_afkwdrmm" title="COBAEV - Nómina - Administrar datos laborales" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <div>
        <table style="width: 100%; height: 100%">
            <tr>
                <td style="vertical-align: top; text-align: right">
                    <h2>
                        Sistema de nómina: Administrar datos laborales
                    </h2>
                </td>
            </tr>
            <tr>
                <td style="text-align: left">
                <asp:UpdatePanel ID="UpdPnlMain" runat="server">
                <ContentTemplate>
                    <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="viewDatosLab" runat="server">
                            <asp:DetailsView ID="dvDatosLab" runat="server" AutoGenerateRows="False" CellPadding="1"
                                DefaultMode="Edit" EmptyDataText="Sin información de antigüedad" HeaderText="Modificando datos laborales"
                                SkinID="SkinDetailsView">
                                <Fields>
                                    <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                        <HeaderStyle Wrap="False" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="N&#250;mero de empleado">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtbxNumEmp" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                Text='<%# Bind("NumEmp") %>' Width="80px" ReadOnly="True"></asp:TextBox>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Homologa en semestres A">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="ChBxHomEnSemA" runat="server" Checked='<%# Bind("HomologaEnSemestreA") %>'
                                                AutoPostBack="True" OnCheckedChanged="ChBxHomEnSemA_CheckedChanged" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Categor&#237;a homologada semestre A">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdCatSemA" runat="server" Text='<%# Bind("IdCatSemA") %>' Visible="False"></asp:Label><asp:UpdatePanel
                                                ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlCategosSemA" runat="server" SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVddlCategosSemA" runat="server" ControlToValidate="ddlCategosSemA"
                                                        Display="None" ErrorMessage="Seleccione categoría para homologar en los semestres A"
                                                        InitialValue="-1"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ChBxHomEnSemA" EventName="CheckedChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </EditItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Zona econ&#243;mica homologaci&#243;n Semestre A">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdZonaEcoA" runat="server" Text='<%# Bind("IdZonaEcoA") %>' Visible="False"></asp:Label><asp:UpdatePanel
                                                ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlZonasEcoA" runat="server" SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ChBxHomEnSemA" EventName="CheckedChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </EditItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Homologa en semestres B">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="ChBxHomEnSemB" runat="server" Checked='<%# Bind("HomologaEnSemestreB") %>'
                                                AutoPostBack="True" OnCheckedChanged="ChBxHomEnSemB_CheckedChanged" />
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="True" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Categor&#237;a homologada semestre B">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdCatSemB" runat="server" Text='<%# Bind("IdCatSemB") %>' Visible="False"></asp:Label><asp:UpdatePanel
                                                ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlCategosSemB" runat="server" SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFVddlCategosSemB" runat="server" ControlToValidate="ddlCategosSemB"
                                                        Display="None" ErrorMessage="Seleccione categoría para homologar en los semestres B"
                                                        InitialValue="-1"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ChBxHomEnSemB" EventName="CheckedChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Zona econ&#243;mica homologaci&#243;n Semestre B">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdZonaEcoB" runat="server" Text='<%# Bind("IdZonaEcoB") %>' Visible="False"></asp:Label><asp:UpdatePanel
                                                ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlZonasEcoB" runat="server" SkinID="SkinDropDownList">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ChBxHomEnSemB" EventName="CheckedChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </EditItemTemplate>
                                        <HeaderStyle Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Plantel para pago">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdPlantel" runat="server" Text='<%# Bind("IdPlantel") %>' Visible="False"></asp:Label><asp:DropDownList
                                                ID="ddlPlanteles" runat="server" SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar" 
                                                 />
                                            <asp:Button ID="btnGurdar" runat="server" OnClick="btnGurdar_Click" 
                                                SkinID="SkinBoton" Text="Guardar" />
                                            <ajaxToolkit:ConfirmButtonExtender ID="CBEbtnGuardar" runat="server" 
                                                ConfirmText="¿Está seguro de guardar los cambios realizados?" 
                                                TargetControlID="btnGurdar">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" />
                                        </EditItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Fields>
                                <HeaderStyle Font-Names="Verdana" Font-Size="Small" HorizontalAlign="Center" />
                            </asp:DetailsView>
                        </asp:View>
                        <asp:View ID="viewExito" runat="server">
                            <table>
                                <tr>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                                    </td>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito" 
                                            Text="Operación realizada exitosamente."></asp:Label>
                                        <br />
                                        <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server" 
                                            PostBackUrl="~/Consultas/Empleados/DatosCOBAEV.aspx" SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="viewError" runat="server">
                            <table>
                                <tr>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Symbol-Stop.png" Width="100px" />
                                    </td>
                                    <td style="vertical-align: middle; text-align: left">
                                        <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                                        <br />
                                        <asp:LinkButton ID="lbReintentarCaptura" runat="server" SkinID="SkinLinkButton">Reintentar operación</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
