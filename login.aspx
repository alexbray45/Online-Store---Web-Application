<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FASTLANEWebApplication.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <br />
    <fieldset id="fldsetcontrols" runat="server"  ClientIDMode="Static">
        <legend>LOGIN HERE</legend>
        <label for="email">Email Address</label>
        <input type="email" runat="server" id="email" name="email" placeholder="Email Address" oninvalid="setCustomValidity('Please Enter Email Address !!')" />
        <br />
        
        <label for="password">Password</label>
        <input type="text" runat="server" id="password" name="password" placeholder="Password" oninvalid="setCustomValidity('Please Enter User Password !!')" />
        <br/>
        <label id="lblerror" name="lblerror" class="info" runat="server"></label>
        <br />
        <asp:Button ID="btnlogin" runat="server" Text="Log in" OnClick="btnlogin_Click"  />

        <asp:Button ID="createaccount" runat="server" Text="Create Account" OnClick="createaccount_Click" />

        

        </fieldset>
</asp:Content>
