<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-header-agileinfo">
        <h2>ADMIN DASHBOARD</h2>
        <div class="clear"></div>
    </div>
    <div class="main-sub-w3-agile">
        <p class="header-botm-w3-agile">SEARCH</p>
        <form id="form2" runat="server">
            <div class="form-botm-w3-agile">
                <div>
                    <p>Enter keyword to search</p>
                    <asp:TextBox ID="searchbox" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="submit-button">
                <asp:Button ID="btnSearch" runat="server" Text="LOGIN" OnClick="btnSearch_Click" />
            </div>
        </form>
    </div>
</asp:Content>

