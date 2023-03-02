<%@ Page Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false"
    CodeFile="AdministracionHorarios.aspx.vb" Inherits="AdministracionHorarios"
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
                    Sistema de nómina: Administrar horarios de docentes
                </h2>
            </td>
        </tr>
     </table>
     <table style="width: 100%;" align="center">
        <tr>
            <td valign="top">
                
                <asp:TextBox ID="hidIdHoras" runat="server" BackColor="White" ForeColor="White" Width="1px" BorderColor="White" BorderStyle="None" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="CVIdHoras" runat="server"
                    ControlToValidate="hidIdHoras" Display="Dynamic" ErrorMessage="No hay relación con alguna asignación de materia"
                    ToolTip="No hay relación con alguna asignación de materia" Type="Text"
                    ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                <p class="pLabel">
                    <asp:Label ID="lblPlantelHead" runat="server" CssClass="pLabel" Text="Plantel:"></asp:Label>
                </p>
                <p class="pTextBox">
                    <asp:Label ID="lblPlantel" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label>
                </p>
                <p class="pLabel">
                    <asp:Label ID="lblMateriaHead" runat="server" CssClass="pLabel" Text="Materia:"></asp:Label>
                </p>
                <p class="pTextBox">
                    <asp:Label ID="lblMateria" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label>
                </p>
                <p class="pLabel">
                    <asp:Label ID="lblGrupoHead" runat="server" CssClass="pLabel" Text="Grupo:"></asp:Label>
                </p>
                <p class="pTextBox">
                    <asp:Label ID="lblGrupo" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label>
                </p>
                <p class="pLabel">
                    <asp:Label ID="lblHorasHead" runat="server" CssClass="pLabel" Text="Horas asignadas:"></asp:Label>
                </p>
                <p class="pTextBox">
                    <asp:Label ID="lblTotalHoras" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label>
                    <asp:textbox ID="hidHorasRestantes" runat="server" BackColor="White" ForeColor="White" Width="1px" BorderColor="White" BorderStyle="None" ValidationGroup="Guardar"/>
                    <asp:CompareValidator ID="CompareValidator3" runat="server"
                            ControlToValidate="hidHorasRestantes" Display="Dynamic" ErrorMessage="La suma de horas supera el total de horas asignadas"
                            Operator="LessThan" ToolTip="La suma de horas supera el total de horas asignadas" Type="Integer" ValidationGroup="Guardar" 
                                ValueToCompare="0">*</asp:CompareValidator>
                </p>
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UPMain" runat="server">
                    <ContentTemplate>
                        <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                        <asp:HiddenField ID="hidIdHorariosClase" runat="server" />
                        <asp:MultiView ID="MVMain" runat="server">
                            <asp:View ID="vwMain" runat="server">
                                <asp:Panel ID="pnlHoras" runat="server" GroupingText="" Visible="true" HorizontalAlign="Left">
                                    <asp:LinkButton ID="lbBackPlanteles" runat="server" Font-Bold="False"
                                        SkinID="SkinLinkButton" ToolTip="Agregar horario" ForeColor="#003300" PostBackUrl="../../Consultas/Empleados/CargaHoraria.aspx">Regresar a carga horaria</asp:LinkButton>
                                    &nbsp;&nbsp;
                                    <asp:LinkButton ID="lbAgregarHorario" runat="server" Font-Bold="False"
                                        SkinID="SkinLinkButton" ToolTip="Agregar horario" ForeColor="#003300" CausesValidation="False">Agregar horario</asp:LinkButton>
                                </asp:Panel>
                                <br /><br />
                                <asp:GridView ID="gvHoras" runat="server" EmptyDataText="No hay horarios registrados actualmente."
                                                SkinID="SkinGridView">
                                    <Columns>
                                        <asp:TemplateField HeaderText="lblIdHorariosClase" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdHorariosClase" runat="server" Text='<%# Bind("IdHorariosClase") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IdDia" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdDia" runat="server" Text='<%# Bind("IdDia") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Día" Visible="True">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDia" runat="server" Text='<%# Bind("Dia") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IdHoraInicio" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdHoraInicio" runat="server" Text='<%# Bind("IdHoraInicio") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Inicio" Visible="True">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInicio" runat="server" Text='<%# Bind("HoraInicio") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Horas" Visible="True">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCantidadHoras" runat="server" Text='<%# Bind("CantidadHoras") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                    CausesValidation="false" ToolTip="Modificar la información del registro." OnClick="ibModificar_Click" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                                    CausesValidation="false" ToolTip="Eliminar el registro." OnClick="ibEliminar_Click" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:View>
                            <asp:View ID="vwHorariosEd" runat="server">
                                <asp:Panel ID="pnlEd" runat="server">
                                    <div class="accountInfo">
                                        <fieldset id="fsEd">
                                            <div class="panelIzquierda">
                                                <asp:Panel ID="pnlEdCampos" runat="server">
                                                    <p class="pLabel">
                                                        <asp:Label ID="Label1" runat="server" CssClass="pLabel" Text="Día:">
                                                        </asp:Label>
                                                    </p>
                                                    <p class="pTextBox">
                                                        <asp:DropDownList ID="ddlDia" runat="server" AutoPostBack="True" 
                                                            SkinID="SkinDropDownList" ValidationGroup="Guardar"></asp:DropDownList>
                                                        <asp:CompareValidator ID="CompareValidator2" runat="server"
                                                            ControlToValidate="ddlDia" Display="Dynamic" ErrorMessage="Seleccione el día"
                                                            Operator="NotEqual" ToolTip="Seleccione el día" Type="Integer" ValidationGroup="Guardar"
                                                                ValueToCompare="0">*</asp:CompareValidator>
                                                    </p>
                                                    <p class="pLabel">
                                                        <asp:Label ID="lblInicio" runat="server" CssClass="pLabel" Text="Hora de inicio:">
                                                        </asp:Label>
                                                    </p>
                                                    <p class="pTextBox">
                                                        <asp:DropDownList ID="ddlHoraInicio" runat="server" AutoPostBack="True" 
                                                            SkinID="SkinDropDownList" ValidationGroup="Guardar"></asp:DropDownList><asp:CompareValidator ID="CVInicio" runat="server"
                                                                    ControlToValidate="ddlHoraInicio" Display="Dynamic" ErrorMessage="Seleccione la hora de inicio"
                                                                    Operator="NotEqual" ToolTip="Seleccione la hora de inicio" Type="Integer" ValidationGroup="Guardar"
                                                                        ValueToCompare="0">*</asp:CompareValidator>
                                                    </p>
                                                    <p class="pLabel">
                                                        <asp:Label ID="lblFin" runat="server" CssClass="pLabel" Text="Cantidad de horas:">
                                                        </asp:Label>
                                                    </p>
                                                    <p class="pTextBox">
                                                        <asp:textbox ID="txtCantidadHoras" runat="server" AutoPostBack="True" Width="100" ValidationGroup="Guardar"/>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                                                                    ControlToValidate="txtCantidadHoras" Display="Dynamic" ErrorMessage="Ingrese la cantidad de horas"
                                                                    Operator="NotEqual" ToolTip="Ingrese la cantidad de horas" Type="Integer" ValidationGroup="Guardar"
                                                                        ValueToCompare="0">*</asp:CompareValidator>
                                            
                                                    </p>
                                                </asp:Panel>
                                            </div>
                                        </fieldset>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel1" runat="server">
                                    <div id="divBotones">
                                        <p class="submitButton">
                                            <asp:Button ID="btnGuardarModifes" runat="server" SkinID="SkinBoton" Text="Guardar"
                                                ToolTip="Guardar cambios y regresar a la pantalla de consulta de reducciones." 
                                                CausesValidation="True"   ValidationGroup="Guardar"/>
                                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="La opción seleccionada realizará cambios en la Base de Datos Institucional, ¿Continuar?"
                                                Enabled="True" TargetControlID="btnGuardarModifes">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                            <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" SkinID="SkinBoton"
                                                Text="Cancelar" ToolTip="Regresar a la pantalla de consulta de reducciones." />
                                            <asp:ValidationSummary
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
                                            &nbsp;<asp:LinkButton ID="lbOtraOperacion0" runat="server"
                                                SkinID="SkinLinkButton">Continuar con otra operación en el sistema</asp:LinkButton>
                                        </td>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    
</asp:Content>
