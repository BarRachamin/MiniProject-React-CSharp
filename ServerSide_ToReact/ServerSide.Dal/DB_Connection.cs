using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ServerSide.Modul;
namespace ServerSide.Dal
{
    public class DB_Connection
    {


        //Connection String
        static string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=localhost\\SQLEXPRESS";
        public delegate object SetDataReader_delegate(SqlDataReader reader);
        //Function that returns information from database and send the inforamtion to another function 
      
        public static object StartReadFromDB(string SqlQuery, SetDataReader_delegate Ptrfunc)
        {
            object retHash = null;
           


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                // Adapter
                using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                {
                    connection.Open();
                    //Reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        retHash = Ptrfunc(reader);

                    }
                }
            }
            return retHash;
        }



        //Function that input to DB row of information about student
     
        public static void InputToDB(string SqlQuery)
        {



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = SqlQuery;

                connection.Open();

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.ExecuteNonQuery();

                }
            }
        }



        //Delete  Function 

        public static void DeleteFromSqlServer(string SqlQuery, int ProductID)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = SqlQuery;

                connection.Open();

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@productID", ProductID);
                    command.ExecuteNonQuery();
                }
            }
        }



        //Update Function
        public static void UpdateRowById(string updateQuery, int productID, int categoryID, int unitsInStock)
        {


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a new SQL command
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {

                        // Add the parameters for the command
                        command.Parameters.AddWithValue("@productID", productID);
                        command.Parameters.AddWithValue("@categoryID", categoryID);
                        command.Parameters.AddWithValue("@unitsInStock", unitsInStock);

                        //Execute the command
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
