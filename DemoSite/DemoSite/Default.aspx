<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="DemoSite._Default" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="css/style.css">
</head>
<body>
    <form id="form1" runat="server">
    <button onclick="writesquare()">klik</button>
	
  <asp:TextBox ID="txthojde" runat="server"></asp:TextBox>
    <h3 id="printsquare"></h3>
  
    <script
  src="https://code.jquery.com/jquery-3.4.1.js"
  integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU="
  crossorigin="anonymous"></script>
    <script type="text/javascript" src="js/JavaScript.js"></script>
        
        <asp:Button ID="Button1" runat="server" Text="Button" />
        
    </form>
</body>
</html>
