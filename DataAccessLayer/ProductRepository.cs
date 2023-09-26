using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductRepository: IProduct
    {
        private readonly string ConnectionString;
        public ProductRepository()
        {
            ConnectionString = @"Data Source=ANIYAAN-1006;Initial Catalog=tempdb;User Id=Anaiyaan; Password=Anaiyaan@123";
        }
        public List<Class1>select()
        {
            try
            {
                List<Class1> Con = new List<Class1>();
                var Connection = new SqlConnection(ConnectionString);
                Connection.Open();
                Con = Connection.Query<Class1>($"exec selectdetails").ToList();
                Connection.Close();
                return Con;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public Class1 selectid(int id)
        {
            try
            {
                var Connection = new SqlConnection(ConnectionString);
                Connection.Open();
               var result = Connection.QueryFirst<Class1>($"exec selectid {id}");
                Connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insert(Class1 e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                con.Execute($"exec insertsp '{e.name}','{e.dob}','{e.place}','{e.pno}'");
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Class1 a)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                con.Execute($"exec updatesp '{a.id}','{a.name}','{a.dob}','{a.place}','{a.pno}'");
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                con.Execute($"exec deletesp '{id}'");
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
