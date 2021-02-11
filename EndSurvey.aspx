<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EndSurvey.aspx.cs" Inherits="EndSurvey" %>

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
			<h2>Thank you for taking the survey...</h2>
			<div class="clear"></div>
		</div>
        <div class="main-sub-w3-agile">
            <p class="header-botm-w3-agile">Before we let you go, would you like to register to our program?</p>
            <form id="form2" runat="server">
                <div class="form-botm-w3-agile">
                    <asp:RadioButtonList ID="rbList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbList_SelectedIndexChnaged"></asp:RadioButtonList>
                </div>
                <div class="form-botm-w3-agile">
                    <asp:TextBox ID="fname" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="fname" runat="server" ErrorMessage="Required!"></asp:RequiredFieldValidator>
                </div>
                <div class="submit-button">
                    <asp:Button ID="btnRegister" visible="false" runat="server" Text="REGISTER & EXIT" />
                    <asp:Button ID="btnExit"  visible="false" runat="server" Text="EXIT" />
                </div>
                <div>
                    <asp:Label ID="answerLbl" visible="false" runat="server" Text="Answer"></asp:Label>
                </div>
                <div>
                    <asp:GridView ID="gridAnswer" runat="server"></asp:GridView>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
