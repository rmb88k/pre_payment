<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddPurchaseGroup.aspx.cs" Inherits="AddPurchaseGroupCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="starter-template" style="margin-top:50px;">

        <!--******************************增加页面代码********************************-->

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	
	<tr>
	<td height="25" width="30%" align="right">
		PurchaseGroupCode(*)
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPurchaseGroupCode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PurchaseGroupCodeName
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPurchaseGroupCodeName" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		Category
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCategory" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		ERS_Layout
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtERS_Layout" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		PurchaseRequestor
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPurchaseRequestor" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		STR_PurchaseGroup
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSTR_PurchaseGroup" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FirstReviewer(*)
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFirstReviewer" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SecondReviewer(*)
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSecondReviewer" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		FirstApprover
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtFirstApprover" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		SecondApprover
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtSecondApprover" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CopyToACC
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCopyToACC" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
    

</table>
        <asp:Button ID="btInsert" runat="server" Text="Add" OnClick="btInsert_Click" />
    </div>
</asp:Content>

