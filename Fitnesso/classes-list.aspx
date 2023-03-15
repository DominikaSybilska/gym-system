<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="classes-list.aspx.cs" Inherits="projekt_obiekt.classes_list" %>

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
            <div class="col-md-10">


                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="login-h3">Dostępne zajęcia</h4>

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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                    ConnectionString="<%$ ConnectionStrings:projekt-obiektDBConnectionString %>"
                                    SelectCommand="SELECT * FROM [tbl_zajecia]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1"
                                    runat="server" AutoGenerateColumns="False" DataKeyNames="idZajec"
                                    DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="idZajec" HeaderText="idZajec" ReadOnly="True"
                                            SortExpression="idZajec" Visible="false"/>
                                        <asp:BoundField DataField="nazwaZajec" HeaderText="Nazwa Zajęć"
                                            SortExpression="nazwaZajec" />
                                        <asp:BoundField DataField="iloscMiejsc" HeaderText="Ilość dostępnych miejsc"
                                            SortExpression="iloscMiejsc" />
                                        <asp:BoundField DataField="dataZajec" HeaderText="Data zajęć"
                                            SortExpression="dataZajec" />
                                        <asp:BoundField DataField="opisZajec" HeaderText="Opis zajeć"
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
</asp:Content>
