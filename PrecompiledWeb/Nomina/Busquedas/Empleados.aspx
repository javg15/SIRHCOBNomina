<%@ page language="VB" enableeventvalidation="false" autoeventwireup="false" inherits="Empleados, App_Web_n4eab0lq" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>COBAEV - Nómina - Búsqueda de empleados</title>
    <script type="text/javascript" src="../Javascript.js"></script>
    <base target="_self" />
    <link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnbuscar">
        <table id="table3" border="0" cellpadding="1" cellspacing="1">
            <tr>
                <td colspan="3" style="height: 30px">
                    <asp:Label ID="label1" runat="server" SkinID="SkinLblNormal">Buscar por</asp:Label><asp:DropDownList
                        ID="ddltipobusqueda" runat="server" AutoPostBack="true" SkinID="SkinDropDownList">
                        <asp:ListItem Value="nombre">Nombre</asp:ListItem>
                        <asp:ListItem Value="numemp" Selected="True">N&#250;mero de empleado</asp:ListItem>
                        <asp:ListItem Value="rfc">RFC</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="3" style="vertical-align: middle;" valign="bottom">
                    <table border="0" cellpadding="1" style="width: 100%">
                        <tr>
                            <td style="vertical-align: middle; text-align: left;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TxtBxWtrMrkExtRFC" runat="server" TargetControlID="txtbxtextoabuscar" WatermarkCssClass="WaterMark" WatermarkText="Escriba aquí el RFC" Enabled="False">
                            </ajaxToolkit:TextBoxWatermarkExtender>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TxtBxWtrMrkExtNombre" runat="server" Enabled="False" TargetControlID="txtbxtextoabuscar" WatermarkCssClass="WaterMark" WatermarkText="Empiece por el apellido paterno">
                            </ajaxToolkit:TextBoxWatermarkExtender>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TxtBxWtrMrkExtNumEmp" runat="server" Enabled="True" TargetControlID="txtbxtextoabuscar" WatermarkCssClass="WaterMark" WatermarkText="Escriba aquí el número de empleado">
                            </ajaxToolkit:TextBoxWatermarkExtender>
                            <asp:TextBox ID="txtbxtextoabuscar" runat="server" MaxLength="13" Width="400px" SkinID="SkinTextBox"></asp:TextBox>
                    <asp:Button ID="btnbuscar" runat="server" SkinID="SkinBoton" Text="Buscar" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddltipobusqueda" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                            </td>
                            <td style="vertical-align: middle; text-align: left; width: 61px;">
                    </td>
                        </tr>
                    </table>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/Spinner2.gif" />
                            <asp:Label ID="Label4" runat="server" SkinID="SkinLblDatos" Text="Buscando..."></asp:Label>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="vertical-align: middle" valign="top">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                    <asp:RequiredFieldValidator ID="rfvtextoabuscar" runat="server" ControlToValidate="txtbxtextoabuscar"
                        CssClass="rfv" Display="dynamic" Font-Italic="True" Font-Names="Verdana" Font-Size="X-Small"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnbuscar" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="vertical-align: middle; height: 30px" valign="top">
                    <asp:CheckBox ID="chbxGuardaEmp" runat="server" Checked="True" Font-Names="Verdana"
                        Font-Size="X-Small" Text="Conservar información de empleado para consultas" Enabled="False" /></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                    <asp:Label ID="lbltipobusqueda" runat="server" Font-Strikeout="False" Font-Underline="True" SkinID="SkinLblDatos"></asp:Label><br />
                    <asp:GridView ID="gvEmpleados" runat="server" AutoGenerateColumns="False"
                        CaptionAlign="Left" EmptyDataText="No hubo coincidencias" Font-Names="Verdana" Font-Size="X-Small" PageSize="20" SkinID="SkinGridView">
                        <Columns>
                            <asp:TemplateField HeaderText="RFC">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnrfc" runat="server" CommandName="CmdRFC"
                                        Text='<%# databinder.eval(container, "dataitem.rfc") %>'></asp:LinkButton>
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
                        </Columns>
                        <HeaderStyle CssClass="dgheader" />
                    </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnbuscar" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        </asp:Panel>
        <br />
        &nbsp;
    </form>
</body>
</html>
