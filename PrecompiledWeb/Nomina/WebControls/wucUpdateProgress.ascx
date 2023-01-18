<%@ control language="VB" enableviewstate="true" autoeventwireup="false" inherits="WebControls_wucUpdateProgress, App_Web_vfc141dy" %>
<div>
    <script type="text/JavaScript" language="JavaScript">
        function pageLoad() {
            var manager = Sys.WebForms.PageRequestManager.getInstance();
            manager.add_endRequest(endRequest);
            manager.add_beginRequest(OnBeginRequest);
        }

        function OnBeginRequest(sender, args) {
            $get('ParentDiv').className = 'modalBackground2';
        }

        function endRequest(sender, args) {
            $get('ParentDiv').className = '';
        }

        function CancelPostBack() {
            var objMan = Sys.WebForms.PageRequestManager.getInstance();
            if (objMan.get_isInAsyncPostBack())
                objMan.abortPostBack();
        }

        function ChangeUpdateProgress(message) {
            document.getElementById('ctl00_ContentPlaceHolder1_wucUpdateProgress1_lblMsjEspera').innerText = message;
        }
    </script>
    <asp:UpdatePanel ID="up_Progress" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="500" 
            DynamicLayout="true">
        <ProgressTemplate>
            <div id="ParentDiv">
            </div>
            <div id="div1" runat="server" align="center" style="z-index: 10; filter: alpha(opacity=40);
                left: 0px; visibility: visible; vertical-align: middle; width: 100%; position: fixed;
                top: 0px; height: 100%; background-color: white" valign="middle">
            </div>
            <div id="div2" runat="server" align="center" style="z-index: 20; border-left-color: black;
                left: 40%; visibility: visible; border-bottom-color: black; vertical-align: middle;
                width: 250px; border-top-style: inset; border-top-color: black; border-right-style: inset;
                border-left-style: inset; position: fixed; top: 40%; height: 100px; background-color: white;
                border-right-color: black; border-bottom-style: inset" valign="middle">
                <br />
                <table>
                    <tr>
                        <td style="vertical-align: middle; text-align: center">
                            <asp:Image ID="img1" runat="server" ImageUrl="~/Imagenes/Spinner2.gif" />
                        </td>
                        <td style="vertical-align: middle; text-align: center">
                            <asp:Label ID="lblMsjEspera" runat="server" SkinID="SkinLblMsjExito" Text="Por favor espere..."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="vertical-align: middle; text-align: center">
                            <asp:Button ID="btnCancelar" runat="server" OnClientClick="javascript:CancelPostBack(); return false;"
                                SkinID="SkinBoton" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </ContentTemplate>
    </asp:UpdatePanel>
</div>