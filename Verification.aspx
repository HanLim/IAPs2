<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Verification.aspx.cs" Inherits="Verification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        main {
            color: #3d3d3d;
            margin-top: 50px;
            height: 750px;
            background-color:#999999;
        }

        #accHandler {
            display: flex;
            height: 100%;
        }
        #accHandler > p {
            margin: auto auto;
            font-size: 3em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div id="accHandler">
        <p runat="server" id="msg"></p>
    </div>
</asp:Content>

