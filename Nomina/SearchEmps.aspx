<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SearchEmps.aspx.vb" Inherits="SearchEmps" 
    MasterPageFile="~/MasterPageBlanca.master"  StylesheetTheme="SkinFile" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=40);
        opacity: 0.4;
    }
    .modalPopup
    {
        border: 3px solid black;
        background-color: #FFFFFF;
        padding-top: 10px;
        padding-left: 10px;
        width: 850px;
        height: 600px;
        text-align: center;
    }
    .modalPopup2
    {
        background-color: #FFFFFF;
        width: 800px;
        height: 500px;
    }    
    .style1
    {
        width: 248px;
    }
    .style3
    {
        width: 285px;
    }
    .style4
    {
        width: 299px;
    }
</style>
<script type="text/JavaScript" language="JavaScript">
    function pageLoad() {
        var manager = Sys.WebForms.PageRequestManager.getInstance();
        manager.add_endRequest(endRequest);
        manager.add_beginRequest(OnBeginRequest);
    }

    function OnBeginRequest(sender, args) {
        $get('ParentDiv').className = 'modalBackground2';
    }

    function endRequest(sender, args) {
        $get('ParentDiv').className = '';
    }

    function CancelPostBack() {
        var objMan = Sys.WebForms.PageRequestManager.getInstance();
        if (objMan.get_isInAsyncPostBack())
            objMan.abortPostBack();
    }
</script>
<div>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="500" DynamicLayout="true">
        <ProgressTemplate>
            <div id="ParentDiv">
            </div>
            <div id="div1" runat="server" align="center" valign="middle" style="width: 100%;
                height: 200%; position: absolute; left: 0; top: 0; visibility: visible; vertical-align: middle;
                background-color: White; z-index: 10; filter: alpha(opacity=40);">
            </div>
            <div id="div2" runat="server" align="center" valign="middle" style="width: 250px;
                height: 100px; position: absolute; left: 40%; top: 40%; visibility: visible;
                vertical-align: middle; border-style: inset; border-color: black; background-color: White;
                z-index: 20">
                <br />
                <table>
                    <tr>
                        <td style="vertical-align: middle; text-align: center;">
                            <asp:Image runat="server" ID="img1" ImageUrl="~/Imagenes/Spinner2.gif" />
                        </td>
                        <td style="vertical-align: middle; text-align: center;">
                            <asp:Label runat="server" ID="lblMsjEspera" Text="Por favor espere..." SkinID="SkinLblMsjExito"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="vertical-align: middle; text-align: center;">
                            <asp:Button runat="server" ID="btnCancelar" OnClientClick="javascript:CancelPostBack(); return false;"
                                SkinID="SkinBoton" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ajaxToolkit:CollapsiblePanelExtender ID="CPEBusqueda" runat="Server" CollapseControlID="TitlePanelBusqueda"
                Collapsed="False" CollapsedImage="~/Imagenes/expand_blue.jpg" CollapsedText="(Mostrar detalles...)"
                ExpandControlID="TitlePanelBusqueda" ExpandedImage="~/Imagenes/collapse_blue.jpg"
                ExpandedText="(Ocultar detalles...)" ImageControlID="Image1" SuppressPostBack="true"
                TargetControlID="ContentPanelBusqueda" TextLabelID="Label5">
            </ajaxToolkit:CollapsiblePanelExtender>
            <ajaxToolkit:TextBoxWatermarkExtender ID="TxtBxWtrMrkExtRFC" runat="server" TargetControlID="txtbxRFC"
                WatermarkCssClass="WaterMark" WatermarkText="Escriba aquí el RFC">
            </ajaxToolkit:TextBoxWatermarkExtender>
            <ajaxToolkit:TextBoxWatermarkExtender ID="TxtBxWtrMrkExtNombre" runat="server" TargetControlID="txtbxNomEmp"
                WatermarkCssClass="WaterMark" WatermarkText="Empiece por el apellido paterno">
            </ajaxToolkit:TextBoxWatermarkExtender>
            <ajaxToolkit:TextBoxWatermarkExtender ID="TxtBxWtrMrkExtNumEmp" runat="server" TargetControlID="txtbxNumEMp"
                WatermarkCssClass="WaterMark" WatermarkText="Escriba aquí el número de empleado">
            </ajaxToolkit:TextBoxWatermarkExtender>
            <table style="width: 780px">
                <tr>
                    <td style="vertical-align: top; text-align: left">
                        <asp:Panel ID="TitlePanelBusqueda" runat="server" BorderColor="White" BorderStyle="Solid"
                            BorderWidth="1px" CssClass="collapsePanelHeader" Width="100%">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/expand_blue.jpg" />
                            Búsqueda de empleados
                            <asp:Label ID="Label5" runat="server">(Mostrar detalles...)</asp:Label>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left">
                        <asp:Panel ID="ContentPanelBusqueda" runat="server" CssClass="collapsePanel" Width="100%">
                            <table class="style1" style="width: 780px">
                                <tr>
                                    <td style="width: 180px; text-align: left;" valign="middle">
                                        <asp:Label ID="Label4" runat="server" SkinID="SkinLblNormal" Text="Seleccione su tipo de búsqueda"></asp:Label>
                                    </td>
                                    <td style="width: 600px; text-align: left;" valign="middle">
                                        <asp:DropDownList ID="ddlTipoBusqueda" runat="server" AutoPostBack="True" SkinID="SkinDropDownList"
                                            Width="288px">
                                            <asp:ListItem Value="RFC">R.F.C.</asp:ListItem>
                                            <asp:ListItem>Nombre</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="NumEmp">Número de empleado</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:Button ID="BtnNewSearch" runat="server" SkinID="SkinBoton" Text="Nueva búsqueda"
                                            Width="125px" />
                                        &nbsp;<asp:Button ID="BtnCancelSearch" runat="server" CausesValidation="False" SkinID="SkinBoton"
                                            Text="Cancelar" ToolTip="Cancelar búsqueda" Width="70px" />
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
                                            SkinID="SkinTextBox" Width="450px"></asp:TextBox>
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
                                    <td colspan="2" style="text-align: left;">
                                        <asp:Panel ID="pnlPopUp" runat="server" Width="100%" Visible="false" Height="250px" ScrollBars="Both">
                                            <table>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lblDrag" runat="server" SkinID="SkinLblMsjExito" Text="Resultados de la búsqueda"
                                                            Width="100%"></asp:Label>
                                                    </td>
                                                    <td style="text-align: right">
                                                        <asp:ImageButton ID="imgbtnClose" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                            ToolTip="Cerrar ventana" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align: left">
                                                        <asp:Panel ID="pnlEmps" runat="server" ScrollBars="Both" Width="100%">
                                                            <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False" CaptionAlign="Left"
                                                                EmptyDataText="No hubo coincidencias" Font-Names="Verdana" Font-Size="X-Small"
                                                                PageSize="20" SkinID="SkinGridView" Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="RFC">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnrfc" runat="server" CommandName="CmdRFC" Text='<%# databinder.eval(container, "dataitem.rfc") %>'></asp:LinkButton>
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
                                                                    <asp:TemplateField HeaderText="Número de empleado">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblNumEmp" runat="server" Text='<%# Bind("numemp") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="dgheader" />
                                                            </asp:GridView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left;">
                                                        &nbsp;
                                                    </td>
                                                    <td style="text-align: right;">
                                                        <asp:Button ID="btnCancel" runat="server" SkinID="SkinBoton" Text="Cancelar" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
