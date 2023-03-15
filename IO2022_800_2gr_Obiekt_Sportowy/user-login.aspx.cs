using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projekt_obiekt
{
    public partial class user_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //user login
        protected void Button1_Click(object sender, EventArgs e)
        {
            //tu zmieniamy serwer na swój
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NEUL726L;Initial Catalog=projekt-obiektDB;Integrated Security=True");
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from tbl_klient WHERE login='" + TextBox1.Text.Trim() +
                    "' AND haslo='" + TextBox2.Text.Trim() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Udane logowanie');</script>");
                        Session["username"] = dr.GetValue(10).ToString();
                        Session["imie"] = dr.GetValue(0).ToString();
                        Session["rola"] = "user";
                    }
                    Response.Redirect("strona-glowna.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Nieprawidłowy login lub hasło');</script>");
                }

            }
        }
    }
}