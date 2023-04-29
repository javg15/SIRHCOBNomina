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
    <script>
        //recargar la pagina llamante
        const queryString = window.location.search;
        const urlParams = new URLSearchParams(queryString);
        if (urlParams.get('sub') == "1") {
            window.opener.location.reload(false);
            window.close()
        }
    </script>
    <style>
     .GvGrid:hover
        {
            border-color: #f1f3f5;
            border: solid;
        }
    </style>
    <table style="width: 100%;" align="center">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Administrar horarios de docentes
                </h2>
            </td>
        </tr>
     </table>
     <table style="width: 100%;" align="left">
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:UpdatePanel ID="UPMain" runat="server">
                    <ContentTemplate>
                        <br />
                        <table>
                            <tr>
                                <td><asp:Label ID="lblPlantelHead" runat="server" CssClass="pLabel" Text="Plantel:"></asp:Label></td>
                                <td><asp:Label ID="lblPlantel" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                    <asp:Label ID="lblEmpleadoHead" runat="server" CssClass="pLabel" Text="Empleado:"></asp:Label>
                </td>
                                <td>
                    <asp:Label ID="lblEmpleado" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label>
                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblMateriaHead" runat="server" CssClass="pLabel" Text="Materia:"></asp:Label></td>
                                <td><asp:Label ID="lblMateria" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblGrupoHead" runat="server" CssClass="pLabel" Text="Grupo:"></asp:Label></td>
                                <td><asp:Label ID="lblGrupo" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label></td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblHorasHead" runat="server" CssClass="pLabel" Text="Horas registradas:"></asp:Label></td>
                                <td><asp:Label ID="lblTotalHoras" runat="server" CssClass="pLabel" Font-Bold="True"></asp:Label>
                                    <asp:textbox ID="hidHorasRestantes" runat="server" BackColor="White" ForeColor="White" Width="1px" BorderColor="White" BorderStyle="None" />
                                </td>
                                <tr>
                                    <td><asp:Label ID="lblObservacionesHead" runat="server" CssClass="pLabel" Text="Observaciones:"></asp:Label></td>
                                    <td><asp:Label ID="lblObservaciones" runat="server" CssClass="pLabel" Font-Bold="True" ForeColor="#CC3300"></asp:Label></td>
                                </tr>
                            </tr>
                        </table>
                        <asp:TextBox ID="hidIdHora" runat="server" BackColor="White" ForeColor="White" Width="1px" BorderColor="White" BorderStyle="None" ></asp:TextBox>

                        <asp:HiddenField ID="hidIdHorariosClase" runat="server" />
                        <asp:HiddenField ID="hidCantidadHorasHorario" runat="server" />

                        <asp:Panel ID="pnlHoras" runat="server" GroupingText="" Visible="true" HorizontalAlign="Left">
                            <asp:LinkButton ID="lbBackPlanteles" runat="server" Font-Bold="False"
                                SkinID="SkinLinkButton" ToolTip="Agregar horario" ForeColor="#003300" PostBackUrl="../../Consultas/Empleados/CargaHoraria.aspx">Regresar a carga horaria</asp:LinkButton>
                            &nbsp;&nbsp;
                            </asp:Panel>
                        <br />
                        <asp:GridView ID="gvHoras" runat="server" EmptyDataText="No hay horarios registrados actualmente."
                                        SkinID="SkinGridViewEmpty" RowStyle-CssClass="GvGrid" ViewStateMode="Enabled">
                            <Columns>
                                <asp:TemplateField HeaderText="HoraInicio" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHoraInicio" runat="server" Text='<%# Bind("HoraInicio") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="HoraFin" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHoraFin" runat="server" Text='<%# Bind("HoraFin") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hora" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHora" runat="server" Text='<%# Bind("Hora") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lunes" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLunes" runat="server" Text='<%# Bind("Lunes") %>' Visible="false"></asp:Label>
                                        <asp:ImageButton ID="ibAdd1" runat="server" ImageUrl="~/Imagenes/Add2Disabled.png" CausesValidation="false" ToolTip="Clic para asignar horario"  />
                                        <asp:ImageButton ID="ibEliminar1" runat="server" ImageUrl="~/Imagenes/Check.png" CausesValidation="false" ToolTip="Clic para quitar asignación de horario" />
                                        <asp:Image ID="imgDocenteTT1" runat="server" ImageUrl="~/Imagenes/Empleado.jpg" CausesValidation="false" ToolTip='<%# Bind("LunesT") %>' />
                                        <asp:Image ID="imgGrupoTT1" runat="server" ImageUrl="~/Imagenes/group.png" CausesValidation="false" ToolTip='<%# Bind("LunesGT") %>' Height="16" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Martes" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMartes" runat="server" Text='<%# Bind("Martes") %>' Visible="false"></asp:Label>
                                        <asp:ImageButton ID="ibAdd2" runat="server" ImageUrl="~/Imagenes/Add2Disabled.png" CausesValidation="false" ToolTip="Clic para asignar horario"  />
                                        <asp:ImageButton ID="ibEliminar2" runat="server" ImageUrl="~/Imagenes/Check.png" CausesValidation="false" ToolTip="Clic para quitar asignación de horario" />
                                        <asp:Image ID="imgDocenteTT2" runat="server" ImageUrl="~/Imagenes/Empleado.jpg" CausesValidation="false" ToolTip='<%# Bind("MartesT") %>' />
                                        <asp:Image ID="imgGrupoTT2" runat="server" ImageUrl="~/Imagenes/group.png" CausesValidation="false" ToolTip='<%# Bind("MartesGT") %>' Height="16" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Miércoles" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMiercoles" runat="server" Text='<%# Bind("Miercoles") %>' Visible="false"></asp:Label>
                                        <asp:ImageButton ID="ibAdd3" runat="server" ImageUrl="~/Imagenes/Add2Disabled.png" CausesValidation="false" ToolTip="Clic para asignar horario"  />
                                        <asp:ImageButton ID="ibEliminar3" runat="server" ImageUrl="~/Imagenes/Check.png" CausesValidation="false" ToolTip="Clic para quitar asignación de horario" />
                                        <asp:Image ID="imgDocenteTT3" runat="server" ImageUrl="~/Imagenes/Empleado.jpg" CausesValidation="false" ToolTip='<%# Bind("MiercolesT") %>' />
                                        <asp:Image ID="imgGrupoTT3" runat="server" ImageUrl="~/Imagenes/group.png" CausesValidation="false" ToolTip='<%# Bind("MiercolesGT") %>' Height="16" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Jueves" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblJueves" runat="server" Text='<%# Bind("Jueves") %>' Visible="false"></asp:Label>
                                        <asp:ImageButton ID="ibAdd4" runat="server" ImageUrl="~/Imagenes/Add2Disabled.png" CausesValidation="false" ToolTip="Clic para asignar horario"  />
                                        <asp:ImageButton ID="ibEliminar4" runat="server" ImageUrl="~/Imagenes/Check.png" CausesValidation="false" ToolTip="Clic para quitar asignación de horario" />
                                        <asp:Image ID="imgDocenteTT4" runat="server" ImageUrl="~/Imagenes/Empleado.jpg" CausesValidation="false" ToolTip='<%# Bind("JuevesT") %>' />
                                        <asp:Image ID="imgGrupoTT4" runat="server" ImageUrl="~/Imagenes/group.png" CausesValidation="false" ToolTip='<%# Bind("JuevesGT") %>' Height="16" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Viernes" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblViernes" runat="server" Text='<%# Bind("Viernes") %>' Visible="false"></asp:Label>
                                        <asp:ImageButton ID="ibAdd5" runat="server" ImageUrl="~/Imagenes/Add2Disabled.png" CausesValidation="false" ToolTip="Clic para asignar horario"  />
                                        <asp:ImageButton ID="ibEliminar5" runat="server" ImageUrl="~/Imagenes/Check.png" CausesValidation="false" ToolTip="Clic para quitar asignación de horario" />
                                        <asp:Image ID="imgDocenteTT5" runat="server" ImageUrl="~/Imagenes/Empleado.jpg" CausesValidation="false" ToolTip='<%# Bind("ViernesT") %>' />
                                        <asp:Image ID="imgGrupoTT5" runat="server" ImageUrl="~/Imagenes/group.png" CausesValidation="false" ToolTip='<%# Bind("ViernesGT") %>' Height="16" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sábado" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSabado" runat="server" Text='<%# Bind("Sabado") %>' Visible="false"></asp:Label>
                                        <asp:ImageButton ID="ibAdd6" runat="server" ImageUrl="~/Imagenes/Add2Disabled.png" CausesValidation="false" ToolTip="Clic para asignar horario"  />
                                        <asp:ImageButton ID="ibEliminar6" runat="server" ImageUrl="~/Imagenes/Check.png" CausesValidation="false" ToolTip="Clic para quitar asignación de horario" />
                                        <asp:Image ID="imgDocenteTT6" runat="server" ImageUrl="~/Imagenes/Empleado.jpg" CausesValidation="false" ToolTip='<%# Bind("SabadoT") %>' />
                                        <asp:Image ID="imgGrupoTT6" runat="server" ImageUrl="~/Imagenes/group.png" CausesValidation="false" ToolTip='<%# Bind("SabadoGT") %>' Height="16" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Domingo" Visible="True">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDomingo" runat="server" Text='<%# Bind("Domingo") %>' Visible="false"></asp:Label>
                                        <asp:ImageButton ID="ibAdd7" runat="server" ImageUrl="~/Imagenes/Add2Disabled.png" CausesValidation="false" ToolTip="Clic para asignar horario"  />
                                        <asp:ImageButton ID="ibEliminar7" runat="server" ImageUrl="~/Imagenes/Check.png" CausesValidation="false" ToolTip="Clic para quitar asignación de horario" />
                                        <asp:Image ID="imgDocenteTT7" runat="server" ImageUrl="~/Imagenes/Empleado.jpg" CausesValidation="false" ToolTip='<%# Bind("DomingoT") %>' />
                                        <asp:Image ID="imgGrupoTT7" runat="server" ImageUrl="~/Imagenes/group.png" CausesValidation="false" ToolTip='<%# Bind("DomingoGT") %>' Height="16" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                            
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    
</asp:Content>
