using Microsoft.Data.SqlClient;

namespace CoreApp
{

    public class Procs
    {
        SqlConnection cnn;

        public Procs()
        {
            //string vcadenaConexion = "Server=(localdb)\\MSSQLLocalDB;Database=MXTest;Trusted_Connection=True;MultipleActiveResultSets=true";
            string vcadenaConexion = "Data Source=SQL5080.site4now.net;Initial Catalog=db_a8331e_test001;User Id=db_a8331e_test001_admin;Password=1122QQww..sa;TrustServerCertificate=True";
            cnn = new SqlConnection(vcadenaConexion);            
            cnn.Open();
        }

        public SqlDataReader EjecutarSQL(string vSQL)
        {
            SqlCommand cmd = new SqlCommand(vSQL, cnn);
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }



    }
}
