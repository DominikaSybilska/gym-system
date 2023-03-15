using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projekt_obiekt
{
    public partial class registration_page : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            fillDropDown();

            fillReservationForUser();
        }
        public void fillReservationForUser()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_rezerwacje WHERE login =  @getLogin ", con);

            if (Session["username"] == null)
            {
                cmd.Parameters.AddWithValue("@getLogin", "");
            }
            else
            {
                cmd.Parameters.AddWithValue("@getLogin", Session["username"].ToString());
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            con.Close();
            GridView1.DataBind();
        }

        protected void clearForm()
        {
            TextBox1.Text = "";

        }

        void deleteReservation()
        {
            
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from [dbo].[tbl_rezerwacje] where idRezerwacji = @idRezerwacji", con);
                cmd.Parameters.AddWithValue("@idRezerwacji", TextBox1.Text.Trim());

                

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Anulowanie rezerewacji udane udane!');</script>");
    
                GridView1.DataBind();
            fillReservationForUser();

                 clearForm();
            
        }
        //rezerwacja
        protected void Button1_Click(object sender, EventArgs e)
        {
            addReservation();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfReservationExists())
            {
                deleteReservation();

            }
            else
            {
                Response.Write("<script>alert('Nie można anulować rezerwacji o podanym ID.');</script>");
            }
        }

        void fillDropDown()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT idZajec, nazwaZajec from tbl_zajecia;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "nazwaZajec";
                DropDownList1.DataValueField = "idZajec";
                DropDownList1.DataBind();

                cmd = new SqlCommand("SELECT idObiektu, nazwa from tbl_obiekt", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataTextField = "nazwa";
                DropDownList3.DataValueField = "idObiektu";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT dataZajec from tbl_zajecia", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "dataZajec";
                DropDownList2.DataBind();
            }
            catch
            {

            }
        }

        void addReservation()
        {
            
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_rezerwacje(idZajec, dataRezerwacji, dataZajec, statusRezerwacji, idObiektu, login) " +
                    "values(@idZajec, @dataRezerwacji, @dataZajec, @statusRezerwacji, @idObiektu, @login)", con);


                cmd.Parameters.AddWithValue("@idZajec", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dataZajec", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@dataRezerwacji", DateTime.Now);
                cmd.Parameters.AddWithValue("@statusRezerwacji", "oczekuje na płatność");
                cmd.Parameters.AddWithValue("@idObiektu", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@login", Session["username"].ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Rezerwacja udana!');</script>");
                GridView1.DataBind();


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String textInDropDown = DropDownList1.Text.ToString();
            String text = "Judo";
            DropDownList1.SelectedValue = DropDownList1.Items.FindByText(DropDownList1.Text.ToString()).Value;
            Response.Write("<script>alert('IM IN!');</script>");
        }

        protected void zajecia_SelectedIndexChanged()
        {
            String textInDropDown = DropDownList1.Text.ToString();
            String text = "Judo";
            DropDownList1.SelectedValue = DropDownList1.Items.FindByText(DropDownList1.Text.ToString()).Value;
            Response.Write("<script>alert('IM IN!');</script>");
        }

        bool checkIfReservationExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                Console.Write(TextBox1.Text);

                SqlCommand cmd = new SqlCommand("SELECT * from tbl_rezerwacje where idRezerwacji='" + TextBox1.Text.Trim() + "';", con);
                

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

            
        }
    }
}
