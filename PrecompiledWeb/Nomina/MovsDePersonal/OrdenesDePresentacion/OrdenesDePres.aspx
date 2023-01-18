<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="MovsDePersonal_OrdenesDePres, App_Web_erzns4be" title="COBAEV - Nómina - Ordenes de presentación por ejercicio" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; vertical-align: top; text-align: center;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Ordenes de presentación por ejercicio
                </h2>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <br />
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlAños" runat="server" DefaultButton="btnConsultar" Font-Names="Verdana"
                            Font-Size="X-Small" GroupingText="Seleccione ejercicio">
                            <br />
                            <asp:DropDownList ID="ddlAños" runat="server" AutoPostBack="True" SkinID="SkinDropDownList"
                                OnSelectedIndexChanged="ddlAños_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Button ID="btnConsultar" runat="server" SkinID="SkinBoton" Text="Consultar"
                                ToolTip="Consultar el acumulado anual de subsidio para el empleo del empleado seleccionado"
                                Visible="False" /><br />
                        </asp:Panel>
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: left">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbCrearNuevaOP" runat="server" SkinID="SkinLinkButton" OnClick="lbCrearNuevaOP_Click"
                            ToolTip="Crear una nueva orden de presentación para el ejercicio actual">Crear nueva orden de presentación</asp:LinkButton><ajaxToolkit:ConfirmButtonExtender
                                ID="CBECrearNuevaOP" runat="server" ConfirmText="La operación solicitada creará una nueva orden de presentación para el ejercicio actual en la Base de datos, ¿Continuar?"
                                TargetControlID="lbCrearNuevaOP">
                            </ajaxToolkit:ConfirmButtonExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvOPs" EventName="RowUpdating" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left; vertical-align: top;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvOPs" runat="server" CellPadding="1" SkinID="SkinGridView" Width="100%"
                            OnSelectedIndexChanged="gvOPs_SelectedIndexChanged" OnRowCancelingEdit="gvOPs_RowCancelingEdit"
                            OnRowEditing="gvOPs_RowEditing" OnRowDeleting="gvOPs_RowDeleting" OnRowUpdating="gvOPs_RowUpdating"
                            OnRowDataBound="gvOPs_RowDataBound" EmptyDataText="No hay ordenes de presentación para el ejercicio seleccionado">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdOrdenDePres" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdOrdenDePres" runat="server" Text='<%# Bind("IdOrdenDePres") %>'
                                            SkinID="SkinLblNormal"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdOrdenDePres_E" runat="server" Text='<%# Bind("IdOrdenDePres") %>'
                                            SkinID="SkinLblNormal"></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Ejercicio" HeaderText="Ejercicio" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Ord. <br /> de Pres.">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblNumOrdPres" runat="server" Text='<%# Eval("NumOrdPres") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumOrdPres_I" runat="server" Text='<%# Bind("NumOrdPres") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Empleado">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblNombreEmpleado" runat="server" Text='<%# Eval("NombreEmpleado") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombreEmpleado_I" runat="server" Text='<%# Bind("NombreEmpleado") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Plantel">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblPlantel" runat="server" Text='<%# Eval("ClavePlantel") %>'
                                            ToolTip='<%# Bind("Plantel") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPlantel_I" runat="server" Text='<%# Bind("ClavePlantel") %>'
                                            ToolTip='<%# Bind("Plantel") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Origen propuesta">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlOrigenPropuesta_E" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrigenPropuesta" runat="server" Text='<%# Bind("OrigenPropuesta") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdOrigenPropuesta" Visible="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdOrigenPropuesta_E" runat="server" Text='<%# Bind("IdOrigenPropuesta") %>'
                                            SkinID="SkinLblNormal"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdOrigenPropuesta" runat="server" Text='<%# Bind("IdOrigenPropuesta") %>'
                                            SkinID="SkinLblNormal"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Oficio propuesta">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbOficioDePropuesta_E" runat="server" MaxLength="50" SkinID="SkinTextBox"
                                            Text='<%# Bind("OficioDePropuesta") %>' Width="200px"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblOficioDePropuesta" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("OficioDePropuesta") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha <br /> Ord. de Pres.">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbFchParaOrdDePres_E" runat="server" MaxLength="10" SkinID="SkinTextBox"
                                            Text='<%# Bind("FchParaOrdDePres","{0:d}") %>'></asp:TextBox>
                                        <asp:CompareValidator ID="cvFchParaOrdDePres" runat="server" ControlToValidate="tbFchParaOrdDePres_E"
                                            Display="Dynamic" ErrorMessage="Fecha incorrecta." Operator="DataTypeCheck" SetFocusOnError="True"
                                            Type="Date"></asp:CompareValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFchParaOrdDePres" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("FchParaOrdDePres", "{0:d}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="True" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdEstatusOP" Visible="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdEstatusOP_E" runat="server" Text='<%# Bind("IdEstatusOP") %>'
                                            SkinID="SkinLblNormal"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEstatusOP" runat="server" Text='<%# Bind("IdEstatusOP") %>' SkinID="SkinLblNormal"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estatus actual">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlEstatusActualOP_E" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstatusActualOP" runat="server" Text='<%# Bind("EstatusActualOP") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdCadena" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdCadena" runat="server" Text='<%# Bind("IdCadena") %>' SkinID="SkinLblNormal"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdCadena_E" runat="server" Text='<%# Bind("IdCadena") %>' SkinID="SkinLblNormal"></asp:Label>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cadena No.">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblNumCadena_E" runat="server" Text='<%# Eval("NumCadena") %>'></asp:Label>
                                        <asp:LinkButton ID="lnkbtnNumCadena_E" runat="server" 
                                            Text='<%# Bind("NumCadena") %>' ToolTip="Ver movimientos asociados a la cadena"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumCadena" runat="server" Text='<%# Bind("NumCadena") %>'></asp:Label>
                                        <asp:LinkButton ID="lnkbtnNumCadena" runat="server" 
                                            Text='<%# Bind("NumCadena") %>' ToolTip="Ver movimientos asociados a la cadena"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cre&#243;">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdUsuarioCreador_E" runat="server" SkinID="SkinLblNormal" Visible="False"
                                            Text='<%# Bind("IdUsuarioCreador") %>'></asp:Label><asp:Label ID="lblLoginCreador_E"
                                                runat="server" SkinID="SkinLblNormal"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdUsuarioCreador" runat="server" SkinID="SkinLblNormal" Visible="False"
                                            Text='<%# Bind("IdUsuarioCreador") %>'></asp:Label><asp:Label ID="lblLoginCreador"
                                                runat="server" SkinID="SkinLblNormal"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Modific&#243;">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdUsuarioModifico_E" runat="server" SkinID="SkinLblNormal" Visible="False"
                                            Text='<%# Bind("IdUsuarioModifico") %>'></asp:Label><asp:Label ID="lblLoginModifico_E"
                                                runat="server" SkinID="SkinLblNormal"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdUsuarioModifico" runat="server" SkinID="SkinLblNormal" Visible="False"
                                            Text='<%# Bind("IdUsuarioModifico") %>'></asp:Label><asp:Label ID="lblLoginModifico"
                                                runat="server" SkinID="SkinLblNormal"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" CommandName="Update"
                                            ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar" />&nbsp;<asp:ImageButton ID="ibCancelar"
                                                runat="server" CausesValidation="False" CommandName="Cancel" ImageUrl="~/Imagenes/Eliminar.png"
                                                ToolTip="Cancelar" />
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
                                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" OnClick="ibEliminar_Click" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                                            TargetControlID="ibEliminar">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibVerOP" runat="server" CausesValidation="False" CommandName="VerOP"
                                            ImageUrl="~/Imagenes/Detalles.gif" ToolTip="Ver orden de presentación" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SePuedeModificar" Visible="False">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkbxSePuedeModificar_E" runat="server" 
                                            Checked='<%# Bind("SePuedeModificar") %>' />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkbxSePuedeModificar" runat="server" 
                                            Checked='<%# Bind("SePuedeModificar") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvOPs" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="gvOPs" EventName="RowEditing" />
                        <asp:AsyncPostBackTrigger ControlID="gvOPs" EventName="RowCancelingEdit" />
                        <asp:AsyncPostBackTrigger ControlID="gvOPs" EventName="RowDeleting" />
                        <asp:AsyncPostBackTrigger ControlID="gvOPs" EventName="RowUpdating" />
                        <asp:AsyncPostBackTrigger ControlID="lbCrearNuevaOP" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ddlA&#241;os" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
