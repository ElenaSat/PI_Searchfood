<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Administrador.Master" AutoEventWireup="true" CodeBehind="RecuperarPasswordF.aspx.cs" Inherits="PI_Searchfood.Views.Administrador.RecuperarPassword.RecuperarPasswordF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="card card-login mx-auto mt-5">
        <div class="card-header">Recuperar Contraseña</div>
        <div class="card-body">
            <div class="text-center mt-4 mb-5">
                <h4>Olvido su Contraseña</h4>
                <p>
                    Ingrese su correo electronico y nosotros le enviaremos los pasos
                          a su correo para la recuperacion de su contraseña.
                </p>

            </div>
            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="btnAceptar" CssClass="btn btn-primary btn-block" Text="Recuperar contraseña" OnClick="btnAceptar_Click" />
        </div>

        <div class="text-center">
            <a class="d-block small mt-3" href="../Administrador/Login/frmLogin.aspx">Ir a Inicio de Sesión</a>
        </div>
       
    </div>
</asp:Content>
