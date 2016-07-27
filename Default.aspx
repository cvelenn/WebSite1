<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2 class="my-h2">
        Overall statistics
    </h2>
    <div class="table-container">
        <table>
            <tr>
                <td class="vertical-td">Profit</td>
                <td class="vertical-td-right"><%= TotalProfit%></td>
            </tr>
            <tr>
                <td class="vertical-td">Yield</td>
                <td class="vertical-td-right"><%= Yield%>%</td>
            </tr>
            <tr>
                <td class="vertical-td">Win Rate</td>
                <td class="vertical-td-right"><%= WinRate%>%</td>
            </tr>
            <tr>
                <td class="vertical-td">Average Odds</td>
                <td class="vertical-td-right"><%= AverageOdds%></td>
            </tr>
            <tr>
                <td class="vertical-td">No. Tips</td>
                <td class="vertical-td-right"><%= NumberOfTips%></td>
            </tr>
        </table>
    </div>
    <div class="table-container">
        <table>            
            <tr style="background: #5D7B9D; color: white">
                <th class="width70">Month</th>
                <th class="width50">Profit</th>
                <th class="width100">Yield</th>
                <th class="width50">No. Tips</th>
            </tr>
        </table>
        <div class="month-table">
            <table>
            <% for (int i = 0; i < MonthList.Count; i++)
                { %>
                <tr>
                    <td class="width70"><%: MonthList[i]%></td>
                    <td class="width50"><%: ProfitList[i]%></td>
                    <td class="width100"><%: YieldList[i]%>%</td>
                    <td class="width50"><%: NumberOfTipsList[i]%></td>
                </tr>
            <% } %>
            </table>
        </div>
    </div>

    <div class="chart">
        <asp:Chart ID="Chart1" runat="server" Width="409px">
            <series>
                <asp:Series ChartArea="ChartArea1" ChartType="Line" Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
    </div>

    <h2>
        Table of tips
    </h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource2" 
            EmptyDataText="There are no data records to display." ForeColor="#333333" 
            GridLines="None" Width="915px" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="league" HeaderText="League" 
                    SortExpression="league" />
                <asp:BoundField DataField="event" HeaderText="Event" SortExpression="event" />
                <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" 
                    DataFormatString="{0:dd/MM/yyyy HH:mm}" />
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
