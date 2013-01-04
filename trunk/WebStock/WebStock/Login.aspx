<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebStock.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
<HEAD>
<TITLE>人员定位管理系统</TITLE>
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=gb2312">
</HEAD>
<BODY BGCOLOR=#FFFFFF LEFTMARGIN=0 TOPMARGIN=0 MARGINWIDTH=0 MARGINHEIGHT=0 style="background-color:#016AA9;" >
   <form id="form1" runat="server" defaultbutton="Button1">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" valign="middle">
<TABLE WIDTH=1003 BORDER=0 CELLPADDING=0 CELLSPACING=0>
	<TR>
		<TD COLSPAN=9>
			<IMG SRC="images/login_01.gif" WIDTH=1003 HEIGHT=189 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=189 ALT=""></TD>
	</TR>
	<TR>
		<TD ROWSPAN=9>
			<IMG SRC="images/login_02.gif" WIDTH=291 HEIGHT=424 ALT=""></TD>
		<TD COLSPAN=7>
			<IMG SRC="images/login_03.gif" WIDTH=421 HEIGHT=29 ALT=""></TD>
		<TD ROWSPAN=9>
			<IMG SRC="images/login_04.gif" WIDTH=291 HEIGHT=424 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=29 ALT=""></TD>
	</TR>
	<TR>
		<TD ROWSPAN=7>
			<IMG SRC="images/login_05.gif" WIDTH=14 HEIGHT=173 ALT=""></TD>
		<TD COLSPAN=5>
			<IMG SRC="images/login_06.gif" WIDTH=394 HEIGHT=49 ALT=""></TD>
		<TD ROWSPAN=7>
			<IMG SRC="images/login_07.gif" WIDTH=13 HEIGHT=173 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=49 ALT=""></TD>
	</TR>
	<TR>
		<TD COLSPAN=5>
			<IMG SRC="images/login_08.gif" WIDTH=394 HEIGHT=25 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=25 ALT=""></TD>
	</TR>
	<TR>
		<TD ROWSPAN=5>
			<IMG SRC="images/login_09.gif" WIDTH=109 HEIGHT=99 ALT=""></TD>
		<TD style="background:url(images/userbg.gif) repeat-x;  WIDTH:147; HEIGHT:22">
         <span style="float:left; display:inline; font-size:12px; color:White; line-height:18px;">用户：</span><div style="float:left">
         <asp:TextBox ID="UserNameTextBox" runat="server"  Width="100px" Height="14px"></asp:TextBox></div>
			</TD>
		<TD COLSPAN=3 ROWSPAN=2>
			<IMG SRC="images/login_11.gif" WIDTH=138 HEIGHT=24 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=22 ALT=""></TD>
	</TR>
	<TR>
		<TD ROWSPAN=3 style="background:url(images/passwordbg.gif) repeat-x; WIDTH:147; HEIGHT:27">
          <span style="float:left; display:inline; font-size:12px; color:White; line-height:18px;">密码：</span><div style="float:left;">
              <asp:TextBox TextMode="Password" ID="PassWordTextBox" runat="server" Width="100px" Height="14px"></asp:TextBox></div>
		</TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=2 ALT=""></TD>
	</TR>
	<TR>
		<TD ROWSPAN=3>
			<IMG SRC="images/login_13.gif" WIDTH=5 HEIGHT=75 ALT=""></TD>
		<TD>
			<a href="#" onclick="loginAction();"><IMG SRC="images/login_14.gif" WIDTH=48 HEIGHT=21 ALT="" border="0"></a></TD>
		<TD ROWSPAN=3>
			<IMG SRC="images/login_15.gif" WIDTH=85 HEIGHT=75 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=21 ALT=""></TD>
	</TR>
	<TR>
		<TD ROWSPAN=2>
			<IMG SRC="images/login_16.gif" WIDTH=48 HEIGHT=54 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=4 ALT=""></TD>
	</TR>
	<TR>
		<TD>
			<IMG SRC="images/login_17.gif" WIDTH=147 HEIGHT=50 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=50 ALT=""></TD>
	</TR>
	<TR>
		<TD COLSPAN=7>
			<IMG SRC="images/login_18.gif" WIDTH=421 HEIGHT=222 ALT=""></TD>
		<TD>
			<IMG SRC="images/spacer.gif" WIDTH=1 HEIGHT=222 ALT=""></TD>
	</TR>
</TABLE>
</td></tr></TABLE>
<div style="display:none;">
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
   </div>
   <script type="text/javascript">
       function loginAction() {
           document.getElementById('<%=Button1.ClientID %>').click();
       }
   </script>
<!-- End ImageReady Slices -->
</form>
</BODY>
</HTML>
