<%@ page enableeventvalidation="false" language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="frmRelArchConExpDig, App_Web_afkwdrmm" title="COBAEV - Nómina - Expedientes digitales (Asociar archivos a empleados)" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 300px" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Expedientes digitales (Asociar documentos a empleados)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnl1" runat="server" Visible="true">
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CPEExpedientes" runat="Server" SuppressPostBack="true"
                                            CollapsedImage="~/Imagenes/expand_blue.jpg" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                                            ImageControlID="Image2" CollapsedText="(Mostrar detalles...)" ExpandedText="(Ocultar detalles...)"
                                            TextLabelID="Label2" Collapsed="False" CollapseControlID="TitlePanelExpediente"
                                            ExpandControlID="TitlePanelExpediente" TargetControlID="ContentPanelExpediente">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                            <tbody>
                                                <tr>
                                                    <td style="vertical-align: top; text-align: left" colspan="2">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left">
                                                        <asp:Panel ID="TitlePanelExpediente" runat="server" Width="100%" BorderWidth="1px"
                                                            BorderStyle="Solid" BorderColor="White" CssClass="collapsePanelHeader">
                                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg"></asp:Image>
                                                            &nbsp;Archivos a relacionar a expedientes digitales
                                                            <asp:Label ID="Label2" runat="server">(Mostrar detalles...)</asp:Label>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: top; width: 100%; text-align: left;">
                                                        <asp:Panel ID="ContentPanelExpediente" runat="server" Width="100%" CssClass="collapsePanel">
                                                            <asp:GridView ID="gvDocumentos" runat="server" AutoGenerateColumns="False" 
                                                                CellPadding="4" SkinID="SkinGridView" EmptyDataText="No hay archivos a relacionar con expedientes digitales."
                                                                OnRowDataBound="gvDocumentos_RowDataBound">
                                                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:Image ID="ibWarning" runat="server" ImageUrl="~/Imagenes/Warning1.png"
                                                                                ToolTip="Registro con inconsistencias." Visible="false" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Nombre archivo">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblNomArchOld" runat="server" Text='<%# Bind("NomArchivo") %>' 
                                                                                Visible="False"></asp:Label>
                                                                            <asp:TextBox ID="tbNomArch" runat="server" SkinID="SkinTextBox" 
                                                                                Text='<%# Bind("NomArchivo") %>' MaxLength="9"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="rfvNomArch" runat="server" 
                                                                                ControlToValidate="tbNomArch" Display="None" 
                                                                                ErrorMessage="Olvidó escribir el nuevo nombre." ValidationGroup="gpoNomArch"></asp:RequiredFieldValidator>
                                                                            <asp:CompareValidator ID="cvNomArch" runat="server" 
                                                                                ControlToValidate="tbNomArch" Display="None" 
                                                                                ErrorMessage="Solo utilice números para el nuevo nombre." 
                                                                                Operator="DataTypeCheck" Type="Integer" ValidationGroup="gpoNomArch"></asp:CompareValidator>
                                                                            <asp:RegularExpressionValidator ID="revNomArch" runat="server" 
                                                                                ControlToValidate="tbNomArch" Display="None" 
                                                                                ErrorMessage="Debe contener exactamente 9 números el nuevo nombre." 
                                                                                ValidationExpression="\d{9}" ValidationGroup="gpoNomArch"></asp:RegularExpressionValidator>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblNomArch" runat="server" Text='<%# Bind("NomArchivo") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Operaciones<br />con archivo">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ibRenameFile" runat="server"
                                                                                    CausesValidation="False" ImageUrl="~/Imagenes/Replace.png" 
                                                                                ToolTip="Renombrar archivo" onclick="ibRenameFile_Click" />
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:ImageButton ID="ibGuardar" runat="server" 
                                                                                ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar archivo con nuevo nombre" 
                                                                                onclick="ibGuardar_Click" ValidationGroup="gpoNomArch" />
                                                                            &nbsp;<asp:ImageButton ID="ibCancelar" runat="server" CausesValidation="False" 
                                                                                ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar operación" 
                                                                                onclick="ibCancelar_Click" />
                                                                        </EditItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Nuevo Doc.">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ibVerDoc" runat="server"
                                                                                    CausesValidation="False" ImageUrl="~/Imagenes/Detalles.png" 
                                                                                ToolTip="Ver nuevo documento en formato PDF" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Agregar Doc.<br />a Exp.">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ibAddDoc" runat="server"
                                                                                    CausesValidation="False" ImageUrl="~/Imagenes/AddDoc.png" 
                                                                                ToolTip="Agregar documento al expediente del empleado" 
                                                                                onclick="ibAddDoc_Click" />
                                                                            <ajaxToolkit:ConfirmButtonExtender ID="ibAddDoc_ConfirmButtonExtender" 
                                                                                runat="server" 
                                                                                ConfirmText="Si el documento ya existe en el expediente del empleado, será reemplazado. ¿Agregar documento a expediente del empelado?" 
                                                                                Enabled="True" TargetControlID="ibAddDoc">
                                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Clave">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCveDoc" runat="server" Text='<%# Bind("CveDoc") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Descripción">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDescDoc" runat="server" Text='<%# Bind("DescDoc") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="NumPag" HeaderText="No. hoja" ReadOnly="True">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Núm. Emp">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("NumEmp") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Nombre del empleado">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblNomEmp" runat="server" Text='<%# Bind("NomEmp") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="IdDoc" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdDoc" runat="server" Text='<%# Bind("IdDoc") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                     </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="IdEmp" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Ver Exp.">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ibVerExp" runat="server"
                                                                                    CausesValidation="False" ImageUrl="~/Imagenes/VerExpediente.gif" 
                                                                                ToolTip="Ver expediente digital del empleado" onclick="ibVerExp_Click" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Doc. actual">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ibVerDoc2" runat="server"
                                                                                    CausesValidation="False" ImageUrl="~/Imagenes/Detalles.png" 
                                                                                ToolTip="Ver documento existente en formato PDF" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Eliminar">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/Eliminar.png"
                                                                                 ToolTip="Eliminar documento" onclick="ibEliminar_Click" />
                                                                            <ajaxToolkit:ConfirmButtonExtender ID="CFEEliminar" runat="server" ConfirmText="¿Está seguro de eliminar el documento?"
                                                                                TargetControlID="ibEliminar">
                                                                            </ajaxToolkit:ConfirmButtonExtender>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <FooterStyle Font-Bold="True" />
                                                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                                <HeaderStyle Font-Bold="True" />
                                                                <AlternatingRowStyle BackColor="White" />
                                                            </asp:GridView>
                                                            <asp:ValidationSummary ID="vsNomArch" runat="server" 
                                                                HeaderText="Errores en el nombre del archivo:" ShowMessageBox="True" 
                                                                ShowSummary="False" ValidationGroup="gpoNomArch" />
                                                            <br />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align:left;">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <br />
                                    <asp:Label ID="lblExpediente" runat="server" SkinID="SkinLblNormal" 
                                        Visible="False">Expediente digital del empleado:</asp:Label>
                                    <br />
                                    <asp:Label ID="lblInfNumEmp" runat="server" SkinID="SkinLblDatos" 
                                        Visible="False"></asp:Label>
                                    &nbsp;<asp:Label ID="lblInfNomEmp" runat="server" SkinID="SkinLblDatos" 
                                        Visible="False"></asp:Label>
                                    <br />
                                    <asp:GridView ID="gvExpedienteDigital" runat="server" 
                                        AutoGenerateColumns="False" CellPadding="4" 
                                        EmptyDataText="Sin información de expediente digital." ForeColor="#333333" OnRowDataBound="gvExpedienteDigital_RowDataBound" 
                                        SkinID="SkinGridView" Visible="False">
                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Clave">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCveDoc" runat="server" Text='<%# Bind("CveDoc") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DescDoc" HeaderText="Descripción" />
                                            <asp:BoundField DataField="NumPag" HeaderText="No. hoja">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Nombre archivo" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNomArch" runat="server" Text='<%# Bind("NomArchivo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibEliminarDeExp" runat="server" CausesValidation="False" 
                                                        ImageUrl="~/Imagenes/Eliminar.png" OnClick="ibEliminarDeExp_Click" 
                                                        ToolTip="Eliminar documento" />
                                                    <ajaxToolkit:ConfirmButtonExtender ID="CFEEliminar" runat="server" 
                                                        ConfirmText="¿Está seguro de eliminar el documento?" 
                                                        TargetControlID="ibEliminarDeExp">
                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibVerDoc" runat="server" CausesValidation="False" 
                                                        ImageUrl="~/Imagenes/Detalles.png" 
                                                        ToolTip="Ver documento en formato PDF" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                        <HeaderStyle Font-Bold="True" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <EmptyDataTemplate>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
