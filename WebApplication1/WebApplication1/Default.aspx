<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body runat="server">
    <form runat="server">
    <asp:TextBox ID="boxbredde" runat="server"></asp:TextBox>
    <asp:TextBox ID="boxhojde" runat="server"></asp:TextBox>
        <asp:RadioButtonList ID="radiocolor" runat="server">
        <asp:ListItem Text="Blå" Value="Blå"></asp:ListItem>
            <asp:ListItem Text="Grøn" Value="Grøn"></asp:ListItem>
            </asp:RadioButtonList>
        </form>
    <button onclick="squareinfo()">klik</button><br />
    <canvas id="myCanvas" width="500" height="500" ></canvas>
    <h3 id="printsquare"></h3>
    <script
  src="https://code.jquery.com/jquery-3.4.1.js"
  integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU="
  crossorigin="anonymous"></script>
    <script type="text/javascript" src="js/JavaScript.js"></script>
</body>
</html>
