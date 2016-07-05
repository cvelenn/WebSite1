<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RegisterUser.aspx.cs" Inherits="RegisterUser" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
                    <h2>
                        Create a New Account
                    </h2>
                    <p>
                        Use the form below to create a new account.
                    </p>

                    <div class="accountInfo">
                        <fieldset class="register">
                            <legend>Account Information</legend>
                            <p>
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="Password">Full Name:</asp:Label>
                                <asp:TextBox ID="FullName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:Label ID="FullNameMessage" ForeColor="Red" runat="server" AssociatedControlID="Password"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="Password">User Name:</asp:Label>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:Label ID="UsernameMessage" ForeColor="Red" runat="server" AssociatedControlID="Password"></asp:Label>
 
                            </p>
                            <p>
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:Label ID="EmailMessage" ForeColor="Red" runat="server" AssociatedControlID="Password"></asp:Label>

                            </p>
                            <p>
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:Label ID="PasswordMessage" ForeColor="Red" runat="server" AssociatedControlID="Password"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:Label ID="ConfirmPasswordMessage" ForeColor="Red" runat="server" AssociatedControlID="Password"></asp:Label>
                            </p>
                            <p>
                                <asp:CheckBox ID="Conditions" runat="server"  AssociatedControlID="ConfirmPassword"/>
                                <asp:HyperLink ID="RegisterHyperLink" href="TermsAndConditions.aspx" runat="server" EnableViewState="false">Accept terms and conditions</asp:HyperLink>                     
                                <asp:Label ID="ConditionsMessage" ForeColor="Red" runat="server" AssociatedControlID="Password"></asp:Label>
                            </p>
                        </fieldset>
                        <p class="submitButton">
                             <asp:Button ID="RegisterButton" runat="server"
                                     Text="Register" onclick="Button1_Click" />
                        </p>
                    </div>


</asp:Content>