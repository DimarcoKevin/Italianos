using Italianos.Logic;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Italianos
{
    public partial class Menu : System.Web.UI.Page
    {
        ReservationDAO _reservationDao;
        protected void Page_Load(object sender, EventArgs e)
        {
            _reservationDao = new ReservationDAO();
            for(int i = 0; i < 3; i++)
            {
                foreach (String itemName in _reservationDao.GetAvailableItems((Course) i))
                {
                    Item item = _reservationDao.GetItemByName(itemName);
                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes.Add("class", "itemDiv");
                    HtmlGenericControl name = new HtmlGenericControl("p");
                    name.Attributes.Add("class", "item");
                    name.InnerText = item.Name;
                    HtmlGenericControl category = new HtmlGenericControl("p");
                    category.Attributes.Add("class", "category");
                    category.InnerText = item.Category.ToString();
                    HtmlGenericControl desc = new HtmlGenericControl("p");
                    desc.Attributes.Add("class", "desc");
                    desc.InnerText = item.Description;
                    div.Controls.Add(name);
                    div.Controls.Add(category);
                    div.Controls.Add(desc);
                    switch (i)
                    {
                        case 0:
                            appCont.Controls.Add(div);
                            break;
                        case 1:
                            mainCont.Controls.Add(div);
                            break;
                        case 2:
                            dessCont.Controls.Add(div);
                            break;
                        default:
                            break;
                    }
                }
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
                } else if (Context.User.IsInRole("admin"))
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