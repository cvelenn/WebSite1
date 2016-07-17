<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
                    <h2>
                        Contact Us
                    </h2>
                    <p>
                        Send us an email with question.
                    </p>

                    <div class="accountInfo">
                        <form id="form1" >
                        <fieldset class="register">
                            <legend>Mail</legend>
                            <p>
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserNameLabel">Your Email:</asp:Label>
                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:Label ID="UsernameMessage" ForeColor="Red" runat="server" AssociatedControlID="UsernameMessage"></asp:Label>
                                
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="UserNameLabel">Question:</asp:Label>
                                <textarea id="TextArea1" cols="43" name="S1" rows="10"></textarea></p>
                        </fieldset>
                        <p class="submitButton">
                             <asp:Button ID="RegisterButton" runat="server"
                                     Text="Submit" onclick="Button1_Click" />
                        </p>
                        </form>
                    </div>


</asp:Content>