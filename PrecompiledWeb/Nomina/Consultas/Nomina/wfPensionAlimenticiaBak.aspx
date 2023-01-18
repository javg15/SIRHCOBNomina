<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="wfMain_PensionAlim2, App_Web_xh1ifbg5" title="COBAEV - Nómina - Consulta de beneficiarios de pensión alimenticia" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register src="../../WebControls/wucMuestraErrores.ascx" tagname="wucMuestraErrores" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <h2>
                Sistema de nómina: Beneficiarios de pensión alimenticia por empleado
            </h2>
            <asp:Panel ID="pnlBuscaEmps" runat="server">
                <uc1:wucBuscaEmpleados ID="wucBuscaEmps" runat="server" EnableViewState="true"></uc1:wucBuscaEmpleados>
            </asp:Panel>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewBenef" runat="server">
                    <p style="text-align: left">
                        <asp:Label ID="lblEmpInf" runat="server" Font-Strikeout="False" Font-Underline="True"
                            Visible="False"></asp:Label>
                    </p>
                    <p style="text-align: left">
                        <asp:LinkButton ID="lbAgregarNuevo" runat="server" Font-Bold="False" Font-Italic="False"
                            ToolTip="Agregar nuevo beneficiario  para pensión alimenticia" Visible="False"
                            OnClick="lbAgregarNuevo_Click">Agregar nuevo beneficiario
                        </asp:LinkButton>
                    </p>
                    <asp:Panel ID="pnlBenefPAVig" runat="server" Visible="false" GroupingText="Beneficiarios de pensión alimenticia (VIGENTES)">
                        <asp:GridView ID="gvPensionados" runat="server" EmptyDataText="Sin información de beneficarios de pensión alimenticia vigentes"
                            SkinID="SkinGridView" Width="100%" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="IdBeneficiario" Visible="False">
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdBeneficiario" runat="server" Text='<%# Bind("IdBeneficiario") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido paterno">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApePat" runat="server" Text='<%# Bind("ApePat") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido materno">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApeMat" runat="server" Text='<%# Bind("ApeMat") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DescParentesco" HeaderText="Parentesco" />
                                <asp:BoundField DataField="DescFormaCalcPA" HeaderText="Forma de cálculo">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OrigenDelPorcentaje" HeaderText="Porcentaje obtenido del">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="strNumDeSalMin" HeaderText="Cantidad de salarios mínimos">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Aplicar solo en quincenas ordinarias">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkbxAplicarSoloEnQnasOrd" runat="server" Checked='<%# Bind("AplicarSoloEnQnasOrd") %>' Enabled="false" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="PrioridadCalculo" HeaderText="Prioridad">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Inicio">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQnaIni" runat="server" Text='<%# Bind("QnaIni") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Término">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQnaFin" runat="server" Text='<%# Bind("QnaFin") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="DescPlantel" HeaderText="Plantel de pago" Visible="false">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FormaDePago" HeaderText="Forma de pago al beneficiario">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibVerDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                            ToolTip="Utilice esta opción si lo que desea es ver información detallada del beneficiario." 
                                            onclick="ibVerDetalles_Click"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibModificar" runat="server" ImageUrl="~/Imagenes/Modificar.png"
                                            ToolTip="Utilice esta opción si lo que desea es modificar algún dato de la información del beneficiario." OnClick="ibModificar_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibBaja" runat="server" ImageUrl="~/Imagenes/HandDown.png" ToolTip="Utilice esta opción si lo que desea es dar de baja este registro."
                                            OnClick="ibBaja_Click" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="ibBaja_CBE" runat="server" 
                                            ConfirmText="" Enabled="True" TargetControlID="ibBaja">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibEliminar" runat="server" ImageUrl="~/Imagenes/Eliminar.png"
                                            ToolTip="Utilice esta opción si lo que desea es eliminar el registro." OnClick="ibEliminar_Click" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará definitivamente éste registro de la Base de Datos, ¿Continuar?"
                                            TargetControlID="ibEliminar">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </asp:Panel>
                    <asp:Panel ID="pnlBenefPAHistoria" runat="server" Visible="false" 
                        GroupingText="Beneficiarios de pensión alimenticia (HISTORIA)">
                        <asp:GridView ID="gvPensionados2" runat="server" EmptyDataText="Sin información histórica de beneficarios de pensión alimenticia"
                            SkinID="SkinGridView" Width="100%" AutoGenerateColumns="False" OnRowDataBound="gvPensionados2_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="IdBeneficiario" Visible="False">
                                    <EditItemTemplate>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdBeneficiario" runat="server" Text='<%# Bind("IdBeneficiario") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ApePat" HeaderText="Apellido paterno" />
                                <asp:BoundField DataField="ApeMat" HeaderText="Apellido materno" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="DescParentesco" HeaderText="Parentesco" />
                                <asp:BoundField DataField="DescFormaCalcPA" HeaderText="Forma de cálculo">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OrigenDelPorcentaje" HeaderText="Porcentaje obtenido del">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="strNumDeSalMin" HeaderText="Cantidad de salarios mínimos">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Aplicar solo en quincenas ordinarias">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkbxAplicarSoloEnQnasOrd" runat="server" Checked='<%# Bind("AplicarSoloEnQnasOrd") %>' Enabled="false" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="PrioridadCalculo" HeaderText="Prioridad">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="QnaIni" HeaderText="Inicio">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="QnaFin" HeaderText="T&#233;rmino">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescPlantel" HeaderText="Plantel de pago" Visible="false">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FormaDePago" HeaderText="Forma de pago al beneficiario">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibVerDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                            ToolTip="Ver información detallada del beneficiario" 
                                            onclick="ibVerDetalles_Click"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibCrearCopia" runat="server" ImageUrl="~/Imagenes/CopiarRegistroEnabled.png"
                                            ToolTip="Crear un nuevo registro de beneficiario de pensión alimenticia tomando como base los datos de este registro." 
                                            onclick="ibCrearCopia_Click"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </asp:Panel>
                </asp:View>
                <asp:View ID="viewCapturaModif" runat="server">
                <div class="accountInfo">
                    <asp:Panel ID="pnlWarning" CssClass="Warning1" runat="server">
                            <b>¡Importante!<br /> </b>Utilice esta opción solo si la captura es realmente de un nuevo beneficiario
                            o si está creando un beneficiario a partir de uno ya existente en estatus no vigente, de 
                            lo contrario podrían generarse resultados no deseados al momento de realizar los 
                            cálculos de los montos a recibir por cada beneficiario, situación que podría presentarse
                            por el valor correspondiente asignado en el campo <b>Prioridad para asignación de recursos</b>
                    </asp:Panel>
                    <p>
                        <asp:CheckBox ID="chbxMostrarOcultarTips" runat="server" AutoPostBack="True" 
                            Text="Mostrar ayuda en los campos a llenar" />
                    </p>
                    <fieldset id="fsCaptura">
                        <legend>
                            <asp:Label ID="lblEmpInf2" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                        </legend>
                    <fieldset id="fsCapturaDatosPersBenef">
                        <legend>
                            <asp:Label ID="lblDatosPersBenef" runat="server" Font-Strikeout="False" Font-Underline="True"
                             Text="Datos personales del beneficiario de pensión alimenticia"></asp:Label>
                        </legend>
                        <div class="panelIzquierda">
                            <p class="pLabel">
                                <asp:Label ID="lblRFC" runat="server" Text="R.F.C.:" CssClass="pLabel" />
                            </p>
                            <p class="pTextBox">
                                <asp:TextBox ID="txtbxRFC" runat="server" MaxLength="13" CssClass="textEntry" AutoPostBack="True"
                                    TabIndex="1"></asp:TextBox>
                                <ajaxToolkit:BalloonPopupExtender ID="txtbxRFC_BPE" runat="server" BalloonPopupControlID="pnlHelpRFC"
                                    CustomCssUrl="" DynamicServicePath="" Enabled="True" ExtenderControlID="txtbxRFC"
                                    TargetControlID="txtbxRFC" DisplayOnFocus="true" BalloonSize="Medium">
                                </ajaxToolkit:BalloonPopupExtender>
                                <asp:RegularExpressionValidator ID="REVRFC" runat="server" ValidationExpression="[A-Z, a-z]{4}\d{6}[A-Z, a-z, 0-9][A-Z, 0-9][A-Z, a-z, 0-9]"
                                    ControlToValidate="txtbxRFC" Display="Dynamic" ErrorMessage="*" ToolTip="R.F.C. incorrecto."
                                    ValidationGroup="GrupoGuardar">
                                </asp:RegularExpressionValidator>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTBERFC" runat="server" TargetControlID="txtbxRFC"
                                    FilterType="Numbers, UppercaseLetters, LowercaseLetters">
                                </ajaxToolkit:FilteredTextBoxExtender>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblApePat" runat="server" CssClass="pLabel" Text="Apellido paterno:" />
                            </p>
                            <p class="pTextBox">
                                <asp:TextBox ID="txtbxApePat" runat="server" AutoPostBack="True" CssClass="textEntry"
                                    MaxLength="30" TabIndex="3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFVApePatEmp" runat="server" ControlToValidate="txtbxApePat"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="La captura del Apellido Paterno es obligatoria."
                                    ValidationGroup="GrupoGuardar">
                                </asp:RequiredFieldValidator>
                                <ajaxToolkit:AutoCompleteExtender ID="ACEApellidosP" runat="server" BehaviorID="AutoCompleteAP"
                                    EnableCaching="true" MinimumPrefixLength="2" ServiceMethod="BuscarApellidos"
                                    ServicePath="~/WSBusquedas.asmx" TargetControlID="txtbxApePat">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FTBEApellidosP" runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                    TargetControlID="txtbxApePat" ValidChars=" ÑñÁáÉéÍíÓóÚó-">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:BalloonPopupExtender ID="txtbxApePat_BPE" runat="server" BalloonPopupControlID="pnlHelpApePat"
                                    BalloonSize="Medium" CustomCssUrl="" DynamicServicePath="" Enabled="True" ExtenderControlID="txtbxApePat"
                                    TargetControlID="txtbxApePat" DisplayOnFocus="true">
                                </ajaxToolkit:BalloonPopupExtender>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblNombre" runat="server" CssClass="pLabel" Text="Nombre:" />
                            </p>
                            <p class="pTextBox">
                                <asp:TextBox ID="txtbxNombre" runat="server" AutoPostBack="True" CssClass="textEntry"
                                    MaxLength="30" TabIndex="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="txtbxNombre_RFV" runat="server" ControlToValidate="txtbxNombre"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="La captura del Nombre es obligatoria."
                                    ValidationGroup="GrupoGuardar">
                                </asp:RequiredFieldValidator>
                                <ajaxToolkit:AutoCompleteExtender ID="txtbxNombre_ACE" runat="server" EnableCaching="true"
                                    MinimumPrefixLength="2" ServiceMethod="BuscarNombres" ServicePath="~/WSBusquedas.asmx"
                                    TargetControlID="txtbxNombre">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:FilteredTextBoxExtender ID="txtbxNombre_FTBE" runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                    TargetControlID="txtbxNombre" ValidChars=" ÑñÁáÉéÍíÓóÚó-">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:BalloonPopupExtender ID="txtbxNombre_BPE" runat="server" BalloonPopupControlID="pnlHelpNombre"
                                    BalloonSize="Medium" CustomCssUrl="" DynamicServicePath="" Enabled="True" ExtenderControlID="txtbxNombre"
                                    TargetControlID="txtbxNombre" DisplayOnFocus="True">
                                </ajaxToolkit:BalloonPopupExtender>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblSexo" runat="server" CssClass="pLabel" Text="Sexo:" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlSexos" runat="server" AutoPostBack="True" CssClass="textEntry"
                                    OnSelectedIndexChanged="ddlSexos_SelectedIndexChanged" TabIndex="6">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ddlSexos_RFV" runat="server" ControlToValidate="ddlSexos"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Seleccionar el sexo del beneficiario es obligatorio."
                                    InitialValue="3" ValidationGroup="GrupoGuardar">
                                </asp:RequiredFieldValidator>
                                <ajaxToolkit:BalloonPopupExtender ID="ddlSexos_BPE" runat="server" CustomCssUrl=""
                                    DynamicServicePath="" Enabled="True" ExtenderControlID="ddlSexos" TargetControlID="ddlSexos"
                                    BalloonPopupControlID="pnlHelpSexos" DisplayOnFocus="True" BalloonSize="Medium">
                                </ajaxToolkit:BalloonPopupExtender>
                            </p>
                            <p class="pLabel">
                                <asp:Label ID="lblParentesco" runat="server" CssClass="pLabel" Text="Parentesco del beneficiario con el empleado:" />
                            </p>
                            <p class="pTextBox">
                                <asp:DropDownList ID="ddlParentescos" runat="server" CssClass="textEntry" TabIndex="8">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="ddlParentescos_RFV" runat="server" ControlToValidate="ddlParentescos"
                                    Display="Dynamic" ErrorMessage="*" ToolTip="Seleccionar el parentesco del beneficiario es obligatorio."
                                    InitialValue="7" ValidationGroup="GrupoGuardar">
                                </asp:RequiredFieldValidator>
                                <ajaxToolkit:BalloonPopupExtender ID="ddlParentescos_BPE" runat="server" CustomCssUrl=""
                                    DynamicServicePath="" Enabled="True" ExtenderControlID="ddlParentescos" TargetControlID="ddlParentescos"
                                    BalloonPopupControlID="pnlHelpParentesco" DisplayOnFocus="True" BalloonSize="Medium">
                                </ajaxToolkit:BalloonPopupExtender>
                            </p>
                        </div>
                         <div class="pnlDerecha">
                             <p class="pLabel">
                                 <asp:Label ID="lblCURP" runat="server" Text="C.U.R.P.:" CssClass="pLabel" />
                             </p>
                             <p class="pTextBox">
                                 <asp:TextBox ID="txtbxCURP" runat="server" MaxLength="18" CssClass="textEntry" AutoPostBack="True"
                                     TabIndex="2"></asp:TextBox>
                                 <ajaxToolkit:BalloonPopupExtender ID="txtbxCURP_BPE" runat="server" BalloonPopupControlID="pnlHelpCURP"
                                     CustomCssUrl="" DynamicServicePath="" Enabled="True" ExtenderControlID="txtbxCURP"
                                     TargetControlID="txtbxCURP" DisplayOnFocus="True" BalloonSize="Medium">
                                 </ajaxToolkit:BalloonPopupExtender>
                                 <asp:RegularExpressionValidator ID="REVCURP" runat="server" ValidationExpression="[A-Z, a-z]{4}\d{6}[A-Z, a-z]{6}[A-Z, a-z, 0-9]{2}"
                                     ControlToValidate="txtbxCURP" Display="Dynamic" ErrorMessage="*" ToolTip="C.U.R.P. incorrecta."
                                     ValidationGroup="GrupoGuardar"></asp:RegularExpressionValidator>
                                 <ajaxToolkit:FilteredTextBoxExtender ID="FTBECURP" runat="server" TargetControlID="txtbxCURP"
                                     FilterType="Numbers, UppercaseLetters, LowercaseLetters">
                                 </ajaxToolkit:FilteredTextBoxExtender>
                             </p>
                             <p class="pLabel">
                                 <asp:Label ID="lblApeMat" runat="server" CssClass="pLabel" Text="Apellido materno:" />
                             </p>
                             <p class="pTextBox">
                                 <asp:TextBox ID="txtbxApeMat" runat="server" AutoPostBack="True" CssClass="textEntry"
                                     MaxLength="30" TabIndex="4"></asp:TextBox>
                                 <ajaxToolkit:AutoCompleteExtender ID="txtbxApeMat_ACE" runat="server" BehaviorID="AutoCompleteAM"
                                     EnableCaching="true" MinimumPrefixLength="2" ServiceMethod="BuscarApellidos"
                                     ServicePath="~/WSBusquedas.asmx" TargetControlID="txtbxApeMat">
                                 </ajaxToolkit:AutoCompleteExtender>
                                 <ajaxToolkit:FilteredTextBoxExtender ID="txtbxApeMat_FTBE" runat="server" FilterType="Custom, UppercaseLetters, LowercaseLetters"
                                     TargetControlID="txtbxApeMat" ValidChars=" ÑñÁáÉéÍíÓóÚó-">
                                 </ajaxToolkit:FilteredTextBoxExtender>
                                 <ajaxToolkit:BalloonPopupExtender ID="txtbxApeMat_BPE" runat="server" BalloonPopupControlID="pnlHelpApeMat"
                                     BalloonSize="Medium" CustomCssUrl="" DynamicServicePath="" Enabled="True" ExtenderControlID="txtbxApeMat"
                                     TargetControlID="txtbxApeMat" DisplayOnFocus="True">
                                 </ajaxToolkit:BalloonPopupExtender>
                             </p>
                             <p class="pLabel">
                             </p>
                             <p class="pTextBox">
                             </p>
                             <p class="pLabel">
                                 <asp:Label ID="lblFechaNac" runat="server" CssClass="pLabel" Text="Fecha de nacimiento:" />
                             </p>
                             <p class="pTextBox">
                                 <asp:TextBox ID="txtbxFecNac" runat="server" CssClass="textEntry" MaxLength="10"
                                     Wrap="False" TabIndex="7"></asp:TextBox>
                                 <ajaxToolkit:CalendarExtender ID="txtbxFecNac_CE" runat="server" Enabled="True" TargetControlID="txtbxFecNac">
                                 </ajaxToolkit:CalendarExtender>
                                 <ajaxToolkit:BalloonPopupExtender ID="txtbxFecNac_BPE" runat="server" BalloonPopupControlID="pnlHelpFechNac"
                                     CustomCssUrl="" DynamicServicePath="" Enabled="True" ExtenderControlID="txtbxFecNac"
                                     BalloonSize="Medium" TargetControlID="txtbxFecNac" DisplayOnFocus="True">
                                 </ajaxToolkit:BalloonPopupExtender>
                                 <asp:CompareValidator ID="txtbxFecNac_CV" runat="server" ControlToValidate="txtbxFecNac"
                                     Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" ToolTip="Fecha incorrecta"
                                     Type="Date" ValidationGroup="GrupoGuardar">
                                 </asp:CompareValidator>
                             </p>
                             <p class="pLabel">
                                 <asp:Label ID="lblEdoNac" runat="server" CssClass="pLabel" Text="Estado natal del beneficiario:" />
                             </p>
                             <p class="pTextBox">
                                 <asp:DropDownList ID="ddlEstados" runat="server" CssClass="textEntry" TabIndex="9">
                                 </asp:DropDownList>
                                 <ajaxToolkit:BalloonPopupExtender ID="ddlEstados_BPE" runat="server" BalloonPopupControlID="pnlHelpEdoNatal"
                                     BalloonSize="Medium" CustomCssUrl="" DynamicServicePath="" Enabled="True" ExtenderControlID="ddlEstados"
                                     TargetControlID="ddlEstados" DisplayOnFocus="True">
                                 </ajaxToolkit:BalloonPopupExtender>
                             </p>
                         </div>
                    </fieldset>
                        <fieldset id="fsCapturaDatosPagoBenef">
                            <legend>
                                <asp:Label ID="lblDatosPagoBenef" runat="server" Font-Strikeout="False" Font-Underline="True"
                                    Text="Datos de la forma de pago al beneficiario de pensión alimenticia"></asp:Label>
                            </legend>
                            <div class="panelIzquierda">
                                <p class="pTextBox">
                                    <asp:CheckBox runat="server" ID="chkbxTransBanc" Text="Pagar mediante transferencia bancaria"
                                        TabIndex="13" AutoPostBack="True" />
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblBancosTB" runat="server" CssClass="pLabel" Text="Banco para la transferencia bancaria:" />
                                </p>
                                <p class="pTextBox">
                                    <asp:DropDownList ID="ddlBancosTB" runat="server" CssClass="textEntry" Enabled="false"
                                        TabIndex="15" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ddlBancosTB_RFV" runat="server" ControlToValidate="ddlBancosTB"
                                        Display="Dynamic" ErrorMessage="*" InitialValue="3" ToolTip="Seleccionar el banco para la transferencia bancaria es obligatorio."
                                        ValidationGroup="GrupoGuardar" Enabled="false">
                                    </asp:RequiredFieldValidator>
                                    <ajaxToolkit:BalloonPopupExtender ID="ddlBancosTB_BPE" runat="server" BalloonPopupControlID="pnlHelpBancosTB"
                                        BalloonSize="Medium" CustomCssUrl="" DisplayOnFocus="True" DynamicServicePath=""
                                        Enabled="True" ExtenderControlID="ddlBancosTB" TargetControlID="ddlBancosTB">
                                    </ajaxToolkit:BalloonPopupExtender>
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblCtaBancBT" runat="server" CssClass="pLabel" Text="Cuenta para la transferencia bancaria:" />
                                </p>
                                <p class="pTextBox">
                                    <asp:TextBox ID="txtbxCtaBancTB" runat="server" CssClass="textEntry" TabIndex="17"
                                        ValidationGroup="GrupoGuardar"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="txtbxCtaBancTB_REV" runat="server" ValidationExpression=""
                                        ControlToValidate="txtbxCtaBancTB" Display="Dynamic" ErrorMessage="*" ToolTip=""
                                        ValidationGroup="GrupoGuardar">
                                    </asp:RegularExpressionValidator>
                                    <ajaxToolkit:BalloonPopupExtender ID="txtbxCtaBancTB_BPE" runat="server" BalloonPopupControlID="pnlHelpCtaBancTB"
                                        BalloonSize="Medium" CustomCssUrl="" DisplayOnFocus="True" DynamicServicePath=""
                                        Enabled="True" ExtenderControlID="txtbxCtaBancTB" TargetControlID="txtbxCtaBancTB">
                                    </ajaxToolkit:BalloonPopupExtender>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtbxCtaBancTB_FTE" runat="server" FilterType="Numbers"
                                        TargetControlID="txtbxCtaBancTB" ValidChars="">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="txtbxCtaBancTB_RFV" runat="server" ControlToValidate="txtbxCtaBancTB"
                                        Display="Dynamic" ErrorMessage="*" ToolTip="La captura de la cuenta para la transferencia bancaria es obligatoria."
                                        ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator>
                                    <p class="pLabel">
                                        <asp:Label ID="lblPlantel" runat="server" CssClass="pLabel" Text="Plantel (Para una posible radicación del recurso):" />
                                    </p>
                                    <p class="pTextBox">
                                        <asp:DropDownList ID="ddlPlanteles" runat="server" CssClass="textEntry" TabIndex="19">
                                        </asp:DropDownList>
                                        <ajaxToolkit:BalloonPopupExtender ID="ddlPlanteles_BPE" runat="server" CustomCssUrl=""
                                            DynamicServicePath="" Enabled="True" ExtenderControlID="ddlPlanteles" TargetControlID="ddlPlanteles"
                                            BalloonPopupControlID="pnlHelpPlanteles" BalloonSize="Medium" DisplayOnFocus="True">
                                        </ajaxToolkit:BalloonPopupExtender>
                                    </p>
                                    <p class="pLabel">
                                        <asp:Label ID="lblQnaIni" runat="server" CssClass="pLabel" Text="Inicio:" />
                                    </p>
                                    <p class="pTextBox">
                                        <asp:DropDownList ID="ddlQnaIni" runat="server" AutoPostBack="true" CssClass="textEntry"
                                            TabIndex="21">
                                        </asp:DropDownList>
                                        <ajaxToolkit:BalloonPopupExtender ID="ddlQnaIni_BPE" runat="server" BalloonPopupControlID="pnlHelpQnaIni"
                                            BalloonSize="Medium" CustomCssUrl="" DisplayOnFocus="true" DynamicServicePath=""
                                            Enabled="True" ExtenderControlID="ddlQnaIni" TargetControlID="ddlQnaIni">
                                        </ajaxToolkit:BalloonPopupExtender>
                                    </p>
                                </p>
                            </div>
                            <div class="pnlDerecha">
                                <p class="pTextBox">
                                    <asp:CheckBox runat="server" ID="chkbxTransInterBanc" Text="Pagar mediante transferencia interbancaria (CLABE)"
                                        TabIndex="14" AutoPostBack="True" />
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblCtaBancTIB" runat="server" CssClass="pLabel" Text="Cuenta para la transferencia interbancaria (CLABE):" />
                                </p>
                                <p class="pTextBox">
                                    <asp:TextBox ID="txtbxCtaTIB" runat="server" CssClass="textEntry" TabIndex="16" ValidationGroup="GrupoGuardar"
                                        AutoPostBack="True" MaxLength="18"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="txtbxCtaTIB_REV" runat="server" ValidationExpression="\d{18}"
                                        ControlToValidate="txtbxCtaTIB" Display="Dynamic" ErrorMessage="*" ToolTip="La longitud de la cuenta para la transferencia interbancaria debe ser de 18 dígitos."
                                        ValidationGroup="GrupoGuardar"></asp:RegularExpressionValidator>
                                    <ajaxToolkit:BalloonPopupExtender ID="txtbxCtaTIB_BPE" runat="server" BalloonPopupControlID="pnlHelpCtaTIB"
                                        BalloonSize="Medium" CustomCssUrl="" DisplayOnFocus="True" DynamicServicePath=""
                                        Enabled="True" ExtenderControlID="txtbxCtaTIB" TargetControlID="txtbxCtaTIB">
                                    </ajaxToolkit:BalloonPopupExtender>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtbxCtaTIB_FTE" runat="server" FilterType="Numbers"
                                        TargetControlID="txtbxCtaTIB" ValidChars="">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="txtbxCtaTIB_RFV" runat="server" ControlToValidate="txtbxCtaTIB"
                                        Display="Dynamic" ErrorMessage="*" ToolTip="La captura de la cuenta para la transferencia interbancaria es obligatoria."
                                        ValidationGroup="GrupoGuardar"></asp:RequiredFieldValidator>
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblBancosTIB" runat="server" CssClass="pLabel" Text="Banco al que pertenece la cuenta interbancaria (CLABE):" />
                                </p>
                                <p class="pTextBox">
                                    <asp:DropDownList ID="ddlBancosTIB" runat="server" CssClass="textEntry" Enabled="false"
                                        TabIndex="18" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ddlBancosTIB_RFV" runat="server" ControlToValidate="ddlBancosTIB"
                                        Display="Dynamic" ErrorMessage="*" InitialValue="4" ToolTip="El banco para la transferencia interbancaria es incorrecto."
                                        ValidationGroup="GrupoGuardar" Enabled="false">
                                    </asp:RequiredFieldValidator>
                                    <ajaxToolkit:BalloonPopupExtender ID="ddlBancosTIB_BPE" runat="server" BalloonPopupControlID="pnlHelpBancosTIB"
                                        BalloonSize="Medium" CustomCssUrl="" DisplayOnFocus="True" DynamicServicePath=""
                                        Enabled="True" ExtenderControlID="ddlBancosTIB" TargetControlID="ddlBancosTIB">
                                    </ajaxToolkit:BalloonPopupExtender>
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblBancoParaDispersion" runat="server" CssClass="pLabel" Text="Banco a través del cual se realizará la dispersión:" />
                                </p>
                                <p class="pTextBox">
                                    <asp:DropDownList ID="ddlBancosParaDispersion" runat="server" CssClass="textEntry"
                                        Enabled="false" TabIndex="20" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ddlBancosParaDispersion_RFV" runat="server" ControlToValidate="ddlBancosParaDispersion"
                                        Display="Dynamic" ErrorMessage="*" InitialValue="3" ToolTip="Seleccionar el banco a través del cual se realizará la dispersión es obligatorio."
                                        ValidationGroup="GrupoGuardar" Enabled="false">
                                    </asp:RequiredFieldValidator>
                                    <ajaxToolkit:BalloonPopupExtender ID="ddlBancosParaDispersion_BPE" runat="server"
                                        BalloonPopupControlID="pnlHelpBancosParaDispersion" BalloonSize="Medium" CustomCssUrl=""
                                        DisplayOnFocus="True" DynamicServicePath="" Enabled="True" ExtenderControlID="ddlBancosParaDispersion"
                                        TargetControlID="ddlBancosParaDispersion">
                                    </ajaxToolkit:BalloonPopupExtender>
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblQnaFin" runat="server" CssClass="pLabel" Text="Fin:" />
                                </p>
                                <p class="pTextBox">
                                    <asp:DropDownList ID="ddlQnaFin" runat="server" CssClass="textEntry" TabIndex="22">
                                    </asp:DropDownList>
                                    <ajaxToolkit:BalloonPopupExtender ID="ddlQnaFin_BPE" runat="server" CustomCssUrl=""
                                        DynamicServicePath="" Enabled="True" ExtenderControlID="ddlQnaFin" TargetControlID="ddlQnaFin"
                                        BalloonPopupControlID="pnlHelpQnaFin" BalloonSize="Medium" DisplayOnFocus="True">
                                    </ajaxToolkit:BalloonPopupExtender>
                                </p>
                            </div>
                        </fieldset>
                        <fieldset id="fsCapturaDatosFormaCalc" style="width: 97%; float: left;">
                            <legend class="sublegend">
                                <asp:Label ID="lblatosFormaCalc" Text="Datos sobre la forma de cálculo de la pensión aliementicia"
                                    runat="server" Font-Strikeout="False" Font-Underline="True">
                                </asp:Label>
                            </legend>
                            <div class="panelIzquierda">
                                <p class="pLabel">
                                    <asp:Label ID="lblFormaDeCalc" runat="server" Text="Forma de cálculo:" CssClass="pLabel" />
                                </p>
                                <p class="pTextBox">
                                    <asp:DropDownList ID="ddlFormaCalculo" runat="server" CssClass="textEntry" AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="1">EN BASE A PORCENTAJE ASIGNADO</asp:ListItem>
                                        <asp:ListItem Value="2">EN BASE A SALARIO MÍNIMO</asp:ListItem>
                                    </asp:DropDownList>
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblPorc" runat="server" CssClass="pLabel" Text="Porcentaje asignado:" />
                                </p>
                                <p class="pTextBox">
                                    <asp:TextBox ID="txtbxPorc" runat="server" CssClass="textEntry" MaxLength="5" TabIndex="11"
                                        ValidationGroup="GrupoGuardar"></asp:TextBox>
                                    <ajaxToolkit:BalloonPopupExtender ID="txtbxPorc_BPE" runat="server" BalloonPopupControlID="pnlHelpPorcentaje"
                                        BalloonSize="Medium" CustomCssUrl="" DisplayOnFocus="True" DynamicServicePath=""
                                        Enabled="True" ExtenderControlID="txtbxPorc" TargetControlID="txtbxPorc">
                                    </ajaxToolkit:BalloonPopupExtender>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtbxPorc_FilteredTextBoxExtender" runat="server"
                                        FilterType="Custom, Numbers" TargetControlID="txtbxPorc" ValidChars=".">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:CompareValidator ID="txtbxPorc_CV" runat="server" ControlToValidate="txtbxPorc"
                                        Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" ToolTip="El valor capturado para el porcentaje es incorrecto."
                                        Type="Double" ValidationGroup="GrupoGuardar">
                                    </asp:CompareValidator>
                                    <asp:CompareValidator ID="txtbxPorc_CV2" runat="server" ControlToValidate="txtbxPorc"
                                        Display="Dynamic" ErrorMessage="*" Operator="GreaterThan" ToolTip="El valor capturado para el porcentaje debe ser mayor a 0.00"
                                        Type="Double" ValidationGroup="GrupoGuardar" ValueToCompare="0.00">
                                    </asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RFVPorc" runat="server" ControlToValidate="txtbxPorc"
                                        Display="Dynamic" ErrorMessage="*" ToolTip="La captura del porcentaje es obligatoria."
                                        ValidationGroup="GrupoGuardar">
                                    </asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="txtbxPorc_RV" runat="server" ControlToValidate="txtbxPorc"
                                        Display="Dynamic" ErrorMessage="*" MaximumValue="100.00" MinimumValue="0.01"
                                        ToolTip="El porcentaje capturado debe estar dentro del rango [0.01-100.00]" Type="Double"
                                        ValidationGroup="GrupoGuardar"></asp:RangeValidator>
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblPorcCompartidoCon" runat="server" CssClass="pLabel" Text="Porcentaje se obtendrá del:" />
                                </p>
                                <p class="pTextBox">
                                    <asp:DropDownList ID="ddlBeneficiarios" runat="server" CssClass="textEntry">
                                    </asp:DropDownList>
                                    <ajaxToolkit:BalloonPopupExtender ID="lbBeneficiarios_BPE" runat="server" BalloonPopupControlID="pnlHelplbBeneficiarios"
                                        BalloonSize="Medium" CustomCssUrl="" DisplayOnFocus="True" DynamicServicePath=""
                                        Enabled="True" ExtenderControlID="ddlBeneficiarios" TargetControlID="ddlBeneficiarios">
                                    </ajaxToolkit:BalloonPopupExtender>
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblPrioridad" runat="server" CssClass="pLabel" Text="Prioridad para asignación de recursos:" />
                                </p>
                                <p class="pTextBox">
                                    <asp:DropDownList ID="ddlPrioridadCalculo" runat="server" CssClass="textEntry" TabIndex="10"
                                        Visible="False">
                                    </asp:DropDownList>
                                    <ajaxToolkit:BalloonPopupExtender ID="ddlPrioridadCalculo_BPE" runat="server" CustomCssUrl=""
                                        DynamicServicePath="" Enabled="True" ExtenderControlID="ddlPrioridadCalculo"
                                        TargetControlID="ddlPrioridadCalculo" BalloonSize="Medium" BalloonPopupControlID="pnlHelpPrioridadCalculo"
                                        DisplayOnFocus="True">
                                    </ajaxToolkit:BalloonPopupExtender>
                                </p>
                            </div>
                            <div class="pnlDerecha">
                                <p class="pLabel">
                                </p>
                                <p class="pTextBox">
                                    <asp:CheckBox runat="server" ID="chbxDescontarSoloEnQnasOrd" Text="Calcular pensión alimenticia solo en quincenas ordinarias" />
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblNumSalMin" runat="server" CssClass="pLabel" Text="Cantidad de salarios mínimos diarios:" />
                                </p>
                                <p class="pTextBox">
                                    <asp:TextBox ID="txtbxNumSalMin" runat="server" CssClass="textEntry" MaxLength="5"
                                        TabIndex="11" ValidationGroup="GrupoGuardar"></asp:TextBox>
                                    <ajaxToolkit:BalloonPopupExtender ID="txtbxNumSalMin_BPE" runat="server" BalloonPopupControlID="pnlHelpNumSalMin"
                                        BalloonSize="Medium" CustomCssUrl="" DisplayOnFocus="True" DynamicServicePath=""
                                        Enabled="True" ExtenderControlID="txtbxNumSalMin" TargetControlID="txtbxNumSalMin">
                                    </ajaxToolkit:BalloonPopupExtender>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="txtbxNumSalMin_FTBE" runat="server" FilterType="Custom, Numbers"
                                        TargetControlID="txtbxNumSalMin" ValidChars=".">
                                    </ajaxToolkit:FilteredTextBoxExtender>
                                    <asp:CompareValidator ID="txtbxNumSalMin_CV" runat="server" ControlToValidate="txtbxNumSalMin"
                                        Display="Dynamic" ErrorMessage="*" Operator="DataTypeCheck" ToolTip="El valor capturado para la cantidad de salarios mínimos es incorrecto."
                                        Type="Double" ValidationGroup="GrupoGuardar">
                                    </asp:CompareValidator>
                                    <asp:CompareValidator ID="txtbxNumSalMin_CV2" runat="server" ControlToValidate="txtbxNumSalMin"
                                        Display="Dynamic" ErrorMessage="*" Operator="GreaterThanEqual" ToolTip="El valor capturado para la cantidad de salarios mínimos debe ser mayor o igual a 0.50"
                                        Type="Double" ValidationGroup="GrupoGuardar" ValueToCompare="0.50">
                                    </asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="txtbxNumSalMin_RFV" runat="server" ControlToValidate="txtbxNumSalMin"
                                        Display="Dynamic" ErrorMessage="*" ToolTip="La captura de la cantidad de salarios mínimos es obligatoria."
                                        ValidationGroup="GrupoGuardar">
                                    </asp:RequiredFieldValidator>
                                </p>
                            </div>
                        </fieldset>
                        <fieldset id="fsCapturaDatosDemanda" style="width: 97%; float: left;">
                            <legend class="sublegend">
                                <asp:Label ID="lblDatosDemanda" Text="Datos del dictamen de pensión aliementicia"
                                    runat="server" Font-Strikeout="False" Font-Underline="True">
                                </asp:Label>
                            </legend>
                            <div class="panelIzquierda">
                                <p class="pLabel">
                                    <asp:Label ID="lblOficioDictamenPA" runat="server" Text="Oficio:" CssClass="pLabel" />
                                </p>
                                <p class="pTextBox">
                                    <asp:TextBox ID="txtbxOficioDictamenPA" runat="server" MaxLength="50" CssClass="textEntry"
                                        AutoPostBack="True" TabIndex="2"></asp:TextBox>
                                    <ajaxToolkit:BalloonPopupExtender ID="txtbxOficioDictamenPA_BPE" runat="server" BalloonPopupControlID="pnlHelpOficioDictamenPA"
                                        CustomCssUrl="" DynamicServicePath="" Enabled="True" ExtenderControlID="txtbxOficioDictamenPA"
                                        TargetControlID="txtbxOficioDictamenPA" DisplayOnFocus="True" BalloonSize="Medium">
                                    </ajaxToolkit:BalloonPopupExtender>
                                </p>
                            </div>
                            <div class="pnlDerecha">
                                <p class="pLabel">
                                    <asp:Label ID="lblExpedienteDictamenPA" runat="server" Text="Expediente:" CssClass="pLabel" />
                                </p>
                                <p class="pTextBox">
                                    <asp:TextBox ID="txtbxExpedienteDictamenPA" runat="server" MaxLength="50" CssClass="textEntry"
                                        AutoPostBack="True" TabIndex="2"></asp:TextBox>
                                    <ajaxToolkit:BalloonPopupExtender ID="txtbxExpedienteDictamenPA_BPE" runat="server"
                                        BalloonPopupControlID="pnlHelpExpedienteDictamenPA" CustomCssUrl="" DynamicServicePath=""
                                        Enabled="True" ExtenderControlID="txtbxExpedienteDictamenPA" TargetControlID="txtbxExpedienteDictamenPA"
                                        DisplayOnFocus="True" BalloonSize="Medium">
                                    </ajaxToolkit:BalloonPopupExtender>
                                </p>
                            </div>
                        </fieldset>
                        </fieldset>
                    </div>
                    <div id="divBotones">
                        <p class="submitButton">
                            <asp:Button ID="btnCrearBenef" runat="server" Text="Guardar" 
                                ValidationGroup="GrupoGuardar"
                                ToolTip="Guardar información del nuevo beneficiario de pensión alimenticia" 
                                TabIndex="23" />
                            <asp:Button ID="btnModifBenef" runat="server" TabIndex="23" Text="Guardar" 
                                ToolTip="Guardar datos modificados" ValidationGroup="GrupoGuardar" 
                                Visible="False" />
                            <ajaxToolkit:ConfirmButtonExtender ID="btnModifBenef_ConfirmButtonExtender" runat="server" 
                                ConfirmText="¿Está seguro de que los datos registrados son correctos?" 
                                Enabled="True" TargetControlID="btnModifBenef">
                            </ajaxToolkit:ConfirmButtonExtender>
                            <ajaxToolkit:ConfirmButtonExtender ID="btnCrearBenef_CBE" runat="server" 
                                ConfirmText="¿Está seguro de que los datos capturados son correctos?" 
                                Enabled="True" TargetControlID="btnCrearBenef">
                            </ajaxToolkit:ConfirmButtonExtender>
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                                ToolTip="Cancelar operación actual" TabIndex="24" />
                        </p>
                    </div>
                    <div>
                                <asp:Panel ID="pnlHelpRFC" runat="server" HorizontalAlign="Justify">
                                    <p>
                                        Dato no obligatorio.
                                    </p>
                                    <p>
                                        En caso de desconocer el dato favor de dejar vacío el campo.
                                    </p>
                                    <p>
                                        Ejemplo de R.F.C. válido: <b>ROLF701026H93</b>
                                    </p>
                                </asp:Panel>
                                    <asp:Panel ID="pnlHelpApePat" runat="server" HorizontalAlign="Justify">
                                        <p>
                                            Dato obligatorio.
                                        </p>
                                        <p>
                                            En caso de contar con un solo apellido deberá escribirlo como 
                                            Apellido Paterno y el campo de Apellido Materno favor de dejarlo vacío.
                                        </p>
                                        <p>
                                            <b>Tip:</b> Puede escribir las primeras letras del Apellido Paterno y en unos
                                            instantes el Sistema le mostrará algunos apellidos relacionados para solo
                                            seleccionar el deseado.
                                        </p>
                                    </asp:Panel>
                                        <asp:Panel ID="pnlHelpNombre" runat="server" HorizontalAlign="Justify">
                                            <p>
                                                Dato obligatorio.
                                            </p>
                                            <p>
                                                <b>Tip:</b> Puede escribir las primeras letras del Nombre y en unos
                                                instantes el Sistema le mostrará algunos nombres relacionados para solo
                                                seleccionar el deseado.
                                            </p>
                                        </asp:Panel>
                                <asp:Panel ID="pnlHelpCURP" runat="server" HorizontalAlign="Justify">
                                    <p>
                                        Dato no obligatorio.
                                    </p>
                                    <p>
                                        En caso de desconocer el dato favor de dejar vacío el campo.
                                    </p>
                                    <p>
                                        Ejemplo de C.U.R.P. válida: <b>ROLF701026HVZDPB06</b>
                                    </p>
                                </asp:Panel>
                                    <asp:Panel ID="pnlHelpApeMat" runat="server" HorizontalAlign="Justify">
                                        <p>
                                            Dato no obligatorio.
                                        </p>
                                        <p>
                                            En caso de contar con un solo apellido deberá escribirlo 
                                            como Apellido Paterno y el campo de Apellido Materno favor de dejarlo vacío.
                                        </p>
                                        <p>
                                            <b>Tip:</b> Puede escribir las primeras letras del Apellido Materno y en unos
                                            instantes el Sistema le mostrará algunos apellidos relacionados para solo
                                            seleccionar el deseado.
                                        </p>
                                    </asp:Panel>
                        <asp:Panel ID="pnlHelpFechNac" runat="server" HorizontalAlign="Justify">
                            <p>
                                Dato no obligatorio.
                            </p>
                            <p>
                                En caso de desconocer el dato favor de dejar vacío el campo.
                            </p>
                            <p>
                                En caso de conocer la fecha de nacimiento favor de escribirla en el formato <b>dd/mm/aaaa</b>.
                            </p>
                        </asp:Panel>   
                        <asp:Panel ID="pnlHelpSexos" runat="server" HorizontalAlign="Justify">
                            Dato obligatorio.
                        </asp:Panel>
                        <asp:Panel ID="pnlHelpParentesco" runat="server" HorizontalAlign="Justify">
                            Dato obligatorio.
                        </asp:Panel>    
                         <asp:Panel ID="pnlHelpPorcentaje" runat="server" HorizontalAlign="Justify">
                            Dato obligatorio.<br />
                            El porcentaje debe estar dentro del rango [0.01-100.00]
                        </asp:Panel>
                         <asp:Panel ID="pnlHelpEdoNatal" runat="server" HorizontalAlign="Justify">
                            Dato no obligatorio.<br />
                            Si no desea especificar el estado natal del beneficario, seleccione la opción "SIN ESPECIFICAR".
                        </asp:Panel>  
                         <asp:Panel ID="pnlHelpPrioridadCalculo" runat="server" HorizontalAlign="Justify">
                            Dato obligatorio.<br />
                            Utilice esta opción para indicar el orden de asignación de recursos al beneficiario de pensión alimenticia.
                            Esta opción es especialmente útil cuando el empleado tiene más de un beneficiario de pensión alimenticia.
                        </asp:Panel>  
                         <asp:Panel ID="pnlHelpPlanteles" runat="server" HorizontalAlign="Justify">
                            Dato obligatorio.<br />
                            Utilice esta opción para indicar el plantel al cual el beneficiario desea que se le radique su pago (cheque).<br />
                            Debe indicarse un plantel aunque el pago sea realizado por transferencia bancaria o interbancaria.
                        </asp:Panel>  
                         <asp:Panel ID="pnlHelpQnaIni" runat="server" HorizontalAlign="Justify">
                            Dato obligatorio.<br />
                            La quincena de inicio indica a partir de que momento empezará a recibir su pago el beneficiario.
                        </asp:Panel>  
                         <asp:Panel ID="pnlHelpQnaFin" runat="server" HorizontalAlign="Justify">
                            Dato obligatorio.<br />
                            La quincena final indica a partir de que momento dejará de recibir su pago el beneficiario.
                        </asp:Panel> 
                         <asp:Panel ID="pnlHelpBancosTB" runat="server" HorizontalAlign="Justify">
                            Dato obligatorio solo si realizará transferencia bancaria al beneficiario.<br />
                        </asp:Panel>  
                         <asp:Panel ID="pnlHelpCtaBancTB" runat="server" HorizontalAlign="Justify">
                            <p>
                                Dato obligatorio solo si realizará transferencia bancaria al beneficiario.
                            </p>
                            <p>
                                La longitud de la cuenta bancaria debe ser de <asp:Label ID="lblLongCtaBacTB" runat="server" Text=""></asp:Label> dígitos.
                            </p>
                        </asp:Panel>  
                         <asp:Panel ID="pnlHelpBancosTIB" runat="server" HorizontalAlign="Justify">
                            Dato obligatorio solo si realizará transferencia interbancaria al beneficiario.<br />
                        </asp:Panel>
                         <asp:Panel ID="pnlHelpCtaTIB" runat="server" HorizontalAlign="Justify">
                            <p>
                                Dato obligatorio solo si realizará transferencia interbancaria al beneficiario.
                            </p>
                            <p>
                                La longitud de la cuenta interbancaria debe ser de 18 dígitos.
                            </p>
                        </asp:Panel>  
                         <asp:Panel ID="pnlHelpBancosParaDispersion" runat="server" HorizontalAlign="Justify">
                            <p>
                                Dato obligatorio solo si realizará transferencia interbancaria al beneficiario.
                            </p>
                        </asp:Panel>
                         <asp:Panel ID="pnlHelpNumSalMin" runat="server" HorizontalAlign="Justify">
                            <p>
                                Dato obligatorio.
                            </p>
                            <p>
                                El cantidad de salarios mínimos por día debe ser mayor o igual de 0.5
                            </p>
                        </asp:Panel>  
                         <asp:Panel ID="pnlHelplbBeneficiarios" runat="server" HorizontalAlign="Justify">
                            <p>
                                Dato obligatorio.
                            </p>
                            <p>
                                Permite indicar de donde será obtenido el porcentaje asignado al
                                beneficiario, si directamente del ingreso del empleado demandado o del porcentaje
                                asignado a algún otro beneficiario según este estipulado en
                                el mandato judicial correspondiente.
                            </p>
                        </asp:Panel>  
                                <asp:Panel ID="pnlHelpOficioDictamenPA" runat="server" HorizontalAlign="Justify">
                                    <p>
                                        Dato no obligatorio.
                                    </p>
                                    <p>
                                        En caso de desconocer el dato favor de dejar vacío el campo.
                                    </p>
                              </asp:Panel>
                                <asp:Panel ID="pnlHelpExpedienteDictamenPA" runat="server" HorizontalAlign="Justify">
                                    <p>
                                        Dato no obligatorio.
                                    </p>
                                    <p>
                                        En caso de desconocer el dato favor de dejar vacío el campo.
                                    </p>
                              </asp:Panel>
                    </div>
                </asp:View>
        <asp:View ID="viewConsulta" runat="server">
        <div class="accountInfo">
            <fieldset id="fsCapturaConsulta">
                    <legend>
                        <asp:Label ID="lblEmpInfConsulta" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                    </legend>
                    <div class="pnlCompleto">
                        <asp:DetailsView ID="dvBenef" runat="server" Height="50px" 
                            SkinID="SkinDetailsView" AutoGenerateRows="False" 
                            HeaderText="Información detallada del beneficiario" 
                            HorizontalAlign="Center">
                            <Fields>
                                <asp:BoundField DataField="RFC" HeaderText="R.F.C.:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />                                    
                                </asp:BoundField>
                                <asp:BoundField DataField="CURP" HeaderText="C.U.R.P.:" >
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ApePat" HeaderText="Apellido paterno:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ApeMat" HeaderText="Apellido materno:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre(s):">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescSexo" HeaderText="Sexo:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FecNac" HeaderText="Fecha de nacimiento:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescParentesco" HeaderText="Parentesco con el empleado:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NomEdo" HeaderText="Estado natal del beneficiario:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescFormaCalcPA" HeaderText="Forma de cálculo:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje asignado:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OrigenDelPorcentaje" HeaderText="Porcentaje obtenido del:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="strNumDeSalMin" HeaderText="Cantidad de salarios mínimos diarios:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Aplicar cálculo solo en quincenas ordinarias:">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkbxAplicarSoloEnQnasOrd" runat="server" Checked='<%# Bind("AplicarSoloEnQnasOrd") %>' Enabled="false" />
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="PrioridadCalculo" 
                                    HeaderText="Prioridad para la asignación de recursos:" >
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FormaDePago" HeaderText="Forma de pago:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescPlantel" HeaderText="Plantel (para posible radicación del cheque):">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CuentaBancaria" HeaderText="Cuenta bancaria:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CLABE" HeaderText="Clave Bancaria Estandarizada (CLABE):">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="QnaIni" HeaderText="Quincena inicial:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="QnaFin" HeaderText="Quincena final:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OficioDictamenPA" HeaderText="Oficio del dictamen de pensión alimenticia:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ExpedienteDictamenPA" HeaderText="Expediente del dictamen de pensión alimenticia:">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:BoundField>
                            </Fields>
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <RowStyle HorizontalAlign="Left" Wrap="False" />
                        </asp:DetailsView>
                    </div>
                    </fieldset
            </div>
            <div id="divBotonesConsulta">
                <p class="submitButton">
                    <asp:Button ID="btnCancelar2" runat="server" Text="Cancelar" ToolTip="Cancelar operación actual"
                        TabIndex="24" />
                </p>
            </div>
        </asp:View>
        <asp:View ID="viewOperacionExitosa" runat="server">
        <p>
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Symbol-Check.png" Width="100px" />
        </p>
        <p>
            <asp:Label ID="lblCapturaExitosa" runat="server" SkinID="SkinLblMsjExito"></asp:Label>
        </p>
        <p>
            <asp:LinkButton ID="lbContinuar" runat="server">Continuar</asp:LinkButton>
        </p>
        </asp:View>
        <asp:View ID="viewErrores" runat="server">
            <uc2:wucMuestraErrores ID="wucMuestraErrores" runat="server"  />
            <div id="divBotonesErrores">
                <p class="submitButton">
                    <asp:Button ID="btnContinuar" runat="server" Text="Regresar a consulta de beneficiarios" ToolTip=""
                        TabIndex="24" />
                </p>
            </div>
        </asp:View>                
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
