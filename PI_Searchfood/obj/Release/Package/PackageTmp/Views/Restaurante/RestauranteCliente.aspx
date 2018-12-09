<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Restaurantes.Master" AutoEventWireup="true" CodeBehind="RestauranteCliente.aspx.cs" Inherits="PI_Searchfood.Views.Restaurante.RestauranteCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="container">
        <div class=" card mx-auto mt-5">
            <div class="card-header">

                <div class="form-row">
                    <div class="col-md-2">
                        <h1>
                            <asp:Label runat="server" ID="lbnomrest" Text="" CssClass="badge badge-info"> </asp:Label></h1>
                    </div>

                    <div class="col-md-2">
                        <i class="fa fa-phone-square"></i>
                        <span class="nav-link-text">
                            <asp:Label runat="server" ID="lbTelefono" Text=""> </asp:Label></span>
                    </div>
                    <div class="col-md-4">
                        <i class="fa fa-envelope"></i>
                        <span class="nav-link-text">
                            <asp:Label runat="server" ID="lbCorreo" Text=""> </asp:Label></span>
                    </div>
                    <div class="col-md-2">
                        <i class="fa fa-map-marker"></i>
                        <span class="nav-link-text">
                            <asp:Label runat="server" ID="lbDire" Text=""> </asp:Label></span>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnReserva" Text="RESERVAR" runat="server" CssClass="btn btn-lg btn-success" OnClick="btnReserva_Click" />
                    </div>


                </div>
                <div class="form-row">
                    <div class="col-md-2">

                        <asp:Label runat="server" ID="lbPrincipal" Text="Principal" CssClass="badge badge-light">Principal </asp:Label>
                        <asp:Label runat="server" ID="lbSu" Text="Sucursal" CssClass="badge badge-light">Sucursal</asp:Label>
                    </div>
                </div>


            </div>

            <div></div>
            <div class="form-row">
                <div class="col-md-4">
                    <div class="card-body">

                        <asp:Image runat="server" Height="200px" Width="250px" ID="imgUsuario" />

                    </div>

                </div>

                <div class="col-md-8">
                    <br>
                    <br>
                    <br>
                    <div style="margin-left: auto; margin-right: auto; text-align: center;">
                        <asp:Label Text="" runat="server" ID="lbdescrest" CssClass="align-content-md-center" />
                    </div>
                </div>
            </div>




            <div class="">

                <h1>
                    <asp:Label Text="SERVICIOS" runat="server" ID="lbServicios" /></h1>

                <div class="form-row">
                    <div class="col-md-6">
                        <i class="fa fa-wifi"></i>
                        <span class="nav-link-text">Wi-FI</span>
                    </div>
                    <div class="col-md-6">
                        <i class="fa fa-car"></i>
                        <span class="nav-link-text">Estacionamiento</span>
                    </div>
                    <div class="col-md-6">
                        <i class="fa fa-wheelchair"></i>
                        <span class="nav-link-text">Acceso para discapacitados</span>
                    </div>


                </div>


            </div>

            <div></div>
            <div></div>

            <div class="">

                <h1>
                    <asp:Label Text="MÉTODOS DE PAGO" runat="server" ID="Label1" /></h1>

                <div class="form-row">
                    <div class="col-md-6">
                        <i class="fa fa-money"></i>
                        <span class="nav-link-text">Efectivo</span>
                    </div>
                    <div class="col-md-6">
                        <i class="fa fa-credit-card"></i>
                        <span class="nav-link-text">Tarjeta</span>
                    </div>
                    <div class="col-md-6">
                        <i class="fa fa-bitcoin"></i>
                        <span class="nav-link-text">Bonos</span>
                    </div>
                </div>


            </div>

            <div></div>
            <div></div>



        </div>
    </div>

</asp:Content>
