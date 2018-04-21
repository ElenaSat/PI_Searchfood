<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Administrador.Master" AutoEventWireup="true" CodeBehind="regPersonas.aspx.cs" Inherits="PI_Searchfood.Views.Administrador.Registros.regPersonas" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="header" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row center-block">
        
        <div class="col-sm-12">
            <%--PRIMERA SECCIÓN CAMPOS--%>
            <div class=" card mx-auto mt-5">
                <div class="card-header">
                    Registro Persona   
                </div>
                <div class="card-body">

                    <div id="form1" runat="server">
                        <div class="" runat="server">
                            <div class="form-row">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="lbOpcion" Visible="false"></asp:Label>
                                    <asp:Label runat="server" ID="lbCodigoUs" Visible="false"></asp:Label>


                                </div>
                            </div>
                        </div>

                        <div class="" runat="server">
                            <div class="form-row">
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="lbIdentificacion" Text="Identificación"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtIdentificacion" CssClass="form-control"> </asp:TextBox>

                                </div>

                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="lbNombre" Text="Nombre"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"> </asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="lbApellido" Text="Apellido"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control"> </asp:TextBox>

                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="lbDirecciòn" Text="Dirección"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control"> </asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="lbCorreo" Text="Correo"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtCorreo" CssClass="form-control"> </asp:TextBox>

                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="lbCelular" Text="Celular"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtCelular" CssClass="form-control"> </asp:TextBox>

                                </div>
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="lbGenero" Text="Genero"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlGenero" CssClass="form-control form-control-lg" OnSelectedIndexChanged="ddlGenero_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="lbContraseña" Text="Contraseña"></asp:Label>
                                    <asp:TextBox runat="server" ID="txtContraseña" TextMode="Password" CssClass="form-control"> </asp:TextBox>

                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="lbConfirmarPassword" Text="Confirmar Contraseña"> </asp:Label>
                                    <asp:TextBox runat="server" ID="txtConfirmarPassword" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvConfirmarPassword" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtConfirmarPassword" ForeColor="Red" ValidationGroup="ValidarCuenta"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator runat="server" ID="cvConfirmarPassword" ErrorMessage="Contraseña no coinciden" ControlToValidate="txtConfirmarPassword" ControlToCompare="txtContraseña" ForeColor="Red"></asp:CompareValidator>
                                </div>

                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="lbPais" Text="Pais"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlPais" CssClass="form-control form-control-lg" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>

                                <div class="col-md-12">
                                    <div runat="server">
                                        <asp:Label runat="server" ID="lbDepartamento" Text="Departamento"></asp:Label>
                                        <asp:ScriptManager runat="server" ID="scrManegerDepart"></asp:ScriptManager>
                                        <asp:UpdatePanel runat="server" ID="updatepaDepartament">
                                            <ContentTemplate>
                                                <asp:DropDownList runat="server" ID="ddlDepartamento" CssClass="form-control form-control-lg" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlPais" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-md-12">

                                    <asp:Label runat="server" ID="lbCiudad" Text="Ciudad"></asp:Label>

                                    <asp:UpdatePanel runat="server" ID="updatepaCiudad">
                                        <ContentTemplate>
                                            <asp:DropDownList runat="server" ID="ddlCiudad" CssClass="form-control form-control-lg" OnSelectedIndexChanged="ddlCiudad_SelectedIndexChanged"></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlDepartamento" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>

                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="lblImagen" Text="Subir Imagen"> </asp:Label>
                                    <asp:FileUpload runat="server" ID="fuImagen" CssClass="form-control-file"></asp:FileUpload>
                                    <asp:RequiredFieldValidator ID="rfvImagen" runat="server" ControlToValidate="fuImagen" ForeColor="Red" ValidationGroup="ValidarCuenta"></asp:RequiredFieldValidator>

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
                                                <asp:TemplateField HeaderText="Identificación">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblIdentificacion" Text='<%# Bind("Identificación")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- REPRESENTACIÓN DE DATOS EN CELDAS--%>
                                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                                                <asp:BoundField HeaderText="Dirección" DataField="Dirección" />
                                                <asp:BoundField HeaderText="Correo" DataField="Correo" />
                                                <asp:BoundField HeaderText="Celular" DataField="Celular" />
                                                <asp:BoundField HeaderText="Genero" DataField="Genero" />
                                                <asp:BoundField HeaderText="Ciudad" DataField="Ciudad" />
                                                <asp:BoundField HeaderText="Usuario" DataField="Usuario" />
                                                <asp:BoundField HeaderText="Contraseña" DataField="Contraseña" />
                                                <asp:BoundField HeaderText="Imagen" DataField="Uimagen" Visible="true" />
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
          
            <br />
            <br />
        </div>
    </div>

</asp:Content>
