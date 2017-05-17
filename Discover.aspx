<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Discover.aspx.cs" Inherits="Discover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .itemAdd {
            margin: 30px auto;
            padding: 10px;
            width: 150px;
            display: block;
            outline: none;
            border: none;
            color: #3d3d3d;
            background-color: #ddd;
            font-family: 'Russo One', sans-serif;
            border-radius: 5px;
            cursor: pointer;
        }
        .headerElements > span {
            color: #92a8d1;
        }
        main {
            color: #3d3d3d;
            margin-top: 50px;
        }
        #content_shopContainer {
            margin: 50px auto 100px auto;
            width: 1300px;
            padding: 0;
            min-height: 750px;
        }
        .items {
            width: 400px;
            height: 500px;
            display: inline-block;
            border-radius: 5px;
            margin: 50px 10px;
        }
        .itemImg {
            width: 300px;
            height: 400px;
            margin: 0 auto;
            display: block;
        }
        .items > * {
            text-align: center;
            display: block;
            margin: 10px auto;
        }
        .detailContainer > p{
            flex:1;
            margin: 0;  
            display: inline-block;
            font-size: 1.5em;
        }
        .detailContainer {
            display: flex;
        }
        #shopHead {
            display: flex;
        }
        #shopHead > * {
            flex: 1;
            text-align: center;
            font-size: 2em;
            margin: 32px;
        }
        #content_cart > span, #cartDiv > input[type="button"] {
            text-align: center;
            margin: 30px auto;
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
        #cartDiv {
            margin: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div id="shopHead">
        <p>Catalogue</p>
        <span></span>
        <div id="cartDiv"><asp:Button runat="server" ID="cart" UseSubmitBehavior="false" Text="Cart" OnClick="cart_Click"/></div>
    </div>
    <div runat="server" id="shopContainer"></div>
</asp:Content>

