<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NeYemekYapsamweb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top:50px; max-width:1400px;">
    <table>
    <tr>
       <td><asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" AutoPostBack="true" CssClass="txtstyle" Width="176px" ></asp:TextBox></td>
            
   <td> <asp:Button ID="Button1" runat="server" Text="Ekle" OnClick="Button1_Click" Width="75px" /></td>
   <td> <asp:Label ID="Label1" runat="server" CssClass="lblstyle" Font-Underline="True" BackColor="White" ForeColor="Red" ></asp:Label></td>
   <td> <asp:Label ID="Label2" runat="server"  CssClass="lblstyle" Font-Underline="True"  BackColor="White" ForeColor="Red"></asp:Label></td>
   <td> <asp:Label ID="Label3" runat="server"  CssClass="lblstyle" Font-Underline="True"  BackColor="White" ForeColor="Red"></asp:Label></td>
        <td> <asp:Button ID="Button2" runat="server" Text="Ara" OnClick="Button2_Click" Width="57px" /></td>
   <td> <asp:Button ID="Button3" runat="server" Text="Seçimleri Temizle" OnClick="Button3_Click"  CssClass="butonstyle"/></td>
        </tr>
        <tr>
    <td><asp:ListBox ID="ListBox1" runat="server" AutoPostBack="true" Visible="false" Width="180" CssClass="txtstyle" ></asp:ListBox></td>
    
        </tr>
           </table>
    </div>
    <div style="margin-top:10px;width:950px">
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Width="1406px" style="margin-left: -100px">
               <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
               <Columns>  
                   <asp:TemplateField>
                       <ItemTemplate>
   <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("fpath")%>' Width="300" Height="150" />
              </ItemTemplate>
                   </asp:TemplateField>
                 <asp:BoundField DataField="adi" HeaderText="Yemek Adı" ItemStyle-Width="80" >    
<ItemStyle Width="80px"></ItemStyle>
                   </asp:BoundField>
                 <asp:BoundField DataField="malzeme" HeaderText="Malzemeler" ItemStyle-Width="15" >    
<ItemStyle Width="15px"></ItemStyle>

                   </asp:BoundField>
                     <asp:BoundField DataField="tarif" HeaderText="Tarifi" ItemStyle-Width="400" >    
<ItemStyle Width="400px"></ItemStyle>

                   </asp:BoundField>
                 
                   
                   <asp:HyperLinkField DataNavigateUrlFields="adi" DataNavigateUrlFormatString="Newpage.aspx?adi={0}" Text="Sayfaya Git" />
             </Columns>   
            
               <EditRowStyle BackColor="#999999" />
            
               <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Width="900px" />
               <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
               <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
               <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
               <SortedAscendingCellStyle BackColor="#E9E7E2" />
               <SortedAscendingHeaderStyle BackColor="#506C8C" />
               <SortedDescendingCellStyle BackColor="#FFFDF8" />
               <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            
           </asp:GridView></div>
                       
     
   
</asp:Content>
