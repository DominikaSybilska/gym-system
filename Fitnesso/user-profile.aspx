<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="user-profile.aspx.cs" Inherits="projekt_obiekt.user_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {

            //$(document).ready(function () {
            //$('.table').DataTable();
            // });

            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('.table1').DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">

                <!-- tworzenie wyglądu formularza z biblioteki bootstrap -->
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="80vw" src="img/generaluser.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="login-h3">Twój profil</h4>
                                    <span>Status konta: </span>
                                    <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="Bieżące dane"></asp:Label>

                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <!-- pola wpisywania pól formularza -->
                         <div class="row">
                            <div class="col-md-6">
                                <label>Pełne imię</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Imię"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Nazwisko</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Nazwisko"></asp:TextBox>
                                </div>
                            </div>
                                 <div class="col-md-6">
                        <label>Płeć</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                              <asp:ListItem Text="Wybierz" Value="wybierz" />
                              <asp:ListItem Text="Kobieta" Value="Kobieta" />
                              <asp:ListItem Text="Mężczyzna" Value="Mężczyzna" />
                               </asp:DropDownList>
                        </div>

                            </div>
                            <div class="col-md-6">
                                <label>Data urodzenia</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" placeholder="Data urodzenia"
                                        TextMode="date"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Numer telefonu</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server" placeholder="Numer telefonu"
                                        TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Adres e-mail</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server" placeholder="e-mail"
                                        TextMode="Email"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Miasto</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server" placeholder="Miasto"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Kod pocztowy</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server" placeholder="Kod pocztowy"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Ulica i numer budynku/mieszkania</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox11" CssClass="form-control" runat="server" placeholder="Pełny adres"
                                        TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:CheckBox ID="CheckBox1" runat="server" />  <label>Czy chcesz zapisać się do newslettera?</label>
                                </div>
                            </div>
                        </div>

                        <!-- user credentials -->
                        <div class="row">
                            <div class="col">
                                <br />
                                <center>
                                    <span class="badge badge-pill badge-dark">Dane użytkownika</span>
                                </center>
                                <br />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Login</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox8" class="form-control" runat="server" placeholder="Login"
                                        ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Stare hasło</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox9" class="form-control" runat="server" placeholder="Hasło"
                                        TextMode="Password" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Nowe hasło</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox10" class="form-control" runat="server" placeholder="Hasło"
                                        TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <!-- przyciski -->
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server"
                                            Text="Zaktualizuj" />
                                    </div>
                                </center>
                            </div>
                        </div>

                    </div>

                </div>
                <a class="back" href="strona-glowna.aspx"><< Powrót do strony głównej</a>
            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="80vw" src="img/gym-near.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Twoje rezerwacje</h4>
                                    <span>Status konta: </span>
                                    <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="Status rezerwacji"></asp:Label>

                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                </div>


            </div>

        </div>

    </div>


</asp:Content>
