<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master" AutoEventWireup="false" 
CodeFile="ConReduccionDeSueldo.aspx.vb" Inherits="Consultas_Empleados_ConReduccionDeSueldo" 
title="COBAEV - Nómina - Empleados con reducción de sueldo" StylesheetTheme="SkinFile" %>
<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<%@ Register src="~/WebControls/wucMuestraErrores.ascx" tagname="wucMuestraErrores" tagprefix="uc3" %>
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
                        <asp:MultiView ID="MVMain" runat="server">
                            <asp:View ID="vwMain" runat="server">
                                <asp:Panel ID="pnl1" runat="server" GroupingText="Ordenar por:" Visible="true" HorizontalAlign="Left">
                                    <asp:DropDownList ID="ddlOrden" runat="server"></asp:DropDownList>
                                    <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" Text="Consultar"
                                        ToolTip="Consultar reducciones."
                                        CausesValidation="False" />
                                    <br /><br />
                                    <asp:LinkButton ID="lbAsignarReduccion" runat="server" Font-Bold="False"
                                       SkinID="SkinLinkButton" ToolTip="Agregar registro de reducción" ForeColor="#003300">Agregar registro de reducción</asp:LinkButton>
                                </asp:Panel>
                        
                                <asp:GridView ID="gvEmps" runat="server" EmptyDataText="No hay empleados con reducción de sueldo actualmente."
                                    SkinID="SkinGridView">
                                    <Columns>
                                        <asp:TemplateField HeaderText="IdReduccion" Visible="True">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IdReduccion") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdReduccion" runat="server" Text='<%# Bind("IdReduccion") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IdEmp" Visible="False">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IdEmp") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdEmp" runat="server" Text='<%# Bind("IdEmp") %>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="PorcDesc" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPorcDesc" runat="server" Text='<%# Bind("PorcDesc") %>'></asp:Label>
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
                                                <asp:Label ID="lblIdQnaIni" runat="server" Text='<%# Bind("IdQnaIni") %>'></asp:Label>
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
                                                <asp:Label ID="lblIdQnaFin" runat="server" Text='<%# Bind("IdQnaFin") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Termino" HeaderText="Fin">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                                    CausesValidation="false" ToolTip="Modificar la información del registro." OnClick="ibModificar_Click" /></ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:View>
                            <asp:View ID="vwReduccionesEd" runat="server">
                                <asp:Panel ID="pnlEd" runat="server">
                                    <div class="accountInfo">
                                        <fieldset id="fsEd">
                                            <div class="panelIzquierda">
                                                <asp:HiddenField ID="hidIdReduccion" runat="server" />
                                                <uc1:wucBuscaEmpleados ID="WucBuscaEmpleados1" runat="server" EnableViewState="true" />
                                                <asp:TextBox ID="hidIdEmpleado" runat="server" BackColor="White" ForeColor="White" Width="1px" BorderColor="White" BorderStyle="None" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CVIdEmp" runat="server"
                                                    ControlToValidate="hidIdEmpleado" Display="Dynamic" ErrorMessage="Seleccione el empleado a afectar"
                                                    ToolTip="Seleccione el empleado a afectar" Type="Text">*</asp:RequiredFieldValidator>

                                                <p class="pLabel">
                                                    <asp:Label ID="lblEmpleadoHead" runat="server" CssClass="pLabel" Text="Empleado:"></asp:Label>
                                                </p>
                                                <p class="pTextBox">
                                                    <asp:Label ID="lblEmpleado" runat="server" CssClass="pLabel" Text=""></asp:Label>
                                                </p>

                                                <p class="pLabel">
                                                    <asp:Label ID="lblPorcentage" runat="server" CssClass="pLabel" Text="% de reducción de sueldo:">
                                                    </asp:Label>
                                                </p>
                                                <asp:Panel ID="pnlEdCampos" runat="server">
                                                    <p class="pTextBox">
                                                        <asp:TextBox ID="txtbxPorcentageReduccion" runat="server" MaxLength="10" CssClass="textEntry" AutoPostBack="True"></asp:TextBox>
                                                        <asp:hiddenfield ID="hidImporteReduccion" runat="server"></asp:hiddenfield>
                                                        <asp:CompareValidator ID="vldCprReduccion1" runat="server" ControlToValidate="txtbxPorcentageReduccion"
                                                            Display="Dynamic" ErrorMessage="Importe incorrecto." Operator="DataTypeCheck" 
                                                            Type="Currency" ToolTip="Importe incorrecto." Text="*" ValueToCompare="100"></asp:CompareValidator>
                                                        <asp:RequiredFieldValidator ID="vldReqReduccion1" runat="server" ControlToValidate="txtbxPorcentageReduccion"
                                                            Display="Dynamic" Text="*" ToolTip="El importe de la porcentage es obligatorio." 
                                                            ErrorMessage="El porcentage de la Reducción es obligatorio.">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="vldCprReduccion2" runat="server" ControlToValidate="txtbxPorcentageReduccion"
                                                            Display="Dynamic" ErrorMessage="Importe incorrecto. No puede ser cero o menor que cero."
                                                            Operator="GreaterThan" ToolTip="Importe incorrecto. No puede ser cero o menor que cero." 
                                                            Type="Currency" ValueToCompare="0" Text="*"></asp:CompareValidator>
                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtbxPorcentageReduccion"
                                                            Display="Dynamic" ErrorMessage="Importe incorrecto. No puede ser mayor que 100."
                                                            Operator="LessThanEqual" ToolTip="Importe incorrecto. No puede ser mayor que 100." 
                                                            Type="Currency" ValueToCompare="100" Text="*"></asp:CompareValidator>
                                                    </p>
                                                    <p class="pLabel">
                                                        <asp:Label ID="lblInicio" runat="server" CssClass="pLabel" Text="Quincena de inicio:">
                                                        </asp:Label>
                                                    </p>
                                                    <p class="pTextBox">
                                                        <asp:DropDownList ID="ddlQuincenaInicio" runat="server" AutoPostBack="True" 
                                                            SkinID="SkinDropDownList"></asp:DropDownList><asp:CompareValidator ID="CVInicio" runat="server"
                                                                    ControlToValidate="ddlQuincenaInicio" Display="Dynamic" ErrorMessage="Seleccione la quincena de inicio"
                                                                    Operator="NotEqual" ToolTip="Seleccione la quincena de inicio" Type="Integer" 
                                                                     ValueToCompare="0">*</asp:CompareValidator>
                                                    </p>
                                                    <p class="pLabel">
                                                        <asp:Label ID="lblFin" runat="server" CssClass="pLabel" Text="Quincena de t&#233;rmino:">
                                                        </asp:Label>
                                                    </p>
                                                    <p class="pTextBox">
                                                        <asp:DropDownList ID="ddlQuincenaFin" runat="server" AutoPostBack="True" 
                                                            SkinID="SkinDropDownList"></asp:DropDownList>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                                                                    ControlToValidate="ddlQuincenaFin" Display="Dynamic" ErrorMessage="Seleccione la quincena de término"
                                                                    Operator="NotEqual" ToolTip="Seleccione la quincena de término" Type="Integer"
                                                                     ValueToCompare="0">*</asp:CompareValidator>
                                                    </p>
                                                </asp:Panel>
                                            </div>
                                        </fieldset>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel1" runat="server">
                                    <div id="divBotonesReduccion">
                                        <p class="submitButton">
                                            <asp:Button ID="btnGuardarModifReducciones" runat="server" SkinID="SkinBoton" Text="Guardar"
                                                ToolTip="Guardar cambios y regresar a la pantalla de consulta de reducciones." 
                                                CausesValidation="True"  />
                                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="La opción seleccionada realizará cambios en la Base de Datos Institucional, ¿Continuar?"
                                                Enabled="True" TargetControlID="btnGuardarModifReducciones">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                            <asp:Button ID="btnCancelarReducciones" runat="server" CausesValidation="False" SkinID="SkinBoton"
                                                Text="Cancelar" ToolTip="Regresar a la pantalla de consulta de reducciones." />
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
                                            <asp:LinkButton ID="lbOtraOperacion" runat="server" SkinID="SkinLinkButton">Cambiar más datos</asp:LinkButton>
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
                                            />
                                        <asp:Button ID="btnCancelarOp" runat="server" Text="Continuar con otra operación en el sistema" 
                                            ToolTip="" 
                                            PostBackUrl="~/Consultas/Empleados/ConReduccionDeSueldo.aspx?TipoOperacion=4" />
                                    </p>
                                </div>
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
</asp:Content>

