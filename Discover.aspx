<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Discover.aspx.cs" Inherits="Discover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .headerElements > span {
            color: #92a8d1;
        }
        main {
            color: #3d3d3d;
            margin-top: 50px;
        }
        #content_shopContainer {
            margin-top: 50px;
            min-height: 750px;
            padding: 100px 100px 0 100px;
        }
        .items {
            width: 300px;
            height: 400px;
            background-color: brown;
            display: inline-block;
            border-radius: 5px;
            margin: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div runat="server" id="shopContainer">
        
    </div>
</asp:Content>

