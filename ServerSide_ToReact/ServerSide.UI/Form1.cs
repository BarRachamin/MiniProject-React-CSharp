using ServerSide.Modul;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSide.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Hashtable ProductsList;
   
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = Northwind; Data Source = localhost\\sqlexpress";

                ProductsList = new Hashtable();


                ProductsList.Clear();


                // Connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    string queryString = "select * from Products";
                    SqlCommand command;
                    // Adapter
                    using (command = new SqlCommand(queryString, connection)) ;
                    {
                        connection.Open();

                        //Reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                int ProductID = reader.GetInt32(0);
                                string ProducttName = reader.GetString(1);
                                int SupplierID= reader.GetInt32(2);
                                int CategoryID= reader.GetInt32(3);
                                string QuantityPerUnit= reader.GetString(4);
                                SqlMoney UnitPrice = reader.GetSqlMoney(5);
                                int UnitsInStock = reader.GetInt16(6);
                                int UnitsOnOrder = reader.GetInt16(7);
                                int ReorderLevel= reader.GetInt16(8);
                                bool Discontinued= reader.GetBoolean(9);
                                MProducts ProductS_Cs = new MProducts(ProductID, ProducttName,SupplierID,CategoryID,QuantityPerUnit, UnitPrice, UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued);
                                ProductsList.Add(ProductID, ProductS_Cs);
                            }
                        }

                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("there was an issue!");
            }
        }
    }
}
