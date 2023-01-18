<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPageSesionIniciada.master"
    AutoEventWireup="false" CodeFile="ABCBajasPersona.aspx.vb" Inherits="ABCBajasPersona"
    Title="COBAEV - Nómina - ABC Movimientos de personal" StylesheetTheme="SkinFile" %>

<%@ Register Src="~/WebControls/wucSearchEmps.ascx" TagName="wucBuscaEmpleados"
    TagPrefix="uc1" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <asp:UpdatePanel ID="UPMain" runat="server">
        <ContentTemplate>
            <h2>
                <asp:Label ID="lblH2" runat="server" Text=""></asp:Label>
            </h2>
            <asp:Panel ID="pnlBuscaEmps" runat="server">
                <uc1:wucBuscaEmpleados ID="wucBuscaEmps" runat="server" EnableViewState="true"></uc1:wucBuscaEmpleados>
            </asp:Panel>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewCapturaModif" runat="server">
                    <asp:Panel ID="pnlCaptura" runat="server" GroupingText="Información complementaria para el movimiento de personal">
                        <div class="accountInfo">
                            <fieldset id="fsCaptura">
                                <legend>
                                    <asp:Label ID="lblInf1" runat="server" Font-Strikeout="False" Font-Underline="True"
                                        Text="Efectos:"></asp:Label>
                                </legend>
                                <div class="panelIzquierda">
                                    <p  class="pLabel">
                                        <asp:Label ID="lblFechaIni" runat="server" CssClass="pLabel" 
                                            Text="Fecha inicio:" />
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxFechaIni" runat="server" CssClass="textEntry" 
                                            MaxLength="10" Wrap="False" TabIndex="1" ValidationGroup="GrupoGuardar"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtbxFechaIni_CE" runat="server" Enabled="True" 
                                            TargetControlID="txtbxFechaIni">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:CompareValidator ID="txtbxFechaIni_CV" runat="server" 
                                            ControlToValidate="txtbxFechaIni" Display="Dynamic" ErrorMessage="*" 
                                            Operator="DataTypeCheck" ToolTip="Fecha incorrecta" Type="Date" 
                                            ValidationGroup="GrupoGuardar">
                                          </asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="txtbxFechaIni_RFV" runat="server" 
                                            ControlToValidate="txtbxFechaIni" Display="Dynamic"  ValidationGroup="GrupoGuardar"
                                             ToolTip="La fecha inicial de los efectos del movimiento de personal es obligatoria."
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </p>
                                </div>
                                <div class="pnlDerecha">
                                    <p  class="pLabel">
                                        <asp:Label ID="lblFechaFin" runat="server" CssClass="pLabel" 
                                            Text="Fecha fin:" />
                                    </p>
                                    <p class="pTextBox">
                                        <asp:TextBox ID="txtbxFechaFin" runat="server" CssClass="textEntry" 
                                            MaxLength="10" Wrap="False" TabIndex="2" ValidationGroup="GrupoGuardar"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="txtbxFechaFin_CE" runat="server" Enabled="True" 
                                            TargetControlID="txtbxFechaFin">
                                        </ajaxToolkit:CalendarExtender>
                                        <asp:CompareValidator ID="txtbxFechaFin_CV" runat="server" 
                                            ControlToValidate="txtbxFechaFin" Display="Dynamic" ErrorMessage="*" 
                                            Operator="DataTypeCheck" ToolTip="Fecha incorrecta" Type="Date" 
                                            ValidationGroup="GrupoGuardar">
                                          </asp:CompareValidator>
                                        <asp:CompareValidator ID="txtbxFechaFin_CV2" runat="server" 
                                            ControlToCompare="txtbxFechaIni" ControlToValidate="txtbxFechaFin" 
                                            Display="Dynamic" ErrorMessage="*" ToolTip="Efectos incorrectos."
                                            Operator="GreaterThanEqual" Type="Date" ValidationGroup="GrupoGuardar">*</asp:CompareValidator>
                                        <asp:RequiredFieldValidator ID="txtbxFechaFin_RFV" runat="server" 
                                            ControlToValidate="txtbxFechaFin" Display="Dynamic"  ValidationGroup="GrupoGuardar"
                                             ToolTip="La fecha final de los efectos del movimiento de personal es obligatoria."
                                            ErrorMessage="*"></asp:RequiredFieldValidator>
                                        </p>
                                </div>
                            </fieldset>
                        </div>
                    <div id="divBotones">
                        <p class="submitButton">
                            <asp:Button ID="btnContinuar" runat="server" Text="Continuar" 
                                TabIndex="3" ValidationGroup="GrupoGuardar"/>
                            <ajaxToolkit:ConfirmButtonExtender ID="btnGuardar_CBE" runat="server" 
                                ConfirmText="¿Está seguro de que los datos a registrar son correctos?" 
                                Enabled="True" TargetControlID="btnContinuar">
                            </ajaxToolkit:ConfirmButtonExtender>
                        </p>
                    </div>
                        <div class="accountInfo">
                            <fieldset id="fsCaptura2">
                                <legend>
                                    <asp:Label ID="lblInf2" runat="server" Font-Strikeout="False" Font-Underline="True"
                                        Text="Plazas que serán afectadas:"></asp:Label>
                                </legend>

                                <asp:GridView ID="gvPlazasVigentes" runat="server" 
                                    EmptyDataText="Plazas por definir." Height="100%" 
                                    OnRowDataBound="gvPlazasVigentes_RowDataBound" 
                                    SkinID="SkinGridViewEmpty" Width="100%" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Plaza(s)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPlazas" runat="server" Text='<%# Bind("Plazas") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Wrap="false" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ocup.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOcupacion" runat="server" Text='<%# Bind("AbrevTipoEmp") %>' 
                                                    ToolTip='<%# Bind("DescTipoEmp") %>'></asp:Label>
                                                <asp:Image ID="imgInfTitular" runat="server" 
                                                    ImageUrl="~/Imagenes/UserInfo.jpg" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sindicato">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSindicato" runat="server" 
                                                    Text='<%# Bind("SiglasSindicato") %>' ToolTip='<%# Bind("NombreSindicato") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Func. Pri.">
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblNombreFuncionPri" runat="server" SkinID="SkinLblNormal" 
                                                    Text=""></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Func. Sec.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNombreFuncionSec" runat="server" SkinID="SkinLblNormal" 
                                                    Text=""></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="IdTipoSemestre" HeaderText="IdTipoSemestre" 
                                            Visible="False" />
                                        <asp:BoundField DataField="TipoSemestre" HeaderText="Semestre">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Inicio" HeaderText="Inicio">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Termino" HeaderText="Fin">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Motivo de baja">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMotGralBaja" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibDetalles" runat="server" 
                                                    ImageUrl="~/Imagenes/Detalles.png" 
                                                    ToolTip="Consultar detalles de la estructura de la plaza." />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibWarning" runat="server" 
                                                    ImageUrl="~/Imagenes/Warning1.png" 
                                                    ToolTip="Haga click para visualizar un listado de observaciones sobre la plaza." />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </fieldset>
                        </div>
                        <div class="accountInfo">
                            <fieldset id="fsCaptura3">
                                <legend>
                                    <asp:Label ID="lblInf3" runat="server" Font-Strikeout="False" Font-Underline="True"
                                        Text="Plazas que serán afectadas (más datos):"></asp:Label>
                                </legend>
                                <asp:GridView ID="gvPlazasVigentes2" runat="server" 
                                    EmptyDataText="Plazas por definir." Height="100%" 
                                    SkinID="SkinGridViewEmpty" Width="100%" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Plaza(s)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPlazas" runat="server" Text='<%# Bind("Plazas") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Wrap="false" />
                                            <HeaderStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IdQnaBajaISSSTE" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdQnaBajaISSSTE" runat="server" Text='<%# Bind("IdQnaBajaISSSTE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="QnaBajaISSSTE" HeaderText="Qna. baja ante ISSSTE">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Fecha baja ante ISSSTE">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaBajaISSSTE" runat="server" 
                                                    Text='<%# Bind("FechaBajaISSSTE", "{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IdQnaBaja" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdQnaBaja" runat="server" Text='<%# Bind("IdQnaBaja") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="QnaBaja" HeaderText="Qna. baja">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </fieldset>
                        </div>
                    <div id="divBotones2">
                        <p class="submitButton">
                            <asp:Button ID="btnContinuar2" runat="server" Text="Continuar" 
                                TabIndex="3" ValidationGroup="GrupoGuardar" Visible="false"/>
                            <ajaxToolkit:ConfirmButtonExtender ID="btnContinuar2_CBE" runat="server" 
                                ConfirmText="¿Está seguro de que los datos a registrar son correctos?" 
                                Enabled="True" TargetControlID="btnContinuar2">
                            </ajaxToolkit:ConfirmButtonExtender>
                        </p>
                    </div>
                    </asp:Panel>
                </asp:View>
            </asp:MultiView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
