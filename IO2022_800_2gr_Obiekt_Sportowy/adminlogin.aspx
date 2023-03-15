<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="projekt_obiekt.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid" style='height:82vh'>

        <div class="container-fluid" style='height:82vh'>
        <div class="row">
            <div class="col-md-6 mx-auto">
                <!-- tworzenie wyglądu formularza z biblioteki bootstrap -->

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100vw" src="img/adminuser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3 class="login-h3">Logowanie Admin</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <div class="col">
                                    <!-- pola wpisywania loginu i hasła -->

                                    <label>Login</label>
                                    <div class="form-group">
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="Login"></asp:TextBox>
                                    </div>
                                    <label>Hasło</label>
                                    <div class="form-group">
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Hasło"
                                            TextMode="Password"></asp:TextBox>
                                    </div>

                                    <!-- przyciski -->
                                    <div class="form-group">
                                        <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server"
                                            Text="Zaloguj" OnClick="Button1_Click" />
                                    </div>
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
                <a class="back" href="strona-glowna.aspx"><< Powrót do strony głównej</a>
            </div>
        </div>
        </div>

</asp:Content>
