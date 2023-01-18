<%@ control language="VB" autoeventwireup="false" inherits="WebControls_wucMuestraFoto2, App_Web_vfc141dy" %>
<!--<link href="../StyleSheetAlternativa.css" rel="stylesheet" type="text/css" />-->
<style type="text/css">
    .modalBackground
    {
        background-color:Silver;
        filter: alpha(opacity=60);
        opacity: 0.5;
        -moz-opacity: 0.50;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: maroon;
        padding-top: 5px;
        padding-left: 5px;
        padding-right:5px;
        width: 350px;
        height: 450px;
    }
 </style>
<asp:FormView ID="fvInfEmpleados" Runat="server" HeaderText="Información del empleado" AllowPaging="false">
<ItemTemplate>
<div id="divHover">
    <div class="contImg">
        <asp:ImageButton ID="imgFoto" runat="server" 
            Width="100px" Height="120px" ToolTip="Ampliar imagen"  />
    </div>
    <div class="descripcion">
        <asp:ImageButton ID="imgZoom" CausesValidation="false" runat="server" ToolTip="Ampliar imagen" ImageUrl="~/Imagenes/Zoom.png" OnClick="imgZoom_Click"/>
        <ajaxToolkit:ModalPopupExtender ID="imgZoom_MPE" runat="server" 
            DynamicServicePath="" Enabled="True" PopupControlID="pnlPopUpFoto"
            DropShadow="true" TargetControlID="btnOpenModalPopUp1"
            BackgroundCssClass="modalBackground" CancelControlID="btnCloseModalPopUp1">
        </ajaxToolkit:ModalPopupExtender>
    </div>
</div>
<div>
    <asp:DetailsView ID="dvInfEmpleado" runat="server" AutoGenerateRows="False" 
        SkinID="SkinDetailsView">
        <Fields>
            <asp:BoundField DataField="RFC" HeaderText="R.F.C.:" />
            <asp:BoundField DataField="CURP" HeaderText="C.U.R.P.:" />
            <asp:BoundField DataField="NumEmp" HeaderText="Núm. Emp.:" />
            <asp:BoundField DataField="ApePatEmp" HeaderText="Apellido Paterno:" />
            <asp:BoundField DataField="ApeMatEmp" HeaderText="Apellido Materno:" />
            <asp:BoundField DataField="NomEmp" HeaderText="Nombre(s):" />
        </Fields>
    
    </asp:DetailsView>
</div>
</ItemTemplate>
</asp:FormView>
<asp:Button ID="btnCloseModalPopUp1" runat="server" Text="Cerrar" style="display:none"/>
<asp:Button ID="btnOpenModalPopUp1" runat="server" Text="Cerrar" style="display:none"/>
<asp:Panel ID="pnlPopUpFoto" runat="server" CssClass="modalPopup" align="center" >
    <asp:UpdatePanel ID="UPModalPopUp1" runat="server">
    <ContentTemplate>
        <asp:Image ID="imgFoto2" runat="server" Width="350px" Height="400px" />
        <div id="divBotones">
            <p class="submitButton">
            <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" 
               Text="Cerrar" CausesValidation="False" />
            </p>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
