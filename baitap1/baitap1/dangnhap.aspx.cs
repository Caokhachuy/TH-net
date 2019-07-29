using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace baitap1
{
    public partial class dangnhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsigninnow_Click(object sender, EventArgs e)
        {
            lblInfo.Text = "Your Email: " + txtemail.Text.ToString() + "<br> Login is OK </br>";
        }
    }
}