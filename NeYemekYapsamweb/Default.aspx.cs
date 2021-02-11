using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeYemekYapsamweb
{
    public partial class _Default : Page
    {
        public static string mal1 = "";//Burada seçilen malzemlerin adlarının tutulacağı değişkenleri oluşturuyoruz
        public static string mal2 = "";
        public static string mal3 = "";
        
        protected void Page_Load(object sender, EventArgs e)// Uygulama açıldığında yüklenecek fonksiyon
        {
            string fpath;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("fpath", typeof(string)),//gridviewin içine atmak için tablo oluşturup sutunarını belirliyoruz
            new DataColumn("adi", typeof(string)),
            new DataColumn("malzeme",typeof(string)),
            new DataColumn("tarif",typeof(string))});
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=Merit\SQLEXPRESS;Initial Catalog=yemekdb;Integrated Security=SSPI;";// SQL server bağlatısnı yapıyoruz
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select * From yemektb";// SQL sorgusu ile yemek listesindeki tüm elemanları çağırıyoruz
            comm.Connection = cnn;
            comm.CommandType = CommandType.Text;
            SqlDataReader rdr;
            cnn.Open();
            rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                fpath = rdr["webfoto"].ToString();// fotoğrafın dosya yolunu belirliyoruz
                dt.Rows.Add(fpath, rdr["adi"].ToString(), rdr["malzeme"].ToString(), rdr["tarif"].ToString());// yemek listesindeki her bir elemanı gridviewin içine satır olarak ekliyoruz

            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            rdr.Close();
            cnn.Close();

        }
            
        
        protected void TextBox1_TextChanged(object sender, EventArgs e)// Arama çubuğundaki yazıyı her değiştirdiğimizde gerçekeleşecek fonksiyon
        {
           ListBox1.Items.Clear(); // Listboxun içini temizler
            ListBox1.Visible = true;
            string veri = TextBox1.Text;// Arama çubuğuna yazılan texti veri değerine atıyoruz
            string kont = "";
            Boolean include = false;
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=Merit\SQLEXPRESS;Initial Catalog=yemekdb;Integrated Security=SSPI;";// SQL server bağlatısnı yapıyoruz
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "Select * from Malzemeler";// SQL sorgusu ile malzemeler listesindeki tüm malzemeleri çağırıyoruz
            comm.Connection = cnn;
            comm.CommandType = CommandType.Text;
            SqlDataReader rdr;
            cnn.Open();
            rdr = comm.ExecuteReader();
            while (rdr.Read())// malzeme listesindeki her bir eleman için
            {
                int sayac = 0;
                kont = rdr["malzemeadi"].ToString(); //malzeme adını kont değerine atıyoruz
                if (veri.Length <= kont.Length)// malzeme adının girilen değerden eşit veya daha uzun olduğunu kontrol ediyoruz
                {
                    for (int i = 0; i < veri.Length; i++)
                    {
                        if (veri[i] == kont[i]) // malzeme adıyla girilen değerin sırasıyla her harfini karşılaştırıyoruz
                        {
                            sayac++;// eşleşen harf var ise sayacı arttırıyoruz
                            if (sayac == veri.Length)// eşleşen harf sayısı girilen kelimenin uzunluğuyla aynı olan
                            {
                               
                               ListBox1.Visible = true;
                               include = true;
                               ListBox1.Items.Add(rdr["malzemeadi"].ToString());// bütün malzemeleri listboxa ekliyoruz
                            }
                        }

                    }
                }
            }
            if (include == false)
            {
                ListBox1.Visible = false;
                ListBox1.Items.Clear();
            }
            rdr.Close();
            cnn.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)// Ara butonuna basıldığında çalışacak fonksiyon
        {
            if (ListBox1.SelectedItem != null)// eğer seçilen malzeme varsa gridviewin içi temizlenir
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            string kont = "";
            char ayrac = ',';
            string[] kelime;
            string fpath;
            ImageField im = new ImageField();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("fpath", typeof(string)),
            new DataColumn("adi", typeof(string)),
            new DataColumn("malzeme",typeof(string)),
            new DataColumn("tarif",typeof(string))});
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=Merit\SQLEXPRESS;Initial Catalog=yemekdb;Integrated Security=SSPI;";// SQL server bağlatısnı yapıyoruz
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select * From yemektb";// SQL sorgusu ile yemek listesindeki tüm elemanları çağırıyoruz
            comm.Connection = cnn;
            comm.CommandType = CommandType.Text;
            SqlDataReader rdr;
            cnn.Open();
            rdr = comm.ExecuteReader();
            if (ListBox1.SelectedItem != null)// Malzeme seçilip seçilmediğinin kontrolü
            {
                while (rdr.Read())// her bir yemek için
                {
                    kont = rdr["malzeme"].ToString();
                    kelime = kont.Split(ayrac);// yemeklerin malzemeleri tek satırda patlıcan,domates,tuz... gibi olduğundan her bir malzeme kelime dizisine eleman olarak atanır
                    for (int i = 0; i < kelime.Length; i++)
                    {
                        if (mal1 == kelime[i])// seçilen ilk malzeme yemeğin malzemlerinden biriyle eşleşiyorsa
                        {
                            if (mal2 != "")// ikinci malzeme seçilip seçilmediği kontrol edilir
                            {
                                for (int a = 0; a < kelime.Length; a++)
                                {
                                    if (mal2 == kelime[a])// seçilen ikinci malzeme yemeğin malzemlerinden biriyle eşleşiyorsa
                                    {
                                        if (mal3 != "")//  üçüncü malzeme seçilip seçilmediği kontrol edilir
                                        {
                                            for (int b = 0; b < kelime.Length; b++)
                                            {
                                                if (mal3 == kelime[b])// seçilen üçüncü malzeme yemeğin malzemlerinden biriyle eşleşiyorsa
                                                {
                                                    fpath = rdr["webfoto"].ToString();
                                                    dt.Rows.Add(fpath, rdr["adi"].ToString(), rdr["malzeme"].ToString(), rdr["tarif"].ToString());// yemek gridviewe satır olarak eklenir

                                                }
                                            }
                                        }
                                        else
                                        {
                                            fpath = rdr["webfoto"].ToString();
                                            dt.Rows.Add(fpath, rdr["adi"].ToString(), rdr["malzeme"].ToString(), rdr["tarif"].ToString());

                                        }
                                    }
                                }
                            }
                            else
                            {
                                fpath = rdr["webfoto"].ToString();
                                dt.Rows.Add(fpath, rdr["adi"].ToString(), rdr["malzeme"].ToString(), rdr["tarif"].ToString());

                            }
                        }
                    }
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else// malzeme seçilmeden basılmışsa uyarır
            {
                Response.Write("<script language=javascript>alert('Önce malzeme seçmeniz gerekir')</script>");
            }
           

            rdr.Close();
            cnn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)// Ekle butonuna basıldığında çalışacak fonksiyon
        {
            if (ListBox1.SelectedItem != null)// textboxun boş olmadığı kontrol edilir
            {
                
                if (ListBox1.SelectedItem.ToString() == mal1 || ListBox1.SelectedItem.ToString() == mal2 || ListBox1.SelectedItem.ToString() == mal3)// istenen mazlemenin daha önce eklenmediği kontrol edilir
                    {
                    Response.Write("<script language=javascript>alert('Bu malzeme zaten eklenmiş')</script>");
                }
                else
                {
                    if (Label1.Text == "")// Hiç malzeme eklenmemişse
                        {
                        mal1 = ListBox1.SelectedItem.ToString();// mal1 değerine kaydedilir
                            Label1.Text = mal1;
                    }
                    else if (Label2.Text == "")// Bir malzeme eklenmişse
                        {
                        mal2 = ListBox1.SelectedItem.ToString();// mal2 değerine kaydedilir
                            Label2.Text = mal2;
                    }
                    else if (Label3.Text == "")// İki mazleme eklenmişse
                        {
                        mal3 = ListBox1.SelectedItem.ToString();// mal3 değerine kaydedilir
                            Label3.Text = mal3;
                    }
                    else// Üç malzeme eklenmişse daha fazla eklenemeyeceği uyarısı çıkar
                    {

                        Response.Write("<script language=javascript>alert('En fazla 3 mazleme seçebilirsiniz')</script>");
                    }
                }
            }
            else// malzeme seçilmemişse uyarı verir
            {
                Response.Write("<script language=javascript>alert('Malzeme Seçmelisiniz')</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)// seçilenleri temizle butonuna basıldığında çalışacak fonksiyon
        {
            mal1 = "";// seçilen malzemelerin içi boşaltılır
            mal2 = "";
            mal3 = "";
            Label1.Text = "";// labeller temizlenir
            Label2.Text = "";
            Label3.Text = "";

        }

        
    }
}