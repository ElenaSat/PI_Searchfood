<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Resources/Template/Restaurantes.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="PI_Searchfood.Views.Restaurante.Menu" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="card mx-auto mt-5">
        <div class="card-header">
            Ingresar Menu
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

                    <div class="col-md-12">
                        <div class="card-body row no-gutters align-items-center">
                            <!--end of col-->
                            <div class="col">

                                <asp:TextBox ID="txtDato" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="acNombre" runat="server"
                                    ServicePath="~/Servicios/wsConsulta.asmx"
                                    ServiceMethod="getConsultarComidaWS"
                                    MinimumPrefixLength="2"
                                    CompletionInterval="100"
                                    EnableCaching="false"
                                    CompletionSetCount="10"
                                    FirstRowSelected="false"
                                    UseContextKey="true"
                                    TargetControlID="txtDato">
                                </ajaxToolkit:AutoCompleteExtender>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </div>
                            <!--end of col-->
                            <div class="col-auto">
                                <asp:Button ID="btnBuscador" Text="BUSCAR" runat="server" CssClass="btn btn-lg btn-success" OnClick="btnBuscador_Click" />
                            </div>
                        </div>
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
                        <asp:Label runat="server" ID="lblImagen" Text="Subir Imagen"> </asp:Label>
                        <asp:FileUpload runat="server" ID="fuImagen" CssClass="form-control-file"></asp:FileUpload>
                        <asp:RequiredFieldValidator ID="rfvImagen" runat="server" ControlToValidate="fuImagen" ForeColor="Red" ValidationGroup="ValidarCuenta"></asp:RequiredFieldValidator>
                        <br />
                    </div>

                    <%--SEGUNDA SECCIÓN BOTONES --%>
                    <div class="col-md-12">
                        <asp:Button ID="btnGuardarC" Text="GUARDAR" runat="server" CssClass="btn btn-primary" OnClick="btnGuardarC_Click" />
                        <asp:Button ID="btnEditar" Text="EDITAR" runat="server" CssClass="btn btn-primary" OnClick="btnEditar_Click" />
                        <asp:Button ID="btnEliminar" Text="ELIMINAR" runat="server" CssClass="btn btn-primary" OnClick="btnEliminar_Click" />
                        <asp:Button ID="btnCancelarC" Text="CANCELAR" runat="server" CssClass="btn btn-primary" OnClick="btnCancelarC_Click" />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
