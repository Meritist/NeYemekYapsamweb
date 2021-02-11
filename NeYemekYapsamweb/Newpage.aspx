<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Newpage.aspx.cs" Inherits="NeYemekYapsamweb.Newpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color:bisque"><table>
        <tr  style="margin-left:auto;margin-right:auto;">
   <td> <asp:Image ID="Image1" runat="server" ImageAlign="Middle"  /></td>
                       </tr>
        <tr style="align-items:center;">
   <td> <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="true" Font-Size="XX-Large" ></asp:Label></td>
           </tr><tr>
  <td> <h3 style="font:bold;">Malzemeler</h3>  <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
               </tr><tr>
   <td><h3 style="font:bold;">Tarifi</h3> <asp:Label ID="Label3" runat="server" Text="Label"> </asp:Label></td>
                   </tr>
    </table></div>
</asp:Content>