<%@ page language="VB" masterpagefile="~/MasterPageBlanca.master" autoeventwireup="false" inherits="Consultas_Percepciones_DeducsPercsAsocAPercProg, App_Web_nszpy5ff" title="COBAEV - Nómina - Percepciones/Deducciones asociadas a percepción programada" theme="SkinFile" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>
<%@ Register Src="~/WebControls/wucUpdateProgress.ascx" TagName="wucUpdateProgress" TagPrefix="TP_wucUpdateProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <TP_wucUpdateProgress:wucUpdateProgress ID="wucUpdateProgress1" runat="server" EnableViewState="true" />
    <table style="width: 100%; height: 100%">
        <tr>
            <td style="vertical-align: top; text-align: right">
                <h2>
                    Sistema de nómina: Percepciones/Deducciones asociadas a percepción programada
                </h2>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <table cellspacing="10">
                    <tr>
                        <td style="text-align: center; vertical-align: top;">
                            <asp:GridView ID="gvPercepciones" runat="server" Caption="Percepciones" CaptionAlign="Left" SkinID="SkinGridView">
                                <Columns>
                                    <asp:BoundField DataField="IdPercepcion" HeaderText="IdPercepcion" Visible="False" />
                                    <asp:BoundField DataField="ClavePercepcion" HeaderText="Clave">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NombrePercepcion" HeaderText="Descripci&#243;n">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td style="text-align: center; vertical-align: top;">
                            <asp:GridView ID="gvDeducciones" runat="server" Caption="Deducciones" CaptionAlign="Left" SkinID="SkinGridView">
                                <Columns>
                                    <asp:BoundField DataField="IdDeduccion" HeaderText="IdDeduccion" Visible="False" />
                                    <asp:BoundField DataField="ClaveDeduccion" HeaderText="Clave">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NombreDeduccion" HeaderText="Descripci&#243;n">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
    <asp:LinkButton ID="lbCerrar" runat="server" SkinID="SkinLinkButton">Cerrar ventana</asp:LinkButton></td>
        </tr>
    </table>
</asp:Content>

