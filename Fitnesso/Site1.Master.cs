using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projekt_obiekt
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                if (Session["rola"] == null || Session["rola"].Equals(""))
                {
                    linkbutton1.Visible = true; //zaloguj link button
                    linkbutton2.Visible = true; //zarejestruj

                    linkbutton3.Visible = false; //wyloguj się
                    linkbutton90.Visible = false; //rezerwacja
                    linkbutton5.Visible = false;
                    linkbutton4.Visible = false; //hello user

                    LinkButton6.Visible = true; //admin login
                    LinkButton11.Visible = false; //zarządzanie zajęciami
                    LinkButton12.Visible = false; //zarządzanie trenerami
                }
                else if (Session["rola"].Equals("user"))
                {
                    linkbutton1.Visible = false; //zaloguj link button
                    linkbutton2.Visible = false; //zarejestruj

                    linkbutton3.Visible = true; //wyloguj się
                    linkbutton90.Visible = true; //rezerwacja
                    linkbutton5.Visible = true;
                    linkbutton4.Visible = true; //hello user
                    linkbutton4.Text = "Witaj, " + Session["username"].ToString();

                    LinkButton6.Visible = true; //admin login
                    LinkButton11.Visible = false; //zarządzanie zajęciami
                    LinkButton12.Visible = false; //zarządzanie trenerami
                }
                else if (Session["rola"].Equals("admin"))
                {
                    linkbutton1.Visible = false; //zaloguj link button
                    linkbutton2.Visible = false; //zarejestruj

                    linkbutton3.Visible = true; //wyloguj się
                    linkbutton90.Visible = true; //rezerwacja
                    linkbutton4.Visible = true; //hello user
                    linkbutton5.Visible = true;
                    linkbutton4.Text = "Witaj, Admin ";

                    LinkButton6.Visible = false; //admin login
                    LinkButton11.Visible = true; //zarządzanie zajęciami
                    LinkButton12.Visible = true; //zarządzanie trenerami
                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("admintrainersmanagement.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminclassesmanagement.aspx");
        }

        protected void linkbutton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("user-login.aspx");
        }

        protected void linkbutton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("user-register.aspx");
        }

        protected void linkbutton4_Click(object sender, EventArgs e)
        {

        }

        protected void linkbutton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["imie"] = "";
            Session["rola"] = "";

            linkbutton1.Visible = true; //zaloguj link button
            linkbutton2.Visible = true; //zarejestruj

            linkbutton3.Visible = false; //wyloguj się
            linkbutton90.Visible = false; //rezerwacja
            linkbutton5.Visible = false; //zobacz profil
            linkbutton4.Visible = false; //hello user

            LinkButton6.Visible = true; //admin login
            LinkButton11.Visible = false; //zarządzanie zajęciami
            LinkButton12.Visible = false; //zarządzanie trenerami

            Response.Redirect("strona-glowna.aspx");
        }

        protected void linkbutton90_Click(object sender, EventArgs e)
        {
            Response.Redirect("reservation-page.aspx");
        }

        protected void linkbutton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("user-profile.aspx");
        }
    }
}