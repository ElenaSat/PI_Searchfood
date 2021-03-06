﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Administrador.Master" AutoEventWireup="true" CodeBehind="regRestaurante.aspx.cs" Inherits="PI_Searchfood.Views.Administrador.Registros.regRestaurante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="card mx-auto mt-5">
        <div class="card-header">
            Registro Restaurante  
        </div>
        <div class="card-body">
            <div class="" runat="server">
                <div class="form-row">
                    <div class="col-md-12">
                        <asp:Label runat="server" ID="lbOpcion" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="lbCodigoRes" Visible="false"></asp:Label>


                    </div>
                </div>
            </div>

            <div class="" runat="server">
                <div class="form-row">
                    <div class="col-md-6">
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lbNit" Text="NIT"></asp:Label>
                            <asp:TextBox runat="server" ID="txtNit" CssClass="form-control"> </asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lbNombre" Text="Nombre"></asp:Label>
                            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"> </asp:TextBox>
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
                            <asp:Label runat="server" ID="lbContraseña" Text="Contraseña"></asp:Label>
                            <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" TextMode="Password"> </asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lbConfirmarPassword" Text="Confirmar Contraseña"> </asp:Label>
                            <asp:TextBox runat="server" ID="txtConfirmarPassword" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvConfirmarPassword" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtConfirmarPassword" ForeColor="Red" ValidationGroup="ValidarCuenta"></asp:RequiredFieldValidator>
                            <asp:CompareValidator runat="server" ID="cvConfirmarPassword" ErrorMessage="Contraseña no coinciden" ControlToValidate="txtConfirmarPassword" ControlToCompare="txtContraseña" ForeColor="Red"></asp:CompareValidator>
                        </div>
                        <div class="col-md-6">
                            <div class="form-check">
                                <label class="form-check-label" />
                                <asp:CheckBox ID="chkSP" runat="server" Text="Sede Principal" OnCheckedChanged="chkSP_CheckedChanged" AutoPostBack="true"/>
                                <br/>
                                <asp:CheckBox ID="chkSC" runat="server" Text="Sede Sucursal" OnCheckedChanged="chkSC_CheckedChanged" AutoPostBack="true"/>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lbRestPrin" Text="Restaurante Principal"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddlRestaurantePrin" CssClass="form-control form-control-lg" AutoPostBack="true"></asp:DropDownList>

                        </div>
                        <div class="col-md-12">
                            <asp:Label runat="server" ID="lbCelular" Text="Celular"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCelular" CssClass="form-control"> </asp:TextBox>
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
                        <%--IMAGEN --%>
                        <div class="col-md-12">
                            <asp:Label runat="server" ID="lblImagen" Text="Subir Imagen"> </asp:Label>
                            <asp:FileUpload runat="server" ID="fuImagen" CssClass="form-control-file"></asp:FileUpload>
                            <asp:RequiredFieldValidator ID="rfvImagen" runat="server" ControlToValidate="fuImagen" ForeColor="Red" ValidationGroup="ValidarCuenta"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-12">
                            <asp:Label runat="server" ID="lbDescripcion" Text="Descripción"></asp:Label>
                            <asp:TextBox runat="server" ID="txtArea" CssClass="form-control" TextMode="MultiLine" Height="200"> </asp:TextBox>
                            <script type="text/javascript">
                                window.onload = function () {
                                    var textarea = document.getElementById('<%=txtArea.ClientID %>');
                                    textarea.scrollTop = textarea.scrollHeight;
                                }
                            </script>
                            <br />
                        </div>

                        <%--SEGUNDA SECCIÓN BOTONES --%>
                        <div class="col-md-12">
                            <asp:Button ID="btnGuardar" Text="GUARDAR" runat="server" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                            <asp:Button ID="btnCancelar" Text="CANCELAR" runat="server" CssClass="btn btn-primary" OnClick="btnCancelar_Click" />
                            <br />
                            <br />
                        </div>


                    </div>
                    <div class="col-md-6" runat="server">
                        <div class="">
                            <label for="lbUbicacion">Ubicación</label>
                            <asp:HiddenField ID="txtIdUb" runat="server" />
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtUbicacion"></asp:TextBox>
                        </div>
                        <div class="">
                            <div id="ModalMapPreview" style="width: 100%; height: 400px;"></div>
                        </div>
                        <!-- Latiud y Longitud -->
                        <div class="">
                            <label for="lbLatitud">Lat.:</label>
                            <asp:TextBox runat="server" ID="txtLat" Text="3.478595800219598" CssClass="form-control"></asp:TextBox>
                            <label for="lbLongitud">Long.:</label>
                            <asp:TextBox runat="server" ID="txtLong" Text="-76.51654064655304" CssClass="form-control"></asp:TextBox>
                        </div>
                        <script>
                            $('#ModalMapPreview').locationpicker({
                                radius: 0,
                                location: {
                                    latitude: $('#<%=txtLat.ClientID%>').val(),
                                    longitude: $('#<%=txtLong.ClientID%>').val()
                                },
                                inputBinding: {
                                    latitudeInput: $('#<%=txtLat.ClientID%>'),
                                    longitudeInput: $('#<%=txtLong.ClientID%>'),
                                    locationNameInput: $('#<%=txtUbicacion.ClientID%>')
                                },
                                enableAutocomplete: true
                            });
                        </script>
                    </div>

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
</asp:Content>
