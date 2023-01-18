<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="wfRecibos.aspx.vb" Inherits="wfRecibos" Title="COBAEV - Nómina - Recibos"
    StylesheetTheme="SkinFile"%>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados" TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<%@ Register Src="../../WebControls/wucMuestraErrores.ascx" TagName="wucMuestraErrores"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <h2>
                Sistema de nómina: Pagos realizados mediante recibos fuera de nómina
            </h2>
                    <div class="accountInfo">
                        <fieldset id="fsCapturaOpciones">
                            <legend>
                                <asp:Label ID="lblOpcsRecibos0" runat="server" Font-Strikeout="False" Font-Underline="True"
                                    Text="Seleccione modalidad de consulta"></asp:Label>
                            </legend>
                            <div class="panelIzquierda2">
                            <!--
                                <p class="pLabel">
                                    <asp:Label ID="lblOpcsRecibos1" CssClass="pLabel" runat="server" Text="Tipos de consulta:"></asp:Label>
                                </p>
                            -->
                                <p class="pTextBox">
                                    <asp:DropDownList ID="ddlOpcsRecibos" runat="server" AutoPostBack="True" 
                                        CssClass="textEntry" >
                                        <asp:ListItem Value="0">Recibos por Empleado</asp:ListItem>
                                        <asp:ListItem Value="1">Recibos por Año/Quincena</asp:ListItem>
                                        <asp:ListItem Value="2">Recibos por Año/Tipo</asp:ListItem>
                                        <asp:ListItem Value="3" Enabled="false">Recibos (Devoluciones)</asp:ListItem>
                                    </asp:DropDownList>
                                </p>
                        </p>
                            </div>
                    <div id="divBotonesOpcRecibos">
                    <!--
                        <p class="pLabel">
                        </p>
                        -->
                        <p class="submitButtonLeft" style="margin-top: 0px;">
                            <asp:Button ID="btnIrOpcsRecibos" runat="server" Text="Ir" 
                                ToolTip="Ir a la opción seleccionada" Width="100px" 
                                CausesValidation="False" />
                        </p>
                    </div>   
                        </fieldset>
                    </div>  
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewRecibosPorEmp" runat="server">
                    <div class="accountInfo">
                        <fieldset id="fsCapturaOpcionRecibosPorEmp">
                            <legend>
                                <asp:Label ID="Label4" runat="server" Font-Strikeout="False" Font-Underline="True"
                                    Text="Consulta de Recibos por Empleado"></asp:Label>
                            </legend>
                            <div class="pnlCompleto">
                                <uc1:wucBuscaEmpleados ID="wucBuscaEmps" runat="server" EnableViewState="true"></uc1:wucBuscaEmpleados>
                            </div>
                        </fieldset>
                    </div>
                    <asp:Panel ID="pnlRecibosPorEmp" runat="server" Visible="false">
                        <p style="text-align: left">
                            <asp:LinkButton ID="lbNuevoRecibo" runat="server" Font-Bold="False" Font-Italic="False"
                                ToolTip="Utilice esta opción si lo que desea es crear un nuevo Recibo para el empleado."
                                Visible="False" OnClick="lbNuevoRecibo_Click" Text="Nuevo Recibo"></asp:LinkButton>
                            <ajaxToolkit:ConfirmButtonExtender ID="lbNuevoRecibo_CBE" runat="server" 
                                ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?" 
                                Enabled="True" TargetControlID="lbNuevoRecibo">
                            </ajaxToolkit:ConfirmButtonExtender>
                            <asp:Label ID="lblEmpSeLePuedeCrearReciboEnQna" runat="server" Font-Bold="True" 
                                Text="Label" Visible="False" CssClass="lblInformativa"></asp:Label>
                        </p>
                        <div class="accountInfo">
                            <fieldset id="fsCapturaConsulta">
                                <legend>
                                    <asp:Label ID="lblEmpInfConsulta" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                                </legend>
                                <div class="pnlCompleto">
                                    <asp:GridView ID="gvHistorialRecibosPorEmp" runat="server" AutoGenerateColumns="False"
                                        EmptyDataText="No existen pagos realizados al empleado mediante recibos fuera de nómina."
                                        OnRowDataBound="gvHistorialRecibosPorEmp_RowDataBound" SkinID="SkinGridView"
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="IdRecibo" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdRecibo" runat="server" Text='<%# Bind("IdRecibo") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Año">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="NumRecibo" HeaderText="Núm. Recibo">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NomEmp" HeaderText="Recibo expedido al empleado" Visible="false" />
                                            <asp:BoundField DataField="DescTipoRecibo" HeaderText="Tipo recibo">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DescEstatusRecibo" HeaderText="Estatus">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaRealDePago" HeaderText="Fecha real de pago" DataFormatString="{0:d}">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QnaDeDevol" HeaderText="Devuelto en la quincena">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QnaAplic" HeaderText="Aplicado en quincena">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QnaIniPeriodoAdeudo" HeaderText="Periodo adeudo (Quincena inicial)">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QnaFinPeriodoAdeudo" HeaderText="Periodo adeudo (Quincena final)">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ObservacionesRecibo" HeaderText="Observaciones" Visible="false">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Recibo creado por">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="false"></asp:Label><asp:Label
                                                        ID="lblUsuario" runat="server"></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ReciboTimbrado" HeaderText="Timbrado">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibEliminar" runat="server" CommandName="CmdEliminar" ImageUrl="~/Imagenes/Eliminar.png"
                                                        ToolTip="Eliminar éste recibo" /><ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar"
                                                            runat="server" ConfirmText="Ésta operación eliminará el registro definitivamente, ¿Continuar?"
                                                            TargetControlID="ibEliminar">
                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibConsultaDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                                        ToolTip="Consultar los detalles del recibo" /></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibModificar" runat="server" CommandName="CmdModificar" ImageUrl="~/Imagenes/Modificar.png"
                                                        ToolTip="Modificar la información de éste recibo" /></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibCapturar" runat="server" ImageUrl="~/Imagenes/Captura1.jpg"
                                                        ToolTip="Capturar/Modificar la informacion complementaria del recibo" /></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="EstatusQnaAplic" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEstatusQnaAplic" runat="server" Text='<%# Bind("AbrevEstatusQna") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Permiso consulta" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPermisoConsulta" runat="server" Text='<%# Bind("PermisoConsulta") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle Font-Italic="True" />
                                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                    </asp:GridView>
                                </div>
                            </fieldset>
                        </div>
                    </asp:Panel>
                </asp:View>
                <asp:View ID="viewRecibosPorAnioQna" runat="server">
                    <div class="accountInfo">
                        <fieldset id="fsCapturaConsulta2">
                            <legend>
                                <asp:Label ID="lblEmpInfConsulta2" runat="server" Font-Strikeout="False" Font-Underline="True"
                                    Text="Consulta de Recibos por Año/Quincena"></asp:Label>
                            </legend>
                            <div class="panelIzquierda">
                                <p class="pLabel">
                                    <asp:Label ID="lblSelAnio" CssClass="pLabel" runat="server" Text="Seleccione año:"></asp:Label>
                                </p>
                                <p class="pTextBox">
                                    <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" CssClass="textEntry" />
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="lblSelQna" CssClass="pLabel" runat="server" Text="Seleccione quincena:"></asp:Label>
                                </p>
                                <p class="pTextBox">
                                    <asp:DropDownList ID="ddlQuincenas" runat="server" CssClass="textEntry" />
                                </p>
                            </div>
                        </fieldset>
                    </div>
                    <p>
                    <div id="divBotones">
                        <p class="submitButtonLeft">
                            <asp:Button ID="btnConsultarAnio" runat="server" Text="Consultar" />
                        </p>
                    </div>
                        <p>
                        </p>
                        <!--OnRowCommand="gvRecibos_RowCommand" OnRowDataBound="gvRecibos_RowDataBound" -->
                        <asp:Panel ID="pnlRecibosPorAnioQna" runat="server" Visible="false">
                            <div class="accountInfo">
                                <fieldset ID="fsCapturaConsulta3">
                                    <legend>
                                        <asp:Label ID="lblEmpInfConsulta3" runat="server" Font-Strikeout="False" 
                                            Font-Underline="True"></asp:Label>
                                    </legend>
                                    <div class="pnlCompleto">
                                        <asp:GridView ID="gvRecibos" runat="server" AutoGenerateColumns="False" 
                                            EmptyDataText="No existen pagos realizados mediante recibos fuera de nómina en la quincena seleccionada." 
                                            SkinID="SkinGridView" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdRecibo" runat="server" Text='<%# Bind("IdRecibo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Año" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="NumRecibo" HeaderText="Num. Recibo">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="NomEmp" HeaderText="Recibo expedido al empleado">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DescTipoRecibo" HeaderText="Tipo recibo">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DescEstatusRecibo" HeaderText="Estatus">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fecha" DataFormatString="{0:d}" 
                                                    HeaderText="Fecha pago">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="QnaDeDevol" HeaderText="Devuelto en la quincena">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="QnaAplic" HeaderText="Aplicado en quincena">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="QnaIniPeriodoAdeudo" 
                                                    HeaderText="Periodo adeudo (Quincena inicial)">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="QnaFinPeriodoAdeudo" 
                                                    HeaderText="Periodo adeudo (Quincena final)">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="IdUsuario" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Recibo creado por">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            <asp:BoundField DataField="ReciboTimbrado" HeaderText="Timbrado">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibEliminar" runat="server" CommandName="CmdEliminar" 
                                                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar éste recibo" />
                                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" 
                                                            ConfirmText="Ésta operación eliminará el registro definitivamente, ¿Continuar?" 
                                                            TargetControlID="ibEliminar">
                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibConsultaDetalles" runat="server" 
                                                            ImageUrl="~/Imagenes/Detalles.png"
                                                            ToolTip="Consultar los detalles del recibo" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibModificar" runat="server" CommandName="CmdModificar" 
                                                            ImageUrl="~/Imagenes/Modificar.png" 
                                                            ToolTip="Modificar la información de éste recibo" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ibCapturar" runat="server" 
                                                            ImageUrl="~/Imagenes/Captura1.jpg" 
                                                            ToolTip="Capturar/Modificar la informacion complementaria del recibo" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="EstatusQnaAplic" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEstatusQnaAplic" runat="server" 
                                                            Text='<%# Bind("AbrevEstatusQna") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Permiso consulta" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPermisoConsulta" runat="server" Text='<%# Bind("PermisoConsulta") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataRowStyle Font-Italic="True" />
                                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                        </asp:GridView>
                                    </div>
                                </fieldset>
                            </div>
                        </asp:Panel>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                        <p>
                        </p>
                    </p>
                </asp:View>
                  <asp:View ID="viewRecibosPorTipo" runat="server">
                    <div class="accountInfo">
                        <fieldset id="fsCapturaRecibosPorTipo">
                            <legend>
                                <asp:Label ID="Label1" runat="server" Font-Strikeout="False" Font-Underline="True"
                                    Text="Consulta de Recibos por Año/Tipo"></asp:Label>
                            </legend>
                            <div class="panelIzquierda">
                                <p class="pLabel">
                                    <asp:Label ID="Label2" CssClass="pLabel" runat="server" Text="Seleccione año:"></asp:Label>
                                </p>
                                <p class="pTextBox">
                                    <asp:DropDownList ID="ddlAnios2" runat="server" AutoPostBack="True" CssClass="textEntry" />
                                </p>
                                <p class="pLabel">
                                    <asp:Label ID="Label3" CssClass="pLabel" runat="server" Text="Seleccione tipo de recibo:"></asp:Label>
                                </p>
                                <p class="pTextBox">
                                    <asp:DropDownList ID="ddlTiposRecibos" runat="server" CssClass="textEntry" />
                                </p>
                            </div>
                        </fieldset>
                    </div>
                    <div id="divBotonesRecibosPorTipo">
                        <p class="submitButtonLeft">
                            <asp:Button ID="btnConsultaRecibosPorTipo" runat="server" Text="Consultar" />
                        </p>
                    </div>
                    <!--OnRowCommand="gvRecibos_RowCommand" OnRowDataBound="gvRecibos_RowDataBound" -->
                    <asp:Panel ID="pnlRecibosPorAnioTipo" runat="server" Visible="false">
                        <div class="accountInfo">
                            <fieldset id="fsCapturaAnioTipo">
                                <legend>
                                    <asp:Label ID="lblRecibosAnioTipo" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                                </legend>
                                <div class="pnlCompleto">
                                    <asp:GridView ID="gvRecibosAnioTipo" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen pagos realizados mediante recibos asociados al año y tipo seleccionados."
                                        SkinID="SkinGridView" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="IdQuincena" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdRecibo" runat="server" Text='<%# Bind("IdRecibo") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Año" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAnio" runat="server" Text='<%# Bind("Anio") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="NumRecibo" HeaderText="Num. Recibo">
                                                <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NomEmp" HeaderText="Recibo expedido al empleado">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DescTipoRecibo" HeaderText="Tipo recibo">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DescEstatusRecibo" HeaderText="Estatus">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha pago" DataFormatString="{0:d}">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QnaDeDevol" HeaderText="Devuelto en la quincena">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QnaAplic" HeaderText="Aplicado en quincena">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QnaIniPeriodoAdeudo" HeaderText="Periodo adeudo (Quincena inicial)">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QnaFinPeriodoAdeudo" HeaderText="Periodo adeudo (Quincena final)">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="IdUsuario" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Recibo creado por">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUsuario" runat="server"></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ReciboTimbrado" HeaderText="Timbrado">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibEliminar" runat="server" CommandName="CmdEliminar" ImageUrl="~/Imagenes/Eliminar.png"
                                                        ToolTip="Eliminar éste recibo" /><ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar"
                                                            runat="server" ConfirmText="Ésta operación eliminará el registro definitivamente, ¿Continuar?"
                                                            TargetControlID="ibEliminar">
                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibConsultaDetalles" runat="server" ImageUrl="~/Imagenes/Detalles.png"
                                                        ToolTip="Consultar los detalles del recibo" /></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibModificar" runat="server" CommandName="CmdModificar" ImageUrl="~/Imagenes/Modificar.png"
                                                        ToolTip="Modificar la información de éste recibo" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ibCapturar" runat="server" ImageUrl="~/Imagenes/Captura1.jpg"
                                                        ToolTip="Capturar/Modificar la informacion complementaria del recibo" /></ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="EstatusQnaAplic" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEstatusQnaAplic" runat="server" Text='<%# Bind("AbrevEstatusQna") %>'></asp:Label></ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Permiso consulta" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPermisoConsulta" runat="server" Text='<%# Bind("PermisoConsulta") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataRowStyle Font-Italic="True" />
                                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                    </asp:GridView>
                                </div>
                            </fieldset>
                        </div>
                    </asp:Panel>
                </asp:View>
                <asp:View ID="viewRecibosDetalles" runat="server">
                    <asp:Panel ID="pnlRecibosDetalles" runat="server">
                        <div class="accountInfo">
                            <fieldset id="fsCapturaConsulta4">
                                <legend>
                                    <asp:Label ID="lblEmpInfConsulta4" runat="server" Font-Strikeout="False" Font-Underline="True"></asp:Label>
                                </legend>
                                <div class="pnlCompleto">
                                    <asp:DetailsView ID="dvReciboDetalles" runat="server" SkinID="SkinDetailsView" AutoGenerateRows="False"
                                        HeaderText="Definición de los datos de creación del Recibo" HorizontalAlign="Left"
                                        Width="100%">
                                        <Fields>
                                            <asp:BoundField DataField="AnioNumRecibo" HeaderText="Anio/Num. Recibo:"></asp:BoundField>
                                            <asp:BoundField DataField="DescTipoRecibo" HeaderText="Tipo recibo:"></asp:BoundField>
                                            <asp:BoundField DataField="DescEstatusRecibo" HeaderText="Estatus:"></asp:BoundField>
                                            <asp:BoundField DataField="ObservacionesRecibo" HeaderText="Observaciones sobre el pago:">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Quincena" HeaderText="Asociado a la quincena:"></asp:BoundField>
                                            <asp:BoundField DataField="QnaIniPeriodoAdeudo" HeaderText="Periodo adeudo (Quincena inicial):">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QnaFinPeriodoAdeudo" HeaderText="Periodo adeudo (Quincena final):">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha pago:"></asp:BoundField>
                                            <asp:BoundField DataField="DescFondoPresup" HeaderText="Fondo presupuestal a afectar:"
                                                HeaderStyle-Width="25%" ItemStyle-Width="75%"></asp:BoundField>
                                            <asp:BoundField DataField="QnaDeDevol" HeaderText="Quincena devolución:"></asp:BoundField>
                                        </Fields>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <RowStyle HorizontalAlign="Left" Wrap="true" />
                                    </asp:DetailsView>
                                </div>
                                <div class="pnlCompleto">
                                    <asp:DetailsView ID="dvReciboDetallesEmp" runat="server" SkinID="SkinDetailsView"
                                        AutoGenerateRows="False" HeaderText="Definición del empleado al cual fue expedido el Recibo"
                                        HorizontalAlign="Left" Width="100%">
                                        <Fields>
                                            <asp:BoundField DataField="Plaza" HeaderText="Clave de cobro:"></asp:BoundField>
                                            <asp:BoundField DataField="RFCEmp" HeaderText="R.F.C.:"></asp:BoundField>
                                            <asp:BoundField DataField="NomEmp" HeaderText="Nombre:"></asp:BoundField>
                                            <asp:BoundField DataField="CTAdscripcion" HeaderText="Centro de trabajo:"></asp:BoundField>
                                            <asp:BoundField DataField="Departamento" HeaderText="Departamento:" HeaderStyle-Width="25%"
                                                ItemStyle-Width="75%">
                                                <HeaderStyle Width="25%" />
                                                <ItemStyle Width="75%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DescRegimenISSSTE" HeaderText="Régimen pensionario ISSSTE:">
                                            </asp:BoundField>
                                        </Fields>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="true" />
                                        <RowStyle HorizontalAlign="Left" Wrap="true" />
                                    </asp:DetailsView>
                                </div>
                                <div class="pnlCompleto">
                                    
                                    <asp:GridView ID="gvPercepciones" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin información de percepciones"
                                        SkinID="SkinGridView" Width="100%" 
                                        Caption='<table width="100%"><tr><td><asp:ImageButton ID="ibAddPercs" runat="server" ShowFooter="True" ShowHeaderWhenEmpty="True" ImageUrl="~/Imagenes/AddPercs.png" /></td></tr></table>'>
                                        <Columns>
                                            <asp:TemplateField HeaderText="IdPercDeduc" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdPerc_E" runat="server" Text='<%# Bind("IdPercDeduc") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ClavePercDeduc" HeaderText="Clave">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="7%" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombrePercDeduc" HeaderText="Percepción" FooterText="Totales percepciones ==&gt;&nbsp;&nbsp;">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Width="33%" HorizontalAlign="Left" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Importe">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImporte_I" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotPercs" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Importe para retroactivo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImpParaRetro_I" runat="server" Text='<%# Bind("ImporteParaRetroactivo", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotPercsRetro" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Importe para aguinaldo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImpParaAgui_I" runat="server" Text='<%# Bind("ImporteParaAguinaldo", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotPercsAgui" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Importe gravado">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImporteGravado" runat="server" Text='<%# Bind("ImporteGravado", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotPercsGrav" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle Font-Bold="False" />
                                    </asp:GridView>
                                </div>
                                <div class="pnlCompleto">
                                    <asp:ImageButton ID="ibAddDeducs" runat="server" ShowFooter="True" ShowHeaderWhenEmpty="True" ImageUrl="~/Imagenes/AddDeducs.jpg" />
                                    <asp:GridView ID="gvDeducciones" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin información de deducciones"
                                        SkinID="SkinGridView" Width="100%" Caption="Deducciones" ShowFooter="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="IdPercDeduc" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdDeduc" runat="server" Text='<%# Bind("IdPercDeduc") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ClavePercDeduc" HeaderText="Clave">
                                                <ItemStyle Width="7%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NombrePercDeduc" HeaderText="Deducción" FooterText="Totales deducciones ==&gt;&nbsp;&nbsp;">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Width="33%" HorizontalAlign="Left" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Importe">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImporte_I" runat="server" Text='<%# Bind("Importe", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotDeducs" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Importe para retroactivo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImpParaRetro_I" runat="server" Text='<%# Bind("ImporteParaRetroactivo", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotDeducsRetro" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Importe para aguinaldo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImpParaAgui_I" runat="server" Text='<%# Bind("ImporteParaAguinaldo", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotDeducsAgui" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Importe gravado">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImporteGravado" runat="server" Text='<%# Bind("ImporteGravado", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotDeducsGrav" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="pnlCompleto">
                                    <asp:GridView ID="gvTotales" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin información de totales"
                                        SkinID="SkinGridView" Width="100%" Caption="Totales">
                                        <Columns>
                                            <asp:BoundField DataField="" HeaderText="">
                                                <ItemStyle Width="7%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Concepto" HeaderText="">
                                                <ItemStyle Width="33%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Importe Neto">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImporte_I" runat="server" Text='<%# Bind("TotalesPercMenosDeduc", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotDeducs" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Retroactivo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImpParaRetro_I" runat="server" Text='<%# Bind("TotalesRetroactivo", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotDeducsRetro" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Aguinaldo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImpParaAgui_I" runat="server" Text='<%# Bind("TotalesAguinaldo", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotDeducsAgui" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gravado">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImporteGravado" runat="server" Text='<%# Bind("TotalesGravado", "{0:c}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotDeducsGrav" runat="server" Text=""></asp:Label>
                                                </FooterTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="15%" HorizontalAlign="Right" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle Font-Bold="true" />
                                    </asp:GridView>
                                </div>
                                <div class="pnlCompleto">
                                    <asp:GridView ID="gvRecibosDatosComplem" runat="server" AutoGenerateColumns="False"
                                        Caption="Conceptos indemnizatorios asociados al recibo"
                                        EmptyDataText="No existen datos complementarios asociados al recibo."
                                        SkinID="SkinGridView" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="AniosDeServicio" HeaderText="A&#241;os de servicio">
                                                <HeaderStyle HorizontalAlign="Center"/>
                                                <ItemStyle HorizontalAlign="Center" Width="25%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IngresoExcento" DataFormatString="{0:c}" HeaderText="Ingreso exento">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" Width="25%"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UltimoSueldo" DataFormatString="{0:c}" HeaderText="Ultimo sueldo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" Width="25%"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ISRUltimoSueldo" DataFormatString="{0:c}" HeaderText="I.S.R. Ultimo sueldo">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Right" Width="25%"/>
                                            </asp:BoundField>
                                            </Columns>
                                    </asp:GridView>
                                </div>
                            </fieldset>
                        </div>
                        <div id="divBotones2">
                            <p class="submitButton">
                                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" />
                                <asp:Button ID="btnExportarAPDF" runat="server" Text="Exportar a PDF" 
                                    ToolTip="Exportar a PDF para impresión" />
                            </p>
                        </div>
                    </asp:Panel>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
