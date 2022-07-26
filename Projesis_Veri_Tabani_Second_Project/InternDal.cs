using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projesis_Veri_Tabani_Second_Project
{
    public class InternDal
    {
        SqlConnection _sqlConnection = new SqlConnection(@"server=(localdb)\mssqllocaldb;initial catalog=Internship;integrated security=true");

        public List<Intern> GetAll()
        {
            ConnectionControl();

            SqlCommand sqlCommand = new SqlCommand("Select * from Intern", _sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<Intern> interns = new List<Intern>();

            while (sqlDataReader.Read())
            {
                Intern intern = new Intern
                {
                    Id = Convert.ToInt16(sqlDataReader["Id"]),
                    Ad = sqlDataReader["Ad"].ToString(),
                    Soyad = sqlDataReader["Soyad"].ToString(),
                    TelefonNo = sqlDataReader["TelefonNo"].ToString(),
                    Sehir = sqlDataReader["Sehir"].ToString(),
                    OkuyorMu = sqlDataReader["OkuyorMu"].ToString()
                };

                interns.Add(intern);
            }

            sqlDataReader.Close();
            _sqlConnection.Close();

            return interns;
        }

        private void ConnectionControl()
        {
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }
        }

        public void Add(Intern intern)
        {
            ConnectionControl();

            SqlCommand sqlCommand = new SqlCommand("Insert into Intern values(@Ad,@Soyad,@TelefonNo,@Sehir,@OkuyorMu)", _sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Ad", intern.Ad);
            sqlCommand.Parameters.AddWithValue("@Soyad", intern.Soyad);
            sqlCommand.Parameters.AddWithValue("@TelefonNo", intern.TelefonNo);
            sqlCommand.Parameters.AddWithValue("@Sehir", intern.Sehir);
            sqlCommand.Parameters.AddWithValue("@OkuyorMu", intern.OkuyorMu);

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public void Update(Intern intern)
        {
            ConnectionControl();

            SqlCommand sqlCommand = new SqlCommand("Update Intern set Ad=@Ad, Soyad=@Soyad, TelefonNo=@TelefonNo, Sehir=@Sehir, OkuyorMu=@OkuyorMu where Id=@Id", _sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Ad", intern.Ad);
            sqlCommand.Parameters.AddWithValue("@Soyad", intern.Soyad);
            sqlCommand.Parameters.AddWithValue("@TelefonNo", intern.TelefonNo);
            sqlCommand.Parameters.AddWithValue("@Sehir", intern.Sehir);
            sqlCommand.Parameters.AddWithValue("@OkuyorMu", intern.OkuyorMu);
            sqlCommand.Parameters.AddWithValue("@Id", intern.Id);

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public void Delete(int Id)
        {
            ConnectionControl();

            SqlCommand sqlCommand = new SqlCommand("Delete from Intern where Id=@Id", _sqlConnection);            
            sqlCommand.Parameters.AddWithValue("@Id", Id);

            sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }
    }
}
