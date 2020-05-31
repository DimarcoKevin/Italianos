using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Italianos.User
{
    public partial class Dashboard : System.Web.UI.Page
    {
        ReservationDAO _reservationDao;
        UserDao _userDao;
        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthenticationTicket cookie = FormsAuthentication.Decrypt(HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value);
            _reservationDao = new ReservationDAO();
            ReservationGrid.DataSource = _reservationDao.GetReservationsByUserId(int.Parse(cookie.Name));
            ReservationGrid.DataBind();
            _userDao = new UserDao();
            foreach(GridViewRow r in ReservationGrid.Rows)
            {
                if (_reservationDao.GetReservationByReservationId(r.Cells[1].Text).Status != Status.Reserved)
                    r.Cells[0].Controls.Clear();
                Name.Text = _userDao.GetUserById(int.Parse(Context.User.Identity.Name)).FirstName;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            _reservationDao.DisableReservation(gvr.Cells[1].Text);
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