<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="AdministracionHorariosAdmin.aspx.vb" Inherits="AdministracionHorariosAdmin"
    Title="COBAEV - Nómina - Administrar horarios" StylesheetTheme="SkinFile"
    MaintainScrollPositionOnPostback="true"  %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucSearchEmps2.ascx" TagName="wucSearchEmps2" TagPrefix="uc2" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<%@ Register src="../../WebControls/wucMuestraErrores.ascx" tagname="wucMuestraErrores" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Administrar horarios de administrativos
                </h2>
            </td>
        </tr>
     </table>
     <table style="width: 100%;" align="left">
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UPMain" runat="server">
                    <ContentTemplate>
                        <br />
                        <table>
                            <tr>
                                <td><asp:Label ID="lblPlantelHead" runat="server" CssClass="pLabel" Text="Plantel:"></asp:Label></td>
                                <td><asp:Label ID="lblPlantel" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                    <asp:Label ID="lblEmpleadoHead" runat="server" CssClass="pLabel" Text="Empleado:"></asp:Label>
                </td>
                                <td>
                    <asp:Label ID="lblEmpleado" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label>
                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblCategoriaHead" runat="server" CssClass="pLabel" Text="Categoria:"></asp:Label></td>
                                <td><asp:Label ID="lblCategoria" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblObservacionesHead" runat="server" CssClass="pLabel" Text="Observaciones:"></asp:Label></td>
                                <td><asp:Label ID="lblObservaciones" runat="server" CssClass="pLabel" Font-Bold="True" ForeColor="#CC3300"></asp:Label></td>
                            </tr>
                        </table>
                        <asp:TextBox ID="hidIdHora" runat="server" BackColor="White" ForeColor="White" Width="1px" BorderColor="White" BorderStyle="None" ></asp:TextBox>

                        <asp:MultiView ID="MVMain" runat="server">
                            <asp:View ID="vwMain" runat="server">
                        <asp:Panel ID="pnlHorasEd" runat="server" GroupingText="" Visible="true" HorizontalAlign="Left">
                            <asp:LinkButton ID="lbBackPlanteles" runat="server" Font-Bold="False"
                                SkinID="SkinLinkButton" ToolTip="Agregar horario" ForeColor="#003300" PostBackUrl="../../Consultas/Empleados/CargaHoraria.aspx">Regresar a administración de plazas</asp:LinkButton>
                            <br>
                            &nbsp;&nbsp;
                            <asp:HiddenField ID="hidIdHorariosAdmin" runat="server" />
                            <asp:HiddenField ID="hidIdEmpleado" runat="server" />
                            <asp:HiddenField ID="hidIdPlantel" runat="server" />
                            <table>
                                <tr>
                                    <td><asp:Label ID="lblModalidad" runat="server" CssClass="pLabel" Text="Modalidad:"></asp:Label></td>
                                    <td><asp:DropDownList ID="ddlTipoJornada" runat="server" CssClass="textEntry" AutoPostBack="True">
                                                <asp:ListItem Value="0">-</asp:ListItem>
                                                <asp:ListItem Value="MAT">Matutino</asp:ListItem>
                                                <asp:ListItem Value="VES">Vespertino</asp:ListItem>
                                                <asp:ListItem Value="MIX">Mixto</asp:ListItem>
                                         </asp:DropDownList>
                                         <asp:CompareValidator ID="CompareValidator2" runat="server"
                                                            ControlToValidate="ddlTipoJornada" Display="Dynamic" ErrorMessage="Seleccione la modalidad"
                                                            Operator="NotEqual" ToolTip="Seleccione la modalidad" Type="String" ValidationGroup="Guardar"
                                                                ValueToCompare="0">*</asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table><tr>
                                    <td><asp:CheckBox ID="chkTodos" runat="server" Text="Lunes a Viernes" AutoPostBack="True" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td><asp:CheckBox ID="chkLunes" runat="server" Text="LUNES"  /></td>
                                    <td><asp:CheckBox ID="chkMartes" runat="server" Text="MARTES"  /></td>
                                    <td><asp:CheckBox ID="chkMiercoles" runat="server" Text="MIERCOLES"  /></td>
                                    <td><asp:CheckBox ID="chkJueves" runat="server" Text="JUEVES"  /></td>
                                    <td><asp:CheckBox ID="chkViernes" runat="server" Text="VIERNES"  /></td>
                                    <td><asp:CheckBox ID="chkSabado" runat="server" Text="SABADO"  /></td>
                                    <td><asp:CheckBox ID="chkDomingo" runat="server" Text="DOMINGO"  /></td>
                                            </tr>
                                            </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="lblHoraIni" runat="server" CssClass="pLabel" Text="Hora inicio:"></asp:Label></td>
                                    <td><asp:DropDownList ID="ddlHoraIni" runat="server" CssClass="textEntry" AutoPostBack="True">
                                                        <asp:ListItem>00</asp:ListItem>
                                                        <asp:ListItem Value="01">01</asp:ListItem>
                                                        <asp:ListItem Value="02">02</asp:ListItem>
                                                        <asp:ListItem Value="03"></asp:ListItem>
                                                        <asp:ListItem Value="04"></asp:ListItem>
                                                        <asp:ListItem Value="05"></asp:ListItem>
                                                        <asp:ListItem Value="06"></asp:ListItem>
                                                        <asp:ListItem Value="07"></asp:ListItem>
                                                        <asp:ListItem Value="08"></asp:ListItem>
                                                        <asp:ListItem Value="09"></asp:ListItem>
                                                        <asp:ListItem Value="10"></asp:ListItem>
                                                        <asp:ListItem Value="11"></asp:ListItem>
                                                        <asp:ListItem Value="12"></asp:ListItem>
                                                        <asp:ListItem Value="13"></asp:ListItem>
                                                        <asp:ListItem Value="14"></asp:ListItem>
                                                        <asp:ListItem Value="15"></asp:ListItem>
                                                        <asp:ListItem Value="16"></asp:ListItem>
                                                        <asp:ListItem Value="17"></asp:ListItem>
                                                        <asp:ListItem Value="18"></asp:ListItem>
                                                        <asp:ListItem Value="19"></asp:ListItem>
                                                        <asp:ListItem Value="20"></asp:ListItem>
                                                        <asp:ListItem Value="21"></asp:ListItem>
                                                        <asp:ListItem Value="22"></asp:ListItem>
                                                        <asp:ListItem Value="23"></asp:ListItem>
                                                        </asp:DropDownList></td>
                                    <td><asp:Label ID="lblMinutosIni" runat="server" CssClass="pLabel" Text="Minutos:"></asp:Label></td>
                                    <td><asp:DropDownList ID="ddlMinutosIni" runat="server" CssClass="textEntry" AutoPostBack="True">
                                                        <asp:ListItem Value="00"></asp:ListItem>
                                                        <asp:ListItem Value="05"></asp:ListItem>
                                                        <asp:ListItem Value="10"></asp:ListItem>
                                                        <asp:ListItem Value="15"></asp:ListItem>
                                                        <asp:ListItem Value="20"></asp:ListItem>
                                                        <asp:ListItem Value="25"></asp:ListItem>
                                                        <asp:ListItem Value="30"></asp:ListItem>
                                                        <asp:ListItem Value="35"></asp:ListItem>
                                                        <asp:ListItem Value="40"></asp:ListItem>
                                                        <asp:ListItem Value="45"></asp:ListItem>
                                                        <asp:ListItem Value="50"></asp:ListItem>
                                                        <asp:ListItem Value="55"></asp:ListItem>
                                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="lblHoraFin" runat="server" CssClass="pLabel" Text="Hora de término:"></asp:Label></td>
                                    <td><asp:DropDownList ID="ddlHoraFin" runat="server" CssClass="textEntry" AutoPostBack="True">
                                                        <asp:ListItem>00</asp:ListItem>
                                                        <asp:ListItem Value="01">01</asp:ListItem>
                                                        <asp:ListItem Value="02">02</asp:ListItem>
                                                        <asp:ListItem Value="03"></asp:ListItem>
                                                        <asp:ListItem Value="04"></asp:ListItem>
                                                        <asp:ListItem Value="05"></asp:ListItem>
                                                        <asp:ListItem Value="06"></asp:ListItem>
                                                        <asp:ListItem Value="07"></asp:ListItem>
                                                        <asp:ListItem Value="08"></asp:ListItem>
                                                        <asp:ListItem Value="09"></asp:ListItem>
                                                        <asp:ListItem Value="10"></asp:ListItem>
                                                        <asp:ListItem Value="11"></asp:ListItem>
                                                        <asp:ListItem Value="12"></asp:ListItem>
                                                        <asp:ListItem Value="13"></asp:ListItem>
                                                        <asp:ListItem Value="14"></asp:ListItem>
                                                        <asp:ListItem Value="15"></asp:ListItem>
                                                        <asp:ListItem Value="16"></asp:ListItem>
                                                        <asp:ListItem Value="17"></asp:ListItem>
                                                        <asp:ListItem Value="18"></asp:ListItem>
                                                        <asp:ListItem Value="19"></asp:ListItem>
                                                        <asp:ListItem Value="20"></asp:ListItem>
                                                        <asp:ListItem Value="21"></asp:ListItem>
                                                        <asp:ListItem Value="22"></asp:ListItem>
                                                        <asp:ListItem Value="23"></asp:ListItem>
                                                        </asp:DropDownList></td>
                                    <td><asp:Label ID="lblMinutosFin" runat="server" CssClass="pLabel" Text="Minutos:"></asp:Label></td>
                                    <td><asp:DropDownList ID="ddlMinutosFin" runat="server" CssClass="textEntry" AutoPostBack="True">
                                                        <asp:ListItem Value="00"></asp:ListItem>
                                                        <asp:ListItem Value="05"></asp:ListItem>
                                                        <asp:ListItem Value="10"></asp:ListItem>
                                                        <asp:ListItem Value="15"></asp:ListItem>
                                                        <asp:ListItem Value="20"></asp:ListItem>
                                                        <asp:ListItem Value="25"></asp:ListItem>
                                                        <asp:ListItem Value="30"></asp:ListItem>
                                                        <asp:ListItem Value="35"></asp:ListItem>
                                                        <asp:ListItem Value="40"></asp:ListItem>
                                                        <asp:ListItem Value="45"></asp:ListItem>
                                                        <asp:ListItem Value="50"></asp:ListItem>
                                                        <asp:ListItem Value="55"></asp:ListItem>
                                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblJornada" runat="server" CssClass="pLabel" Text="Jornada:"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtJornada" runat="server" enabled="false" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>  <asp:Button ID="btnGuardarModifes" runat="server" SkinID="SkinBoton" Text="Agregar"
                                                ToolTip="Agregar horario" 
                                                CausesValidation="True"   ValidationGroup="Guardar"/>
                                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="La opción seleccionada realizará cambios en la Base de Datos Institucional, ¿Continuar?"
                                                Enabled="True" TargetControlID="btnGuardarModifes">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                            </td>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnl2" runat="server" GroupingText="Horario laboral del empleado" HorizontalAlign="Left">
                                
                                <asp:GridView ID="gvHorarios" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen horarios registrados."
                                    SkinID="SkinGridView" ShowFooter="True" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="IdHorariosAdmin" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdHorariosAdmin" runat="server" Text='<%# Bind("IdHorariosAdmin") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Modalidad">
                                            <ItemTemplate>
                                                <asp:Label ID="lblModalidad" runat="server" Text='<%# Bind("TipoJornada") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Día de la semana">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDia" runat="server" Text='<%# Bind("Dia") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Hora Inicio">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHoraInicio" runat="server" Text='<%# Bind("HoraInicio") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Hora Fin">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHoraFin" runat="server" Text='<%# Bind("HoraFin") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                    CausesValidation="false" ToolTip="Eliminar registro." 
                                                    onclick="ibEliminar_Click" />
                                                <ajaxToolkit:ConfirmButtonExtender ID="ibEliminar_CBE" runat="server" 
                                                    ConfirmText="La opción seleccionada eliminará el registro de la Base de Datos Institucional, ¿Continuar?" Enabled="True" TargetControlID="ibEliminar">
                                                </ajaxToolkit:ConfirmButtonExtender>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </asp:Panel>
                            </asp:Panel>
                                <asp:Panel ID="Panel1" runat="server">
                                    <div id="divBotones">
                                        <p class="submitButton">
                                            &nbsp;<asp:ValidationSummary
                                                ID="VSGrupoGuardarI" runat="server" ShowMessageBox="True" ShowSummary="False"
                                                ValidationGroup="Guardar" />
                                        </p>
                                    </div>
                                </asp:Panel>
                            </asp:View>
                            <asp:View ID="viewExito" runat="server">
                                <table>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: left">
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
                                        </td>
                                        <td style="vertical-align: middle; text-align: left">
                                            <asp:Label ID="lblExito" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
                                            <br />
                                            <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton" CausesValidation="False">Cambiar más datos</asp:LinkButton>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                <asp:GridView ID="gvObservsPlaza" runat="server" AutoGenerateColumns="False" 
                                    Caption="Observaciones" SkinID="SkinGridView" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="Observacion" HeaderText="Observaciones" />
                                    </Columns>
                                </asp:GridView>
                                <br />
                            </asp:View>
                            <asp:View ID="viewError" runat="server">
                                <asp:Label ID="lblError" runat="server" SkinID="SkinLblMsjErrores"></asp:Label>
                                <uc3:wucMuestraErrores ID="wucMuestraErrores1" runat="server" />
                                <div id="divBotonesErrores">
                                    <p class="submitButton">
                                        <asp:Button ID="btnReintentarOp" runat="server" Text="Reintentar operación" ToolTip=""
                                            CausesValidation="False" />
                                        <asp:Button ID="btnCancelarOp" runat="server" Text="Continuar con otra operación en el sistema" 
                                            ToolTip="" 
                                            PostBackUrl="~/Consultas/Empleados/CargaHoraria.aspx" />
                                    </p>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                        <br />
                            
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    
</asp:Content>
