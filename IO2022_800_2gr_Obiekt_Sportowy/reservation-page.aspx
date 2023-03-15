<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="reservation-page.aspx.cs" Inherits="projekt_obiekt.registration_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">
       $(document).ready(function () {

           //$(document).ready(function () {
           //$('.table').DataTable();
           // });

           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
           var username = 'Session["username"]';
           var sqlforuser = "SELECT * FROM tbl_rezerwacje WHERE login = '" + username +"'";

           //$('.table1').DataTable();
       });
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container"">
        <div class="row">
            <div class="col-md-5">


                <!-- tworzenie wyglądu formularza z biblioteki bootstrap -->
                <div class="card">
                    <div class="card-body">


                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="login-h3">Dane rezerwacji</h4>

                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="80vw" src="img/classes.png" />
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
                            <div class="col-md-12">
                                <label>Zarezerwuj</label>

                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="ID zrezerwacji"></asp:TextBox>
                                        </div>
                                </div>

                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" 
                                        AutoPostBack="True" ></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Wybierz datę</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server" 
                                        AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Wybierz obiekt</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server" 
                                        AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                        <div class="col-md-6">
                        <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server"
                            Text="Zarezerwuj" OnClick="Button1_Click" />
                        </div>
                        <div class="col-md-6">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" 
                                Text="Anuluj" OnClick="Button4_Click" />      
                    </div>
                            </div>
                    </div>
                </div>

            </div>

        <div class="col-md-7">


            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <h4 class="login-h3">Lista rezerwacji</h4>

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
                            <asp:GridView class="table table-striped table-bordered" ID="GridView1"
                                runat="server" AutoGenerateColumns="False" DataKeyNames="idRezerwacji">
                                <Columns>
                                    <asp:BoundField DataField="idRezerwacji" HeaderText="idRezerwacji" ReadOnly="True"
                                        SortExpression="idRezerwacji" />
                                    <asp:BoundField DataField="idZajec" HeaderText="idZajec" ReadOnly="True"
                                        SortExpression="idZajec" Visible="false"/>
                                    <asp:BoundField DataField="dataRezerwacji" HeaderText="Data rezerwacji"
                                        SortExpression="dataRezerwacji" />
                                    <asp:BoundField DataField="dataZajec" HeaderText="Data zajęć"
                                        SortExpression="dataZajec" />
     
                                    <asp:BoundField DataField="login" HeaderText="Login"
                                        SortExpression="login" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                    <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <h4 class="login-h3">Lista zajęć</h4>

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
                            <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                                ConnectionString="<%$ ConnectionStrings:projekt-obiektDBConnectionString %>"
                                SelectCommand="SELECT * FROM [tbl_zajecia] " ></asp:SqlDataSource>
                            <asp:GridView class="table-striped table-bordered" ID="GridView2"
                                runat="server" AutoGenerateColumns="False" DataKeyNames="idZajec"
                                DataSourceID="SqlDataSource3">
                                <Columns>
                                    <asp:BoundField DataField="idZajec" HeaderText="idZajec" ReadOnly="True"
                                        SortExpression="idZajec" Visible="false" />
                                    <asp:BoundField DataField="nazwaZajec" HeaderText="Nazwa zajęć"
                                        SortExpression="nazwaZajec" />
                                    <asp:BoundField DataField="iloscMiejsc" HeaderText="Ilość dostępnych miejsc"
                                        SortExpression="iloscMiejsc" />
                                    <asp:BoundField DataField="dataZajec" HeaderText="Data zajęć"
                                        SortExpression="dataZajec" />
                                    <asp:BoundField DataField="opisZajec" HeaderText="Opis zajęć"
                                        SortExpression="opisZajec" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>


                </div>
                </div>

            </div>
        </div>
</div>

</div>
</asp:Content>
