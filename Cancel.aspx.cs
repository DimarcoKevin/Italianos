using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Italianos
{
    public partial class Cancel : System.Web.UI.Page
    {
        ReservationDAO _reservationDAO;
        protected void Page_Load(object sender, EventArgs e)
        {
            _reservationDAO = new ReservationDAO();
            if (!IsPostBack)
            {
                resInfo.Visible = false;
            }
        }

        protected void BtnFindReservation_Click(object sender, EventArgs e)
        {
            Reservation r = _reservationDAO.GetReservationByReservationId(TxtReservationId.Text);
            if(r == null)
            {
                ErrResId.Text = "Reservation Does not Exist!";
            }
            else
            {
                resInfo.Visible = true;
                hostInfo.InnerText = $"Host: {r.Host.FirstName}  {r.Host.LastName}";
                timeInfo.InnerText = $"Reservation Date: {r.ReservationDate.Date} {r.ReservationDate.TimeOfDay.Hours - 12}PM";
                tableNum.InnerText = $"Table Number: {r.TableNumber}";
                appetizer.InnerText = $"Appetizer: {r.Appetizer.Name}";
                main.InnerText = $"Main: {r.Main.Name}";
                dessert.InnerText = $"Dessert: {r.Dessert.Name}";
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            _reservationDAO.DisableReservation(TxtReservationId.Text);
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