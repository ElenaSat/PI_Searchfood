<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Administrador.Master" AutoEventWireup="true" CodeBehind="regRestaurante.aspx.cs" Inherits="PI_Searchfood.Views.Administrador.Registros.regRestaurante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="mx-auto mt-5">
        <div class="" runat="server">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lbTitulo" Text="Restaurante"></asp:Label>

                    <asp:Label runat="server" ID="lbOpcion" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="lbCodigoRes" Visible="false"></asp:Label>


                </div>
            </div>
        </div>

        <div class="" runat="server">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbNit" Text="NIT"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNit" CssClass="form-control"> </asp:TextBox>

                </div>

                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbNombre" Text="Nombre"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"> </asp:TextBox>
                </div>

                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbDirecciòn" Text="Dirección"></asp:Label>
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control"> </asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbCorreo" Text="Correo"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control"> </asp:TextBox>

                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbContraseña" Text="Contraseña"></asp:Label>
                    <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control"> </asp:TextBox>

                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbCelular" Text="Celular"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCelular" CssClass="form-control"> </asp:TextBox>

                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbLatitud" Text="Latitud"></asp:Label>
                    <asp:TextBox runat="server" ID="txtLatitud" CssClass="form-control"> </asp:TextBox>

                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbLongitud" Text="Longitud"></asp:Label>
                    <asp:TextBox runat="server" ID="txtLongitud" CssClass="form-control"> </asp:TextBox>

                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbDescripcion" Text="Descripción"></asp:Label>
                    <asp:TextBox runat="server" ID="txtArea" CssClass="form-control" TextMode="MultiLine" Height="200"> </asp:TextBox>
                    <script type="text/javascript">
                        window.onload = function () {
                            var textarea = document.getElementById('<%=txtArea.ClientID %>');
                            textarea.scrollTop = textarea.scrollHeight;
                        }
                    </script>
                </div>


                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbPais" Text="Pais"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlPais" CssClass="form-control" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <div runat="server">
                        <asp:Label runat="server" ID="lbDepartamento" Text="Departamento"></asp:Label>
                        <asp:ScriptManager runat="server" ID="scrManegerDepart"></asp:ScriptManager>
                        <asp:UpdatePanel runat="server" ID="updatepaDepartament">
                            <ContentTemplate>
                                <asp:DropDownList runat="server" ID="ddlDepartamento" CssClass="form-control" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlPais" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="col-md-3">

                    <asp:Label runat="server" ID="lbCiudad" Text="Ciudad"></asp:Label>

                    <asp:UpdatePanel runat="server" ID="updatepaCiudad">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" ID="ddlCiudad" CssClass="form-control" OnSelectedIndexChanged="ddlCiudad_SelectedIndexChanged"></asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlDepartamento" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>



            </div>

        </div>
        <%--SEGUNDA SECCIÓN BOTONES --%>

        <br />
        <div class="" runat="server">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Button ID="btnGuardar" Text="GUARDAR" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" Text="CANCELAR" runat="server" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
        <br />
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
                                        <asp:Label runat="server" ID="lblNIT" Text='<%# Bind("Identificacion")%>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- REPRESENTACIÓN DE DATOS EN CELDAS--%>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Dirección" DataField="Dirección" />
                                <asp:BoundField HeaderText="Celular" DataField="Celular" />

                                <asp:TemplateField HeaderText="Descripcion">
                                        <ItemTemplate>
                                           <asp:TextBox ID="txtDescripcion2" runat="server" Text='<%# Bind("Descripcion")%>' TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Latitud" DataField="Latitud" />
                                <asp:BoundField HeaderText="Longitud" DataField="Longitud" />
                                <asp:BoundField HeaderText="Ciudad" DataField="Ciudad" />
                                <asp:BoundField HeaderText="Usuario Codigo" DataField="Usuario" />
                                <asp:BoundField HeaderText="Correo" DataField="Correo" />
                                <asp:BoundField HeaderText="Contraseña" DataField="Contraseña" />



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
