<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        #intro {
            padding: 30px;
            margin-top: 600px;
            
            /*background-color: #92a8d1;*/
            background-image: url("../img/bg/intro-banner.jpg");
            height: 250px;
        }
        #homeContent {
            font-family: 'Righteous', cursive;
        }
        #intro > * {
            text-align: center;
        }
        #introName {
            margin: 10px;
            font-size: 5em;
        }
        #introDesc {
            margin: 15px;
            font-family: 'Ceviche One', cursive;
            font-size: 2.5em;
        }
        #banner {
            position: fixed;
            top: 0;
            width: 100%;
            height: 100%;
             max-width: none;
            z-index: -1;
        }
        #homeContent {
            color: #7a7a7a;
            padding-top: 30px;
            background-color: white;
            height: 500px;
            text-align: center;
        }
        #homeContent > p {
            font-size: 4em;
            margin-top: 40px;
        }
        #reasons {
            display: flex;
        }
        #reasons > div {
            flex: 1;
        }
        #reasons > div > img {
            width: 100px;
            height: 120px;
        }
        #reasons > div > p {
            font-size: 2em;
        }
        #shopLink {
            text-align: center;
            width: 100px;
            margin: 0 auto;
            padding: 5px;
            background-color: rgba(146, 168, 255, 1);
            border-radius: 20px;
        }
        #shopLink:hover {
            border: 1px solid azure;
            
        }
    </style>
</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
    <img id="banner" src="img/bg/homepage-banner1.png" />
    <div id="intro">
        <p id="introName">
            HL Phone Store
        </p>
        <p id="introDesc">
            Best Online Smart Phone Seller in Town
        </p>
        <p id="shopLink">
            <a href="#">Shop Now</a>
        </p>
    </div>
    <div id="homeContent">
        <p>Why Us</p>
        <div id="reasons">
            <div>
                <img src="../img/icon/price-icon.png" />
                <p>Cheaper Deals</p>
            </div>
            <div>
                <img src="../img/icon/warranty-icon.png" />
                <p>Longer Warranty</p>
            </div>
            <div>
                <img src="../img/icon/customerservice-icon.png" />
                <p>24-hr Support</p>
            </div>
        </div>
    </div>
</asp:Content>

