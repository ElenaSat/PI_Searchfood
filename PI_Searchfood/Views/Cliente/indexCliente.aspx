<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Cliente.Master" AutoEventWireup="true" CodeBehind="indexCliente.aspx.cs" Inherits="PI_Searchfood.Views.Cliente.indexCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

    <script>
         <!-- Para Cargar -->
    $(document).ready(function () {
        $('#exampleModal').modal('show');
    });

    </script>

    <div class="container">
        <div class=" card mx-auto mt-5">
            <div class="card-header">
                <h1><b>Bienvenido</b></h1>
            </div>
            <div class="card-body">

                <asp:Image runat="server" Height="150px" Width="150px" ID="imgUsuario" />

            </div>

        </div>
    </div>
    <!-- Button trigger modal -->

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Preferencias de Comida. ¡Vamos Selecciona alguna!</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <h2>Categoria</h2>
                    <div class="">
                        <div class="form-row">
                            <div class="btn-group btn-group-justified">
                                <div class="btn-group">
                                    <asp:Button runat="server" ID="btnCR" Text="Comida Rápida" CssClass="btn btn-primary btn-sm" OnClick="btnCR_Click"  />
                                </div>
                                <div class="btn-group">
                                    <asp:Button runat="server" ID="btnCE" Text="Comida Exóticas" CssClass="btn btn-danger btn-sm" OnClick="btnCE_Click"  />
                                </div>
                                <div class="btn-group">
                                    <asp:Button runat="server" ID="btnCD" Text="Comda Diarias" CssClass="btn btn-info btn-sm" OnClick="btnCD_Click"  />
                                </div>
                                <div class="btn-group">
                                    <asp:Button runat="server" ID="btnCV" Text="Comida Vegana" CssClass="btn btn-success btn-sm" OnClick="btnCV_Click"  />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="">
                        <div class="form-row">
                            <div class="col-md-4">
                                <asp:CheckBox runat="server" ID="chkbox" AutoPostBack="false" Text="<img src='../../Images/Restaurantes/Menu/01.jpg' class='img-thumbnail' alt='Cinque Terre' width='100' height='100'>" />


                            </div>
                            <div class="col-md-4">
                                <asp:CheckBox runat="server" ID="CheckBox1" AutoPostBack="false" Text="<img src='../../Images/Restaurantes/Menu/02.jpg' class='img-thumbnail' alt='Cinque Terre' width='100' height='100'>" />
                            </div>
                            <div class="col-md-4">
                                <asp:CheckBox runat="server" ID="CheckBox2" AutoPostBack="false" Text="<img src='../../Images/Restaurantes/Menu/03.jpg' class='img-thumbnail' alt='Cinque Terre' width='100' height='100'>" />
                            </div>
                        </div>

                    </div>
                    <div class="">
                        <div class="form-row">
                            <div class="col-md-4">
                                <asp:CheckBox runat="server" ID="CheckBox3" AutoPostBack="false" Text="<img src='../../Images/Restaurantes/Menu/01.jpg' class='img-thumbnail' alt='Cinque Terre' width='100' height='100'>" />
                            </div>
                            <div class="col-md-4">
                                <asp:CheckBox runat="server" ID="CheckBox4" AutoPostBack="false" Text="<img src='../../Images/Restaurantes/Menu/04.jpg' class='img-thumbnail' alt='Cinque Terre' width='100' height='100'>" />
                            </div>
                            <div class="col-md-4">
                                <asp:CheckBox runat="server" ID="CheckBox5" AutoPostBack="false" Text="<img src='../../Images/Restaurantes/Menu/02.jpg' class='img-thumbnail' alt='Cinque Terre' width='100' height='100'>" />
                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-warning" data-dismiss="modal">CANCELAR</button>
                    <asp:Button runat="server" ID="btnGUARDAR" Text="GUARDAR" CssClass="btn btn-primary" OnClick="btnGUARDAR_Click" />
                </div>
            </div>
        </div>
    </div>



</asp:Content>
