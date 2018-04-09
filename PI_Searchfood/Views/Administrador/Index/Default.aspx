<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Administrador.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PI_Searchfood.Views.Administrador.Index.Default" %>

<asp:Content ID="Cont1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="mx-auto mt-5">
        <div class="">
            <div class="form-row">
                <div class="col-md-4" >
                    <asp:Image ID="imgSearchfood" runat="server" ImageUrl="~/Views/Administrador/Index/Icon/imgSearchFood.png" Height="100%" Width="100%"></asp:Image>

                </div>
                <div class="col-md-7">

                    <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Ej: Pizza, Perro Caliente "></asp:TextBox>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-block" Text="Buscar" />
                </div>
            </div>


        </div>


    </div>





</asp:Content>
