<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListPurchaseGroup.aspx.cs" Inherits="ListPurchaseGroup" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<%@ Register src="PageNav.ascx" tagname="PageNav" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="starter-template">
    <div id="SearchBar">
        Purchase Group<asp:TextBox ID="tbPurchaseGroupCode" runat="server"></asp:TextBox>
        <asp:Button ID="btSearch" runat="server" OnClick="btSearch_Click" Text="Search" CssClass="btn btn-primary"/>
        <asp:Button ID="btNew" runat="server" OnClick="btNew_Click" text="Create New" CssClass="btn btn-primary"/>
        <br /><br />

    </div>
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="table">
    
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ItemStyle-HorizontalAlign="Center"  /> 
		    <asp:BoundField DataField="PurchaseGroupCode" HeaderText="PurchaseGroupCode" SortExpression="PurchaseGroupCode" ItemStyle-HorizontalAlign="Center"  /> 
		    <asp:BoundField DataField="PurchaseGroupCodeName" HeaderText="PurchaseGroupCodeName" SortExpression="PurchaseGroupCodeName" ItemStyle-HorizontalAlign="Center"  /> 
		    <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" ItemStyle-HorizontalAlign="Center"  /> 
		    <asp:BoundField DataField="ERS_Layout" HeaderText="ERS_Layout" SortExpression="ERS_Layout" ItemStyle-HorizontalAlign="Center"  /> 
		    <asp:BoundField DataField="PurchaseRequestor" HeaderText="PurchaseRequestor" SortExpression="PurchaseRequestor" ItemStyle-HorizontalAlign="Center"  />
            <asp:BoundField DataField="FirstReviewer" HeaderText="FirstReviewer" SortExpression="FirstReviewer" ItemStyle-HorizontalAlign="Center"  /> 
		    <asp:BoundField DataField="SecondReviewer" HeaderText="SecondReviewer" SortExpression="SecondReviewer" ItemStyle-HorizontalAlign="Center"  />  
		    <asp:BoundField DataField="STR_PurchaseGroup" HeaderText="STR_PurchaseGroup" SortExpression="STR_PurchaseGroup" ItemStyle-HorizontalAlign="Center"  /> 
		    <asp:BoundField DataField="CopyToACC" HeaderText="CopyToACC" SortExpression="CopyToACC" ItemStyle-HorizontalAlign="Center"  /> 
            <asp:HyperLinkField Text="Edit" Target="_blank" DataNavigateUrlFormatString="EditPurchaseGroup.aspx?id={0}" DataNavigateUrlFields="ID"/>
        </Columns>
    </asp:GridView>
            <uc1:PageNav ID="PageNav1" runat="server" />
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"
                meta:resourceKey="AspNetPager1" CustomInfoHTML="共 %PageCount% 页" CustomInfoTextAlign="Right"
                CustomInfoClass="" CustomInfoStyle="">
                </webdiyer:AspNetPager>
   

        </div>

</asp:Content>

