using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormMyContact.Repository;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WinFormMyContact.Services
{
   public class ContactRepository : IContactRepositoy
    {
        private string connectionString = "Data Source=.;Initial Catalog=Contact_DB;User ID=sa;Password=1993";
        public bool Delete(int ContactID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "delete from MyContacts where ContactID=@ContactID";
                SqlCommand cmd=new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ContactID", ContactID);
                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Insert(string FName, string LName, string Mobile, string Email, int Age)
        {
            SqlConnection connection=new SqlConnection(connectionString);

            try
            {
                string query = "Insert into MyContacts (FirstName,LastName,Mobile,Email,Age) values(@FirstName,@LastName,@Mobile,@Email,@Age)";
                SqlCommand cmd=new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@FirstName", FName);
                cmd.Parameters.AddWithValue("@LastName", LName);
                cmd.Parameters.AddWithValue("@Mobile", Mobile);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Age", Age);
                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable Search(string Parameter)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "select * from MyContacts where FirstName like @parameter";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + Parameter + "%");
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
            catch (Exception)
            {

                DataTable data = new DataTable();
                return data;
            }

        }

        public DataTable SellectAll()
        {
            string Query = "select * from MyContacts";
            SqlConnection connection=new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(Query,connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SellectRow(int ContactID)
        {
            DataTable dt=new DataTable();
            string query = "select * from MyContacts where ContactID="+ContactID;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query,connection);
            adapter.Fill(dt);
            return dt;
        }


        public bool Update(int ContactID, string FName, string LName, string Mobile, string Email, int Age)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                var query= "update MyContacts set FirstName=@FirstName,LastName=@LastName,Age=@Age,Mobile=@Mobile,Email=@Email where ContactID=@ContactID";
                SqlCommand cmd = new SqlCommand(query,connection);
                cmd.Parameters.AddWithValue("@FirstName", FName);
                cmd.Parameters.AddWithValue("@LastName", LName);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@Mobile", Mobile);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@ContactID", ContactID);
                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
