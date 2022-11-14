using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace middleeast_project.user
{
    public partial class user : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.Url.AbsoluteUri.ToString().Contains("default.aspx"))
            {
                form1.Attributes.Add("class", "sub_page");
            }
            else
            {
                form1.Attributes.Remove("class");
                Control webusercontrol1 = (Control)Page.LoadControl("webUserControl1.ascx");
                Panel1.Controls.Add(webusercontrol1);

            }

        }
    }
}