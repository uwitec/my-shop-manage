<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommonUserControl.ascx.cs"
    Inherits="WebStock.CommonUserControl" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2.Export, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.2, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2, Version=10.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>
<div style="width: 100%">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
            </asp:ScriptManager>
            <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%">
                <PanelCollection>
                    <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                        <table width="100%">
                            <tr>
                                <td width="60px">
                                    &nbsp;
                                </td>
                                <td width="70px">
                                    <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" Text="简单查询" Width="100%">
                                    </dx:ASPxCheckBox>
                                </td>
                                <td width="50px">
                                </td>
                                <td width="50px">
                                    <dx:ASPxCheckBox ID="ASPxCheckBox2" runat="server" Width="100%" Text="分组">
                                    </dx:ASPxCheckBox>
                                </td>
                                <td width="50px">
                                </td>
                                <td width="100px">
                                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="导出到EXCEL">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxRoundPanel>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" Width="100%">
            </dx:ASPxGridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server">
    </dx:ASPxGridViewExporter>
</div>
