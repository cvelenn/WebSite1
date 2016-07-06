<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="UpdateUserStatus.aspx.cs" Inherits="UpdateUserStatus" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>



<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.date-time').datetimepicker();
        });
</script>
        <div class="accountInfo">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="UsernameTB" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Search" runat="server" Text="Search" onclick="Search_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Register"></asp:Label>
                        <asp:CheckBox ID="RegisterCX"  runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Email:"></asp:Label>
                        <asp:Label ID="EmailLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Previouse Date:"></asp:Label>
                        <asp:Label ID="DateLabel" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Set Date:"></asp:Label>
                        <asp:TextBox ID="Date" runat="server" class="date-time" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="UpdateUser" runat="server" Text="Update User" 
                            onclick="UpdateUser_Click" />
                    </td>
                </tr>
            </table>
        </div>


</asp:Content>