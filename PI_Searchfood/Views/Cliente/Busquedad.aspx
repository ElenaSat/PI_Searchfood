<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Busquedad.aspx.cs" Inherits="PI_Searchfood.Views.Cliente.Busquedad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtNombre" runat="server" Width="100%"></asp:TextBox>
                    <ajaxToolkit:AutoCompleteExtender ID="acNombre" runat="server"
                        ServicePath="~/Servicios/wsConsulta.asmx"
                        ServiceMethod="getConsultarComidaWS"
                        MinimumPrefixLength="2" 
                        CompletionInterval="100"
                        EnableCaching="false" 
                        CompletionSetCount="10"
                        FirstRowSelected="false" 
                        UseContextKey="true" 
                        TargetControlID="txtNombre"></ajaxToolkit:AutoCompleteExtender>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
    </form>
</body>
</html>
