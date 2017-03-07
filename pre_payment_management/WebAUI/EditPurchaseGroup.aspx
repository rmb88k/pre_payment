<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditPurchaseGroup.aspx.cs" Inherits="EditPurchaseGroupCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="starter-template" style="margin-top:50px;">

        <!--******************************修改页面代码********************************-->

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtID" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
	</td></tr>
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
		CopyToACC
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCopyToACC" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CreateBy
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtCreateBy" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		CreateDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtCreateDate" runat="server" Width="200px"  ReadOnly="true"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EditBy
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEditBy" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		EditDate
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtEditDate" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
	</td></tr>

</table>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </div>

</asp:Content>

