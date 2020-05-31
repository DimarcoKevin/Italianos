using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Italianos.Admin
{
    public partial class ViewItems : System.Web.UI.Page
    {
        ReservationDAO _reservationDAO = new ReservationDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
                ItemGrid.DataSource = _reservationDAO.GetItems();
                ItemGrid.DataBind();
                foreach (GridViewRow r in ItemGrid.Rows)
                {
                    string name = r.Cells[1].Text;
                    if(_reservationDAO.GetItemByName(name).Available == false)
                    {
                        CheckBox chBox = r.FindControl("Available") as CheckBox;
                        chBox.Checked = false;
                    }
                }
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow r in ItemGrid.Rows)
            {
                CheckBox chBox = r.FindControl("Available") as CheckBox;
                _reservationDAO.UpdateItem(r.Cells[1].Text, chBox.Checked);
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
    }
}