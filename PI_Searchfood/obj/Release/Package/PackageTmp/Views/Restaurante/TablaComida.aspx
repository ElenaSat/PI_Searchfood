<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Restaurantes.Master" AutoEventWireup="true" CodeBehind="TablaComida.aspx.cs" Inherits="PI_Searchfood.Views.Restaurante.TablaComida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="card mx-auto mt-5">
        <div class="card-header">
          <h1> <b>Tabla de Registros de Alimentos</b></h1>
        </div>
        <div class="card-body">
            <div class="table-responsive" runat="server">
                <div class="form-row">
                    <div class="col-md-12">
     <%-- REPRESENTACIÓN DE DATOS EN CONTROLES WEB--%>
                        <asp:GridView runat="server" ID="gvwDatos" Width="100%" AutoGenerateColumns="False" EmptyDataText="No se encontraron Registros" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvwDatos_RowCommand">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>                   
                                             <asp:TemplateField HeaderText="NIT">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="CodigoComida" Text='<%# Bind("longcomiCodigo")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- REPRESENTACIÓN DE DATOS EN CELDAS--%>
                                            <asp:BoundField HeaderText="Categoria" DataField="obclstbCategoria.strcateDescripcion" />
                                            <asp:BoundField HeaderText="Codigo Restaurante" DataField="obclstbRestaurante.longrestCodigo" />
                                            <asp:BoundField HeaderText="Valor Comida" DataField="loncomiValor" />

                                            <asp:TemplateField HeaderText="Descripcion Comida">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDeC" runat="server" Text='<%# Bind("strcomiDescripcion")%>' TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="RutaImagen" DataField="strcomiRutaImagen" />
                           
                                            <%-- MODIFICAR--%>
                                            <asp:TemplateField HeaderText="Modificar">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImbModificar" runat="server" ImageUrl="~/Views/Administrador/Images/edit.png" CommandName="Modificar" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <%-- ELIMINAR--%>
                                            <asp:TemplateField HeaderText="Eliminar">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImbEliminar" runat="server" ImageUrl="~/Views/Administrador/Images/delete.png" CommandName="Eliminar" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />

                                    </asp:GridView>
    </div>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
