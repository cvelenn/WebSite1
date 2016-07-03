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
            GridLines="None" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Update" 
                    ShowHeader="True" Text="Update"  />
                <asp:ButtonField ButtonType="Button" CommandName="DeleteRow" 
                    HeaderText="Delete" ShowHeader="True" Text="Delete"  />
                <asp:BoundField DataField="id" HeaderText="Id" 
                    SortExpression="id" />
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
            ProviderName="<%$ ConnectionStrings:kladionicaConnectionString1.ProviderName %>" 
            SelectCommand="SELECT [id], [league], [event], [date], [selection], [odd], [stake], [profit], [result], [bookmaker] FROM [tips]">
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
