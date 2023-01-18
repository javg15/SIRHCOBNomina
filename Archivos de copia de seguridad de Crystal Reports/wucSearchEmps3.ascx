<%@ Control Language="VB" EnableViewState="true" AutoEventWireup="false" CodeFile="wucSearchEmps3.ascx.vb"
    Inherits="WebControls_wucSearchEmps3" %>
<%@ Register src="wucMuestraFoto.ascx" tagname="wucMuestraFoto" tagprefix="uc1" %>
<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlGral" runat="server" DefaultButton="BtnSearch">
                <ajaxToolkit:TextBoxWatermarkExtender ID="TxtBxWtrMrkExtRFC" runat="server" TargetControlID="txtbxRFC"
                    WatermarkCssClass="WaterMark" WatermarkText="Escriba aquí el RFC">
                </ajaxToolkit:TextBoxWatermarkExtender>
                <ajaxToolkit:TextBoxWatermarkExtender ID="TxtBxWtrMrkExtNombre" runat="server" TargetControlID="txtbxNomEmp"
                    WatermarkCssClass="WaterMark" WatermarkText="Empiece por el apellido paterno">
                </ajaxToolkit:TextBoxWatermarkExtender>
                <ajaxToolkit:TextBoxWatermarkExtender ID="TxtBxWtrMrkExtNumEmp" runat="server" TargetControlID="txtbxNumEMp"
                    WatermarkCssClass="WaterMark" WatermarkText="Escriba aquí el número de empleado">
                </ajaxToolkit:TextBoxWatermarkExtender>
                <table style="padding: 0px; margin: 0px; width: 100%;">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
                                <table class="style1" style="width: 100%">
                                    <tr>
                                        <td style="text-align: left; width: 250px;" valign="middle">
                                            <asp:Label ID="Label4" runat="server" SkinID="SkinLblNormal" Text="Seleccione su tipo de búsqueda"></asp:Label>
                                        </td>
                                        <td style="width: 600px; text-align: left;" valign="middle">
                                            <asp:DropDownList ID="ddlTipoBusqueda" runat="server" AutoPostBack="True" SkinID="SkinDropDownList"
                                                Width="300px">
                                                <asp:ListItem Value="RFC">R.F.C.</asp:ListItem>
                                                <asp:ListItem>Nombre</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="NumEmp">Número de empleado</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;<asp:Button ID="BtnNewSearch" runat="server" SkinID="SkinBoton" 
                                                Text="Nueva búsqueda" />
                                            &nbsp;<asp:Button ID="BtnCancelSearch" runat="server" CausesValidation="False" SkinID="SkinBoton"
                                                Text="Cancelar" ToolTip="Cancelar búsqueda" />
                                        </td>
                                         <td rowspan="7" style="text-align: center; vertical-align:top;" >
                                                <uc1:wucMuestraFoto ID="wucMuestraFoto1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">
                                            &nbsp;
                                        </td>
                                        <td style="text-align: left;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;" valign="middle">
                                            <asp:Label ID="Label1" runat="server" SkinID="SkinLblNormal" Text="R.F.C."></asp:Label>
                                        </td>
                                        <td style="text-align: left;" valign="middle">
                                            <asp:TextBox ID="txtbxRFC" runat="server" MaxLength="13" ReadOnly="True" SkinID="SkinTextBox"
                                                Width="300px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvRFC" runat="server" ControlToValidate="txtbxRFC"
                                                Display="None" Enabled="False" ErrorMessage="Se requiere que escriba el RFC completo o en parte."
                                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            <asp:HiddenField ID="hfRFC" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;" valign="middle">
                                            <asp:Label ID="Label2" runat="server" SkinID="SkinLblNormal" Text="Nombre"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" valign="middle">
                                            <asp:TextBox ID="txtbxNomEmp" runat="server" Columns="60" MaxLength="90" ReadOnly="True"
                                                SkinID="SkinTextBox" Width="300px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtbxNomEmp"
                                                Display="None" Enabled="False" ErrorMessage="Se requiere que escriba el  nombre completo o en parte."
                                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            <asp:HiddenField ID="hfNomEmp" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;" valign="middle">
                                            <asp:Label ID="Label3" runat="server" SkinID="SkinLblNormal" Text="Número de empleado"></asp:Label>
                                        </td>
                                        <td style="text-align: left;" valign="middle">
                                            <asp:TextBox ID="txtbxNumEmp" runat="server" MaxLength="5" SkinID="SkinTextBox" Width="300px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNumEmp" runat="server" ControlToValidate="txtbxNumEmp"
                                                Display="None" Enabled="False" ErrorMessage="Se requiere que escriba el  número de empleado completo o en parte."
                                                SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                            <asp:HiddenField ID="hfNumEmp" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Names="Verdana"
                                                Font-Size="X-Small" ShowMessageBox="True" ShowSummary="False" />
                                        </td>
                                        <td style="text-align: left;" valign="middle">
                                            <asp:Button ID="BtnSearch" runat="server" SkinID="SkinBoton" Text="Buscar" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left;">
                                            &nbsp;
                                        </td>
                                        <td style="text-align: left;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="text-align: left;">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                            <asp:Panel ID="pnlPopUp" runat="server" Width="100%" Visible="false" Height="250px"
                                                ScrollBars="Both">
                                                <table width="95%">
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:Label ID="lblDrag" runat="server" SkinID="SkinLblMsjExito" Text="Resultados de la búsqueda"
                                                                Width="100%"></asp:Label>
                                                        </td>
                                                        <td style="text-align: right">
                                                            <asp:ImageButton ID="imgbtnClose" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                                ToolTip="Cerrar los resultados de la búsqueda" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: left">
                                                            <asp:Panel ID="pnlEmps" runat="server" ScrollBars="Both" Width="100%">
                                                                <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                                                                    EmptyDataText="No hubo coincidencias" Font-Names="Verdana" Font-Size="X-Small"
                                                                    PageSize="20" ShowHeaderWhenEmpty="True" SkinID="SkinGridView" Width="100%" OnRowCommand="gvEmpleados_RowCommand"  OnRowDataBound="gvEmpleados_RowDataBound" >
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="RFC">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtnrfc" runat="server" CommandName="CmdRFC" Text='<%# databinder.eval(container, "dataitem.rfc") %>'></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="CURP">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCURP" runat="server" Text='<%# Bind("curp") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" />
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
                                                                        <asp:TemplateField HeaderText="Número de empleado">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("numemp") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="text-align: right;">
                                                            <asp:ImageButton ID="imgbtnClose0" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                                ToolTip="Cerrar los resultados de la búsqueda" />
                                                            <asp:Button ID="btnCancel" runat="server" SkinID="SkinBoton" Text="Cancelar" Visible="False" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="BtnSearch" EventName="Click" />
                                                    <asp:AsyncPostBackTrigger ControlID="gvEmpleados" EventName="RowCommand" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
