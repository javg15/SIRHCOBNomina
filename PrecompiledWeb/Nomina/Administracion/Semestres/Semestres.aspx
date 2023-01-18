<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="Administracion_Semestres, App_Web_ih3sz3il" title="COBAEV - Nómina - Administración de semestres" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Semestres (Administración)
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbCrearNuevoSemestre" runat="server" SkinID="SkinLinkButton">Crear nuevo semestre</asp:LinkButton><ajaxToolkit:ConfirmButtonExtender
                            ID="CBECrearNuevoSemestre" runat="server" ConfirmText="La operación solicitada creará un nuevo semestre en la Base de datos, ¿Continuar?"
                            TargetControlID="lbCrearNuevoSemestre">
                        </ajaxToolkit:ConfirmButtonExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvSemestres" EventName="RowUpdating" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
    <asp:GridView ID="gvSemestres" runat="server" CellPadding="1" SkinID="SkinGridView" Width="100%" 
    OnSelectedIndexChanged="gvSemestres_SelectedIndexChanged" OnRowCancelingEdit="gvSemestres_RowCancelingEdit" OnRowEditing="gvSemestres_RowEditing" OnRowDeleting="gvSemestres_RowDeleting" OnRowUpdating="gvSemestres_RowUpdating" OnRowDataBound="gvSemestres_RowDataBound">
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                <ItemStyle HorizontalAlign="Center" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="IdSemestre" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblIdSemestre" runat="server" Text='<%# Bind("IdSemestre") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblIdSemestre_E" runat="server" Text='<%# Bind("IdSemestre") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="AnioSemestre" HeaderText="A&#241;o" ReadOnly="True">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="TipoSemestre" HeaderText="A/B" ReadOnly="True">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="IdQuincenaIni" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblIdQuincenaIni" runat="server" Text='<%# Bind("IdQuincenaIni") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Wrap="True" />
                <EditItemTemplate>
                    <asp:Label ID="lblIdQuincenaIni_E" runat="server" Text='<%# Bind("IdQuincenaIni") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Inicio">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlQnaIni" runat="server" SkinID="SkinDropDownList">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblQnaIni" runat="server" Text='<%# Bind("QnaIni") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IdQuincenaFin" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblIdQuincenaFin" runat="server" Text='<%# Bind("IdQuincenaFin") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
                <EditItemTemplate>
                    <asp:Label ID="lblIdQuincenaFin_E" runat="server" Text='<%# Bind("IdQuincenaFin") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fin">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlQnaFin" runat="server" SkinID="SkinDropDownList">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblQnaFin" runat="server" Text='<%# Bind("QnaFin") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Wrap="True" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IdQuincenaFinInterinas" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblIdQuincenaFinInterinas" runat="server" Text='<%# Bind("IdQuincenaFinInterinas") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Wrap="False" />
                <EditItemTemplate>
                    <asp:Label ID="lblIdQuincenaFinInterinas_E" runat="server" Text='<%# Bind("IdQuincenaFinInterinas") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>          
            <asp:TemplateField HeaderText="Fin horas interinas">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlQnaFinInt" runat="server" SkinID="SkinDropDownList">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblQnaFinInt" runat="server" Text='<%# Bind("QnaFinInt") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Permite modificaciones">
                <ItemTemplate>
                    <asp:CheckBox ID="ChkBxPermiteModif" runat="server" Checked='<%# Bind("PermiteModificacion") %>'
                        Enabled="False" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                <EditItemTemplate>
                    <asp:CheckBox ID="ChkBxPermiteModif_E" runat="server" Checked='<%# Bind("PermiteModificacion") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Semestre actual">
                <ItemTemplate>
                    <asp:CheckBox ID="ChkBxActual" runat="server" Checked='<%# Bind("Actual") %>'
                        Enabled="False" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                <EditItemTemplate>
                    <asp:CheckBox ID="ChkBxActual_E" runat="server" Checked='<%# Bind("Actual") %>' />
                </EditItemTemplate>
            </asp:TemplateField>            
            <asp:TemplateField HeaderText="Permite carga de plantillas">
                <EditItemTemplate>
                    <asp:CheckBox ID="ChkBxPermiteCargaPlanti_E" runat="server" Checked='<%# Bind("PermiteCargaDePlantillas") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="ChkBxPermiteCargaPlanti" runat="server" Checked='<%# Bind("PermiteCargaDePlantillas") %>'
                        Enabled="False" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" CommandName="Update"
                        ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar" />&nbsp;<asp:ImageButton
                            ID="ibCancelar" runat="server" CausesValidation="False" CommandName="Cancel"
                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="CBECancelar" runat="server" ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?"
                        TargetControlID="ibGuardar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" CommandName="Edit"
                        ImageUrl="~/Imagenes/Modificar.png" ToolTip="Modificar" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" CommandName="Delete"
                        ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                        TargetControlID="ibEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Wrap="false" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvSemestres" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="gvSemestres" EventName="RowEditing" />
                        <asp:AsyncPostBackTrigger ControlID="gvSemestres" EventName="RowCancelingEdit" />
                        <asp:AsyncPostBackTrigger ControlID="gvSemestres" EventName="RowDeleting" />
                        <asp:AsyncPostBackTrigger ControlID="gvSemestres" EventName="RowUpdating" />
                        <asp:AsyncPostBackTrigger ControlID="lbCrearNuevoSemestre" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

