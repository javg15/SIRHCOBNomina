<%@ page language="VB" enableeventvalidation="false" masterpagefile="~/MasterPageSesionIniciada.master" autoeventwireup="false" inherits="ABCPlazas, App_Web_xmuq13zf" title="COBAEV - Nómina - ABC Plazas" stylesheettheme="SkinFile" maintainScrollPositionOnPostBack="true" %>

<%@ Register Src="~/WebControls/wucSearchEmpsAux.ascx" TagName="wucBuscaEmpleados"
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
                <uc1:wucBuscaEmpleados ID="wucBuscaEmpsAux" runat="server" EnableViewState="true"></uc1:wucBuscaEmpleados>
            </asp:Panel>
            <asp:MultiView ID="mvABCPLazas" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewCapturaModif" runat="server">
                 <asp:Panel ID="pnlCapturaModif" runat="server" GroupingText="Información de la plaza:">
                 <div class="divLeft1024">
                    <asp:Panel ID="pnClavePlaza" runat="server" GroupingText="Clave de la plaza a asignar:" 
                            Width="100%" HorizontalAlign="Center" >

                    <asp:TextBox ID="txtbxZE" runat="server" ReadOnly="True" Width="40px"></asp:TextBox>
                    <asp:Label ID="lblGuion1punto1" runat="server" Text="-"></asp:Label>
                    <asp:TextBox ID="txtbxClaveCatego" runat="server" ReadOnly="True" Width="70px"></asp:TextBox>   
                    <asp:Label ID="lblGuion2punto1" runat="server" Text="-"></asp:Label>
                    <asp:TextBox ID="txtBxHoras" runat="server" ReadOnly="True" Width="40px"></asp:TextBox>
                    <asp:Label ID="lblGuion3punto1" runat="server" Text="-"></asp:Label>
                    <asp:TextBox ID="txtbxCons" runat="server" ReadOnly="True" Width="70px"></asp:TextBox>

                </asp:Panel>
                </div>
                <div class="divLeft420">
                <div id="divPlazaDetalles" class="divLeft420">
                        <p class="pTop">
                            <asp:Label ID="lblTipoPlaza" runat="server" Text="Tipo de plaza:"></asp:Label>
                        </p>
                        <p class="pBottom">
                            <asp:DropDownList ID="ddlTiposPlaza" runat="server"  Width="100%" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop2">
                            <asp:Label ID="lblPlanteles" runat="server" Text="Centro de trabajo:" ToolTip="Centro de trabajo donde es/será ejercida la plaza"></asp:Label>
                        </p>
                        <p class="pTop3">
                            <asp:Label ID="lbldivOrdenPlanteles" runat="server" Text="Ordenar por:"></asp:Label>
                            <asp:DropDownList ID="ddlOrdenPlanteles" runat="server"  Width="150px" 
                                AutoPostBack="True">
                                 <asp:ListItem Value="CLAVEASC" Selected="True">Clave ASC</asp:ListItem>
                                 <asp:ListItem Value="CLAVEDESC">Clave DESC</asp:ListItem>
                                 <asp:ListItem Value="DESCRASC">Descripción ASC</asp:ListItem>
                                 <asp:ListItem Value="DESCRDESC">Descripción DESC</asp:ListItem>
                            </asp:DropDownList>
                        </p>
                        <p class="pBottom">
                            <asp:DropDownList ID="ddlPlanteles" runat="server"  Width="100%"  
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop2">
                            <asp:Label ID="lblDepto" runat="server" Text="Departamento:" ToolTip="Departamento dentro del Centro de trabajo donde es/será ejercida la plaza"></asp:Label>
                        </p>
                        <p class="pTop3">
                             <asp:Label ID="lblOrdenDeptos" runat="server" Text="Ordenar por:"></asp:Label>
                            <asp:DropDownList ID="ddlOrdenDeptos" runat="server"  Width="150px" 
                                AutoPostBack="True">
                                 <asp:ListItem Value="CLAVEASC" Selected="True">Clave ASC</asp:ListItem>
                                 <asp:ListItem Value="CLAVEDESC">Clave DESC</asp:ListItem>
                                 <asp:ListItem Value="DESCRASC">Descripción ASC</asp:ListItem>
                                 <asp:ListItem Value="DESCRDESC">Descripción DESC</asp:ListItem>
                            </asp:DropDownList>
                        </p>
                        <p class="pBottom">
                            <asp:DropDownList ID="ddlDeptos" runat="server"  Width="100%" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop">
                            <asp:Label ID="lblZE" runat="server" Text="Zona económica de la plaza:"></asp:Label>
                        </p>
                         <p class="pBottom">
                            <asp:DropDownList ID="ddlZonasEco" runat="server" Width="100%" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                         <p class="pTop">
                            <asp:Label ID="lblFPPlaza" runat="server" Text="Naturaleza de la plaza:"></asp:Label>
                        </p>
                         <p class="pBottom">
                            <asp:DropDownList ID="ddlFPsPlaza" runat="server" Width="100%"  
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop2">
                            <asp:Label ID="lblCatego" runat="server" Text="Categorías:"></asp:Label>
                        </p>
                        <p class="pTop3">
                            <asp:Label ID="lblOrdenCatego" runat="server" Text="Ordenar por:"></asp:Label>
                            <asp:DropDownList ID="ddlOrdenCategos" runat="server"  Width="150px" 
                                AutoPostBack="True">
                                 <asp:ListItem Value="CLAVEASC" Selected="True">Clave ASC</asp:ListItem>
                                 <asp:ListItem Value="CLAVEDESC">Clave DESC</asp:ListItem>
                                 <asp:ListItem Value="DESCRASC">Descripción ASC</asp:ListItem>
                                 <asp:ListItem Value="DESCRDESC">Descripción DESC</asp:ListItem>
                            </asp:DropDownList>
                        </p>
                        </p>
                         <p class="pBottom">
                            <asp:DropDownList ID="ddlCategos" runat="server"  Width="100%"  
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </p>
                        <p class="pTop">
                            <asp:Label ID="lblConsecutivo" runat="server" Text="Consecutivo (Número que identifica a la plaza como única):"></asp:Label>
                        </p>
                         <p class="pBottom">
                            <asp:TextBox ID="txtbxConsecutivo" runat="server" Width="95%"  MaxLength="5" 
                                AutoPostBack="True"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="txtbxConsecutivo_FTBE" runat="server" 
                                Enabled="True" FilterType="Numbers" TargetControlID="txtbxConsecutivo"></ajaxToolkit:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RFV_txtbxConsecutivo" runat="server" 
                                ControlToValidate="txtbxConsecutivo" Display="Dynamic" 
                                ErrorMessage="La captura del consecutivo de plaza es obligatoria." 
                                ToolTip="La captura del consecutivo de plaza es obligatoria." 
                                 ValidationGroup="gpoValidaPlaza">*</asp:RequiredFieldValidator>
                        </p>
                         <p class="pTopCenter">
                            <asp:Button ID="btnValidaPlaza" runat="server" Text="Validar plaza y continuar" 
                                Width="200px" CssClass="btn" ValidationGroup="gpoValidaPlaza" />
                        </p>
                 </div>
                 </div>
                 <div class="divRight420">
                         <p class="pTop">
                            <asp:Label ID="lblSindicato" runat="server" Text="Sindicato al que pertenece la plaza:"></asp:Label>
                        </p>
                         <p class="pBottom">
                             <asp:TextBox ID="txtbxSindicato" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
                        </p>
                         <p class="pTop">
                            <asp:Label ID="lblTitular" runat="server" Text="Titular de la plaza:"></asp:Label>
                        </p>
                         <p class="pBottom">
                             <asp:TextBox ID="txtbxTitular" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
                        </p>
                         <p class="pTop">
                            <asp:Label ID="lblOcupAct" runat="server" Text="Ocupante actual de la plaza:"></asp:Label>
                        </p>
                         <p class="pBottom">
                             <asp:TextBox ID="txtbxOcupAct" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
                        </p>
                         <p class="pTop">
                            <asp:Label ID="lblEstatusPlaza" runat="server" Text="Ocupación actual de la plaza:"></asp:Label>
                        </p>
                         <p class="pBottom">
                             <asp:TextBox ID="txtbxEstatusPlaza" runat="server" ReadOnly="True" Width="100%"></asp:TextBox>
                        </p>
                 </div>
                 </asp:Panel>
                </asp:View>
                <asp:View ID="viewBaja" runat="server">
                 <asp:Panel ID="pnlBaja" runat="server" GroupingText="Información de la plaza:">
                    Baja
                 </asp:Panel>
                </asp:View>
            </asp:MultiView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
