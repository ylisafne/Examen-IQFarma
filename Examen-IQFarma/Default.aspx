<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Examen_IQFarma._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <button type="button" class="btn btn-primary" id="agregar">Agregar</button>
    <script>
        $("#agregar").click(function () {
            $('#Registrar').modal('show');
        });
    </script>

      <asp:GridView ID="GvList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-intel"
            EmptyDataText="No se encontraron datos" ShowHeaderWhenEmpty="True" DataKeyNames="Codigo">
            <Columns>
                <asp:BoundField DataField="Codigo" Visible="false" />
                <asp:BoundField DataField="Usuari" HeaderText="Usuario" />
                <asp:BoundField DataField="Contrasena" HeaderText="Contraseña" />
                <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" />
                <asp:BoundField DataField="CodigoArea" HeaderText="Area" />                                   
            </Columns>
        </asp:GridView>


<div class="modal" id="Registrar" tabindex="-1">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Agregar Usuario</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
          <div class="form-group col-12 col-sm-6 col-md-6 col-lg-3">
              <label class="control-label" for="ddlIdPresup">Usuario</label>
              <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" Width="400px"></asp:TextBox>
          
          </div>
          <div class="form-group col-12 col-sm-6 col-md-6 col-lg-3">
              <label class="control-label" for="ddlIdPresup">Contraseña</label>
              <asp:TextBox ID="txtcontrasena" runat="server" CssClass="form-control" Width="400px"></asp:TextBox>
          
          </div>
          <div class="form-group col-12 col-sm-6 col-md-6 col-lg-3">
              <label class="control-label" for="ddlIdPresup">Area</label>
              <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control"></asp:DropDownList>
          </div>
          
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" runat="server" onserverclick="Unnamed_ServerClick" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>
    
</asp:Content>
