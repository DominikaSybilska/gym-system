<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="admintrainersmanagement.aspx.cs" Inherits="projekt_obiekt.admininstructorsmenagment" %>
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

    <div class="container">
        <div class="row">
            <div class="col-md-5">

                <!-- tworzenie wyglądu formularza z biblioteki bootstrap -->
                <div class="card">
                    <div class="card-body">
                        

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="login-h3">Dane trenera</h4>

                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="80vw" src="img/trainer.png" />
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
                            <div class="col-md-4">
                                <label>ID trenera</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" placeholder="ID"></asp:TextBox>
                                        <asp:Button class="btn btn-primary" ID="Button1" runat="server"
                                            Text="Idź" OnClick="Button1_Click" />
                                        </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Imię trenera</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server" placeholder="Imię trenera"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-12">
                                <label>Nazwisko trenera</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server" placeholder="Nazwisko trenera"></asp:TextBox>
                                        </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Opis trenera</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server" placeholder="Opis trenera"
                                        TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                    <div class="col-4">
                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-success" 
                            runat="server" Text="Dodaj" OnClick="Button2_Click" />      
                    </div>
                        <div class="col-4">
                        <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" 
                                Text="Zaktualizuj" OnClick="Button3_Click" />      
                    </div>
                        <div class="col-4">
                        <asp:Button ID="Button4" class="btn btn-lg btn-block btn-danger" runat="server" 
                                Text="Usuń" OnClick="Button4_Click" />      
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
                                    <h4 class="login-h3">Lista trenerów</h4>

                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:projekt-obiektDBConnectionString %>" 
                                SelectCommand="SELECT * FROM [tbl_pracownik]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" 
                                    runat="server" AutoGenerateColumns="False" DataKeyNames="idPracownika" 
                                    DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="idPracownika" HeaderText="idPracownika" 
                                            ReadOnly="True" SortExpression="idPracownika" />
                                        <asp:BoundField DataField="imie" HeaderText="imie" SortExpression="imie" />
                                        <asp:BoundField DataField="nazwisko" HeaderText="nazwisko" 
                                            SortExpression="nazwisko" />
                                        <asp:BoundField DataField="opisPracownika" HeaderText="opisPracownika" 
                                            SortExpression="opisPracownika" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>


                    </div>

                </div>


            </div>

        </div>

    </div>



</asp:Content>
