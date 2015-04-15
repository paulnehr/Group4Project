using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Group4WebApp
{
    public partial class SearchItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            DataSet dataset = Group4Project_ClassLibrary.ItemCategory.GetCategories();


            if (!Page.IsPostBack) 
            {

                ddlAllCategories.CausesValidation = true;
                gvItems.Visible = false;

            }
        }


            protected void ddlAllCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            Search.Visible = true;
            gvItems.Visible = false;


            int categoryID = Convert.ToInt32(ddlAllCategories.SelectedValue);

                DataSet dataset = ItemListing.GetAllItemsForCategory(categoryID);
        }
   
    
    protected void Search_Click(object sender, EventArgs e)
        {
            
           
            
            gvItems.Visible = true;

            int categoryID = Convert.ToInt32(ddlAllCategories.SelectedValue);



            
             DataSet dataset = client.GetAllItemsForCategory(categoryID);
            gvCategories.DataSource = dataset.Tables[0];
            gvCategories.DataBind();
        


        }
    
    
    
    }
}