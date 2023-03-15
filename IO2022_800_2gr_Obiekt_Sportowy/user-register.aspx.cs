using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace projekt_obiekt
{

    public partial class user_register : System.Web.UI.Page
    {
        klient Klient;
        konto Konto;
        //tu zmieniamy serwer na swój
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NEUL726L;Initial Catalog=projekt-obiektDB;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //przycisk zarejestruj klik
        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Klient = new klient();
            this.Konto = new konto();
            Klient.imie = TextBox1.Text.Trim();
            Klient.nazwisko = TextBox10.Text.Trim();
            Klient.dataUrodzenia = TextBox2.Text.Trim();
            Klient.NumerTelefonu = TextBox3.Text.Trim();
            Klient.Plec = DropDownList1.SelectedItem.Value;
            Klient.Email = TextBox4.Text.Trim();
            Klient.Miasto = TextBox5.Text.Trim();
            Klient.KodPocztowy = TextBox6.Text.Trim();
            Klient.Adres = TextBox7.Text.Trim();
            Konto.haslo = TextBox9.Text.Trim();
            Konto.login = TextBox8.Text.Trim();

            if (checkNotNull())
            {
                Response.Write("<script>alert('Wypełnij wszystkie wymagane pola.');</script>");
            }
            else if (checkMemberExists())
            {
                Response.Write("<script>alert('Użytkownik o takim loginie istnieje już w bazie danych, spróbuj inny login.');</script>");
            }
            else if (checkEmailDuplicate())
            {
                Response.Write("<script>alert('Użytkownik o podanym adresie e-mail już istnieje w naszej bazie.');</script>");
            }
            else if (checkNameandAdressLength())
            {
                Response.Write("<script>alert('Nieprawidłowe imię, nazwisko lub adres.');</script>");
            }
            else if (checkMemberAge())
            {
                Response.Write("<script>alert('Nieprawidłowa data urodzenia. Minimalny wiek użytkownika: 16 lat. " +
                    "Maksymalny wiek użytkownika: 90 lat');</script>");
            }
            else if (checkPhoneNumber())
            {
                Response.Write("<script>alert('Wprowadź poprawny numer telefonu nie uwzględniając numeru kierunkowego.');</script>");
            }
            else if (checkPostCode())
            {
                Response.Write("<script>alert('Niepoprawny kod pocztowy. Wprowadż kod pocztowy w formacie 00-000');</script>");
            }
            else if(checkPassword())
            {
                Response.Write("<script>alert('Nieprawidłowe hasło.');</script>");
                    //<ul> Hasło musi zawierać co najmniej 8 znaków.</ul> " +"<ul> Hasło musi zawierać co najmniej jedną wielką literę.</ul> <ul> Hasło musi zawierać co najmniej jedną cyfrę.</ul>)
            }
            else
            {
                signUpNewUser();
            }
        }


        //sprawdzenie czy użytkownik o podanym loginie już istnieje
        bool checkMemberExists()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * from tbl_klient WHERE login='" + TextBox8.Text.Trim() + "';", con);
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

        //walidacja - niepuste pola wymagane
        bool checkNotNull()
        {
            if (Klient.imie != "" && Klient.nazwisko != "" && Klient.dataUrodzenia != "" && Klient.NumerTelefonu != "" &&
                Klient.Email != "" && Klient.Miasto != "" && Klient.KodPocztowy != "" && Klient.Adres != "" &&
                Konto.haslo != "" && Konto.login != "" && Klient.Plec != "wybierz")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //walidacja - odpowiednia długość imienia, nazwiska i adresu
        bool checkNameandAdressLength()
        {
            if (Klient.imie.Length > 2 && Klient.nazwisko.Length > 1 && Klient.Miasto.Length > 2 && Klient.Adres.Length > 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //walidacja - wiek użytkownika
        bool checkMemberAge()
        {
            int wiek = (DateTime.Now.Year - DateTime.Parse(Klient.dataUrodzenia).Year);

            if (wiek > 16 && wiek < 90)
            {
                return false;
            }
            else if (wiek == 18 && DateTime.Now.Month >= DateTime.Parse(Klient.dataUrodzenia).Month
                && DateTime.Now.Day >= DateTime.Parse(Klient.dataUrodzenia).Day)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //walidacja - kod pocztowy
        bool checkPostCode()
        {
            if (Klient.KodPocztowy.Length != 6)
            {
                return true;
            }
            else if (Klient.KodPocztowy.Contains("-"))
            {
                string cyfry = "0123456789";
                if (cyfry.Contains(Klient.KodPocztowy[0]) && cyfry.Contains(Klient.KodPocztowy[1]) && cyfry.Contains(Klient.KodPocztowy[3]) &&
                    cyfry.Contains(Klient.KodPocztowy[4]) && cyfry.Contains(Klient.KodPocztowy[5]))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        //walidacja - Numer telefonu, liczba cyfr
        bool checkPhoneNumber()
        {
            if (Klient.NumerTelefonu.Length != 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //walidacja - zduplikowany Email
        bool checkEmailDuplicate()
        {

            SqlCommand cmd = new SqlCommand("SELECT * from tbl_klient WHERE email='" + TextBox4.Text.Trim() + "';", con);
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

        //walidacja poprawności hasła
        bool checkPassword()
        {
            if (Konto.haslo.Length<8)
            {
                return true;
            }
            else
            {
                string reg_1 = @"(\b)(\w*)(\d+)(\w*)([A-Z]+)(\w*)(\b)";
                string reg_2 = @"(\b)(\w*)([A-Z]+)(\w*)(\d+)(\w*)(\b)";

                Regex r_1 = new Regex(reg_1 , RegexOptions.IgnoreCase);
                Regex r_2 = new Regex(reg_2, RegexOptions.IgnoreCase);

                Match m_1 = r_1.Match(Konto.haslo);
                Match m_2= r_2.Match(Konto.haslo);  

                if (m_1.Success)
                {
                    return false;
                }
                else if(m_2.Success) 
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        //wprowadzenie nowego użytkownika
        void signUpNewUser()
        {


            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_klient(imie, nazwisko, dataUrodzenia, numerTelefonu, plec, email, miasto, kodPocztowy, adres, haslo, login, newsletter) " +
            "values(@Imię, @Nazwisko, @dataUrodzenia, @Numertelefonu, @Płeć, @email, @Miasto, @Kodpocztowy, @adres, @Hasło, @Login, @news)", con);

            cmd.Parameters.AddWithValue("@Imię", TextBox1.Text.Trim());
            cmd.Parameters.AddWithValue("@Nazwisko", TextBox10.Text.Trim());
            cmd.Parameters.AddWithValue("@dataUrodzenia", TextBox2.Text.Trim());
            cmd.Parameters.AddWithValue("@Numertelefonu", TextBox3.Text.Trim());
            cmd.Parameters.AddWithValue("@Płeć", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
            cmd.Parameters.AddWithValue("@Miasto", TextBox5.Text.Trim());
            cmd.Parameters.AddWithValue("@Kodpocztowy", TextBox6.Text.Trim());
            cmd.Parameters.AddWithValue("@adres", TextBox7.Text.Trim());
            cmd.Parameters.AddWithValue("@Hasło", TextBox9.Text.Trim());
            cmd.Parameters.AddWithValue("@Login", TextBox8.Text.Trim());
            cmd.Parameters.AddWithValue("@news", CheckBox1.Checked ? "T" : "N");

            cmd.ExecuteNonQuery();

            TextBox1.Text = "";
            TextBox10.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            DropDownList1.SelectedItem.Value = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox9.Text = "";
            TextBox8.Text = "";

            Response.Write("<script>alert('Rejestracja zakończona pomyślnie. Przejdź do ekranu logowania');</script>");
        }

    }
}
internal class konto
{
    internal string haslo;
    internal string login;
}
internal class klient
{
    internal string imie;
    internal string nazwisko;
    internal string dataUrodzenia;
    internal string Plec;
    internal string Miasto;
    internal string KodPocztowy;
    internal string Adres;
    public string NumerTelefonu { get; internal set; }
    public string Email { get; internal set; }
}


