using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NeYemekYapsamweb
{
    public partial class Newpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string yemekadi = Request.QueryString["adi"];// önceki formdan gelen yemeğin adı tanımlanır
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=Merit\SQLEXPRESS;Initial Catalog=yemekdb;Integrated Security=SSPI;";// SQL server bağlatısnı yapıyoruz
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "select * From yemektb where adi = '"+ yemekadi +"'";// SQL sorgusu ile yemek tablosundan daha önce basılan yemek çağırılır
            comm.Connection = cnn;
            comm.CommandType = CommandType.Text;
            SqlDataReader rdr;
            cnn.Open();
            rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                Label1.Text = rdr["adi"].ToString();
                Label2.Text = rdr["malzeme"].ToString();
                Label3.Text = rdr["tarif"].ToString();
                Image1.ImageUrl = rdr["webfoto"].ToString();// Yemeğin bilgileri label ve reismlere aktarılır
            }
            rdr.Close();
            cnn.Close();
            }
    }
}