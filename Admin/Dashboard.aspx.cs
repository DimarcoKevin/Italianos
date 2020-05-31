using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Italianos.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        ReservationDAO _reservationDAO;
        UserDao _userDao;
        protected void Page_Load(object sender, EventArgs e)
        {
            _userDao = new UserDao();
            _reservationDAO = new ReservationDAO();
            if (!IsPostBack)
            {
                ReservationGrid.DataSource = _reservationDAO.ReadAll(Status.Reserved);
                ReservationGrid.DataBind();
                Name.Text = _userDao.GetUserById(int.Parse(Context.User.Identity.Name)).FirstName;
            }
        }

        protected void BtnCreateItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/AddMenuItem.Aspx");
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