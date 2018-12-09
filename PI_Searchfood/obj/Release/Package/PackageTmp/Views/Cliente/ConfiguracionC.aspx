<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Cliente.Master" AutoEventWireup="true" CodeBehind="ConfiguracionC.aspx.cs" Inherits="PI_Searchfood.Views.Cliente.ConfiguracionC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
     <div class="row center-block" >
        <div class="col-sm-2"></div>
        <div class="col-sm-8">
    <div class=" card mx-auto mt-5">
        <div class="card-header">
           Configuración Cuenta
        </div>
        <div class="card-body">

            <div id="form1" runat="server">
               
                <div class="" runat="server">
                    <div class="form-row">
                        <div class="col-md-6">
                            <asp:Label runat="server" ID="lbIdentificacion" Text="Identificación"></asp:Label>
                            <asp:TextBox runat="server" ID="txtIdentificacion" CssClass="form-control" Enabled="false"> </asp:TextBox>

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
               

            </div>

        </div>
    </div>
    
        <div class="col-sm-2"></div>
            <br/>
     <br/>
   </div>
         </div>
</asp:Content>
