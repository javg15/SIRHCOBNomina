<%@ page language="VB" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="MovsDePersonal_Cadenas, App_Web_gy0kusdy" title="COBAEV - Nómina - Cadenas de movimientos de personal" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Cadenas de movimientos de personal
                </h2>
            </td>
        </tr>
    </table>
<div style="display: none;" >
     <asp:TextBox runat="server" ID="hiddenTextBox1" />
     <ajaxToolkit:CalendarExtender ID="hiddenTextBoxCE" runat="server"
          TargetControlID="hiddenTextBox1" />
</div>
    <asp:UpdatePanel ID="UpdPnlMain" runat="server" >
        <ContentTemplate>
            <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
                <tr>
                    <td style="vertical-align: top; text-align: left">
                        <br />
                        <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar" Font-Names="Verdana"
                            Font-Size="X-Small" GroupingText="Seleccione ejercicio">
                            <br />
                            <asp:DropDownList ID="ddlAños" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAños_SelectedIndexChanged"
                                SkinID="SkinDropDownList">
                            </asp:DropDownList>
                            <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" Text="Consultar"
                                ToolTip="Consultar el acumulado anual de subsidio para el empleo del empleado seleccionado"
                                Visible="False" /><br />
                        </asp:Panel>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: left">
                        <asp:LinkButton ID="lbCrearNuevaCadena" runat="server" SkinID="SkinLinkButton">Crear nueva cadena</asp:LinkButton><ajaxToolkit:ConfirmButtonExtender
                            ID="CBECrearNuevaCadena" runat="server" ConfirmText="La operación solicitada creará una nueva cadena para el ejercicio actual en la Base de datos, ¿Continuar?"
                            TargetControlID="lbCrearNuevaCadena">
                        </ajaxToolkit:ConfirmButtonExtender>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left; vertical-align: top;">

                        <asp:Panel ID="pnlCadenas" runat="server">
                            <asp:GridView ID="gvCadenas" runat="server" CellPadding="1" 
                                EmptyDataText="No hay cadenas para el ejercicio seleccionado" 
                                OnRowCancelingEdit="gvCadenas_RowCancelingEdit" 
                                OnRowDataBound="gvCadenas_RowDataBound" OnRowDeleting="gvCadenas_RowDeleting" 
                                OnRowEditing="gvCadenas_RowEditing" OnRowUpdating="gvCadenas_RowUpdating" 
                                OnSelectedIndexChanged="gvCadenas_SelectedIndexChanged" SkinID="SkinGridView" 
                                Width="100%">
                                <Columns>
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" 
                                        ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="IdCadena" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdCadena" runat="server" SkinID="SkinLblNormal" 
                                                Text='<%# Bind("IdCadena") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdCadena_E" runat="server" SkinID="SkinLblNormal" 
                                                Text='<%# Bind("IdCadena") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Ejercicio" HeaderText="Ejercicio" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NumCadena" HeaderText="Cadena No." ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Origen propuesta">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlOrigenPropuesta_E" runat="server" 
                                                SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrigenPropuesta" runat="server" 
                                                Text='<%# Bind("OrigenPropuesta") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IdOrigenPropuesta" Visible="False">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdOrigenPropuesta_E" runat="server" SkinID="SkinLblNormal" 
                                                Text='<%# Bind("IdOrigenPropuesta") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdOrigenPropuesta" runat="server" SkinID="SkinLblNormal" 
                                                Text='<%# Bind("IdOrigenPropuesta") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Oficio propuesta">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbOficioDePropuesta_E" runat="server" MaxLength="50" 
                                                SkinID="SkinTextBox" Text='<%# Bind("OficioDePropuesta") %>' Width="200px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOficioDePropuesta" runat="server" SkinID="SkinLblNormal" 
                                                Text='<%# Bind("OficioDePropuesta") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha órdenes de presentación">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="tbFchParaOrdDePres_E" runat="server" MaxLength="10" 
                                                SkinID="SkinTextBox" Text='<%# Bind("FchParaOrdDePres","{0:d}") %>'></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CE_tbFchParaOrdDePres_E" runat="server" 
                                                Enabled="True" TargetControlID="tbFchParaOrdDePres_E">
                                            </ajaxToolkit:CalendarExtender>
                                            <asp:CompareValidator ID="cvFchParaOrdDePres" runat="server" 
                                                ControlToValidate="tbFchParaOrdDePres_E" Display="Dynamic" 
                                                ErrorMessage="*" ToolTip="Fecha incorrecta." Operator="DataTypeCheck" 
                                                SetFocusOnError="True" Type="Date"></asp:CompareValidator>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblFchParaOrdDePres" runat="server" SkinID="SkinLblNormal" 
                                                Text='<%# Bind("FchParaOrdDePres", "{0:d}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="true" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IdEstatusCadena" Visible="False">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdEstatusCadena_E" runat="server" SkinID="SkinLblNormal" 
                                                Text='<%# Bind("IdEstatusCadena") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdEstatusCadena" runat="server" SkinID="SkinLblNormal" 
                                                Text='<%# Bind("IdEstatusCadena") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estatus actual">
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlEstatusActualCadena_E" runat="server" 
                                                SkinID="SkinDropDownList">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblEstatusActualCadena" runat="server" 
                                                Text='<%# Bind("EstatusActualCadena") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Creó">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdUsuarioCreador_E" runat="server" SkinID="SkinLblNormal" 
                                                Text='<%# Bind("IdUsuarioCreador") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="lblLoginCreador_E" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdUsuarioCreador" runat="server" SkinID="SkinLblNormal" 
                                                Text='<%# Bind("IdUsuarioCreador") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="lblLoginCreador" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Modificó">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblIdUsuarioModifico_E" runat="server" SkinID="SkinLblNormal" 
                                                Text='<%# Bind("IdUsuarioModifico") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="lblLoginModifico_E" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdUsuarioModifico" runat="server" SkinID="SkinLblNormal" 
                                                Text='<%# Bind("IdUsuarioModifico") %>' Visible="False"></asp:Label>
                                            <asp:Label ID="lblLoginModifico" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                        <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" 
                                                CommandName="Update" ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar" />
                                            &nbsp;<asp:ImageButton ID="ibCancelar" runat="server" CausesValidation="False" 
                                                CommandName="Cancel" ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Cancelar" />
                                            <ajaxToolkit:ConfirmButtonExtender ID="CBECancelar" runat="server" 
                                                ConfirmText="La operación solicitada guardará las modificaciones realizadas en la Base de datos, ¿Continuar?" 
                                                TargetControlID="ibGuardar">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibEditar" runat="server" CausesValidation="False" 
                                                CommandName="Edit" ImageUrl="~/Imagenes/Modificar.png" ToolTip="Modificar" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" 
                                                CommandName="Delete" ImageUrl="~/Imagenes/Eliminar.png" 
                                                OnClick="ibEliminar_Click" ToolTip="Eliminar cadena" />
                                            <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" 
                                                ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?" 
                                                TargetControlID="ibEliminar">
                                            </ajaxToolkit:ConfirmButtonExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibVerMovs" runat="server" CausesValidation="False" 
                                                CommandName="VerMovs" ImageUrl="~/Imagenes/Detalles.gif" 
                                                ToolTip="Ver movimientos asociados a la cadena" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Wrap="false" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <br />

                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
