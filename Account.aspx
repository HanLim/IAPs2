<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        main {
            color: #3d3d3d;
            margin-top: 50px;
            height: 750px;
            background-color:#999999;
        }

        /*main:before {
            background-image: url("../img/bg/header-banner.jpg");
            content: "";
            position: absolute;
            left: 0;
            right: 0;
            z-index: -2;
            display: block;
            background-size:cover;
            width: 100%;
            height: 100%;
            filter: blur(10px);
        }*/
        #accHandler {
            display: flex;
            height: 100%;
        }
        #signIn, #signUp {
            flex: 1;
            margin: auto;
            width: 320px;
            height: 350px;
            
        }
        #signUp {
            border-left: #ddd solid 1px;
        }
        #signIn > p, #signUp > p {
            text-align:center;
            color: #4465a2;
        }
        #signIn > p:nth-of-type(1), #signUp > p:nth-of-type(1) {
            margin-top: 10px;
            font-size: 3em;
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
        #signUp > input {
            margin: 15px auto;
        }
        input[type="submit"] {
            width: 150px;
        }
        input:focus{
            background-color: #ccc;
        }
        .err {
            color: #ff5050;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div id="accHandler">
        <div id="signIn">
            <p>Sign In</p>
            <asp:TextBox ID="loginUserName" runat="server" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="loginPWInput" runat="server" placeholder="Password" TextMode="Password" ></asp:TextBox>
            <asp:Button ID="login" runat="server" Text="Login" onclick="ValidateUser"/>
            <p id="err1" class="err" runat="server"></p>
        </div>
        <div id="signUp">
            <p>Sign Up</p>
            <asp:TextBox ID="signupEmailInput" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
            <asp:TextBox ID="signupUserName" runat="server" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="signupPWInput" runat="server" placeholder="Password" TextMode="Password" ></asp:TextBox>
            <asp:TextBox ID="signupPWInput2" runat="server" placeholder="ConfirmPassword" TextMode="Password" ></asp:TextBox>
            <asp:Button ID="signup" runat="server" Text="Signup" onclick="RegisterUser"/>
            <p id="err2" class="err" runat="server"></p>
        </div>
    </div>
</asp:Content>
