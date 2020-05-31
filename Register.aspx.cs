using Logic;
using System;
using System.Net.Mail;
using System.Web;

namespace Italianos
{
    public partial class Register : System.Web.UI.Page
    {
        UserDao _userDao;
        protected void Page_Load(object sender, EventArgs e)
        {
            _userDao = new UserDao();
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            bool canRegister = true;

            if (_userDao.EmailExists(TxtEmail.Text))
            {
                canRegister = false;
                ErrEmail.Text = "Email exists";
            } else if (String.IsNullOrEmpty(TxtEmail.Text))
            {
                canRegister = false;
                ErrEmail.Text = "Email cannot be empty";
            }

            if(TxtPassword.Text.Length < 10)
            {
                canRegister = false;
                ErrPassword.Text = "Password cannot be less than 10 characters";
            }
            else if(TxtPassword.Text.Length > 15)
            {
                canRegister = false;
                ErrPassword.Text = "Password cannot be greater than 15 characters";
            }

            if (String.IsNullOrEmpty(TxtFirstName.Text))
            {
                canRegister = false;
                ErrFName.Text = "First name cannot be empty";
            }

            if (String.IsNullOrEmpty(TxtLastName.Text))
            {
                canRegister = false;
                ErrLName.Text = "Last name cannot be empty";
            }

            if (canRegister)
            {
                string verificationCode = _userDao.GenerateVerificationCode();
                _userDao.Register(TxtEmail.Text, TxtPassword.Text, TxtFirstName.Text, TxtLastName.Text, TxtPhoneNumber.Text, verificationCode);
                string from = "italianosemail@gmail.com"; //Replace this with your own correct Gmail Address

                string to = TxtEmail.Text; //Replace this with the Email Address to whom you want to send the mail

                MailMessage mail = new MailMessage();
                mail.To.Add(to);    
                mail.From = new MailAddress(from, "Welcome to Italianos", System.Text.Encoding.UTF8);
                mail.Subject = "Verify your email";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = "<h1>Welcome to Italianos!<h1>"
                           + $"<p>Hello {TxtFirstName.Text} {TxtLastName.Text} " +
                           $"<br/>Please click " + $"<a href=\"https://localhost:44352/Verify.aspx?id=" + $"{verificationCode}\"this link</a> to verify your email<br/>"+"</p>";
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                SmtpClient client = new SmtpClient();
                //Add the Creddentials- use your own email id and password

                client.Credentials = new System.Net.NetworkCredential(from, "g4T5wRQtj3A5GUy");

                client.Port = 587; // Gmail works on this port
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true; //Gmail works on Server Secured Layer
                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    Exception ex2 = ex;
                    string errorMessage = string.Empty;
                    while (ex2 != null)
                    {
                        errorMessage += ex2.ToString();
                        ex2 = ex2.InnerException;
                    }
                    HttpContext.Current.Response.Write(errorMessage);
                }
                Response.Redirect("~/Login.aspx");
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