<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SysInfo.aspx.cs" Inherits="WebStock.SysInfo" %>

<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v10.2, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .SysInfoGrid
        {
            border: 1px solid #CCCCCC;
            width: 100%;
        }
        .SysInfoGrid td
        {
            border-right: 1px solid #E9E9E9;
            border-bottom: 1px solid #E9E9E9;
            background: #F5F5F5;
            font-size: 11px;
            padding: 6px 6px 6px 12px;
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" HeaderText="" Height="100%"
        Width="100%">
    </dx:ASPxRoundPanel>
</asp:Content>
