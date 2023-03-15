using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projekt_obiekt
{
    
    public partial class admininstructorsmenagment : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //dodawanie
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkNotNull()==false) 
            {
                Response.Write("<script>alert('Puste pola wymagane.');</script>");
            }
            else if(checkNameLength()==false)
            {
                Response.Write("<script>alert('Nieprawidłowe imię lub nazwisko pracownika.');</script>");
            }
            else if (checkIfTrainerExists())
            {
                Response.Write("<script>alert('Pracownik o takim ID już istnieje. Nie można utworzyć drugiego takiego samego rekordu.');</script>");
            }
            else if (checkIfTrainerExistsName())
            {
                Response.Write("<script>alert('Taki pracowanik już istnieje. Skorzystaj z pola search.');</script>");
            }
            else
            { 
                addNewTrainer();
            }
        }
        //aktualizacja
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfTrainerExists())
            {
                updateTrainer();
            }
            else
            {
                Response.Write("<script>alert('Nie można odnaleźć pracownika o podanym ID.');</script>");
            }
        }

        //usuwanie
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfTrainerExists())
            {
                deleteTrainer();

            }
            else
            {
                Response.Write("<script>alert('Nie można odnaleźć pracownika o podanym ID.');</script>");
            }
        }
        //'idź' przycisk
        protected void Button1_Click(object sender, EventArgs e)
        {
            getTrainerById();
        }

        void getTrainerById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from tbl_pracownik where idPracownika='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox3.Text = dt.Rows[0][2].ToString();
                    TextBox7.Text = dt.Rows[0][3].ToString();
                }
                else
                {

                    Response.Write("<script>alert('Nie można odnaleźć pracownika o podanym ID.');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void deleteTrainer()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_pracownik  WHERE idPracownika='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Usunięcie pracownika udane!');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateTrainer()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE tbl_pracownik SET imie=@trainer_name,nazwisko=@trainer_surname,opisPracownika=@trainer_description WHERE idPracownika='" + TextBox1.Text.Trim()+"'", con);

                cmd.Parameters.AddWithValue("@trainer_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@trainer_surname", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@trainer_description", TextBox7.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Zmiana pracownika udana!');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void addNewTrainer()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_pracownik(idPracownika,imie,nazwisko,opisPracownika) values(@trainer_id,@trainer_name,@trainer_surname,@trainer_description)", con);

                cmd.Parameters.AddWithValue("@trainer_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@trainer_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@trainer_surname", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@trainer_description", TextBox7.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Dodanie pracownika udane!');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //walidacja - puste pola wymagane
        bool checkNotNull()
        {
            if(TextBox2.Text.Length>0 && TextBox3.Text.Length>0 && TextBox7.Text.Length>0) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //walidacja - długość imienia i nazwiska
        bool checkNameLength()
        {
            if (TextBox2.Text.Length>2 && TextBox3.Text.Length>1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //walidacja - duplikat ID
        bool checkIfTrainerExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from tbl_pracownik where idPracownika='" + TextBox1.Text.Trim() + "';", con);
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

        //walidacja - duplikat (imie i nazwisko)
        bool checkIfTrainerExistsName()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from tbl_pracownik where [imie]='" + TextBox2.Text.Trim() + 
                    "'and [nazwisko]='"+TextBox3.Text.Trim()+"';", con);
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


        void clearForm()
        {

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox7.Text = "";

        }
    }
}
