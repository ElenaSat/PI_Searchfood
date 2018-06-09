<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Restaurantes.Master" AutoEventWireup="true" CodeBehind="RtMenu.aspx.cs" Inherits="PI_Searchfood.Views.Restaurante.RtMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="card mx-auto mt-5">
        <div class="card-header">
            Ingresar Menu.  
        </div>
        <div class="card-body">
            <div class="" runat="server">
                <div class="form-row">
                    <div class="col-md-12">
                        <asp:Label runat="server" ID="lbOpcion" Visible="false"></asp:Label>

                    </div>
                </div>
            </div>

            <div class="" runat="server">
                <div class="form-row">

                     <div class="col-md-4">
                        <asp:Label runat="server" ID="lbCodigoComida" Text="CodigoComida"></asp:Label>
                        <asp:TextBox runat="server" ID="txtCodigoComida" CssClass="form-control"> </asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label runat="server" ID="lbNombreC" Text="Nombre Comida"></asp:Label>
                        <asp:TextBox runat="server" ID="txtNombreC" CssClass="form-control"> </asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label runat="server" ID="lbValorC" Text="Precio Neto comida"></asp:Label>
                        <asp:TextBox runat="server" ID="txtValorC" CssClass="form-control"> </asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label runat="server" ID="lbCategoria" Text="Categoria"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lbDescripcionC" Text="Descripción Comida"></asp:Label>
                        <asp:TextBox runat="server" ID="txtDescripcionC" CssClass="form-control" TextMode="MultiLine" Height="200"> </asp:TextBox>
                        <script type="text/javascript">
                            window.onload = function () {
                                var textarea = document.getElementById('<%=txtDescripcionC.ClientID %>');
                                textarea.scrollTop = textarea.scrollHeight;
                            }
                        </script>
                        <br />
                    </div>
                    <div class="col-md-6">
                    </div>


                    <div class="col-md-6">
                        <asp:Label runat="server" ID="lblImagen" Text="Subir Imagen"> </asp:Label>
                        <asp:FileUpload runat="server" ID="fuImagen" CssClass="form-control-file"></asp:FileUpload>
                        <asp:RequiredFieldValidator ID="rfvImagen" runat="server" ControlToValidate="fuImagen" ForeColor="Red" ValidationGroup="ValidarCuenta"></asp:RequiredFieldValidator>
                        <br />
                    </div>

                    <%--SEGUNDA SECCIÓN BOTONES --%>
                    <div class="col-md-12">
                        <asp:Button ID="btnGuardarC" Text="GUARDAR" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelarC" Text="CANCELAR" runat="server" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
                        <br />
                        <br />
                    </div>

                    <%--TERCERA SECCIÓN MOSTRAR CONTENIDO --%>
                    <div class="" runat="server">
                        <div class="form-row">
                            <div class="col-md-12">
                                <asp:Label runat="server" ID="lbSubtitulo" Text="Resultado"></asp:Label>


                            </div>
                        </div>
                        <div class="" runat="server">
                            <div class="form-row">
                                <div class="col-md-12" style="overflow: auto">
                                    <asp:GridView runat="server" ID="gvwDatos" Width="100%" AutoGenerateColumns="False" EmptyDataText="No se encontraron Registros" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvwDatos_RowCommand">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <%-- REPRESENTACIÓN DE DATOS EN CONTROLES WEB--%>
                                            <asp:TemplateField HeaderText="NIT">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="CodigoComida" Text='<%# Bind("longcomiCodigo")%>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- REPRESENTACIÓN DE DATOS EN CELDAS--%>
                                            <asp:BoundField HeaderText="Categoria" DataField="clstbCategoria.strcateDescripcion" />
                                            <asp:BoundField HeaderText="Codigo Restaurante" DataField="clstbRestaurante.longrestCodigo" />
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
            </div>
        </div>
    </div>


</asp:Content>
