<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Examen._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
    <div class="container">
        <h1>Examen</h1>

        <div class="form-group">
            <label for="txtId">ID:</label>
            <asp:TextBox ID="txtId" runat="server" CssClass="form-control" placeholder="ID"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtDescripcion">Descripción:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" placeholder="Descripción"></asp:TextBox>
        </div>
         <asp:CheckBoxList ID="chkServicios" runat="server">
             <asp:ListItem Text="Por Procedimientos" Value="sps"></asp:ListItem>
             <asp:ListItem Text="Por WebServices" Value="ws"></asp:ListItem>
        </asp:CheckBoxList>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary" OnClick="btnActualizar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
       
        <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="text-success"></asp:Label>

        <h2>Consultar</h2>
        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary" OnClick="btnConsultar_Click" />

        <h2>Resultados</h2>
      <asp:DataGrid ID="dgResultados" runat="server" AutoGenerateColumns="False" CssClass="table">
        <Columns>
            <asp:BoundColumn DataField="idExamen" HeaderText="ID" />
            <asp:BoundColumn DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundColumn DataField="Descripcion" HeaderText="Descripción" />
        </Columns>
         <ItemStyle CssClass="odd-row" />
         <AlternatingItemStyle CssClass="even-row" />
      </asp:DataGrid>
    </div>

     <link href="Site.css" rel="stylesheet" type="text/css" />

</asp:Content>
