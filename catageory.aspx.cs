using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace middleeast_project.admin
{
    public partial class catageory : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter asd;
        DataTable ta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["breadCrum"] = "Category";
                getCategories();
            }
            lblmsg.Visible = false;


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string actionName = string.Empty, imagePath = string.Empty, fileExtension = string.Empty;
            bool isVaIidToExecute = false;
            int categoryld = Convert.ToInt32(hdnid.Value);
            con = new SqlConnection(connection.getconnectionstrings());
            cmd = new SqlCommand("Category_Crud", con);
            cmd.Parameters.AddWithValue("@Action ", categoryld == 0 ? "INSERT" : "update");
            cmd.Parameters.AddWithValue("@CategoryId", categoryld);
            cmd.Parameters.AddWithValue("@Name", Textname.Text.Trim());
            cmd.Parameters.AddWithValue(" @IsActive ", cbisactive.Checked);
            if (FileUpload1.HasFile)
            {
                if (utlis.IsValidExtension(FileUpload1.FileName))
                {
                    Guid obj = Guid.NewGuid();
                    fileExtension = Path.GetExtension(FileUpload1.FileName);
                    imagePath = "Images/Category/" + obj.ToString() + fileExtension;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/Category/") + obj.ToString() + fileExtension);
                    cmd.Parameters.AddWithValue("@ImageUrl", imagePath);
                    isVaIidToExecute = true;
                }
                else
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "Please select .jpg . jpeg or . png image";
                    lblmsg.CssClass = "alert alert—danger";
                    isVaIidToExecute = false;
                }
            }
            else
            {

                isVaIidToExecute = true;

            }
            if (isVaIidToExecute)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    actionName = categoryld == 0 ? "inserted" : "updated";
                    lblmsg.Visible = true;
                    lblmsg.Text = "category" + actionName + "successfully!";
                    getCategories();
                    Clear();
                }
                catch (Exception ex)
                {
                    lblmsg.Visible = true;
                    lblmsg.Text = "error" + ex.Message;
                    lblmsg.CssClass = "aleart aleart-danger";
                }
                finally
                {
                    con.Close();
                }
            }
        }
        private void getCategories()
        {
            con = new SqlConnection(connection.getconnectionstrings());
            cmd = new SqlCommand("Category_Crud", con);
            cmd.Parameters.AddWithValue("@Action", "SELECT");
            cmd.CommandType = CommandType.StoredProcedure;
            asd = new SqlDataAdapter(cmd);
            ta = new DataTable();
            asd.Fill(ta);
            rcategory.DataSource = ta;
            rcategory.DataBind();


        }

        private void Clear()
        {
            Textname.Text = string.Empty;
            cbisactive.Checked = false;
            hdnid.Value = "0";
            Button1.Text = "Add";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}