<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="AdministracionAntiguedad.aspx.vb" Inherits="ABC_Empleados_AdministracionAntiguedad"
    Title="COBAEV - Nómina - Administrar antigüedad" StylesheetTheme="SkinFile" %>

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
                        Sistema de nómina: Empleados (Administrar antigüedad)
                    </h2>
                </td>
            </tr>
            <tr>
                <td>
                <asp:UpdatePanel ID="UpdPnlMain" runat="server">
                <ContentTemplate>
                    <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="viewAntiguedad" runat="server">
                            <asp:DetailsView ID="dvAntiguedad" runat="server" AutoGenerateRows="False" CellPadding="1"
                                DefaultMode="Edit" EmptyDataText="Sin información de antigüedad" HeaderText="Modificando antigüedad"
                                SkinID="SkinDetailsView">
                                <Fields>
                                    <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                        <HeaderStyle Wrap="False" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha de ingreso al COBAEV">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtbxFchIngCOBAEV" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                                Text='<%# Bind("FchIngCOBAEV", "{0:d}") %>' Width="100px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="txtbxFchIngCOBAEV_CE" runat="server" 
                                                Enabled="True" TargetControlID="txtbxFchIngCOBAEV">
                                            </ajaxToolkit:CalendarExtender>
                                            <asp:CompareValidator
                                                        ID="CVFchIngCOBAEV" runat="server" ControlToValidate="txtbxFchIngCOBAEV" Display="None"
                                                        ErrorMessage="Fecha de ingreso al COBAEV incorrecta" Operator="DataTypeCheck"
                                                        Type="Date"></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="RFVFchINgCOBAEV" runat="server" ControlToValidate="txtbxFchIngCOBAEV"
                                                Display="None" ErrorMessage="Omitió escribir la fecha de ingreso al COBAEV"></asp:RequiredFieldValidator><asp:RangeValidator
                                                    ID="RVFchINgCOBAEV" runat="server" ControlToValidate="txtbxFchIngCOBAEV" Display="None"
                                                    ErrorMessage="Rango permitido para fecha de ingreso al COBAEV" MinimumValue="30/07/1988"
                                                    Type="Date"></asp:RangeValidator><asp:HiddenField ID="hfFchIngCOBAEV" runat="server" />
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quincena de ingreso al COBAEV">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtbxQnaIngCOBAEV" runat="server" Text='<%# Bind("QnaIngCOBAEV") %>'
                                                SkinID="SkinTextBox" Width="100px" MaxLength="6"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender
                                                    ID="FTBEQnaIngCOBAEV" runat="server" FilterType="Numbers" TargetControlID="txtbxQnaIngCOBAEV">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            &nbsp;
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="A&#241;o(s)">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtbxAnios" runat="server" Text='<%# Bind("AniosAnt") %>' MaxLength="2"
                                                SkinID="SkinTextBox" Width="100px"></asp:TextBox><asp:RangeValidator ID="RVAnios"
                                                    runat="server" ControlToValidate="txtbxAnios" Display="None" ErrorMessage="Rango permitido para los años [0-50]"
                                                    MaximumValue="50" MinimumValue="0" Type="Integer"></asp:RangeValidator><asp:RequiredFieldValidator
                                                        ID="RFVAnios" runat="server" ControlToValidate="txtbxAnios" Display="None" ErrorMessage="Omitió escribir los años"></asp:RequiredFieldValidator><ajaxToolkit:FilteredTextBoxExtender
                                                            ID="FTBEAnios" runat="server" FilterType="Numbers" TargetControlID="txtbxAnios">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mes(es)">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtbxMeses" runat="server" Text='<%# Bind("MesesAnt") %>' MaxLength="2"
                                                SkinID="SkinTextBox" Width="100px"></asp:TextBox><asp:RequiredFieldValidator ID="RFVMeses"
                                                    runat="server" ControlToValidate="txtbxMeses" Display="None" ErrorMessage="Omitió escribir los meses"></asp:RequiredFieldValidator><asp:RangeValidator
                                                        ID="RVMeses" runat="server" ControlToValidate="txtbxMeses" Display="None" ErrorMessage="Rango permitido para meses [0-12]"
                                                        MaximumValue="12" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FTBEMeses" runat="server" FilterType="Numbers"
                                                TargetControlID="txtbxMeses">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="D&#237;a(s)">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtbxDias" runat="server" Text='<%# Bind("DiasAnt") %>' MaxLength="2"
                                                SkinID="SkinTextBox" Width="100px"></asp:TextBox>
                                            <ajaxToolkit:NumericUpDownExtender ID="txtbxDias_NumericUpDownExtender" 
                                                runat="server" Enabled="True" Maximum="15" Minimum="0" RefValues="" 
                                                ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Step="15" Tag="" 
                                                TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtbxDias" 
                                                Width="80">
                                            </ajaxToolkit:NumericUpDownExtender>
                                            <asp:RequiredFieldValidator ID="RFVDias"
                                                    runat="server" ControlToValidate="txtbxDias" Display="None" ErrorMessage="Omitió escribir los días"></asp:RequiredFieldValidator><asp:RangeValidator
                                                        ID="RVDias" runat="server" ControlToValidate="txtbxDias" 
                                                Display="None" ErrorMessage="Rango permitido para días [0-15]"
                                                        MaximumValue="15" MinimumValue="0" Type="Integer"></asp:RangeValidator><ajaxToolkit:FilteredTextBoxExtender
                                                            ID="FTBEDias" runat="server" TargetControlID="txtbxDias" 
                                                ValidChars="015">
                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#218;ltima actualizaci&#243;n">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtbxQuincenaCalculo" runat="server" MaxLength="6" SkinID="SkinTextBox"
                                                Text='<%# Bind("QuincenaCalculo") %>' Width="100px"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FTBEQuincenaCalcul" runat="server" FilterType="Numbers"
                                                TargetControlID="txtbxQuincenaCalculo">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cobra prima de antig&#252;edad">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="chkbxCobraPrimaAnt" runat="server" Checked='<%# Bind("CobraPrimaAnt") %>'
                                                SkinID="SkinCheckBox" />
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar" 
                                                 />
                                            <asp:Button ID="btnGurdar" runat="server" SkinID="SkinBoton" Text="Guardar" OnClick="btnGurdar_Click" /><ajaxToolkit:ConfirmButtonExtender
                                                ID="CBEbtnGuardar" runat="server" ConfirmText="¿Está seguro de guardar los cambios realizados?"
                                                TargetControlID="btnGurdar">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                            <asp:ValidationSummary ID="VSAntiguedad" runat="server" ShowMessageBox="True" ShowSummary="False" />
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
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
