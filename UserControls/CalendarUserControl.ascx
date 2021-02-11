<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CalendarUserControl.ascx.cs" Inherits="UserControls_CalendarUserControl" %>
<asp:Label ID="Label1" runat="server" Text="Birthday"></asp:Label>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<asp:ImageButton ID="ImageButton1" runat="server" src="../img/calendarIcon.png" OnClick="ImageButton1_Click" />
<asp:Calendar ID="Calendar1" runat="server" Visible="false" OnSelectionChanged="Selection_Change"></asp:Calendar>
<asp:TextBox ID="dateBox" runat="server"></asp:TextBox>
<asp:Button ID="Button1" runat="server" Text="Go" />