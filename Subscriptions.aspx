<%@ Page Title="Subscriptions" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Subscriptions.aspx.cs" Inherits="Subscriptions" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script src="https://www.paypalobjects.com/js/external/dg.js" type="text/javascript"></script>
    <h2>
        Subscriptions
    </h2>
    <div class="accountInfo">
        You can choose one of the following membership options:<br><br>
        
             <asp:RadioButton ID="RadioButton1" runat="server" Checked GroupName="option" />1 month: 59 euro <br>
             <asp:RadioButton ID="RadioButton2" runat="server"  GroupName="option"/>3 months: 159 euro (save 10%)<br>
             <asp:RadioButton ID="RadioButton3" runat="server"  GroupName="option"/>6 months: 279 euro (save 21%)<br>
             <asp:RadioButton ID="RadioButton4" runat="server"  GroupName="option"/>12 months: 499 euro (save 30%)<br><br>
        
        <div>
            <asp:ImageButton ID="ImageButton1" runat="server" 
                ImageUrl="https://www.paypalobjects.com/en_US/i/btn/btn_paynowCC_LG.gif" 
                onclick="ImageButton1_Click" /> 
        </div>
        <br>
        <div>
            If you prefer alternative payment methods (Skrill or Neteller) please <a class="level1" href="ContactUs.aspx">contact us</a>
        </div>
    </div>
</asp:Content>
