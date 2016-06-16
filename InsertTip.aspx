<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertTip.aspx.cs" Inherits="InsertTip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Submit1_onclick() {
        alert(2)
        }

// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label">League</asp:Label>
        <asp:TextBox ID="league" runat="server"></asp:TextBox>

        <br />

        <asp:Label ID="Label2" runat="server" Text="Label">Event</asp:Label>
        <asp:TextBox ID="Event" runat="server"></asp:TextBox>

        <br />

        <asp:Label ID="Label3" runat="server" Text="Label">Date</asp:Label>
        <asp:TextBox ID="date" runat="server"></asp:TextBox>

        <br />

        <asp:Label ID="Label4" runat="server" Text="Label">Selection</asp:Label>
        <asp:TextBox ID="section" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="Label5" runat="server" Text="Label">Odd</asp:Label>
        <asp:TextBox ID="odd" runat="server"></asp:TextBox><br />
&nbsp;<asp:Label ID="Label6" runat="server" Text="Label">Stake</asp:Label>
        <asp:TextBox ID="stake" runat="server"></asp:TextBox>&nbsp;&nbsp;
        <br />

        <asp:Label ID="Label7" runat="server" Text="Label">Profit</asp:Label>
        <asp:TextBox ID="profit" runat="server"></asp:TextBox></div>
    <p>

        <asp:Label ID="Label8" runat="server" Text="Label">Result</asp:Label>
        <asp:TextBox ID="result" runat="server"></asp:TextBox></p>
    <p>
        
        <asp:Label ID="Label9" runat="server" Text="Label">Bookmaker</asp:Label>
        <asp:TextBox ID="bookmarker" runat="server"></asp:TextBox></p>

                 <asp:Button ID="InsertTipButton" runat="server" CommandName="InsertTipButton" Text="Insert tip" 
                        ValidationGroup="LoginUserValidationGroup" onclick="InsertTipButton_Click" 
                        onclientclick="LInsertTipButton_click"/>

    </form>
    <p>
        &nbsp;</p>
    <p>


</body>
</html>
