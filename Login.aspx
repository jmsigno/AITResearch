<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-header-agileinfo">
        <h2>ADMIN LOGIN</h2>
        <div class="clear"></div>
    </div>
    <div class="main-sub-w3-agile">
        <p class="header-botm-w3-agile">Please enter your username and password to login.</p>
        <form id="form2" runat="server">
            <div class="form-botm-w3-agile">
                <div>
                    <p>Username</p>
                    <asp:TextBox ID="username" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username" ErrorMessage="Username required!"></asp:RequiredFieldValidator>
                </div>
                <div>
                    <p>Password</p>
                    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="password" ErrorMessage="Password required!"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="submit-button">
                <asp:Button ID="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" />
            </div>
        </form>
    </div>
</asp:Content>
