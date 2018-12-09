<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Restaurantes.Master" AutoEventWireup="true" CodeBehind="indexRestaurante.aspx.cs" Inherits="PI_Searchfood.Views.Restaurante.frmRestaurante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <script src="../../js/demo/chart-area-demo.js"></script>
    <script src="../../js/demo/chart-bar-demo.js"></script>
    <script src="../../js/demo/chart-pie-demo.js"></script>
    <script src="../../js/demo/datatables-demo.js"></script>
    <script src="../../js/sb-admin-charts.js"></script>
    <script src="../../js/sb-admin-datatables.js"></script>
       <div class="container">
        <div class=" card mx-auto mt-5">
            <div class="card-header">
                <h1><b>Bienvenido</b></h1>
            </div>
            <div class="card-body">
                <div class="form-row">
                    <div class="col-md-2">
                 <asp:Image runat="server" Height="150px" Width="150px" ID="imgUsuario" />
                        </div>
                  
                    <div class="col-md-10">
                        <br>
                        <br>
                <asp:Label runat="server" Text="
                   El restaurante La Noria ocupa la planta baja del Casal organizado en dos comedores:
El comedor Do Carrasca, con cabida para treinta comensales, nos ofrece posada al abrigo de su gran chimenea.
El comedor Da Paloma está pensado para albergar pequeñas celebraciones o comidas de empresa, con una capacidad de hasta ochenta personas. Además dispone de proyector y pantalla lo que posibilita su utilización para presentaciones y eventos similares.
El local, inaugurado en el verano de 2004, ofrece cocina tradicional con toques de modernidad. El restaurante aprovecha los productos de la zona ( excelentes carnes, salazones, pulpo, productos de la huerta, pescados de la cercana ría de Vigo…) combinándolos con nuevos sabores y texturas." ></asp:Label>
                   </div>
 </div>
        </div>
             <div >

          <!-- Breadcrumbs-->
          <ol class="breadcrumb">
            <li class="breadcrumb-item">
              <a href="#">Dashboard</a>
            </li>
            <li class="breadcrumb-item active">Charts</li>
          </ol>

          <!-- Area Chart Example-->
          <div class="card mb-3">
            <div class="card-header">
              <i class="fas fa-chart-area"></i>
              Tabla de Visitas</div>
            <div class="card-body">
              <canvas id="myAreaChart" width="100" height="30"></canvas>
            </div>
            <div class="card-footer small text-muted">Última Actualización 0.5 seg</div>
          </div>

          <div class="row">
            <div class="col-lg-8">
              <div class="card mb-3">
                <div class="card-header">
                  <i class="fas fa-chart-bar"></i>
                  Reservas</div>
                <div class="card-body">
                  <canvas id="myBarChart" width="100" height="50"></canvas>
                </div>
                <div class="card-footer small text-muted">Última Actualización 0.5 seg</div>
              </div>
            </div>
            <div class="col-lg-4">
              <div class="card mb-3">
                <div class="card-header">
                  <i class="fas fa-chart-pie"></i>
                  Satisfacción del Servicio los Clientes</div>
                <div class="card-body">
                  <canvas id="myPieChart" width="100" height="100"></canvas>
                    <p> Green=Satisfactorio Blue=Bueno Yellow=Regular Red=No Satisfactorio </p>
                </div>
                <div class="card-footer small text-muted">Última Actualización 0.5 seg</div>
              </div>
            </div>
          </div>

          

        </div>
           
        </div>
    </div>
    <script src="../../js/demo/chart-area-demo.js"></script>
    <script src="../../js/demo/chart-bar-demo.js"></script>
    <script src="../../js/demo/chart-pie-demo.js"></script>
    <script src="../../js/demo/datatables-demo.js"></script>
</asp:Content>
