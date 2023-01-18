<%@ Control Language="VB" EnableViewState="true" AutoEventWireup="false" CodeFile="wucSearchEmps4.ascx.vb" Inherits="wucSearchEmps4" %>
    <link href="<%= ResolveClientUrl("~/CSS/reset.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= ResolveClientUrl("~/CSS/searchemps.css") %>" rel="stylesheet" type="text/css" />
<asp:UpdatePanel ID="UPMain" runat="server">
    <ContentTemplate>
        <asp:MultiView ID="mvBuscaEmps" runat="server" ActiveViewIndex="0">
            <asp:View ID="viewBuscar" runat="server">
                <div id="contenedorSearchEmps">
                    <fieldset class="pFieldSet">
                        <legend class="pLegend">
                            <asp:Label ID="lblLegendSearchEmps" runat="server" Text="Consulta de Recibos por Empleado"></asp:Label>
                        </legend>
                        <p class="pLabel">
                            <asp:Label ID="lblSelTipoBusq" runat="server" Text="Buscar empleado por"></asp:Label>
                        </p>
                            <p>
                                <asp:DropDownList ID="ddlTipoBusq" CssClass="ddl" runat="server" AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="NumEmp">Número de empleado</asp:ListItem>
                                    <asp:ListItem>Nombre</asp:ListItem>
                                    <asp:ListItem Value="RFC">R.F.C.</asp:ListItem>
                                    <asp:ListItem Value="CURP">C.U.R.P.</asp:ListItem>
                                </asp:DropDownList>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblTextoBusq" runat="server" Text="Teclee el número de empleado"></asp:Label>
                            </p>
                            <p class="pBusqueda">
                                <asp:TextBox ID="txtbxTextoBusq" CssClass="txtbx" runat="server"></asp:TextBox>
                            </p>
                            <p class="pBusqueda">
                                <asp:Button ID="BtnSearch" class="btn" runat="server" Text="Buscar" CausesValidation="False" />
                            </p>
                        </div>
                    </fieldset>
                </div>
            </asp:View>
        </asp:MultiView>
    </ContentTemplate>
</asp:UpdatePanel>
