<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        main {
            color: #3d3d3d;
            height: 750px;
            margin-top: 50px;
        }
        main > * {
            margin: auto;
            display: block;
        }
        #cartHeader {
            text-align:center;
            margin-top: 100px;
            font-size: 4em;
        }
        table {
            width: 800px;
            margin: 100px auto;
            text-align:center;
            table-layout: fixed;
        }
        td {
            width: 50%;
        }
        input[type="button"] {
            text-align: center;
            padding: 10px;
            width: 150px;
            display: inline;
            outline: none;
            border: none;
            color: #3d3d3d;
            background-color: #ddd;
            font-family: 'Russo One', sans-serif;
            border-radius: 5px;
        }
        #payment > p, #payment > a {
            display: block;
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
            width: 150px;
            margin: 15px auto;
            background-color: #ccc;
        }
        #content_downloadLink {
            display: none;
        }
        .err {
            color: #ff5050;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <p id="cartHeader">Items in cart</p>
    <div id="cartConten">
        <div runat="server" id="items">
            <table runat="server" id="table"></table>
        </div>
        
        <div id="payment">
            <asp:TextBox ID="cardNum" runat="server" placeholder="Card Number"></asp:TextBox>
            <asp:TextBox ID="secCode" runat="server" placeholder="Security Code"></asp:TextBox>
            <asp:TextBox ID="address" runat="server" placeholder="Mailing Address"></asp:TextBox>
            <asp:Button ID="pay" runat="server" Text="Confirm Payment" onclick="Pay"/>
            <p id="err" class="err" runat="server"></p>
            <a id="downloadLink" runat="server" download="true">Download Recept here</a>
        </div>
    </div>
    
</asp:Content>