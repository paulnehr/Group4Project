<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyItems.aspx.cs" Inherits="Group4WebApp.MyItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ObjectDataSource ID="dsAllItemsForUser" runat="server"
        TypeName="Group4WebApp"
        SelectMethod="GetAllItemsForUser"/>

    <asp:DropDownList ID="ddlAllItemsForUser" runat="server"
        DataSourceID="dsAllItemsForUser"
        DataTextField="itemName"
        DataValueField="itemNum"
        AppendDataBoundItems="true"
        AutoPostBack="true" 
        OnSelectedIndexChanged="ddlAllItemsForUser_SelectedIndexChanged">
    </asp:DropDownList>


     <asp:GridView 
        ID="gvUserItems" 
        runat="server" 
        EmptyDataText="No Items Match Your Search" AutoGenerateColumns="False"
        >
       
        <Columns>

            <asp:BoundField HeaderText="Item Number" DataField="itemNum" />
            <asp:BoundField HeaderText="Name" DataField="itemName" />
            <asp:BoundField HeaderText="Description" DataField="itemDescription" />
            <asp:BoundField HeaderText="Price" DataField="itemPrice" />
            <asp:BoundField HeaderText="Photo" DataField="itemPhoto" />
            <asp:BoundField HeaderText="Date Posted" DataField="itemDateTime" />
            <asp:BoundField HeaderText="Item Status" DataField="itemStatus" />
            <asp:BoundField HeaderText="User ID" DataField="userID" />

        </Columns>
            
    </asp:GridView>



</asp:Content>