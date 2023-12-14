<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="DetallesReparaciones.aspx.cs" Inherits="Exameen2Programacion2.DetallesReparaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div>
        <h1>PAGINA DE DETALLES</h1>
        <asp:Label ID="lCorreo" runat="server" Text=""></asp:Label>
    </div> 
      <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
            CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RowStyle-CssClass="rows" AllowPaging="True" />

        <br />
        <br />
        <br />

    
    <div class="container text-center">
     DetallesReparacionID: <asp:TextBox ID="tID" class="form-control" runat="server"></asp:TextBox>
        ReparacionID: <asp:TextBox ID="tRepID" class="form-control" runat="server"></asp:TextBox>
        Descripcion: <asp:TextBox ID="tDes" class="form-control" runat="server"></asp:TextBox>
        FechaFin: <asp:TextBox ID="tFF" class="form-control" runat="server"></asp:TextBox>
        FechaIni: <asp:TextBox ID="tFI" class="form-control" runat="server"></asp:TextBox>
    </div>
    <div class="container text-center">

        <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="Button1_Click" />
        <asp:Button ID="Button2" class="btn btn-outline-secondary" runat="server" Text="Borrar" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" class="btn btn-outline-danger" Text="Modificar" OnClick="Button3_Click" />
        <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-danger" Text="Consultar" OnClick="Bconsulta_Click" />
       </div>
</asp:Content>
