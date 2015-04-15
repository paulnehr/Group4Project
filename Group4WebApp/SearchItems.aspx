<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SearchItems.aspx.cs" Inherits="Group4WebApp.SearchItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <asp:ObjectDataSource ID="dsAllCategories" runat="server"
        TypeName="Group4Project_ClassLibrary"
        SelectMethod="GetAllCategories"/>

    <asp:DropDownList ID="ddlAllCategories" runat="server"
        DataSourceID="dsAllCategories"
        DataTextField="categoryName"
        DataValueField="categoryID"
        AppendDataBoundItems="true"
        AutoPostBack="true" 
        OnSelectedIndexChanged="ddlAllCategories_SelectedIndexChanged">

        <asp:ListItem Value="0">Select a Category (required) </asp:ListItem>

    </asp:DropDownList>

    <asp:RequiredFieldValidator 
        ID="rfvDdlAllCategorie"
        runat="server"
        ControlToValidate="ddlAllCategories"
        InitialValue="0"
        ErrorMessage="Category Needs to be selected"
        EnableClientScript="true"
        Display="Dynamic"
        CssClass="ErrorMessage"
        />
       
 
    
    <asp:Button ID="Search" runat="server"
        Text="Search Courses" OnClick="Search_Click" />
        


    <asp:GridView 
        ID="gvItems" 
        runat="server" 
        EmptyDataText="No Items Match Your Search"
        >
       
        <Columns>

            


            <asp:BoundField HeaderText="Item Name" DataField="itemName" />
            <asp:BoundField HeaderText =" Item Price" DataField ="itemPrice" />
            


        </Columns>
            
    </asp:GridView>



</asp:Content>
