<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Table of tips
    </h2>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource2" 
            EmptyDataText="There are no data records to display." ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="league" HeaderText="league" 
                    SortExpression="league" />
                <asp:BoundField DataField="event" HeaderText="event" SortExpression="event" />
                <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                <asp:BoundField DataField="selection" HeaderText="selection" 
                    SortExpression="selection" />
                <asp:BoundField DataField="odd" HeaderText="odd" SortExpression="odd" />
                <asp:BoundField DataField="stake" HeaderText="stake" SortExpression="stake" />
                <asp:BoundField DataField="profit" HeaderText="profit" 
                    SortExpression="profit" />
                <asp:BoundField DataField="result" HeaderText="result" 
                    SortExpression="result" />
                <asp:BoundField DataField="bookmaker" HeaderText="bookmaker" 
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
            ProviderName="<%$ ConnectionStrings:kladionicaConnectionString1.ProviderName %>" 
            SelectCommand="SELECT [league], [event], [date], [selection], [odd], [stake], [profit], [result], [bookmaker] FROM [tips]">
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
