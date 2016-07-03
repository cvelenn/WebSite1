<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="table-container">
        <table>
            <tr>
                <td>Profit</td>
                <td><%= TotalProfit%></td>
            </tr>
            <tr>
                <td>Yield</td>
                <td><%= Yield%>%</td>
            </tr>
            <tr>
                <td>Win Rate</td>
                <td><%= WinRate%>%</td>
            </tr>
            <tr>
                <td>Average Odds</td>
                <td><%= AverageOdds%></td>
            </tr>
            <tr>
                <td>Number Of Tips</td>
                <td><%= NumberOfTips%></td>
            </tr>
        </table>
    </div>
    <div class="table-container">
        <table>
        <tr>
            <th>Month</th>
            <th>Profit</th>
            <th>Yield</th>
            <th>Number Of Tips</th>
        </tr>
        <% for (int i = 0; i < MonthList.Count; i++)
           { %>
            <tr>
                <td><%: MonthList[i]%></td>
                <td><%: ProfitList[i]%></td>
                <td><%: YieldList[i]%>%</td>
                <td><%: NumberOfTipsList[i]%></td>
            </tr>
        <% } %>
    
        </table>
    </div>

    <h2>
        Table of tips
    </h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource2" 
            EmptyDataText="There are no data records to display." ForeColor="#333333" 
            GridLines="None" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="league" HeaderText="League" 
                    SortExpression="league" />
                <asp:BoundField DataField="event" HeaderText="Event" SortExpression="event" />
                <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" 
                    DataFormatString="{0:MM/dd/yyyy HH:mm}" />
                <asp:BoundField DataField="selection" HeaderText="Selection" 
                    SortExpression="selection" />
                <asp:BoundField DataField="odd" HeaderText="Odds" SortExpression="odd" />
                <asp:BoundField DataField="stake" HeaderText="Stake" SortExpression="stake" />
                <asp:BoundField DataField="profit" HeaderText="Profit" 
                    SortExpression="profit" />
                <asp:BoundField DataField="result" HeaderText="Result" 
                    SortExpression="result" />
                <asp:BoundField DataField="bookmaker" HeaderText="Bookmaker" 
                    SortExpression="bookmaker" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:kladionicaConnectionString1 %>" 
            ProviderName="<%$ ConnectionStrings:kladionicaConnectionString1.ProviderName %>" >
        </asp:SqlDataSource>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    </asp:Content>
