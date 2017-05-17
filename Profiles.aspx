<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profiles.aspx.cs" Inherits="Profiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        main {
            padding-top: 150px;
            color: #3d3d3d;
            margin-top: 50px;
            height: 560px;
            /*background-color: darkcyan;*/
        }
         a#account{
             color:#92a8d1;
         }
        #accHandler {            
            margin: auto;
            width: 500px;
            border-radius: 5px;
            border: 1px solid darkcyan;
        }
        #accHandler > p {
            text-align: center;
            display: block;
            font-size: 1.5em;
        }
        input {
            margin: 30px auto;
            padding: 10px;
            width: 300px;
            display: block;
            outline: none;
            border: none;
            color: #3d3d3d;
            background-color: #ddd;
            font-family: 'Russo One', sans-serif;
            border-radius: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div id="accHandler">
        <p id="username" runat="server"></p>
        <asp:TextBox ID="oldpw" runat="server" placeholder="Old Password" TextMode="Password" ></asp:TextBox>
        <asp:TextBox ID="pw" runat="server" placeholder="New Password" TextMode="Password" ></asp:TextBox>
        <asp:TextBox ID="pw2" runat="server" placeholder="ConfirmPassword" TextMode="Password" ></asp:TextBox>
        <asp:Button ID="Submit" onclick="changepw" runat="server" Text="Change Password"></asp:Button>
        <p id="err" runat="server"></p>
        <asp:Button ID="logout" onclick="userLogout" runat="server" Text="Logout"></asp:Button>
    </div>
</asp:Content>