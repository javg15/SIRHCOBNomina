<%@ Page EnableEventValidation="false" Language="VB" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ABCPlazasBase.aspx.vb" Inherits="ABCPlazasBase"
    Title="COBAEV - Nómina - Empleados, control de incidencias" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<%@ Register src="../../WebControls/wucMuestraErrores.ascx" tagname="wucMuestraErrores" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Administración de plazas
                </h2>
            </td>
        </tr>
    <tr>
            <td style="vertical-align: top; width: 100%; height: 100%; text-align: left">
                <table style="width: 100%">
                    <tr>
                        <td style="vertical-align: top; text-align: left">
<asp:UpdatePanel ID="UpdPnlMain" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnl1" runat="server">
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="viewPlazas" runat="server">
                <asp:Panel ID="pnlInfPlaza" runat="server" GroupingText="Información de la plaza base">
                    <asp:TextBox  ID="hidIdPlazas" runat="server" BackColor="white" BorderColor="white" BorderWidth="0px" ForeColor="white" Width="1px" text="0"/>
                    <asp:RequiredFieldValidator ID="CVIdPlazas" runat="server"
                            ControlToValidate="hidIdPlazas" Display="Dynamic" ErrorMessage="Seleccione la plaza a asignar como titular"
                            ToolTip="Seleccione la plaza a asignar como titular" Type="Text"
                            ValidationGroup="gpoGuarda" >*</asp:RequiredFieldValidator>
                    <asp:DetailsView ID="dvPlaza" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                        DefaultMode="Insert" Width="100%">
                        <FieldHeaderStyle Width="250px" Wrap="True" />
                        <Fields>
                            <asp:TemplateField HeaderText="Tipo de plaza"><InsertItemTemplate><asp:DropDownList ID="ddlTipoPlaza" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                                    <asp:ListItem Value="-" Text="-"/>
                                <asp:ListItem Value="ECB" Text="Escolarizado Bachillerato (ECB)"/>
                                <asp:ListItem Value="RPR" Text="Recursos Propios (RP)"/>
                                <asp:ListItem Value="EMS" Text="EMSAD"/>
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CVTipoPlaza" runat="server"
                                                    ControlToValidate="ddlTipoPlaza" Display="Dynamic" ErrorMessage="Seleccione el tipo de plaza"
                                                    Operator="NotEqual" ToolTip="Seleccione el tipo de plaza" Type="String"
                                                    ValidationGroup="gpoGuarda" ValueToCompare="-">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Función de la plaza"><InsertItemTemplate>
                                <asp:DropDownList ID="ddlFuncionPlaza" runat="server" SkinID="SkinDropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlFuncionPlaza_SelectedIndexChanged">
                                                    <asp:ListItem Value="-" Text="-"/>
                                                    <asp:ListItem Value="1" Text="Administrativa"/>
                                                    <asp:ListItem Value="2" Text="Docentes"/>
                                                    <asp:ListItem Value="3" Text="Directiva"/>                
                                    </asp:DropDownList><asp:CompareValidator ID="CVFuncionPlaza" runat="server"
                                                    ControlToValidate="ddlFuncionPlaza" Display="Dynamic" ErrorMessage="Seleccione la función de la plaza"
                                                    Operator="NotEqual" ToolTip="Seleccione la función de la plaza" Type="String"
                                                    ValidationGroup="gpoGuarda" ValueToCompare="-">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Centro de Adscripción al que pertenece la Plaza<br />(Utilizado para pago)"><InsertItemTemplate><asp:DropDownList ID="ddlPlantelesPlaza" runat="server" SkinID="SkinDropDownList" AutoPostBack="True" 
                                        ></asp:DropDownList><asp:CompareValidator ID="CVPlantelesPlaza" runat="server"
                                                ControlToValidate="ddlPlantelesPlaza" Display="Dynamic" ErrorMessage="Seleccione el centro de adscripción de la plaza"
                                                Operator="NotEqual" ToolTip="Seleccione el centro de adscripción de la plaza" Type="Integer"
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Categor&#237;a"><InsertItemTemplate>
                                <asp:DropDownList ID="ddlCategorias" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged"
                                    ></asp:DropDownList><asp:CompareValidator ID="CVCategorias" runat="server"
                                                ControlToValidate="ddlCategorias" Display="Dynamic" ErrorMessage="Seleccione la categoría"
                                                Operator="NotEqual" ToolTip="Seleccione la categoría" Type="Integer"
                                                ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator>
                                 
                                                                           </InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad de horas disponibles (solo si aplica segun la categoría)"><InsertItemTemplate>
                                        <asp:textbox ID="txtHoras" runat="server" AutoPostBack="True"></asp:textbox><asp:CompareValidator ID="CVHoras" runat="server"
                                                ControlToValidate="txtHoras" Display="Dynamic" ErrorMessage="Ingrese las horas"
                                                Operator="NotEqual" ToolTip="Ingrese las horas" Type="Integer"
                                                ValidationGroup="gpoGuarda" ValueToCompare="0" Enabled="False">*</asp:CompareValidator>
                                <asp:RegularExpressionValidator id="RVtxtHoras" runat="SERVER" 
                                           ControlToValidate="txtHoras" ErrorMessage="Introduzca solo caracteres numéricos" ValidationExpression="^[0-9]{1,3}$"  Display="Dynamic"   ValidationGroup="gpoGuarda">
                                        </asp:RegularExpressionValidator>

                                                                                                                              </InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Sindicato"><InsertItemTemplate><asp:DropDownList ID="ddlSindicato" runat="server" SkinID="SkinDropDownList" AutoPostBack="True"
                                                ></asp:DropDownList><asp:CompareValidator ID="CVSindicato" runat="server"
                                                    ControlToValidate="ddlSindicato" Display="Dynamic" ErrorMessage="Seleccione la categoría"
                                                    Operator="NotEqual" ToolTip="Seleccione el sindicato" Type="Integer"
                                                    ValidationGroup="gpoGuarda" ValueToCompare="0">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>
                            <asp:TemplateField HeaderText="Estatus de la plaza BASE"><InsertItemTemplate><asp:DropDownList ID="ddlEstatusPlaza" runat="server" SkinID="SkinDropDownList" AutoPostBack="True">
                                <asp:ListItem Value="-" Text="-"/>
                                <asp:ListItem Value="A" Text="Activa"/>
                                <asp:ListItem Value="B" Text="Ocupada"/>
                                <asp:ListItem Value="D" Text="Deshabilitada"/>
                                <asp:ListItem Value="C" Text="Cancelada"/></asp:DropDownList>
                                <asp:CompareValidator ID="CVPlazasEstatusBase" runat="server"
                                                ControlToValidate="ddlEstatusPlaza" Display="Dynamic" ErrorMessage="Seleccione el estatus"
                                                Operator="NotEqual" ToolTip="Seleccione el estatus de la plaza base" Type="String"
                                                ValidationGroup="gpoGuarda" ValueToCompare="-">*</asp:CompareValidator></InsertItemTemplate><HeaderStyle  HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Esquema de pago">
                                <InsertItemTemplate>
                                            <asp:DropDownList ID="ddlEsquemaPago" runat="server" SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                </InsertItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=""><InsertItemTemplate></InsertItemTemplate><HeaderStyle HorizontalAlign="Left" Wrap="False" /><ItemStyle HorizontalAlign="Left" Wrap="False" /></asp:TemplateField>

                            
                       </Fields>
                </asp:DetailsView>
                    
                 <asp:DetailsView ID="dvBotones" runat="server" AutoGenerateRows="False" SkinID="SkinDetailsView"
                        DefaultMode="Insert" Width="100%">
                        <FieldHeaderStyle Width="250px" Wrap="True" />
                        <Fields>       
                            <asp:TemplateField ShowHeader="False"><EditItemTemplate>
                                <asp:Button ID="btnCancelar" runat="server" SkinID="SkinBoton" Text="Cancelar" CausesValidation="false"/>
                                <asp:Button ID="btnGuardar" runat="server" SkinID="SkinBoton" Text="Guardar" ToolTip="Guardar cambios"
                                        OnClick="btnGuardar_Click" ValidationGroup="gpoGuarda" /><ajaxToolkit:ConfirmButtonExtender ID="CBE" runat="server"
                                            TargetControlID="btnGuardar" ConfirmText="¿Está seguro de guardar los cambios realizados?"></ajaxToolkit:ConfirmButtonExtender><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="gpoGuarda" /></EditItemTemplate><ItemStyle HorizontalAlign="Right" /></asp:TemplateField>
                        </Fields>
                    </asp:DetailsView>
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
                                    PostBackUrl="~/Consultas/Plazas/PlazasBase.aspx?TipoOperacion=4" 
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
                    <uc3:wucMuestraErrores ID="wucMuestraErrores1" runat="server" />
                    <div id="divBotonesErrores">
                        <p class="submitButton">
                            <asp:Button ID="btnReintentarOp" runat="server" Text="Reintentar operación" ToolTip=""
                                />
                            <asp:Button ID="btnCancelarOp" runat="server" Text="Continuar con otra operación en el sistema" 
                                ToolTip="" 
                                PostBackUrl="~/Consultas/Plazas/PlazasBase.aspx?TipoOperacion=4" />
                        </p>
                    </div>
                    <!--
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
                    -->
                </asp:View>
            </asp:MultiView>
        </asp:Panel>
    
    </ContentTemplate>
    <Triggers>
        
    </Triggers>
</asp:UpdatePanel>
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
   </table>
</asp:Content>
               