<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Administrador.Master" AutoEventWireup="true" CodeBehind="regExPersona.aspx.cs" Inherits="PI_Searchfood.Views.Administrador.Registros.regExPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">

    <div class="mx-auto mt-5">
        <div class="" runat="server">
            <div class="form-row">
                <div class="col-md-12">
                    <asp:Label runat="server" ID="lbTitulo" Text="Personas"></asp:Label>

                    <asp:Label runat="server" ID="lbOpcion"></asp:Label>


                </div>
            </div>
        </div>

        <div class="" runat="server">
            <div class="form-row">
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbIdentificacion" Text="Identificación"></asp:Label>
                    <asp:TextBox runat="server" ID="txtIdentificacion" CssClass="form-control"> </asp:TextBox>

                </div>

                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbNombre" Text="Nombre"></asp:Label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"> </asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbApellido" Text="Apellido"></asp:Label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control"> </asp:TextBox>

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
                    <asp:Label runat="server" ID="lbCelular" Text="Celular"></asp:Label>
                    <asp:TextBox runat="server" ID="txtCelular" CssClass="form-control"> </asp:TextBox>

                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbGenero" Text="Genero"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlGenero" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-md-3">
                    <asp:Label runat="server" ID="lbContraseña" Text="Contraseña"></asp:Label>
                    <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control"> </asp:TextBox>

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
</asp:Content>
