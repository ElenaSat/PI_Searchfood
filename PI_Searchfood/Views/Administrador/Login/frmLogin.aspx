<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Template/Administrador.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="PI_Searchfood.Views.Administrador.Login.frmLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
  
    <div class="row">
         <div class="col-md-4">
        <div class="form-row">
                            <div class="col-md-12">
        <div class="card card-register mx-auto mt-5">
            <div class="card-header">Usuario</div>
            <div class="card-body">
                
                    <div class="form-group">
                        <div class="col-md-12">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
          </div>
                        </div>
          <div class="form-group">
          <div class="col-md-12">
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
          </div>

          </div>
          <div class="form-group">
              <div class="col-md-12">
            <div class="form-check">
              <label class="form-check-label"/>
                <asp:CheckBox ID="chkRecordar" runat="server" Text="Recordar Contraseña" />
            </div>
                  <div class="form-check">
                      
                                              
                   <asp:RadioButton ID="Radio1" runat="server" Text="Persona" GroupName="A"  />
                   <asp:RadioButton ID="Radio2" runat="server" Text="Restaurantes" GroupName="A" />
                    

                   </div>
                  </div>
          </div>
                     <div class="col-md-12">
                    <asp:Button ID="btnAceptar1" runat="server" CssClass="btn btn-primary btn-block" Text="Aceptar" OnClick="btnAceptar_Click"  /> 
              </div>  
                      
             <div class="col-md-12">
            <div class="text-center">
          <a class="d-block small mt-3" href="../Registrar/Registrar.aspx">Registrar Cuenta</a>
          <a class="d-block small" href="../Recuperar Password/Recuperar Password.aspx">Olvido su contraseña?</a>
        </div>
            </div>
                 </div> 
        </div>
     </div>
        </div> 
       </div>
 
          <div class="col-md-4">
             <div class="form-group">
              <div class="col-md-12">
              <br/>   
              <br/>
              <br/>
                  <p class="letrerologin">
                  ¿No hace parte de nuestra comunidad aún ?
                  Únete y obten muchos beneficios
                   </p>
              <asp:Button ID="btnUnirse" runat="server" CssClass="btn btn-primary btn-block" Text="UNIRSE"  /> 
               </div>
                  </div>
           </div>
        </div>
     
    </asp:Content>
