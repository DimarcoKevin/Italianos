using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Italianos
{
    public partial class Verify : System.Web.UI.Page
    {
        UserDao _userDao = new UserDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                _userDao.VerifyEmail(Request.QueryString["id"]);
            }
                Response.Redirect("~/Home.aspx");
        }
        protected void BtnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Menu.aspx");
        }

        protected void BtnAccount_Click(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                if (Context.User.IsInRole("user"))
                {
                    Response.Redirect("~/Users/Dashboard.aspx");
                }
                else if (Context.User.IsInRole("admin"))
                {
                    Response.Redirect("~/Admin/Dashboard.aspx");
                }
            }
            Response.Redirect("~/Login.aspx");
        }

        protected void BtnReservations_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Users/Dashboard.aspx");
        }
    }
}