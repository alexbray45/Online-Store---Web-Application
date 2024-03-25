<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="FASTLANEWebApplication.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <fieldset id="fldsetcontrols" runat="server"  ClientIDMode="Static">
        <legend>REGISTER HERE</legend>
        
        <label for="email">Email Address</label>
        <input type="email" runat="server" id="email" name="email" placeholder="Email Address" oninvalid="setCustomValidity('Please Enter Email Address !!')" />
        <br />
        
        <label for="firstname">Firstname</label>
        <input type="text" runat="server" id="firstname" name="firstname" placeholder="Firstname" oninvalid="setCustomValidity('Please Enter Firstname !!')" />
        <br />

        <label for="surname">Surname</label>
        <input type="text" runat="server" id="surname" name="surname" placeholder="Surname" oninvalid="setCustomValidity('Please Enter Surname !!')" />
        <br />

        <label for="gender">Gender</label>
        <select runat="server" id="gender" name="gender">
            <option value="0">Select...</option>
            <option value="F">Female</option>
            <option value="M">Male</option>
        </select>
        <br />

        <label for="dob">Date Of Birth</label>
        <input type="date" runat="server" id="dob" name="dob" oninvalid="setCustomValidity('Please Select The Date Of Birth !!')" />
        <br />

        <label for="password">Password</label>
        <input type="text" runat="server" id="password" name="password" placeholder="Password" oninvalid="setCustomValidity('Please Enter User Password !!')" />
        <br />

        <label for="cellno">Cell Number</label>
        <input type="text" runat="server" id="cellno" name="cellno" placeholder="Cellphone Number" oninvalid="setCustomValidity('Please Enter User Cell Number !!')" />
        <br />

        <label for="address">Address</label>
        <input type="text" runat="server" id="address" name="address" placeholder="Address" oninvalid="setCustomValidity('Please Enter User Address !!')" />
        <br />

        <label for="groupid">User Group</label>
        <select runat="server" id="groupid" name="groupid">

        </select>
        <br />


        <label id="lblerror" name="lblerror" class="info" runat="server"></label>

        <hr />
        &nbsp;<asp:Button ID="btnregister" runat="server" Text="Register" OnClick="btnregister_Click"  />
&nbsp;<asp:Button ID="btnclear" runat="server" Text="Cancel" OnClick="btnclear_Click"  />


    </fieldset>

    <script>
        function ConfirmDelete() {
            var conf = confirm("Do you want to delete this record ?");
            if (conf == false) {
                return;
            }
        }
    </script>
</asp:Content>
