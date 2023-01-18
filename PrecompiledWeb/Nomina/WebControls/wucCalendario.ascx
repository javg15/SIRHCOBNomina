<%@ control language="VB" autoeventwireup="false" inherits="wucCalendario, App_Web_vfc141dy" %>

    <asp:UpdatePanel ID="UPMain" runat="server">
    <ContentTemplate>
    
    <div style="width: 300px;">
        <div style="width: 150px; float: left;">
            <asp:Label ID="Label1" runat="server" Text="Año:"></asp:Label>
        </div>
        <div style="width: 150px; float: right;">
             <asp:Label ID="Label3" runat="server" Text="Mes:"></asp:Label>
        </div>
        <div style="width: 150px; float: left;">          
            <asp:DropDownList ID="ddlAnios" runat="server" Width="140px" 
                AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <div style="width: 150px; float: right;">          
            <asp:DropDownList ID="ddlMeses" runat="server" Width="140px" 
                AutoPostBack="True">
            </asp:DropDownList>
        </div>
    </div>
    <div style="width: 300px;">
        <asp:Calendar ID="Calendar1" runat="server" NextPrevFormat="FullMonth" 
            ShowGridLines="True" BackColor="White" 
            BorderColor="#999999" CellPadding="4" Font-Names="Verdana" Font-Size="9pt" 
            ForeColor="Black" Height="180px" Width="300px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" CssClass="diaNoSelPorFinDeSemana" />
        </asp:Calendar>
    </div>

    </ContentTemplate>
    </asp:UpdatePanel>



