<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Administrador.Master" AutoEventWireup="true" CodeBehind="Busquedad.aspx.cs" Inherits="PI_Searchfood.Views.Administrador.Index.Busquedad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div style="background-image: url('...\Images\DfImages\sap.PNG'); width: 100%; height: 100%;">
        <div class="row">
            <div class="col-md-3" >
                    <asp:Image ID="imgSearchfood" runat="server" ImageUrl="~/Views/Administrador/Index/Icon/imgSearchFood.png" Height="100%" Width="100%"></asp:Image>

                </div>
            <div class="col-md-7">
                 <br>
                    <br>                    
                    <br><br>
                    <br>
                    <br>
                   
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Ej: Pizza, Perro Caliente "></asp:TextBox>

            </div>

            <div class="col-md-2">
                <br>
                    <br>                    
                    <br>
                    <br><br>
                    <br>
                   
                <asp:Button ID="btnbuscar" Text="Buscar" runat="server" CssClass="btn btn-primary" OnClick="btnbuscar_Click" />


            </div>
        </div>
        <br>
        <div class="row">
            <div class="col-md-12" id="panel">
                <div class="panel panel-default">
                    <div class="panel-heading">Establecimiento</div>
                    <div class="panel-body" >
                        <div class="table-responsive" style="align-content:center">
                            <asp:GridView runat="server" ID="grvbusqueda" Width="100%" AutoGenerateColumns="False" EmptyDataText="No se encontraron Registros" OnRowCommand="grvbusqueda_RowCommand">

                                <Columns>
                                    <%-- REPRESENTACIÓN DE DATOS EN CONTROLES WEB--%>
                                    <asp:TemplateField HeaderText="Identificación" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl" Text='<%# Bind("longrestCodigo")%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%-- REPRESENTACIÓN DE DATOS EN CELDAS--%>

                                    <asp:BoundField DataField="strrestNombre"/>
                                    <asp:BoundField DataField="strrestDireccion" />
                                    <asp:BoundField DataField="strrestTelefono" />
                                    <asp:BoundField DataField="strrestcorreo" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button CssClass="btn btn-success" runat="server" CommandName="Ir" Text="IR" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>


                            </asp:GridView>



                        </div>
                    </div>
                </div>
            </div>
        </div>
     
    </div>

</asp:Content>
