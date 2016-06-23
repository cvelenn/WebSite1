<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="EditTip.aspx.cs" Inherits="EditTip" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<script type="text/javascript">
    $(document).ready(function () {
        $(document).ready(function () {
            $('.date-time').datetimepicker();
        });
    });
</script>

    <form id="form1" >
    <div>
    <table>
        <tr>
            <td>
            <asp:Label ID="Label1" runat="server" Text="Label">League</asp:Label>
            </td>
            <td>
            <asp:TextBox ID="league" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            <asp:Label ID="Label2" runat="server" Text="Label">Event</asp:Label>
            </td>
            <td>
            <asp:TextBox ID="Event" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            <asp:Label ID="Label3" runat="server" Text="Label">Date</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Date" runat="server" class="date-time" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            <asp:Label ID="Label4" runat="server" Text="Label">Selection</asp:Label>
            </td>
            <td>
            <asp:TextBox ID="section" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            <asp:Label ID="Label5" runat="server" Text="Label">Odd</asp:Label>
            </td>
            <td>
            <asp:TextBox ID="odd" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            <asp:Label ID="Label6" runat="server" Text="Label">Stake</asp:Label>
            </td>
            <td>
            <asp:TextBox ID="stake" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
             <asp:Label ID="Label7" runat="server" Text="Label">Profit</asp:Label>
            </td>
            <td>
            <asp:TextBox ID="profit" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            <asp:Label ID="Label8" runat="server" Text="Label">Result</asp:Label>
            </td>
            <td>
            <asp:TextBox ID="result" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            <asp:Label ID="Label9" runat="server" Text="Label">Bookmaker</asp:Label>
            </td>
            <td>
            <asp:TextBox ID="bookmarker" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
        

       
        </div>

                           <asp:Button ID="UpdateTipButton" runat="server" CommandName="UpdateTipButton" Text="Update tip" 
                        ValidationGroup="LoginUserValidationGroup" onclick="UpdateTipButton_Click" 
                        onclientclick="LUpdateTipButton_click"/>

    </form>
</asp:Content>