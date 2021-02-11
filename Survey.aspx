<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Survey.aspx.cs" Inherits="Survey" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body>
    <div class="main-w3-header">
        <div class="navbar-header">
            <a href="index.html"><img class="logo" src="img/ait.png" alt="ait logo" /></a>
        </div>
    </div>
    <div class="main-w3-agile">
        <div class="form-header-agileinfo">
			<h2>Customer Service Improvement Survey</h2>
			<div class="clear"></div>
		</div>
        <div class="main-sub-w3-agile">
            <p class="header-botm-w3-agile"><asp:Label ID="questionLbl" runat="server" Text="Question"></asp:Label></p>
            <form id="form1" runat="server">
                <div class="form-botm-w3-agile">
                    <asp:PlaceHolder ID="optHolder" runat="server"></asp:PlaceHolder>
                </div>
                <div class="submit-button">
                    <asp:Button ID="btnNext"  runat="server" Text="NEXT" OnClick="btnNext_Click" />
                    <asp:Button ID="btnSkip" runat="server" Text="SKIP" OnClick="btnSkip_Click" />
                </div>
            </form>
        </div>
    </div>
</body>
</html>
