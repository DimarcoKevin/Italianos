using Italianos.Logic;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Italianos
{
    public partial class Login : System.Web.UI.Page
    {
        UserDao _userDao;
        protected void Page_Load(object sender, EventArgs e)
        {
            _userDao = new UserDao();
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            
            if (_userDao.IsAuthentic(TxtEmail.Text, TxtPassword.Text))
            {
                Logic.User usr = _userDao.Login(TxtEmail.Text, TxtPassword.Text);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, usr.UserId.ToString(),
                                                    DateTime.Now, DateTime.Now.AddMinutes(10), false, 
                                                    usr.Role == Role.USER ? "user" : "admin");
                string strTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, strTicket));
                if(FormsAuthentication.GetRedirectUrl(usr.UserId.ToString(), false) == null)
                {
                    if(usr.Role == Role.USER) { Response.Redirect("~/Users/Dashboard.aspx");  }
                    else { Response.Redirect("~/Admin/Dashboard.aspx"); }
                        
                }
                Response.Redirect(FormsAuthentication.GetRedirectUrl(usr.UserId.ToString(), false));
            }
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
        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }
    }
}