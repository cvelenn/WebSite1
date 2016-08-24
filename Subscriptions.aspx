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
        You can choose one of the following membership options:
        <ul>
            <li>1 month: 59 euro </li>
            <li>3 months: 159 euro (save 10%) </li>
            <li>6 months: 279 euro (save 21%) </li>
            <li>12 months: 499 euro (save 30%)</li>
        </ul>
<%--        <div>
            <form action="https://www.sandbox.paypal.com/webapps/adaptivepayment/flow/pay&paykey=AP-9HY848657G6071234" target="PPDGFrame"
            class="standard">
            <label for="buy">
                Use PayPal:</label>
            <input type="image" id="submitBtn" value="Pay with PayPal" src="https://www.paypalobjects.com/en_US/i/btn/btn_paynowCC_LG.gif">
            <input id="type" type="hidden" name="expType" value="light">
            <input id="paykey" type="hidden" name="paykey" value="AP-9HY848657G6071234">
            </form>
            <script type="text/javascript" charset="utf-8">
                var embeddedPPFlow = new PAYPAL.apps.DGFlow({ trigger: 'submitBtn' });
            </script>
        </div>--%>
        <br>
        <div>
            If you prefer alternative payment methods (Skrill or Neteller) please <a class="level1" href="ContactUs.aspx">contact us</a>
        </div>
    </div>
</asp:Content>
