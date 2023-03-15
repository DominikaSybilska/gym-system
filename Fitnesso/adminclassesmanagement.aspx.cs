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
    public partial class adminclassesmanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //dodawanie
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfClassesExists())
            {
                Response.Write("<script>alert('Zajęcia o takim ID już istnieją. Nie można utworzyć drugiego takiego samego rekordu.');</script>");
            }
            else
            {
                addNewClasses();
            }
        }

        //aktualizacja
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfClassesExists())
            {
                updateClasses();
            }
            else
            {
                Response.Write("<script>alert('Nie można odnaleźć zajęć o podanym ID.');</script>");
            }
        }
        //usuwanie
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfClassesExists())
            {
                deleteClasses();

            }
            else
            {
                Response.Write("<script>alert('Nie można odnaleźć zajęć o podanym ID.');</script>");
            }
        }
        void getClassesById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from tbl_zajecia where idZajec='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox3.Text = dt.Rows[0][2].ToString();
                    TextBox4.Text = dt.Rows[0][3].ToString();
                    TextBox7.Text = dt.Rows[0][4].ToString();
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
        void deleteClasses()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_zajecia  WHERE idZajec='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Usunięcie zajęć udane!');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateClasses()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE tbl_zajecia SET nazwaZajec=@classes_name,iloscMiejsc=@freePlaces, dataZajec=@classes_date,opisZajec=@classes_description WHERE idZajec='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@classes_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@freePlaces", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@classes_date", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@classes_description", TextBox7.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Zmiana zajęć udana!');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void addNewClasses()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_zajecia(idZajec,nazwaZajec,iloscMiejsc,dataZajec,opisZajec) values(@classes_id,@classes_name,@freePlaces,@classes_date,@classes_description)", con);

                cmd.Parameters.AddWithValue("@classes_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@classes_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@freePlaces", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@classes_date", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@classes_description", TextBox7.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Dodanie zajęć udane!');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        bool checkIfClassesExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from tbl_zajecia where idZajec='" + TextBox1.Text.Trim() + "';", con);
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
            TextBox4.Text = "";
            TextBox7.Text = "";

        }

        //przycisk idź
        protected void Button1_Click(object sender, EventArgs e)
        {
            getClassesById();
        }
    }
}
