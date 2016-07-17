<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="SendPassword.aspx.cs" Inherits="SendPassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
                    <h2>
                        Password recovery
                    </h2>
                    <p>
                        Password will be sent to you by mail.
                    </p>

                    <div class="accountInfo">
                        <fieldset class="register">
                            <legend>Account Information</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserNameLabel">User Name:</asp:Label>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:Label ID="UsernameMessage" ForeColor="Red" runat="server" AssociatedControlID="UsernameMessage"></asp:Label>
 
                            </p>
                        </fieldset>
                        <p class="submitButton">
                             <asp:Button ID="RegisterButton" runat="server"
                                     Text="Submit" onclick="Button1_Click" />
                        </p>
                    </div>


</asp:Content>