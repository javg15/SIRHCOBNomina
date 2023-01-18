<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="CadenaMovsAsociados, App_Web_gy0kusdy" title="COBAEV - Nómina - Cadenas, movimientos asociados" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress"
    TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table border="0" cellpadding="0" cellspacing="0" style="width: 70%;">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Cadenas (Movimientos asociados)
                </h2>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvCadena" runat="server" CellPadding="1" OnRowDataBound="gvCadena_RowDataBound"
                            SkinID="SkinGridView">
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/Select.png" ShowSelectButton="True"
                                    Visible="False">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="IdCadena" Visible="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdCadena_E" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("IdCadena") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdCadena" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("IdCadena") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NumCadena" HeaderText="Cadena No." ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Ejercicio" HeaderText="Ejercicio" ReadOnly="True">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Origen propuesta">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlOrigenPropuesta_E" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrigenPropuesta" runat="server" Text='<%# Bind("OrigenPropuesta") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdOrigenPropuesta" Visible="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdOrigenPropuesta_E" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("IdOrigenPropuesta") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdOrigenPropuesta" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("IdOrigenPropuesta") %>'></asp:Label>
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
                                <asp:TemplateField HeaderText="Fecha &#243;rdenes de presentaci&#243;n">
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
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdEstatusCadena" Visible="False">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdEstatusCadena_E" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("IdEstatusCadena") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdEstatusCadena" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("IdEstatusCadena") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estatus actual">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlEstatusActualCadena_E" runat="server" SkinID="SkinDropDownList">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblEstatusActualCadena" runat="server" Text='<%# Bind("EstatusActualCadena") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cre&#243;">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdUsuarioCreador_E" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("IdUsuarioCreador") %>'
                                            Visible="False"></asp:Label><asp:Label ID="lblLoginCreador_E" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdUsuarioCreador" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("IdUsuarioCreador") %>'
                                            Visible="False"></asp:Label><asp:Label ID="lblLoginCreador" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Modific&#243;">
                                    <EditItemTemplate>
                                        <asp:Label ID="lblIdUsuarioModifico_E" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("IdUsuarioModifico") %>'
                                            Visible="False"></asp:Label><asp:Label ID="lblLoginModifico_E" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdUsuarioModifico" runat="server" SkinID="SkinLblNormal" Text='<%# Bind("IdUsuarioModifico") %>'
                                            Visible="False"></asp:Label><asp:Label ID="lblLoginModifico" runat="server" SkinID="SkinLblNormal"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" Visible="False">
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="ibGuardar" runat="server" CausesValidation="True" CommandName="Update"
                                            ImageUrl="~/Imagenes/CDROM.png" ToolTip="Guardar" />
                                        <asp:ImageButton ID="ibCancelar" runat="server" CausesValidation="False" CommandName="Cancel"
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
                                <asp:TemplateField ShowHeader="False" Visible="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibEliminar" runat="server" CausesValidation="False" CommandName="Delete"
                                            ImageUrl="~/Imagenes/Eliminar.png" ToolTip="Eliminar" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="CBEEliminar" runat="server" ConfirmText="La operación solicitada eliminará el registro de la Base de datos, ¿Continuar?"
                                            TargetControlID="ibEliminar">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" Visible="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibVerMovs" runat="server" CausesValidation="False" CommandName="VerMovs"
                                            ImageUrl="~/Imagenes/Detalles.gif" ToolTip="Ver movimientos asociados a la cadena" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                        <asp:Label ID="Label3" runat="server" SkinID="SkinLblMsjExito" Text="Movimientos asociados a la cadena:"></asp:Label><br />
                        <asp:GridView ID="gvMovs" runat="server" SkinID="SkinGridView2" AutoGenerateColumns="False"
                            EmptyDataText="No hay movimientos asociados a la cadena." ShowFooter="True" OnRowDataBound="gvMovs_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="IdCadena" Visible="False">
                                    <EditItemTemplate>
                                        &nbsp;
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdCadena" runat="server" Text='<%# Bind("IdCadena") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdPlaza" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPlaza" runat="server" Text='<%# Bind("IdPlaza") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="TipoMov" HeaderText="Tipo Mov." Visible="False">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NumEmp" HeaderText="Num. Emp." Visible="False">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RFCEmp" HeaderText="R.F.C.">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ApePatEmp" HeaderText="Apellido paterno">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ApeMatEmp" HeaderText="Apellido materno">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NomEmp" HeaderText="Nombre">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MotivoBaja" HeaderText="Motivo de baja">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MotivoAlta" HeaderText="Motivo de alta">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Categoria" HeaderText="Categor&#237;a">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Ocupacion" HeaderText="Ocupaci&#243;n">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Inicio" HeaderText="Inicio">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fin" HeaderText="Fin">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NumEmpTit" HeaderText="Num. Emp. Titular" Visible="False">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RFCEmpTit" HeaderText="R.F.C. Titular">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreTitular" HeaderText="Nombre Titular">
                                    <HeaderStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                </asp:BoundField>
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
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
            </td>
        </tr>
    </table>
</asp:Content>
